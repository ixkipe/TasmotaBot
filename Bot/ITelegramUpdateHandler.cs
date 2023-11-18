using Telegram.Bot;
using Telegram.Bot.Types;

namespace MiscellaneousGibs.TasmotaBot;

/// <summary>
/// An abstract type for an entity that contains asynchronous operations accepted by <c>bot.StartReceiving()</c> method.
/// <br/>
/// Gets registered as a singleton during app startup.
/// </summary>
public interface ITelegramUpdateHandler {
  /// <summary>
  /// Handle an update in a Telegram chat, such as a message.
  /// </summary>
  /// <param name="bot">Telegram bot who was witness to the update.</param>
  /// <param name="update">The update, such as a message or a member chat join event.</param>
  /// <returns></returns>
  Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken);

  /// <summary>
  /// Handle an exception caused by the chat update.
  /// </summary>
  /// <param name="bot">Telegram bot who was witness to the update.</param>
  /// <param name="exception">An exception caused by the message.</param>
  /// <returns></returns>
  Task HandlePollingErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken);
}