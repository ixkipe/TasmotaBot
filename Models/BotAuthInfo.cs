namespace MiscellaneousGibs.TasmotaBot.Models;

/// <summary>
/// Configuration section containing information about the Telegram bot.
/// </summary>
public class BotAuthInfo {
  /// <summary>
  /// Telegram bot authentication token provided by BotFather.
  /// </summary>
  public string BotToken { get; set; }

  /// <summary>
  /// User IDs permitted to use the bot and its commands.
  /// </summary>
  public long[] AllowedIds { get; set; }
}