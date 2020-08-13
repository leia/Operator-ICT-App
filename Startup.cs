using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT_Operator_App.JWT;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace ICT_Operator_App {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddControllers();
      services.AddTokenAuthentication(Configuration);
      var cs = Configuration.GetConnectionString("DbConnection");
      services.AddDbContext<MusicCatalogDbContext>(options => options.UseSqlServer(cs));
      services.AddSwaggerGen(c => {
        var securitySchema = new OpenApiSecurityScheme {
          Description = "JWT Authorization header using the Bearer scheme.",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.Http,
          Scheme = "bearer",                   
          Reference = new OpenApiReference {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
          }
        };
        c.AddSecurityDefinition("Bearer", securitySchema);
        

        var securityRequirement = new OpenApiSecurityRequirement();
        securityRequirement.Add(securitySchema, new[] { "Bearer" });
        c.AddSecurityRequirement(securityRequirement);
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }
      app.UseMiddleware<AuthenticationMiddleware>();
      app.UseSwagger();
      app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });

      app.UseHttpsRedirection();

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}
