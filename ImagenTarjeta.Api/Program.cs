
using ImagenTarjeta.Api.Interfaces;
using ImagenTarjeta.Api.Models;
using ImagenTarjeta.Api.Services;

namespace ImagenTarjeta.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<List<TarjetaMapping>>(builder.Configuration.GetSection("Mapping"));
            builder.Services.AddScoped<ITarjetasService, TarjetaService>();
            builder.Services.AddHealthChecks();

            var app = builder.Build();

            app.MapHealthChecks("/health");

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{

            //}
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

           

            app.MapGet("/imagentarjeta", (ITarjetasService tarjetasService, HttpContext httpContext, string?bin, string?clase) =>
            {                
                var url = tarjetasService.GetUrlTarjeta(bin, clase);
                return url;                
            })
            .WithName("ImagenTarjeta")
            .WithOpenApi();

            app.Run();
        }
    }
}
