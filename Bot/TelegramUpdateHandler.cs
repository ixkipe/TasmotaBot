using MiscellaneousGibs.TasmotaBot.Broker;
using MiscellaneousGibs.TasmotaBot.Helpers;
using MiscellaneousGibs.TasmotaBot.Logging;
using MQTTnet;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MiscellaneousGibs.TasmotaBot;

/// <summary>
/// Contains operations responsible for handling Telegram updates and exceptions.
/// <br/>
/// Gets registered as a singleton and wrapped into <c>ITelegramUpdateHandler</c> during app startup.
/// </summary>
public class TelegramUpdateHandler : ITelegramUpdateHandler
{
  private readonly IConfiguration _config;
  private readonly MqttFactory _mqttFactory;

  public TelegramUpdateHandler(IConfiguration config, MqttFactory mqttFactory)
  {
    _config = config;
    _mqttFactory = mqttFactory;
  }

  /// <summary>
  /// Handle Telegram chat update, such as a message or a chat member join event.
  /// </summary>
  /// <param name="bot">The Telegram bot that was witness to the update.</param>
  /// <param name="update">A Telegram chat update.</param>
  public Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
  {
    // Checking if the update is a plain text message. If not, ignore.
    if (update.Type is not Telegram.Bot.Types.Enums.UpdateType.Message) return Task.CompletedTask;
    if (string.IsNullOrEmpty(update.Message.Text)) return Task.CompletedTask;

    // The Telegram ID of the user who sent the message is listed among the allowed ones in appsettings.yml.
    bool idIsAllowed = _config.IsTelegramIdAllowed(update.Message.From.Id);

    // Execute command if the message starts with a slash and the access to commands is granted to the user.
    if (idIsAllowed && update.Message.Text[0] == '/') {
      return _mqttFactory.CreateAndManageMqttClient(new Models.BotMessageParams(bot, update, _config));
    }
    
    // When the message is a command, but the user is not authorized to send them
    if (update.Message.Text[0] == '/') {
      // Log the ID, the first name and the message of the user who made an attempt
      Log.Warning(
        LogEntryTemplate.UnauthorizedCommandAttempt,
        update.Message.From.FirstName,
        update.Message.From.Id,
        update.Message.Text
      );
    }

    return Task.CompletedTask;
  }

  /// <summary>
  /// Handle an exception thrown by the Telegram API.
  /// </summary>
  public Task HandlePollingErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
  {
    Log.Error(exception.ToString());
    return Task.CompletedTask;
  }
}