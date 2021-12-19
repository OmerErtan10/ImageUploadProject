using ImageUploadProject.Business.Concrete;
using ImageUploadProject.Business.Interfaces;
using ImageUploadProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using ImageUploadProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using ImageUploadProject.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageUploadProject.Business.Containers.MicrosoftIoc
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddDbContext<ImageProjectContext>();
        }
    }
}
