using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Mappings;
using WebApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClassDbContext>(options =>
options.UseSqlServer(connection));

builder.Services.AddAutoMapper(typeof(EntitiesToDtoMapping));


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ClassDbContext>();

builder.Services.AddScoped<ICliente, ClienteRepository>();


//builder.Services.AddDbContext<ClassDbContext>(Options =>
//{
//    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
