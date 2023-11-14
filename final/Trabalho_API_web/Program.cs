var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EstacionamentoDbContext>(); //Linha adicionada a mão

builder.Services.AddCors();//linha add pro angular

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opcoes => opcoes
    .WithOrigins("http://localhost:4200") // endereço do front
    .AllowAnyHeader().AllowAnyMethod().AllowCredentials());//linha add pro angular

app.UseAuthorization();

app.MapControllers();

app.Run();
