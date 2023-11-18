using Telegram.Bot;
using Telegram.Bot.Types;

namespace MiscellaneousGibs.TasmotaBot.Models;

/// <summary>
/// A parameter type which contains the instance of a Telegram bot, an <c>Update</c> which is currently being handled, and application configuration.
/// </summary>
/// <param name="BotClient">The Telegram bot.</param>
/// <param name="Update">The chat update.</param>
/// <param name="Config">App configuration.</param>
public record BotMessageParams(ITelegramBotClient BotClient, Update Update, IConfiguration Config);