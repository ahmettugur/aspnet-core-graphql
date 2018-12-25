using GraphQL.Types;
using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindGraphQL.Types.ObjectTypes
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(IProductService productService, IOrderDetailViewService orderDetailViewService)
        {
            Name = "Siparisler";
            Description = "Musteri siparisleri";

            Field(_ => _.OrderID).Description("Siparis No");
            Field(_ => _.CustomerID,type:typeof(StringGraphType)).Description("Musteri No");
            Field(_ => _.EmployeeID, nullable: true).Description("Personel No");
            Field(_ => _.OrderDate,nullable:true).Description("Siparis Tarihi");
            Field(_ => _.RequiredDate, nullable: true).Description("Istenen Tarih");
            Field(_ => _.ShippedDate, nullable: true).Description("Gönderilen Tarih");
            Field(_ => _.ShipVia, nullable: true).Description("Gönderme Sekli");
            Field(_ => _.Freight, nullable: true).Description("Nakliye");
            Field(_ => _.ShipName).Description("Gonderen");
            Field(_ => _.ShipAddress).Description("Gonderici Adresi");
            Field(_ => _.ShipCity).Description("Sehir");
            Field(_ => _.ShipRegion,nullable:true).Description("Bolge");
            Field(_ => _.ShipPostalCode).Description("Posta Kodu");
            Field(_ => _.ShipCountry).Description("Ulke");

            Field<ListGraphType<OrderDetailViewType>>(
                "orderDetail",
                Description = "Siparis Detaylalrı",
                resolve: context =>
                {
                    return orderDetailViewService.GetAll(_ => _.OrderID == context.Source.OrderID);
                }
            );
        }
    }
}