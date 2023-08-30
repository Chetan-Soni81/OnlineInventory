using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Customer;
using OnlineInventory.ViewModels.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.CustomerTypeService
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        private ApplicationDbContext _context;
        public CustomerTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var customerTypeList = _context.CustomerTypes;

            var vm = customerTypeList.ModelToVM().AsQueryable();
            return await PaginatedList<CustomerTypeListViewModel>.CreateAsync(vm, pageSize, pageNumber); 
        }
    }
}
