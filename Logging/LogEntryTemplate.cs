namespace MiscellaneousGibs.TasmotaBot.Logging;

/// <summary>
/// Contains templates for Serilog log entries.
/// </summary>
public class LogEntryTemplate {
  /// <summary>
  /// Employed when a message is received in Telegram.
  /// <br/>
  /// <c>0</c>: First name of the Telegram user who sent the message.
  /// <br/>
  /// <c>1</c>: The ID of the user who sent the message.
  /// <br/>
  /// <c>2</c>: The body of the message.
  /// </summary>
  public const string MessageReceived = "{0} ({1}): {2}";
  
  /// <summary>
  /// Used when a user whose Telegram ID is not included in the configuration file attempts to run a command.
  /// <br/>
  /// <c>0</c>: First name of the Telegram user who sent the message.
  /// <br/>
  /// <c>1</c>: The ID of the user who sent the message.
  /// <br/>
  /// <c>2</c>: The body of the message.
  /// </summary>
  public const string UnauthorizedCommandAttempt = "Warning: Unauthorized command execution attempt from {0} ({1}). Message: {2}";
}