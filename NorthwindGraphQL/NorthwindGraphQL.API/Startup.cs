using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NorthwindGraphQL.API.Schemas;
using NorthwindGraphQL.Business.Contracts;
using NorthwindGraphQL.Business.Services;
using NorthwindGraphQL.Data;
using NorthwindGraphQL.Data.Contracts;
using NorthwindGraphQL.Data.EntityFramework.Concrete;
using NorthwindGraphQL.Types.ObjectTypes;

namespace NorthwindGraphQL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Context

            services.AddScoped<DbContext, NorthwindDbContext>();

            //Business
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailViewService, OrderDetailViewService>();
            

            //Data Respository
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<ISupplierRepository, EFSupplierRepository>();
            services.AddScoped<IOrderRepository,EFOrderRepository>();
            services.AddScoped<IOrderDetailViewRepository, EFOrderDetailViewRepository>();

            //GraphQL Document
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            //GraphQL Query
            services.AddSingleton<NorthwindAppQuery>();
            //services.AddSingleton<NorthwindAppMutation>();

            //GraphQL Types
            services.AddSingleton<ProductType>();
            services.AddSingleton<CategoryType>();
            services.AddSingleton<SupplierType>();
            services.AddSingleton<OrderType>();
            services.AddSingleton<OrderDetailViewType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new NorthwindAppSchema(new FuncDependencyResolver(type => sp.GetService(type))));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
