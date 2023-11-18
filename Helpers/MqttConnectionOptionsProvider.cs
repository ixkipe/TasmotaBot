using MQTTnet.Client;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

#warning Missing docs
public static class MqttConnectionOptionsProvider {
  public static MqttClientOptions GenerateMqttConnectionOptions(this IConfiguration config) {
    return new MqttClientOptionsBuilder()
      .WithTcpServer(config["MqttInfo:Server"])
      .Build();
  }
}