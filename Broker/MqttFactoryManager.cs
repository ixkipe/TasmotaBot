using MiscellaneousGibs.TasmotaBot.Helpers;
using MiscellaneousGibs.TasmotaBot.Logging;
using MiscellaneousGibs.TasmotaBot.Models;
using MQTTnet;
using Serilog;

namespace MiscellaneousGibs.TasmotaBot.Broker;

/// <summary>
/// Contains methods responsible for creating and managing MQTT clients.
/// </summary>
public static class MqttFactoryManager {
  /// <summary>
  /// Creates an MQTT client, handles the received command, outputs the result to the chat and disposes of the client.
  /// </summary>
  /// <param name="mqttFactory">A factory responsible for creating clients and other MQTT entities.</param>
  /// <param name="messageParams">Telegram bot in use, an <c>Update</c> which is being handled and app configuration.</param>
  public static async Task CreateAndManageMqttClient(this MqttFactory mqttFactory, BotMessageParams messageParams) {
    var command = messageParams.Update.Message.Text;

    // Log the command sent by the user.
    Log.Information(
      LogEntryTemplate.MessageReceived,
      messageParams.Update.Message.From.FirstName,
      messageParams.Update.Message.From.Id,
      command
    );

    // Find the device by the corresponding command; if no device found, ignore the message.
    var deviceInfo = messageParams.Config.GetDeviceByCommand(command);
    if (deviceInfo is null) return;

    // Create MQTT client, connect to the Mosquitto server specified in the config file.
    var mqttClient = mqttFactory.CreateMqttClient();
    await mqttClient.ConnectAsync(messageParams.Config.GenerateMqttConnectionOptions(), CancellationToken.None);

    // Subscribe to the power state topic before executing the command.
    Task receiveTask = mqttClient.ReceiveMessageAndDisconnectAsync(messageParams, deviceInfo.Topic);
    Task publishTask = mqttClient.PublishAsync(
      deviceInfo.GenerateCommandMessage(
        deviceInfo.GenerateCommandBasedMqttMessageData(command)
      )
    );
    // Then wait for both operations to finish.
    Task.WaitAll(publishTask, receiveTask);
  }
}