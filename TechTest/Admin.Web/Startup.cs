using System.Reflection;
using Admin.Common.Services;
using Admin.Common.Services.Implementation;
using Admin.Data.Models;
using Admin.Data.Repositories;
using Admin.Data.Repositories.Implementation;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Admin.Web
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
			services.AddControllersWithViews();
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddControllersWithViews();
			AddServiceDependencies(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		private void AddServiceDependencies(IServiceCollection services)
		{
			services.AddDbContext<AdminContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

			services.AddTransient<IPersonService, PersonService>();
			services.AddTransient<IGroupsService, GroupsService>();

			services.AddTransient<IPersonRepository, PersonRepository>();
			services.AddTransient<IGroupsRepository, GroupsRepository>();
		}
	}
}
