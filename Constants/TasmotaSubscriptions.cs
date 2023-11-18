namespace MiscellaneousGibs.TasmotaBot.Constants;

/// <summary>
/// Contains topic templates to subscribe to when fetching values or displaying messages.
/// </summary>
public class TasmotaSubscriptions {
  /// <summary>
  /// The topic to subscribe to for getting the current power state of the device.
  /// <br/>
  /// <c>0</c>: The topic of the device.
  /// </summary>
  public const string StateResultTopic = "stat/{0}/POWER";
}