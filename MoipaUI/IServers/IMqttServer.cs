using NATS.Net;

namespace MoipaUI.Servers;

public interface IMqttServer
{
    public NatsClient MqttConnect();
}