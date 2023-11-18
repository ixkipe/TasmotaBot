namespace MiscellaneousGibs.TasmotaBot.Models;

/// <summary>
/// Telegram commands associated with a certain device.
/// </summary>
public class TelegramCommands {
  /// <summary>
  /// Toggle the power of the device.
  /// </summary>
  public string TogglePower { get; set; }

  /// <summary>
  /// Current power state of the device.
  /// </summary>
  public string Status { get; set; }
}