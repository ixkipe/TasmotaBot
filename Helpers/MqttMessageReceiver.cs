using MiscellaneousGibs.TasmotaBot.Constants;
using MiscellaneousGibs.TasmotaBot.Models;
using MQTTnet;
using MQTTnet.Client;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

#warning Missing docs
public static class MqttMessageReceiver {
  public static async Task ReceiveMessageAndDisconnectAsync(this IMqttClient mqttClient, BotMessageParams messageParams) {
    mqttClient.ApplicationMessageReceivedAsync += async e => {
      await 
      (
        (messageParams as BotMessageParamsWithArgs)
        with { PowerStatus = e.ApplicationMessage.ConvertPayloadToString() }
      )
      .SendResultMessage();

      await mqttClient.DisconnectAsync();
    };

    await mqttClient.SubscribeAsync(
      new[] { TasmotaSubscriptions.StateResultTopic }.GenerateSubscribeOptions(),
      CancellationToken.None
    );
  }
}