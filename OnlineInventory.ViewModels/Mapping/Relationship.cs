using OnlineInventory.Models;
using OnlineInventory.ViewModels.Bill;
using OnlineInventory.ViewModels.Customer;
using OnlineInventory.ViewModels.Invoice;
using OnlineInventory.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public static IEnumerable<CustomerListViewModel> ModelToVM(this IEnumerable<Models.Customer> customers)
        {
            List<CustomerListViewModel> list = new();
            foreach(var vm in customers)
            {
                list.Add(new CustomerListViewModel
                {
                    CustomerId = vm.CustomerId,
                    CustomerName = vm.CustomerName,
                    CustomerTypeId = vm.CustomerTypeId,
                    Address = vm.Address,
                    City = vm.City,
                    State = vm.State,
                    ZipCode = vm.ZipCode,
                    Phone = vm.Phone,
                    Email = vm.Email,
                    ContactPerson = vm.ContactPerson
                });
            }
            return list;
        }

        public static IEnumerable<InvoiceListViewModel> ModelToVM(this IEnumerable<Models.Invoice> invoices)
        {
            List<InvoiceListViewModel> list = new();
            foreach (var vm in invoices)
            {
                list.Add(new InvoiceListViewModel
                {
                    InvoiceId = vm.InvoiceId,
                    InvoiceName = vm.InvoiceName,
                    ShipmentId = vm.ShipmentId,
                    InvoiceDate = vm.InvoiceDate,
                    InvoiceDueDate = vm.InvoiceDueDate,
                    InvoiceTypeId = vm.InvoiceTypeId
                });
            }
            return list;
        }

        public static IEnumerable<InvoiceTypeListViewModel> ModelToVM(this IEnumerable<InvoiceType> invoiceTypes) {
            List<InvoiceTypeListViewModel> list = new();
            foreach (var vm in invoiceTypes)
            {
                list.Add(new InvoiceTypeListViewModel
                {
                    InvoiceTypeId = vm.InvoiceTypeId,
                    InvoiceTypeName = vm.InvoiceTypeName,
                    Description = vm.Description,
                });
            }

            return list;
        }

        public static IEnumerable<BillTypeListViewModel> ModelToVM(this IEnumerable<BillType> billTypes)
        {
            List<BillTypeListViewModel> list = new();
            foreach (var vm in billTypes)
            {
                list.Add(new BillTypeListViewModel
                {
                    BillTypeId = vm.BillTypeId,
                    BillTypeName = vm.BillTypeName,
                    Description = vm.Description
                });
            }
            return list;
        }

        public static IEnumerable<BillListViewModel> ModelToVM(this IEnumerable<Models.Bill> bills)
        {
            List<BillListViewModel> list = new();
            foreach (var vm in bills)
            {
                list.Add(new BillListViewModel
                {
                    BillId = vm.BillId,
                    BillName = vm.BillName,
                    GoodsReceivedNoteId = vm.GoodsReceivedNoteId,
                    VendorDoNumber = vm.VendorDoNumber,
                    VendorInvoiceNumber = vm.VendorInvoiceNumber,
                    BillDate = vm.BillDate,
                    BillDueDate = vm.BillDueDate,
                    BillTypeId = vm.BillTypeId
                });
            }
            return list;
        }

        public static IEnumerable<ProductTypeListViewModel> ModelToVM(this IEnumerable<ProductType> productTypes)
        {
            List<ProductTypeListViewModel> list = new();
            foreach (var vm in productTypes)
            {
                list.Add(new ProductTypeListViewModel
                {
                    ProductTypeId = vm.ProductTypeId,
                    ProductTypeName = vm.ProductTypeName,
                    Description = vm.Description
                });
            }
            return list;
        }

        public static IEnumerable<ProductListViewModel> ModelToVM(this IEnumerable<Models.Product> products)
        {
            List<ProductListViewModel> list = new();
            foreach (var vm in products)
            {
                list.Add(new ProductListViewModel
                {
                    ProductId = vm.ProductId,
                    ProductName = vm.ProductName,
                    ProductCode = vm.ProductCode,
                    BarCode = vm.BarCode,
                    Description = vm.Description,
                    ProductImage = vm.ProductImage,
                    MeasureUnitId = vm.MeasureUnitId,
                    BuyingPrice = vm.BuyingPrice,
                    SellingPrice = vm.SellingPrice,
                    BranchId = vm.BranchId,
                    CurrencyId = vm.CurrencyId
                });
            }

            return list;
        }
    } 
}
