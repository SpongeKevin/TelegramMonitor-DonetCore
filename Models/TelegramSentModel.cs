using System.ComponentModel.DataAnnotations;

namespace TelegramMonitor.Api.Models
{
    public class TelegramSentModel
    {
        /// <summary>
        /// 要發送的訊息
        /// </summary>
        [Required]
        public string Message { set; get; }
    }
}
