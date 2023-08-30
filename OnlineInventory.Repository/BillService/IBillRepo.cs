using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.BillService
{
    public interface IBillRepo
    {
        Task<PaginatedList<BillListViewModel>> GetAll(int pageSize, int pageNumber);
    }
}
