namespace MiscellaneousGibs.TasmotaBot.Helpers;

#warning Missing docs
public static class AuthHelper {
  public static bool IsTelegramIdAllowed(this IConfiguration config, long id) {
    return config.GetSection("Telegram:AllowedIds").Get<long[]>().Contains(id);
  }
}