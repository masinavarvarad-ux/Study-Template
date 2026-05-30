var builder = WebApplication.CreateBuilder(args);

// 1. Регистрируем контроллеры в системе
builder.Services.AddControllers();

// 2. Включаем генерацию OpenAPI документа (json) по стандарту .NET 10
builder.Services.AddOpenApi();

var app = builder.Build();

// Настройка среды разработки
if (app.Environment.IsDevelopment())
{
    // 3. Создаем эндпоинт /openapi/v1.json
    app.MapOpenApi();

    // 4. Подключаем интерфейс Swagger UI поверх сгенерированного json
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Библиотека API v1");
        options.RoutePrefix = string.Empty; // Делает Swagger главной страницей при запуске
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 5. Привязываем маршруты контроллеров
app.MapControllers();

app.Run();
