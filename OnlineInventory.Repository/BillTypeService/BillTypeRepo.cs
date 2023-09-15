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
        private ApplicationDbContext _context;

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
        public void Add(CreateBillTypeViewModel model)
        {
            var billType = model.VMToModel();
            _context.BillTypes.Add(billType);
            _context.SaveChanges();
        }
        public void Update(BillTypeViewModel model)
        {
            var billType = _context.BillTypes.Where(x => x.BillTypeId == model.BillTypeId).FirstOrDefault();
            if(billType != null)
            {
                billType.BillTypeName = model.BillTypeName;
                billType.Description = model.Description;
            }
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var billType = _context.BillTypes.Where(x => x.BillTypeId == id).FirstOrDefault();
            if(billType != null)
            {
                _context.BillTypes.Remove(billType);
            }
            _context.SaveChanges();
        }
        public BillTypeViewModel GetById(int id)
        {
            var model = _context.BillTypes.Where(x => x.BillTypeId == id).FirstOrDefault();
            var vm = new BillTypeViewModel(model);
            return vm;
        } 
    }
}
