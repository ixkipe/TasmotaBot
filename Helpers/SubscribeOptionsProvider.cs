using MQTTnet.Client;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

/// <summary>
/// Contains helper methods that provide MQTT subscribe options.
/// </summary>
public static class SubscribeOptionsProvider {
  /// <summary>
  /// Create MQTT subscribe options based on the specified topics.
  /// </summary>
  /// <param name="topics">Topics to subscribe to.</param>
  /// <returns><c>MqttClientSubscribeOptions</c></returns>
  public static MqttClientSubscribeOptions GenerateSubscribeOptions(this IEnumerable<string> topics) {
    return new MqttClientSubscribeOptionsBuilder()
      .WithTopicFilter(f => {
        foreach (var topic in topics) {
          f.WithTopic(topic);
        }
      })
      .Build();
  }
}