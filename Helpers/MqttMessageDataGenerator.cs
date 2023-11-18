using MiscellaneousGibs.TasmotaBot.Constants;
using MiscellaneousGibs.TasmotaBot.Models;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

/// <summary>
/// Contains helper methods responsible for creating MQTT message data, such as commands and payloads.
/// </summary>
public static class MqttMessageDataGenerator {
  /// <summary>
  /// Create MQTT message data based on the supplied bot command. 
  /// </summary>
  /// <param name="deviceInfo">The device that is being addressed.</param>
  /// <param name="command">The entered command.</param>
  /// <returns><c>MqttMessageData</c></returns>
  public static MqttMessageData GenerateCommandBasedMqttMessageData(this DeviceInfo deviceInfo, string command) {
    return new MqttMessageData(
      TasmotaCommands.PowerState,
      // provide "TOGGLE" payload if the power needs to be toggled, or no payload if only the state is requested
      command == deviceInfo.TelegramCommands.TogglePower ?
      TasmotaPayloads.PowerToggle
      :
      string.Empty
    );
  }
}