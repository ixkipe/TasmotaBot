using MiscellaneousGibs.TasmotaBot.Models;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

#warning Missing docs
public static class DeviceFetcher {
  public static string? GetDeviceNameByCommand(this IConfiguration config, string command) {
    foreach (var device in config.GetRequiredSection("MqttInfo:Devices").Get<DeviceInfo[]>()) {
      if (command == device.TelegramCommands.Status || command == device.TelegramCommands.TogglePower) {
        return device.DeviceName;
      }
    }

    return null;
  }

  public static DeviceInfo? GetDeviceByCommand(this IConfiguration config, string command) {
    foreach (var device in config.GetRequiredSection("MqttInfo:Devices").Get<DeviceInfo[]>()) {
      if (command == device.TelegramCommands.Status || command == device.TelegramCommands.TogglePower) {
        return device;
      }
    }
    
    return null;
  }
}