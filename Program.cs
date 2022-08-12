

using Microsoft.EntityFrameworkCore;
using dockcompyml.Data;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var server =  ".\\SqlExpress";
var port =  "1433"; // Default SQL Server port
var user =  "pythonusr1"; // Warning do not use the SA account
var password =  "Archer!!77";
var database =  "bookDb";

 var constr="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BookDb;Data Source=.\\sqlexpress; User ID=pythonusr1; Password=Archer!!77";
builder.Services.AddDbContext<AppDataDbcontext>(
    opts=>{
        opts.EnableDetailedErrors();
        opts.EnableSensitiveDataLogging();
        opts.UseSqlServer(constr);
        //opts.UseSqlServer($"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}");
    }, ServiceLifetime.Transient
);  //link program.cs to dbcontext database


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapGet("/GetAllBook/", async (AppDataDbcontext db)=>{

    var books=await db.Books.ToListAsync();

    return books;
});

app.Run();
