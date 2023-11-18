using Telegram.Bot;
using Telegram.Bot.Types;

namespace MiscellaneousGibs.TasmotaBot;

#warning Missing docs
public interface ITelegramUpdateHandler {
  Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken);
  Task HandlePollingErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken);
}