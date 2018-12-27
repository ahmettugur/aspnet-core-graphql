using GraphQL.Types;
using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Types.ObjectTypes
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryService categoryService, ISupplierService supplierService, IOrderDetailViewService orderDetailViewService)
        {
            Name = "Urun";
            Description = "Ürün kolonları";

            Field(_ => _.ProductID).Description("Urun No");
            Field(_ => _.ProductName).Description("Urun Adı");
            Field(_ => _.SupplierID, nullable: true).Description("Tedarikci No");
            Field(_ => _.CategoryID, nullable: true).Description("Kategori No");
            Field(_ => _.QuantityPerUnit).Description("Birim miktarı");
            Field(_ => _.UnitPrice, nullable: true).Description("Birim Fiyatı");
            Field(_ => _.UnitsInStock, nullable: true, type: typeof(IntGraphType)).Description("Stok miktarı");
            Field(_ => _.UnitsOnOrder, nullable: true, type: typeof(IntGraphType)).Description("Siparişteki miktarı");
            Field(_ => _.ReorderLevel, nullable: true, type: typeof(IntGraphType)).Description("Yeniden sipariş seviyesi");
            Field(_ => _.Discontinued, nullable: true).Description("Stoğu var mı?");

            Field<CategoryType>(
                "category",
                Description = "Urunun bulunduğu kategori",
                resolve: context =>
                {
                    return categoryService.Get(_ => _.CategoryID == context.Source.CategoryID);
                });
            Field<SupplierType>(
                "supplier",
                Description = "Tedarikci",
                resolve: context =>
                {
                    var supplier = supplierService.Get(_ => _.SupplierID == context.Source.SupplierID);
                    return supplier;
                }
            );
            Field<ListGraphType<OrderDetailViewType>>(
                "orders",
                Description = "Ürüne Ait Siparişler",
                resolve: context =>
                {
                    return orderDetailViewService.GetAll(_ => _.ProductID == context.Source.ProductID);
                }
            );

        }
    }
}

/*
  public Supplier Supplier { get; set; }     
     
*/
