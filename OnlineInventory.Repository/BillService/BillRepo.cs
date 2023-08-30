using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Bill;
using OnlineInventory.ViewModels.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.BillService
{
    public class BillRepo : IBillRepo
    {
        private readonly ApplicationDbContext _context;

        public BillRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<BillListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var bills = _context.Bills;
            var vm = bills.ModelToVM().AsQueryable();

            return await PaginatedList<BillListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
