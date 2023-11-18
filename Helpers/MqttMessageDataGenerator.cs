using MiscellaneousGibs.TasmotaBot.Constants;
using MiscellaneousGibs.TasmotaBot.Models;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

#warning Missing docs
public static class MqttMessageDataGenerator {
  public static MqttMessageData GenerateCommandBasedMqttMessageData(this DeviceInfo deviceInfo, string command) {
    return new MqttMessageData(
      TasmotaCommands.PowerState,
      command == deviceInfo.TelegramCommands.TogglePower ?
      TasmotaPayloads.PowerTogglePayload
      :
      string.Empty
    );
  }
}