using MoipaUI.IServers;
using NATS.Net;
using Newtonsoft.Json;

namespace MoipaUI.Models;

public class MqttModel:IMqttServer
{
    private NatsClient NatsClient { get; set; } = new NatsClient("192.168.3.9:4222");
    
    
    [JsonProperty("msg")]
    public string? Msg{get;set;}

    public MqttModel()
    {
        NatsClient.SubscribeAsync<string>("/.test.topic1");
    }

    public async Task PublishMessage(string message)
    {
        var sMsg = new MqttModel { Msg = message };
        var msg = JsonConvert.SerializeObject(sMsg);
        //string json1 = JsonSerializer.Serialize();
      await  NatsClient.PublishAsync("/.test.topic2", msg);
    }

    // private string StringToJson(string message)
    // {
    //     var jsonText =string.Format($"{{ \"msg\":{message}}}"); 
    //     return jsonText;
    // }
}