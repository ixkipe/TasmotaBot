using MiscellaneousGibs.TasmotaBot.Models;
using MQTTnet;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

#warning Missing docs
public static class TasmotaMqttMessageGenerator {
  public static MqttApplicationMessage GenerateCommandMessage(this DeviceInfo deviceInfo, MqttMessageData messageData) {
    return new MqttApplicationMessageBuilder()
      .WithTopic(string.Format(messageData.CommandTemplate, deviceInfo.Topic))
      .WithPayload(messageData.Payload)
      .Build();
  }
}