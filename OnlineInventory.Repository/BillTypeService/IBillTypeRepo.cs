using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.BillTypeService
{
    public interface IBillTypeRepo
    {
        Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int pageNumber);
    }
}
