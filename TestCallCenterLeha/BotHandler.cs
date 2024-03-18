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
        int offset = 0;

        //глобально опрашиваем сервер нахуй
        while (true)
        {
            //Получаем апдейты с сервера
            Update[] updates = await _bot.GetUpdatesAsync(offset);

            foreach (Update newUpdate in updates)//прогоняем все
            {
                offset = update.Id + 1;//чтобы в следующий раз мы с другим сдвигом брали обновления

                await HandleUpdate(newUpdate);
            }
        }
    }

    private static async Task HandleUpdate(Update update)
    {
        if (update.Message != null)
        {
            //получаем сообщение из апдейта
            Message message = update.Message;

            if (message.Text == null)
            {
                return;
            }

            if (message.Text == "/start")
            {
                await _bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,//берем чат с которого нам написали
                    text: "Привет всем");
            }
        }
    }

    private static async Task OnError(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        //обработка ошибок от бота
    }

}

