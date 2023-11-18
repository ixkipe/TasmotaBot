using MQTTnet.Client;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

#warning Missing docs
public static class SubscribeOptionsProvider {
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