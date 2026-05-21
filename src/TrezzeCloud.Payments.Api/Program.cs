using MassTransit;
using TrezzeCloud.Payments.Application.Consumers;

var builder = WebApplication.CreateBuilder(args);
var rabbitHost = builder.Configuration["RabbitMq:Host"] ?? "rabbitmq";
var rabbitUsername = builder.Configuration["RabbitMq:Username"] ?? "guest";
var rabbitPassword = builder.Configuration["RabbitMq:Password"] ?? "guest";

builder.Services.AddControllers();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<OrderPlacedConsumer>();

    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(
            rabbitHost,
            "/",
            host =>
        {
            host.Username(rabbitUsername);
            host.Password(rabbitPassword);
        });

        cfg.ReceiveEndpoint("payments-order-placed", endpoint =>
        {
            endpoint.ConfigureConsumer<OrderPlacedConsumer>(context);
        });
    });
});

var app = builder.Build();

app.MapControllers();

app.Run();