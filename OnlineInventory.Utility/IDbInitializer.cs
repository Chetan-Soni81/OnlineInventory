using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Utility
{
    public interface IDbInitializer
    {
        void CreateRules();
        Task CreateSuperAdmin();
        Task SendEmail(string FromEmail, string Subject, string FromName, string Message, string toEmail, string toName, string smtpUser, string smtpPassword, string smtpHost, string smtpPort, bool smtpSSl);
        Task<string> UploadFile(List<IFormFile> files, IWebHostEnvironment env, string Directory);
    }

    

    //public interface IWebHostEnvironment
    //{
    //}
}
