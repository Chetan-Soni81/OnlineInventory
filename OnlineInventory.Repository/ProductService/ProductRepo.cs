using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Mapping;
using OnlineInventory.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.ProductService
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<ProductListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var products = _context.Products;
            var vm = products.ModelToVM().AsQueryable();

            return await PaginatedList<ProductListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
