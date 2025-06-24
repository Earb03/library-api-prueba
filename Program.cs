using LibraryApiPrueba.Services;

var builder = WebApplication.CreateBuilder(args);

// Agrega la política CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // tu frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClient para servicios
builder.Services.AddHttpClient<IBookService, BookService>();
builder.Services.AddHttpClient<IAuthorService, AuthorService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🧩 Usa la política CORS aquí
app.UseCors("AllowAngularClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
