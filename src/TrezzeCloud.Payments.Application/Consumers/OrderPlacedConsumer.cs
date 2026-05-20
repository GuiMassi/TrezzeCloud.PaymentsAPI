using MassTransit;
using TrezzeCloud.Contracts.Events;

namespace TrezzeCloud.Payments.Application.Consumers;

public sealed class OrderPlacedConsumer : IConsumer<OrderPlacedEvent>
{
    public async Task Consume(ConsumeContext<OrderPlacedEvent> context)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("PROCESSING PAYMENT");
        Console.WriteLine($"Order: {context.Message.OrderId}");
        Console.WriteLine($"User: {context.Message.UserId}");
        Console.WriteLine($"Game: {context.Message.GameId}");
        Console.WriteLine($"Price: {context.Message.Price}");
        Console.WriteLine("Status: Approved");
        Console.WriteLine("====================================");

        await context.Publish(new PaymentProcessedEvent(
            context.Message.OrderId,
            context.Message.UserId,
            context.Message.GameId,
            context.Message.Price,
            "Approved",
            DateTime.UtcNow));
    }
}