using MiscellaneousGibs.TasmotaBot.Constants;
using MiscellaneousGibs.TasmotaBot.Models;
using MQTTnet;
using MQTTnet.Client;
using Serilog;

namespace MiscellaneousGibs.TasmotaBot.Helpers;

/// <summary>
/// Contains helper methods that receive messages over MQTT.
/// </summary>
public static class MqttMessageReceiver {
  /// <summary>
  /// Receive response over MQTT, send the result to the Telegram chat, disconnect and dispose of the MQTT client.
  /// </summary>
  /// <param name="mqttClient">The MQTT client associated with the current command and the requested state.</param>
  /// <param name="messageParams">Telegram bot in use, an <c>Update</c> which is being handled and app configuration.</param>
  /// <param name="deviceTopic">The topic of the device.</param>
  /// <returns></returns>
  #warning Must come up with another "MessageParams" type that will contain the device topic
  public static async Task ReceiveMessageAndDisconnectAsync(this IMqttClient mqttClient, BotMessageParams messageParams, string deviceTopic) {
    await mqttClient.SubscribeAsync(
      new[] { string.Format(TasmotaSubscriptions.StateResultTopic, deviceTopic) }.GenerateSubscribeOptions(),
      CancellationToken.None
    );
    
    mqttClient.ApplicationMessageReceivedAsync += e => {
      #warning Create mapping method
      var messageParamsWithArgs = new BotMessageParamsWithArgs(
        BotClient: messageParams.BotClient,
        Update: messageParams.Update,
        Config: messageParams.Config,
        PowerStatus: e.ApplicationMessage.ConvertPayloadToString()
      );

      // send message to the user containing the current power state
      messageParamsWithArgs.SendResultMessage().Wait();

      // once the message has been sent, disconnect and dispose of the client
      mqttClient.DisconnectAsync().Wait();
      mqttClient.Dispose();

      return Task.CompletedTask;
    };
  }
}