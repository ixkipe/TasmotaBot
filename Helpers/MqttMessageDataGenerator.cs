using MiscellaneousGibs.TasmotaBot.Constants;
using MiscellaneousGibs.TasmotaBot.Models;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

#warning Missing docs
public static class MqttMessageDataGenerator {
  public static MqttMessageData GenerateCommandBasedMqttMessageData(this DeviceInfo deviceInfo, string command) {
    return command == deviceInfo.TelegramCommands.TogglePower ?
      new MqttMessageData(TasmotaCommands.TogglePower, TasmotaPayloads.PowerTogglePayload)
      :
      new MqttMessageData(TasmotaCommands.RequestState, string.Empty);
  }
}