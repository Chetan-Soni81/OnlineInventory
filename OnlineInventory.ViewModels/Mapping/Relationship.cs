using OnlineInventory.Models;
using OnlineInventory.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.ViewModels.Mapping
{
    public static class Relationship
    {
        public static IEnumerable<CustomerTypeListViewModel> ModelToVM(this IEnumerable<CustomerType> customerType)
        {
            List<CustomerTypeListViewModel> list = new();
            foreach (var model in customerType)
            {
                list.Add(new CustomerTypeListViewModel
                {
                    CustomerTypeId = model.CustomerTypeId,
                    CustomerTypeName = model.CustomerTypeName,
                    Description = model.Description,
                });
            }

            return list;
        }
    } 
}
