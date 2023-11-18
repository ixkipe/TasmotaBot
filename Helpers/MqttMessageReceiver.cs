using MiscellaneousGibs.TasmotaBot.Constants;
using MiscellaneousGibs.TasmotaBot.Models;
using MQTTnet;
using MQTTnet.Client;
using Serilog;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

#warning Missing docs
public static class MqttMessageReceiver {
  public static async Task ReceiveMessageAndDisconnectAsync(this IMqttClient mqttClient, BotMessageParams messageParams, string deviceTopic) {
    await mqttClient.SubscribeAsync(
      new[] { string.Format(TasmotaSubscriptions.StateResultTopic, deviceTopic) }.GenerateSubscribeOptions(),
      CancellationToken.None
    );
    
    mqttClient.ApplicationMessageReceivedAsync += e => {
      // create mapping method
      var messageParamsWithArgs = new BotMessageParamsWithArgs(
        BotClient: messageParams.BotClient,
        Update: messageParams.Update,
        Config: messageParams.Config,
        PowerStatus: e.ApplicationMessage.ConvertPayloadToString()
      );

      messageParamsWithArgs.SendResultMessage().Wait();

      mqttClient.DisconnectAsync().Wait();

      return Task.CompletedTask;
    };
  }
}