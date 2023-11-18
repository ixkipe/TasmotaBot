namespace MiscellaneousGibs.TasmotaBot.Helpers;

/// <summary>
/// Contains authorization-related helper methods.
/// </summary>
public static class AuthHelper {
  /// <summary>
  /// Determine whether the specified Telegram ID is present in the application configuration file.
  /// </summary>
  /// <param name="config">The app configuration.</param>
  /// <param name="id">The Telegram ID in question.</param>
  /// <returns></returns>
  public static bool IsTelegramIdAllowed(this IConfiguration config, long id) {
    return config.GetSection("Telegram:AllowedIds").Get<long[]>().Contains(id);
  }
}