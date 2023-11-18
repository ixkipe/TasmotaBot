namespace MiscellaneousGibs.TasmotaBot.Constants;

/// <summary>
/// Contains command templates for manipulating devices over MQTT.
/// </summary>
public class TasmotaCommands {
  /// <summary>
  /// Toggle power of a device flashed with Tasmota.
  /// <br/>
  /// <c>0</c>: The topic of the device.
  /// </summary>
  public const string PowerState = "cmnd/{0}/POWER";
}