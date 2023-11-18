namespace MiscellaneousGibs.TasmotaBot.Models;

/// <summary>
/// Configuration section containing information about a device.
/// </summary>
public class DeviceInfo {
  /// <summary>
  /// The name of the device.
  /// <br/>
  /// The Telegram bot will refer to the device using this value in chat messages.
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// The unique topic of the device.
  /// </summary>
  public string Topic { get; set; }
  
  /// <summary>
  /// Telegram commands associated with this device.
  /// </summary>
  public TelegramCommands TelegramCommands { get; set; }
}