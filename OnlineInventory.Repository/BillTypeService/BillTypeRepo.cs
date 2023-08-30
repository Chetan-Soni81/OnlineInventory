using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Bill;
using OnlineInventory.ViewModels.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.BillTypeService
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private readonly ApplicationDbContext _context;

        public BillTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var billTypes = _context.BillTypes;
            var vm = billTypes.ModelToVM().AsQueryable();

            return await PaginatedList<BillTypeListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
