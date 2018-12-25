using GraphQL.Types;
using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Types.ObjectTypes
{
    public class SupplierType : ObjectGraphType<Supplier>
    {
        public SupplierType(IProductService productService)
        {
            Name = "Tedarikci";
            Description = "Urun Tedarikcileri";

            Field(_ => _.SupplierID).Description("Tedarikci No");
            Field(_ => _.CompanyName).Description("Sirket Adı");
            Field(_ => _.ContactName).Description("Iletisime gecilecek kisi");
            Field(_ => _.ContactTitle).Description("Ünvan");
            Field(_ => _.Address).Description("Addres");
            Field(_ => _.City).Description("Şehir");
            Field(_ => _.Region).Description("Bölge");
            Field(_ => _.PostalCode).Description("Posta Kodu");
            Field(_ => _.Country).Description("Ulke");
            Field(_ => _.Phone).Description("Telefon Numarası");
            Field(_ => _.Fax).Description("Fax Numarası");
            Field(_ => _.HomePage).Description("Web Sitesi");

            Field<ListGraphType<ProductType>>(
                "products",
                Description = "Urunler",
                resolve: context =>
                {
                    return productService.GetAll(_ => _.SupplierID == context.Source.SupplierID);
                }
            );

        }
    }
}
