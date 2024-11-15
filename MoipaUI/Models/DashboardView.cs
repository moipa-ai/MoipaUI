using MoipaUI.Servers;

namespace MoipaUI.Models;

public class DashboardView
{
    private readonly IMqttServer _mqttServer;

    public DashboardView(IMqttServer mqttServer)
    {
        _mqttServer = mqttServer;
    }
}