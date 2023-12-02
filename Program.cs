using MiscellaneousGibs.TasmotaBot;
using MQTTnet;
using Serilog;
using Telegram.Bot;

#warning Missing docs

IHostEnvironment environment = null;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args)
	.ConfigureAppConfiguration(builder => {
		builder.AddYamlFile("appsettings.yml", optional: false);
	})
	.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration))
	.ConfigureServices((builder, services) =>
	{
		services.AddSingleton<ITelegramBotClient, TelegramBotClient>(
			implementationFactory: s => new TelegramBotClient(s.GetRequiredService<IConfiguration>()["Telegram:BotToken"])
		);
		services.AddSingleton(implementationInstance: new MqttFactory());
		services.AddSingleton<ITelegramUpdateHandler, TelegramUpdateHandler>();
		services.AddHostedService<Worker>();
		environment = builder.HostingEnvironment;
	});

// published application is run via systemd
// while debugging/running in development mode, no systemd support is required
if (environment.IsProduction()) {
	hostBuilder = hostBuilder.UseSystemd();
}

var app = hostBuilder.Build();
app.Run();
