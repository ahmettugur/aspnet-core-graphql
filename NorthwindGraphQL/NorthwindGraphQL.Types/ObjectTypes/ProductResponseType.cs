using GraphQL.Types;
using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Types.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Types.ObjectTypes
{
    public class ProductResponseType:ObjectGraphType<ProductResponse>
    {
        public ProductResponseType(IProductService productService)
        {
            Name = "Urunler";
            Description = "Urun Listesi";

            Field(_ => _.CurrentCategory).Description("Kategori");
            Field(_ => _.CurrentPage).Description("Sayfa");
            Field(_ => _.PageCount).Description("Sayfa Sayısı");
            Field(_ => _.PageSize).Description("sayfa boyutu");
            Field(_ => _.Products,type:typeof(ListGraphType<ProductType>)).Description("UrunListesi");
        }
    }
}