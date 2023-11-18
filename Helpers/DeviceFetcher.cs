using MiscellaneousGibs.TasmotaBot.Models;
using Serilog;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

/// <summary>
/// Contains helper methods that provide device-related information.
/// </summary>
public static class DeviceFetcher {
  /// <summary>
  /// Fetch the name of the device by a corresponding command.
  /// </summary>
  /// <param name="config">The app configuration.</param>
  /// <param name="command">The entered command.</param>
  /// <returns>The device name, or <c>NULL</c> if no device found.</returns>
  public static string? GetDeviceNameByCommand(this IConfiguration config, string command) {
    // Get a list of devices from appsettings.yml
    foreach (var device in config.GetRequiredSection("MqttInfo:Devices").Get<DeviceInfo[]>()) {
      // Check if the input matches any of the commands
      if (command == device.TelegramCommands.Status || command == device.TelegramCommands.TogglePower) {
        return device.Name;
      }
    }

    // When no device is found
    return null;
  }

  /// <summary>
  /// Get all information about a device by a corresponding command.
  /// </summary>
  /// <param name="config">The app configuration.</param>
  /// <param name="command">The entered command</param>
  /// <returns></returns>
  public static DeviceInfo? GetDeviceByCommand(this IConfiguration config, string command) {
    // Iterate all the devices listed in the config
    foreach (var device in config.GetRequiredSection("MqttInfo:Devices").Get<DeviceInfo[]>()) {
      // Check if the input matches any of the commands
      if (command == device.TelegramCommands.Status || command == device.TelegramCommands.TogglePower) {
        return device;
      }
    }
    
    // When no device is found
    return null;
  }
}