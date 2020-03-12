using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelegramMonitor.Api.Models;

namespace TelegramMonitor.Api.Services
{
    public class TelegramServices
    {
        public BotConfig _botConfig { get; set; }

        public TelegramServices(IOptions<BotConfig> botConfig)
        {
            _botConfig = botConfig.Value;
        }

        /// <summary>
        /// 調用層，傳入訊息後依照 appsettings 中的 機器人來發送訊息
        /// </summary>
        /// /// <param name="id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Send(string id, string message)
        {            
            var token = _botConfig.Token;            

            await Send(token, id, message);
        }

        /// <summary>
        /// 執行層，依照傳入參數發送訊息
        /// </summary>
        /// /// <param name="token"></param>
        /// <param name="id"></param>
        /// /// <param name="message"></param>
        /// <returns></returns>
        public async Task Send(string token, string id, string message)
        {            
            var Bot = new Telegram.Bot.TelegramBotClient(token);

            await Bot.SendTextMessageAsync(
                        chatId: id,
                        text: message
                    );
        }
    }
}
