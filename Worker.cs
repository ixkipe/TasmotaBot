using MiscellaneousGibs.TasmotaBot.Models;
using MQTTnet;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace MiscellaneousGibs.TasmotaBot;

#warning Missing docs
public class Worker : BackgroundService
{
	private readonly IConfiguration _config;
	private readonly ITelegramBotClient _bot;
	private readonly MqttFactory _mqttFactory;
	private readonly ITelegramUpdateHandler _updateHandler;

	public Worker(IConfiguration config, ITelegramBotClient bot, MqttFactory mqttFactory, ITelegramUpdateHandler updateHandler)
	{
		_config = config;
		_bot = bot;
		_mqttFactory = mqttFactory;
		_updateHandler = updateHandler;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		_bot.StartReceiving(
			updateHandler: _updateHandler.HandleUpdateAsync,
			pollingErrorHandler: _updateHandler.HandlePollingErrorAsync,
			receiverOptions: new Telegram.Bot.Polling.ReceiverOptions() {
				AllowedUpdates = new[] { UpdateType.Message }
			},
      cancellationToken: stoppingToken
		);
	}
}
