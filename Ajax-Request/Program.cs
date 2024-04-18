var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options => options.AddPolicy("CorsName", builder => {
    builder.AllowAnyOrigin();

    // WithOrigin : Apiye ulaþmasý gereken uygulamanýn web adresi yazýlýr. Bu durumda sadece izin verilen uygulama web apiye eriþir.
    // AllowAnyOrigin : Api tüm gelen isteklere origin gözetmeksizin izin verir.
    // AllowAnyMethod : Metot bazýnda kýsýtlama yapýlar. 
    // AllowAnyHeader : Header bazýnda kýsýtlama

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


// Yapýlan cors tanýmýnýn sisteme tanýtýlmasý
app.UseCors("CorsName");

app.Run();


