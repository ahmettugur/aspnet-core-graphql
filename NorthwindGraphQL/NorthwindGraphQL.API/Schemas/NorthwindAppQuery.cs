using GraphQL.Types;
using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Types.ObjectTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.API.Schemas
{
    public class NorthwindAppQuery : ObjectGraphType<object>
    {
        public NorthwindAppQuery(IProductService productService,
            ICategoryService categoryService,
            ISupplierService supplierService,
            IOrderService orderService,
            ICustomerService customerService)
        {
            #region Product
            Field<ListGraphType<ProductType>>(
                "allProduct",
                Description = "Tum Urunler",
                resolve: context =>
                 {
                     return productService.GetAll();
                 }
            );
            Field<ProductType>(
                "product",
                Description = "Ürün Detay",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "productId" }
                ),
                resolve: context =>
                 {
                     var productId = context.GetArgument<int>("productId");
                     return productService.Get(_ => _.ProductID == productId);
                 }
            );
            #endregion

            #region Category
            Field<ListGraphType<CategoryType>>(
                "allCategory",
                Description = "Kategoriler",
                resolve: context =>
                 {
                     return categoryService.GetAll();
                 }
            );
            Field<CategoryType>(
                "category",
                Description = "Kategori Detay",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "categoryID" }
                ),
                resolve: context =>
                {
                    var categoryId = context.GetArgument<int>("categoryID");
                    return categoryService.Get(_ => _.CategoryID == categoryId);
                }
            );
            #endregion

            #region Supplier
            Field<ListGraphType<SupplierType>>(
                "allSupplier",
                Description = "Tedarikciler",
                resolve: context =>
                {
                    return supplierService.GetAll();
                }
            );
            Field<SupplierType>(
                "supplier",
                Description = "Tedarikci Detay",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "supplierId" }
                ),
                resolve: context =>
                {
                    var supplierId = context.GetArgument<int>("supplierId");
                    return supplierService.Get(_ => _.SupplierID == supplierId);
                }
            );
            #endregion

            #region Order
            Field<ListGraphType<OrderType>>(
                "allOrders",
                Description = "Siparisler",
                resolve: context =>
                {
                    return orderService.GetAll();
                }
            );

            Field<OrderType>(
                "order",
                Description = "Siparis Detay",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "orderId" }
                ),
                resolve: context =>
                {
                    var orderId = context.GetArgument<int>("orderId");
                    return orderService.Get(_ => _.OrderID == orderId);
                }
            );
            #endregion

            #region Müşteri
            Field<ListGraphType<CustomerType>>(
                "allCustomers",
                Description = "Musteriler",
                resolve: context =>
                {
                    return customerService.GetAll();
                }
            );

            Field<CustomerType>(
                "customer",
                Description = "Musteri Detay",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "customerId" }
                ),
                resolve: context =>
                {
                    var customerId = context.GetArgument<string>("customerId");
                    return customerService.Get(_ => _.CustomerID == customerId);
                }
            );
            #endregion
        }

    }
}
