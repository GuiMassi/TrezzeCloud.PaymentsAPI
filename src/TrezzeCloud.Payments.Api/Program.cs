using MassTransit;
using TrezzeCloud.Payments.Application.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<OrderPlacedConsumer>();

    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
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