using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Customer;
using OnlineInventory.ViewModels.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.CustomerService
{
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<CustomerListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var customerList = _context.Customers;

            var vm = customerList.ModelToVM().AsQueryable();
            return await PaginatedList<CustomerListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }

    }  
}
