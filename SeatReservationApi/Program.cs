using SeatReservation.Domain;
using SeatReservation.Infrastructure.Postgre;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<ReservertionServiceDbContext>(_ => 
    new ReservertionServiceDbContext(builder.Configuration.GetConnectionString("ReservationServiceDb")!));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(option => option.SwaggerEndpoint("/openapi/v1.json", "SeatReservationApi")); 
}

app.MapPost("/users", (ReservertionServiceDbContext dbContext) =>
{
    var social = new SocialNetwork
    {
        Name = "test",
        Link = "test"
    };

    dbContext.Add(new User()
    {
        Details = new Details()
        {
            Socials = [social, social, social],
            Description = "test"
        }
    });

    dbContext.SaveChanges();
});

app.Run();