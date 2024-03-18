using Telegram.Bot;
using Telegram.Bot.Types;

namespace TestCallCenterLeha;

public static class BotHandler
{
    private static TelegramBotClient _bot;

    public static void Initialize(string botToken)
    {
        _bot = new TelegramBotClient(botToken);
        _bot.StartReceiving(OnUpdate, OnError);
    }
    private static async Task OnUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {
        //обрботка всех апдейтов
    }

    private static async Task OnError(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        //обработка ошибок от бота
    }

}

