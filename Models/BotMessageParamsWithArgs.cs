using Telegram.Bot;
using Telegram.Bot.Types;

namespace MiscellaneousGibs.TasmotaBot.Models;

#warning Missing docs
public record BotMessageParamsWithArgs(ITelegramBotClient BotClient, Update Update, IConfiguration Config, string PowerStatus) : BotMessageParams(BotClient, Update, Config);