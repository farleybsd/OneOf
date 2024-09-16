using Microsoft.AspNetCore.Mvc;
using ResultPattern.OneOf.Application;
using ResultPattern.OneOf.Application.Erros;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/cars", async ([FromBody] RegisterCarRequest req, ICarService service, CancellationToken ct = default) =>
{


    var carResult = await service.AddCar(req.Name, ct);

    return carResult.Match(
        car => Results.Created($"cars/{car.Id}", car),
        error =>
        {
            if (error.ErrorType == ErrorType.BusinessRuler)
                return Results.Conflict(error);

            return Results.BadRequest(error);
        });

    //SUCESSO
    //if (carResult.IsSuccess())
    //{
    //    var car = carResult.GetSuccess();
    //    return Results.Created($"cars/{car.Id}", car);
    //}

    // In Case Erros
    //var erroObj = carResult.GetError();

    //if (erroObj.ErrorType == ErrorType.BusinessRuler)
    //    return Results.Conflict(erroObj);

    //return Results.BadRequest(erroObj);

});

app.Run();