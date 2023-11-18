using MiscellaneousGibs.TasmotaBot.Broker;
using MiscellaneousGibs.TasmotaBot.Helpers;
using MiscellaneousGibs.TasmotaBot.Logging;
using MQTTnet;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MiscellaneousGibs.TasmotaBot;

#warning Missing docs
public class TelegramUpdateHandler : ITelegramUpdateHandler
{
  private readonly IConfiguration _config;
  private readonly MqttFactory _mqttFactory;

  public TelegramUpdateHandler(IConfiguration config, MqttFactory mqttFactory)
  {
    _config = config;
    _mqttFactory = mqttFactory;
  }

  public async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
  {
    if (update.Type is not Telegram.Bot.Types.Enums.UpdateType.Message) return;
    if (string.IsNullOrEmpty(update.Message.Text)) return;

    bool idIsAllowed = _config.IsTelegramIdAllowed(update.Message.From.Id);

    if (idIsAllowed) {
      await _mqttFactory.CreateAndManageMqttClient(new Models.BotMessageParams(bot, update, _config));
    }
    else if (!idIsAllowed && update.Message.Text[0] == '/') {
      Log.Warning(
        LogEntryTemplate.UnauthorizedCommandAttempt,
        update.Message.From.FirstName,
        update.Message.From.Id,
        update.Message.Text
      );
    }
  }

  public Task HandlePollingErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
  {
    Log.Error(exception.ToString());
    return Task.CompletedTask;
  }
}