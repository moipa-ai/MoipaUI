using NATS.Net;

namespace MoipaUI.Servers;

public class MqttServer:IMqttServer
{
    private NatsClient _natsClient = new();

    public NatsClient MqttConnect()
    {
        var js = new NatsClient();
        return js;
    }
}