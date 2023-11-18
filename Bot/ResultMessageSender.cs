using MiscellaneousGibs.TasmotaBot.Helpers;
using MiscellaneousGibs.TasmotaBot.Models;
using Serilog;
using Telegram.Bot;

namespace MiscellaneousGibs.TasmotaBot;

/// <summary>
/// Contains methods responsible for sending messages which contain command results to Telegram chats.
/// </summary>
public static class ResultMessageSender {
  /// <summary>
  /// Send message containing a command result to a Telegram chat.
  /// </summary>
  /// <param name="messageParams">Telegram bot in use, an <c>Update</c> which is being handled, app configuration, and the current power state of the device.</param>
  /// <returns></returns>
  public static async Task SendResultMessage(this BotMessageParamsWithArgs messageParams) {
    await messageParams.BotClient.SendTextMessageAsync(
      chatId: messageParams.Update.Message.Chat.Id,
      text: $"{messageParams.Config.GetDeviceNameByCommand(messageParams.Update.Message.Text)}: <strong>{messageParams.PowerStatus}</strong>", parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
    );
  }
}