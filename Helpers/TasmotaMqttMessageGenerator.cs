using MiscellaneousGibs.TasmotaBot.Models;
using MQTTnet;
using Serilog;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

/// <summary>
/// Contains helper methods responsible for creating MQTT messages.
/// </summary>
public static class TasmotaMqttMessageGenerator {
  /// <summary>
  /// Create an MQTT message based on the provided command, topic and payload.
  /// </summary>
  /// <param name="deviceInfo">Information about the target device.</param>
  /// <param name="messageData">The command and the payload.</param>
  /// <returns><c>MqttApplicationMessage</c></returns>
  public static MqttApplicationMessage GenerateCommandMessage(this DeviceInfo deviceInfo, MqttMessageData messageData) {
    return new MqttApplicationMessageBuilder()
      .WithTopic(string.Format(messageData.CommandTemplate, deviceInfo.Topic))
      .WithPayload(messageData.Payload)
      .Build();
  }
}