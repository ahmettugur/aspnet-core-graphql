﻿using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Data.Contracts;
using NorthwindGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NorthwindGraphQL.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product Add(Product entity)
        {
            return _productRepository.Add(entity);
        }

        public int Delete(Product entity)
        {
            return _productRepository.Delete(entity);
        }

        public Product Get(Expression<Func<Product, bool>> predicate)
        {
            return _productRepository.Get(predicate);
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> predicate = null)
        {
            return _productRepository.GetAll(predicate);
        }

        public Product Update(Product entity)
        {
            return _productRepository.Update(entity);
        }
    }
}
