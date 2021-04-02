using System.Linq;
using API.ModelAPI;
using DAOEntityFramework;
using DAOEntityFramework.EntityActions;
using DAOEntityFramework.EntityActionsInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppContext>(opt => opt.UseInMemoryDatabase("TestDatabase"));
			services.AddSingleton<IToDoGet, ToDoGet>();
			services.AddSingleton<IToDoAdd, ToDoAdd>();
			services.AddSingleton<IToDoEdit, ToDoEdit>();
			services.AddSingleton<IResultAPI, ResultAPI>();
			services.AddSingleton<IToDoStatus, ToDoStatus>();
			services.AddSingleton<IToDoDelete, ToDoDelete>();
			
			services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
								  builder =>
								  {
									  builder.WithOrigins("http://localhost:4200")
									  .AllowAnyHeader()
									  .AllowAnyMethod();
								  });
			});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "Place Info Service API",
					Version = "v1",
					Description = "Sample service for Learner",
				});
				options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseSwagger();
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "My API V1");
			});

			app.UseCors(MyAllowSpecificOrigins);
			app.UseHttpsRedirection();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
