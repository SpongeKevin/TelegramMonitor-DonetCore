using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TelegramMonitor.Api.Models;
using TelegramMonitor.Api.Services;

namespace TelegramMonitor.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TelegramNotifyController : ControllerBase
    {
        private readonly TelegramServices _telegramSend;

        public TelegramNotifyController(TelegramServices telegramSend)
        {
            _telegramSend = telegramSend;            
        }

        /// <summary>
        /// 發送訊息給指定對象(群組or個人) 給 Telegram 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task SendMessage(string id,  TelegramSentModel message)
        {           
            await _telegramSend.Send(id, message.Message);
        }
    }
}
