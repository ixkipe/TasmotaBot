namespace MiscellaneousGibs.TasmotaBot.Models;

/// <summary>
/// A parameter type containing an MQTT command template and a payload.
/// </summary>
/// <param name="CommandTemplate">MQTT command template.</param>
public record MqttMessageData(string CommandTemplate, string Payload);