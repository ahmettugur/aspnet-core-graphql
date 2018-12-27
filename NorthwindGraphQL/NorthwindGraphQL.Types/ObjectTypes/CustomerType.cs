using GraphQL.Types;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Types.ObjectTypes
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Name = "Musteriler";
            Description = "Musteri";

            Field(_ => _.CustomerID).Description("Musteri No");
            Field(_ => _.CompanyName).Description("Sirket Adı");
            Field(_ => _.ContactName).Description("Iletisime gecilecek kisi");
            Field(_ => _.ContactTitle).Description("Acıklama");
            Field(_ => _.Address).Description("Adres");
            Field(_ => _.City).Description("Il");
            Field(_ => _.Region).Description("Bolge");
            Field(_ => _.PostalCode).Description("Posta Kodu");
            Field(_ => _.Country).Description("Ulke");
            Field(_ => _.Phone).Description("Telefon");
            Field(_ => _.Fax).Description("Fax");
        }
    }
}
