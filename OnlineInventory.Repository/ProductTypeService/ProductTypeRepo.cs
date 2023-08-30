using OnlineInventory.Repository.Paging;
using OnlineInventory.ViewModels.Mapping;
using OnlineInventory.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repository.ProductTypeService
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<ProductTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var productTypes = _context.ProductTypes;
            var vm = productTypes.ModelToVM().AsQueryable();

            return await PaginatedList<ProductTypeListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
