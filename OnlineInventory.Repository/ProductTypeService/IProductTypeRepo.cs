using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.ProductTypeService
{
    public interface IProductTypeRepo
    {
        Task<PaginatedList<ProductTypeListViewModel>> GetAll(int pageSize, int pageNumber);
    }
}
