using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Invoice;
using OnlineInventory.ViewModels.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.InvoiceTypeService
{
    public class InvoiceTypeRepo : IInvoiceTypeRepo
    {
        private readonly ApplicationDbContext _context;

        public InvoiceTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var invoiceTypes = _context.InvoiceTypes;
            var vm = invoiceTypes.ModelToVM().AsQueryable();

            return await PaginatedList<InvoiceTypeListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
