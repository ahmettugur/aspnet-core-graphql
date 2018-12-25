using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Data.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Order Add(Order entity)
        {
            return _orderRepository.Add(entity);
        }

        public int Delete(Order entity)
        {
            return _orderRepository.Delete(entity);
        }

        public Order Get(Expression<Func<Order, bool>> predicate)
        {
            return _orderRepository.Get(predicate);
        }

        public List<Order> GetAll(Expression<Func<Order, bool>> predicate = null)
        {
            return _orderRepository.GetAll(predicate);
        }

        public Order Update(Order entity)
        {
            return _orderRepository.Update(entity);
        }
    }
}
