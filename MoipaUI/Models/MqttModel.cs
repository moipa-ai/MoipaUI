using MoipaUI.IServers;
using NATS.Net;

namespace MoipaUI.Models;

public class MqttModel:IMqttServer
{
    private NatsClient NatsClient { get; set; } = new NatsClient("192.168.3.9:4222");

    public MqttModel()
    {
        NatsClient.SubscribeAsync<string>("/.test.topic1");
    }

    public async Task PublishMessage(string message)
    {
      await  NatsClient.PublishAsync("/.test.topic2", message);
    }
}