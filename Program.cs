using Maxishop.Infrastructure.DbContexts;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Add cors 
builder.Services.AddCors(option =>
{
    option.AddPolicy("CustomPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

});
// Add services to the container.
#region Database Connectivity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion
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


app.UseCors("CustomPolicy");//pipe line 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
