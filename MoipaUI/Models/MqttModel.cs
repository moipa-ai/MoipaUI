using MoipaUI.Servers;
using NATS.Net;

namespace MoipaUI.Models;

public class MqttModel:IMqttServer
{
    public NatsClient NatsClient { get; set; } = new NatsClient();
    public NatsClient MqttConnect()
    {
        var js = new NatsClient();
        return js;
    }
}