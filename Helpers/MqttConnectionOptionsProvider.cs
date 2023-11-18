using MQTTnet.Client;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

/// <summary>
/// Contains helper methods responsible for creating MQTT connection options.
/// </summary>
public static class MqttConnectionOptionsProvider {
  /// <summary>
  /// Create an instance of <c>MqttClientOptions</c> based on the Mosquitto server address specified in the application configuration.
  /// </summary>
  /// <param name="config">The app configuration.</param>
  /// <returns><c>MqttClientOptions</c></returns>
  public static MqttClientOptions GenerateMqttConnectionOptions(this IConfiguration config) {
    return new MqttClientOptionsBuilder()
      .WithTcpServer(config["MqttInfo:Server"])
      .Build();
  }
}