using MiscellaneousGibs.TasmotaBot.Helpers;
using MiscellaneousGibs.TasmotaBot.Models;
using Telegram.Bot;

namespace MiscellaneousGibs.TasmotaBot;

#warning Missing docs
public static class ResultMessageSender {
  public static async Task SendResultMessage(this BotMessageParamsWithArgs messageParams) {
    await messageParams.BotClient.SendTextMessageAsync(
      chatId: messageParams.Update.Message.Chat.Id,
      text: $"{messageParams.Config.GetDeviceNameByCommand(messageParams.Update.Message.Text)}: <strong>{messageParams.PowerStatus}</strong>", parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
    );
  }
}