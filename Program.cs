using Microsoft.EntityFrameworkCore;
using webreportes_backend.Context;
using webreportes_backend.Filters;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ValidationFilter>();
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins("http://127.0.0.1:5173").AllowAnyHeader().AllowAnyMethod();
					  });
});


// añadimos el contexto a los servicios
builder.Services.AddDbContext<UserContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("conexionSQLSERVER"));
});


var app = builder.Build();

// creamos un scope para crear la BD al momento de ejecutar la APP
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<UserContext>();
	context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
