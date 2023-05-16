using ContribuyentesDGII.Api.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnection = builder.Configuration.GetConnectionString("DGIIConnection");
InternalConnections.ConnectionString = dbConnection;
builder.Services.AddDbContext<ContribuyentesDbContext>(options =>
    options.UseSqlServer(dbConnection));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IContribuyenteRepository, ContribuyenteRepository>();
builder.Services.AddScoped<IContribuyenteService, ContribuyenteService>();
builder.Services.AddScoped<IComprobanteFiscalRepository, ComprobanteFiscalRepository>();
builder.Services.AddScoped<IComprobanteFiscalService, ComprobanteFiscalService>();
builder.Services.AddScoped<EstatusController>();
builder.Services.AddScoped<TipoPersonasController>();
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

app.Run();
