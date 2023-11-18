using MiscellaneousGibs.TasmotaBot.Models;
using MQTTnet;
using Serilog;
using Telegram.Bot;

namespace MiscellaneousGibs.TasmotaBot;

#warning Missing docs
public class Worker : BackgroundService
{
	private readonly IConfiguration _config;
	private readonly ITelegramBotClient _bot;
	private readonly MqttFactory _mqttFactory;

	public Worker(IConfiguration config, ITelegramBotClient bot, MqttFactory mqttFactory)
	{
		_config = config;
		_bot = bot;
		_mqttFactory = mqttFactory;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			Log.Information("Worker running at: {time}", DateTimeOffset.Now);
			await Task.Delay(1000, stoppingToken);
		}
	}
}
