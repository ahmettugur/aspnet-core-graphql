using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Data.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Services
{
    public class OrderDetailViewService : IOrderDetailViewService
    {
        private readonly IOrderDetailViewRepository _orderDetailViewRepository;
        public OrderDetailViewService(IOrderDetailViewRepository orderDetailViewRepository)
        {
            _orderDetailViewRepository = orderDetailViewRepository;
        }
        public OrderDetailView Get(Expression<Func<OrderDetailView, bool>> predicate)
        {
            return _orderDetailViewRepository.Get(predicate);
        }

        public List<OrderDetailView> GetAll(Expression<Func<OrderDetailView, bool>> predicate = null)
        {
            return _orderDetailViewRepository.GetAll(predicate);
        }
    }
}
