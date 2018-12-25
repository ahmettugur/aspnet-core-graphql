using GraphQL.Types;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Types.ObjectTypes
{
    public class OrderDetailViewType : ObjectGraphType<OrderDetailView>
    {
        public OrderDetailViewType()
        {
            Name = "SiparisDetay";
            Description = "Siparis Detayları";

            Field(_ => _.OrderID).Description("Siparis No");
            Field(_ => _.ProductID).Description("Urun No");
            Field(_ => _.ProductName).Description("Urun Adı");
            Field(_ => _.UnitPrice).Description("Birim Fiyatı");
            Field(_ => _.Quantity,type:typeof(IntGraphType)).Description("Adet");
            Field(_ => _.Discount).Description("Indirim");
            Field(_ => _.ExtendedPrice).Description("Genişletilmiş Fiyat");
        }
    }
}