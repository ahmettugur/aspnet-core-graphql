using GraphQL.Types;
using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Types.ObjectTypes
{
    public class CategoryType:ObjectGraphType<Category>
    {
        public CategoryType(IProductService productService)
        {
            Field(_=>_.CategoryID).Description("Kategori No");
            Field(_ => _.CategoryName).Description("Kategori Adı");
            Field(_ => _.Description).Description("Kategori Açıklaması");

            Field<ListGraphType<ProductType>>(
                "products",
                Description="Kategoriye ait urunler",
                resolve: context =>{
                    return productService.GetAll(_ => _.CategoryID == context.Source.CategoryID);
                });

        }
    }
}
