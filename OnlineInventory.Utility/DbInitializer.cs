using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineInventory.Utility.HelperClass;
using Microsoft.Extensions.Options;
using OnlineInventory.Repository;
using OnlineInventory.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace OnlineInventory.Utility
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private SuperAdmin _superAdmin;
        private ApplicationDbContext _context;
        private IRoleInventory _roleInventory;
        public DbInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<SuperAdmin> superAdmin, ApplicationDbContext context, IRoleInventory roleInventory)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _superAdmin = superAdmin.Value;
            _context = context;
            _roleInventory = roleInventory;
        }

        public void CreateRules()
        {
            throw new NotImplementedException();
        }

        public async Task CreateSuperAdmin()
        {
            AppUser user = new()
            {
                Email = "",
                UserName = "",
                EmailConfirmed = true
            };

            var response = await _userManager.CreateAsync(user, _superAdmin.Password);

            if (response.Succeeded)
            {
                UserProfile userProfile = new()
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = user.Email,
                    AppUserId = user.Id
                };

                await _context.UserProfiles.AddAsync(userProfile);
                await _context.SaveChangesAsync();
                await _roleInventory.AddRoleAsync(user.Id);
            }
        }

        public async Task SendEmail(string FromEmail, string Subject, string FromName, string Message, string toEmail, string toName, string smtpUser, string smtpPassword, string smtpHost, string smtpPort, bool smtpSSl)
        {
            var body = Message;

            var messageRequest = new MailMessage();
            messageRequest.To.Add(new MailAddress(toEmail, toName));
            messageRequest.From = new MailAddress(FromEmail, FromName);
            messageRequest.Subject = Subject;
            messageRequest.Body = body;
            messageRequest.IsBodyHtml = true;

            using(var smtp = new SmtpClient())
            {
                var crediential = new NetworkCredential
                {
                    UserName = smtpUser,
                    Password = smtpPassword,
                };

                smtp.Credentials = crediential;
                smtp.Host = smtpHost;
                smtp.Port = Convert.ToInt32(smtpPort);
                smtp.EnableSsl = smtpSSl;
                await smtp.SendMailAsync(messageRequest);
            }

        }

        public async Task<string> UploadFile(List<IFormFile> files, IWebHostEnvironment env, string Directory)
        {
            var response = string.Empty;
            var upload = Path.Combine(env.WebRootPath, Directory);
            var fileExtensions = string.Empty;
            var filePath = string.Empty;
            var fileName = string.Empty;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    fileExtensions = Path.GetExtension(file.FileName);
                    fileName = Guid.NewGuid().ToString() + fileExtensions;
                    filePath = Path.Combine(upload, fileName);
                    using (var ms = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(ms);
                    }

                    response = fileName;
                }

            }
            return response;
        }
    }
}
