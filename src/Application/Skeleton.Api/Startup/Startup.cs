using System.IO;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Skeleton.Api.GraphQL.Query;
using Skeleton.Api.GraphQL.Schemas;
using Skeleton.Domain.Models;
using Skeleton.Domain.Repositories.Abstraction;
using Skeleton.Domain.Services.Core;
using Skeleton.Domain.UnitOfWork.Abstraction;
using Skeleton.Internal;
using Skeleton.Internal.Repositories.Core;
using Skeleton.Internal.UnitOfWork;

namespace Skeleton.Api
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
            services.AddDbContext<SkeletonApiContext>(
                options => options.UseMySQL(Configuration.GetConnectionString("SkeletonApiContext")));
            // Services
            services
                .AddScoped<ICrudService<Question, int>, CrudService<Question, int>>();
            
            // Repositories
            services
                .AddScoped<ICrudRepository<Question, int>, CrudRepository<Question, int>>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

            // GraphQL
            services
                .AddScoped<QuestionQuery>()
                .AddScoped<QuestionSchema>()
                .AddGraphQL()
                // Add required services for de/serialization
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { }) // For .NET Core 3+
                .AddWebSockets()
                .AddGraphTypes(typeof(QuestionSchema));
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebSockets();
            app.UseGraphQL<QuestionSchema>();
            if (env.IsDevelopment())
            {
                app.UseGraphiQLServer();
            }
        }
    }
}
