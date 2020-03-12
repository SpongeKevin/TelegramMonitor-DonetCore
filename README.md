## .NET Core 3.1 實現的 Telegram 通知機器人

由於有監控服務狀態的需求，因此使用了 .NET Core 3.1 實現了一個發訊息到 Telegram 的簡易機器人

### 功能簡介

對 API 發送訊息，即可送至指定的群組或個人

### 技術選擇

- C#
- .NET Core 3.1
- Telegram.Bot 15.4.0
- Swashbuckle.AspNetCore 5.1.0

## 使用方法
1. 創建一個 Telegram_Bot，請參考 [官方文件](https://core.telegram.org/bots#6-botfather)

2. 將機器人的 Token 寫入 TelegramMonitor.Api/appsettings.json.sample 並將其改名為 appsettings.json
    ```  
    "BotConfig": {
        "Token": "00:AA_BBCCDD_EE"
    }
    ```

3. 於 Telegram 中創立一個私人群組，可參考 [文件](https://tgtw.cc/post-how-to-create-group)

4. 將機器人加入此群組並且設為最高管理者

5. 在群組裡隨意發送一則訊息

6. 開啟你的瀏覽器並且輸入 https://api.telegram.org/botXXX:YYYY/getUpdates
    ```
    https://api.telegram.org/bot00:AA_BBCCDD_EE/getUpdates
    ```

7. 你會得到以下回傳，記下你的 群組ID，發訊息的時候會用到
    ```
    {
        "ok":true,
        "result":[
            {
                "update_id":"更新的訊息ID",
                "message":{
                    "message_id":1,
                    "from":{
                        "id":"發信者的訊息ID",
                        "is_bot":false,
                        "first_name":"發信者使用者ID",
                        "username":"發信者使用者名稱",
                        "language_code":"zh-hant"
                    },
                    "chat":{
                        "id":"群組ID",
                        "title":"群組名稱",
                        "type":"supergroup"
                    },
                    "date":1583997547,
                    "text":"123"
                }
            }
        ]
    }
    ```
    
8. 啟動 TelegramMonitor.Api 專案，將會看到 swagger 的 UI 介面，將剛取得的 群組ID 帶入 id 參數，就可發訊息

備註: 只要使用者有加 bot 好友，填入 發信者的訊息ID就可發訊息給單一個人

## License

The [MIT License](LICENSE)