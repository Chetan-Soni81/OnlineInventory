using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.ProductService
{
    public interface IProductRepo
    {
        Task<PaginatedList<ProductListViewModel>> GetAll(int pageSize, int pageNumber);
    }
}
