using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Data.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public Supplier Add(Supplier entity)
        {
            return _supplierRepository.Add(entity);
        }

        public int Delete(Supplier entity)
        {
            return _supplierRepository.Delete(entity);
        }

        public Supplier Get(Expression<Func<Supplier, bool>> predicate)
        {
            return _supplierRepository.Get(predicate);
        }

        public List<Supplier> GetAll(Expression<Func<Supplier, bool>> predicate = null)
        {
            return _supplierRepository.GetAll(predicate);
        }

        public Supplier Update(Supplier entity)
        {
            return _supplierRepository.Update(entity);
        }
    }
}
