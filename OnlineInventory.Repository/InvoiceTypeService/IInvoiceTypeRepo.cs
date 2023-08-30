using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.InvoiceTypeService
{
    public interface IInvoiceTypeRepo
    {
        Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageSize, int pageNumber);
    }
}
