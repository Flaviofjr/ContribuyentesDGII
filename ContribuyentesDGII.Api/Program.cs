
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    { //Solo para obtener la precision de formato que viene de la base de datos con los dos digitos despues del punto
        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnection = builder.Configuration.GetConnectionString("DGIIConnection");
InternalConnections.ConnectionString = dbConnection;
builder.Services.AddDbContext<ContribuyentesDbContext>(options =>
    options.UseSqlServer(dbConnection));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IContribuyenteRepository, ContribuyenteRepository>();
builder.Services.AddScoped<IContribuyenteService, ContribuyenteService>();
builder.Services.AddScoped<IComprobanteFiscalRepository, ComprobanteFiscalRepository>();
builder.Services.AddScoped<IComprobanteFiscalService, ComprobanteFiscalService>();
builder.Services.AddScoped<EstatusController>();
builder.Services.AddScoped<TipoPersonasController>();
//CORS
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("MyCORSPloicy", policy =>
    {
        policy.AllowAnyOrigin();
        policy.WithOrigins("https://localhost:7092");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyCORSPloicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
