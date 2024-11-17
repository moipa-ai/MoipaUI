using NATS.Net;

namespace MoipaUI.IServers;
/// <summary>
/// mqtt初始化在mqttserver里面
/// </summary>
public interface IMqttServer
{
    public Task PublishMessage(string message);
}