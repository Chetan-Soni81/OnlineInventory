using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Invoice;
using OnlineInventory.ViewModels.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.InvoiceService
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<InvoiceListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var invoices = _context.Invoices;

            var vm = invoices.ModelToVM().AsQueryable();
            return await PaginatedList<InvoiceListViewModel>.CreateAsync(vm, pageSize, pageNumber); 
        }
    }
}
