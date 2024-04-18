var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options => options.AddPolicy("CorsName", builder => {
    builder.AllowAnyOrigin();

    // WithOrigin : Apiye ula�mas� gereken uygulaman�n web adresi yaz�l�r. Bu durumda sadece izin verilen uygulama web apiye eri�ir.
    // AllowAnyOrigin : Api t�m gelen isteklere origin g�zetmeksizin izin verir.
    // AllowAnyMethod : Metot baz�nda k�s�tlama yap�lar. 
    // AllowAnyHeader : Header baz�nda k�s�tlama

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


// Yap�lan cors tan�m�n�n sisteme tan�t�lmas�
app.UseCors("CorsName");

app.Run();


