namespace MiscellaneousGibs.TasmotaBot.Constants;

/// <summary>
/// Contains values that can be provided as payloads to MQTT messages.
/// </summary>
public class TasmotaPayloads {
  /// <summary>
  /// Toggle the power of the device.
  /// </summary>
  public const string PowerToggle = "TOGGLE";

  /// <summary>
  /// Switch on the device.
  /// </summary>
  public const string PowerOn = "ON";

  /// <summary>
  /// Switch off the device.
  /// </summary>
  public const string PowerOff = "OFF";
}