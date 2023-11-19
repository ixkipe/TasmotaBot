using MiscellaneousGibs.TasmotaBot;
using MQTTnet;
using Serilog;
using Telegram.Bot;

#warning Missing docs

IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureAppConfiguration(builder => {
		builder.AddYamlFile("appsettings.yml", optional: false);
	})
	.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration))
	.ConfigureServices(services =>
	{
		services.AddSingleton<ITelegramBotClient, TelegramBotClient>(
			implementationFactory: s => new TelegramBotClient(s.GetRequiredService<IConfiguration>()["Telegram:BotToken"])
		);
		services.AddSingleton(implementationInstance: new MqttFactory());
		services.AddSingleton<ITelegramUpdateHandler, TelegramUpdateHandler>();
		services.AddHostedService<Worker>();
	})
	.UseSystemd() // for prod only
	.Build();

host.Run();
