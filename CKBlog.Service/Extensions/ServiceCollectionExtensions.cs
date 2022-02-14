using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Data.Context;
using CKBlog.Data.Repositories.Abstract;
using CKBlog.Data.Repositories.Concrete;
using CKBlog.Data.UnitOfWork;
using CKBlog.Service.Services.Abstract;
using CKBlog.Service.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CKBlog.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            serviceCollection.AddScoped<IArticleRepository, ArticleRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<ISocialMediaRepository, SocialMediaRepository>();

            serviceCollection.AddScoped<IArticleService, ArticleService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<ISocialMediaService, SocialMediaService>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
    }
}
