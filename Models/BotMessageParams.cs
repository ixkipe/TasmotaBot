using Telegram.Bot;
using Telegram.Bot.Types;

namespace MiscellaneousGibs.TasmotaBot.Models;

#warning Missing docs
public record BotMessageParams(ITelegramBotClient BotClient, Update Update, IConfiguration Config);