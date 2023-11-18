using MiscellaneousGibs.TasmotaBot.Helpers;
using MiscellaneousGibs.TasmotaBot.Logging;
using MiscellaneousGibs.TasmotaBot.Models;
using MQTTnet;
using Serilog;

namespace MiscellaneousGibs.TasmotaBot.Broker;

#warning Missing docs
public static class MqttFactoryManager {
  public static async Task CreateAndManageMqttClient(this MqttFactory mqttFactory, BotMessageParams messageParams) {
    // generate MQTT client
    // convert Telegram message to respective device command
    // send MQTT message
    // get response from device
    // send response to Telegram chat
    var command = messageParams.Update.Message.Text;
    Log.Information(
      LogEntryTemplate.MessageReceived,
      messageParams.Update.Message.From.FirstName,
      messageParams.Update.Message.From.Id,
      command
    );
    var deviceInfo = messageParams.Config.GetDeviceByCommand(command);
    if (deviceInfo is null) return;

    var mqttClient = mqttFactory.CreateMqttClient();
    await mqttClient.ConnectAsync(messageParams.Config.GenerateMqttConnectionOptions(), CancellationToken.None);

    Task receiveTask = mqttClient.ReceiveMessageAndDisconnectAsync(messageParams, deviceInfo.Topic);
    Task publishTask = mqttClient.PublishAsync(
      deviceInfo.GenerateCommandMessage(
        deviceInfo.GenerateCommandBasedMqttMessageData(command)
      )
    );
    Task.WaitAll(publishTask, receiveTask);
  }
}