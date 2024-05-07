
using GeniuseeTestTask.Handlers;
using GeniuseeTestTask.Interfaces;
using GeniuseeTestTask.Services;

namespace GeniuseeTestTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
          
            builder.Services.AddHttpClient();
            builder.Services.AddLogging();

            builder.Services.AddSingleton<IRainfallApiService, RainfallApiService>();
            builder.Services.AddScoped<IRainfallService, RainfallService>();
            
            builder.Services.AddSwaggerGen(c =>
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "GeniuseeTestTask.xml")));
            builder.Services.AddExceptionHandler<AppExceptionHandler>();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rainfall Api v1"));
            }

            app.UseExceptionHandler(_ => { });
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
