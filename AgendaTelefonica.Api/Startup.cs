using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaTelefonica.Domain;
using AgendaTelefonica.Domain.Handlers;
using AgendaTelefonica.Domain.Respositories;
using AgendaTelefonica.Infra.Context.DataContext;
using AgendaTelefonica.Infra.Context.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaTelefonica.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.AddScoped<AgendaTelefonicaDataContext, AgendaTelefonicaDataContext>();
            services.AddScoped<ContactHandler, ContactHandler>();
            services.AddTransient<IContactRepository, ContactRepository>();

            var config = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperProfile>();  });           
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);            
            //services.AddAutoMapper(typeof(Startup).Assembly);
            //Mapper.AssertConfigurationIsValid();


            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Agenda Telefônica", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }     

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agenda Telefônica - V1"); });
        }
    }
}
