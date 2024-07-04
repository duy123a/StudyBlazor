using Microsoft.EntityFrameworkCore;
using SimpleVideoGameLibrary.Server.Data;

namespace SimpleVideoGameLibrary.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<DataContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			// Config cors
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowBlazorClient",
					builder =>
					{
						builder.WithOrigins("http://localhost:5011")
							.AllowAnyMethod()
							.AllowAnyHeader();
					});
			});

			builder.Services.AddControllers();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			// Use CORS policy
			app.UseCors("AllowBlazorClient");

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
