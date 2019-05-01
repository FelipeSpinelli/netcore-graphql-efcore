using EFCoreGraphQL.Api.GraphQL;
using EFCoreGraphQL.Api.GraphQL.Types;
using EFCoreGraphQL.Core.Data;
using EFCoreGraphQL.Data;
using EFCoreGraphQL.Data.Repositories;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreGraphQL.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<MarvelContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:MarvelDb"]));
            services.AddTransient<ICharacterRepository, CharacterRepository>();
            services.AddTransient<IComicRepository, ComicRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ISerieRepository, SerieRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<MarvelQuery>();
            services.AddSingleton<MarvelMutation>();
            services.AddSingleton<CharacterType>();
            services.AddSingleton<ComicType>();
            services.AddSingleton<ComicInputType>();
            services.AddSingleton<EventType>();
            services.AddSingleton<SerieType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new MarvelSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
