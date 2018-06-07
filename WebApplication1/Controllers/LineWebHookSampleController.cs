using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "CVfzZeskAfcQeyevyc7k4bBONPU3oCtT0oydYm9MrDXKYK2oHC0KtjGF1wAjogrhrKM42B3Fu7DWHFNzEC9rDliPH09/3uAkIDXarQpSMACeX8fupBUpZXamhLdWsO+/PaQFpBoWHSYhRYXK6DmNUAdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "U26dd87213fa1f3d11d0a0a4d57a54cb5";

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                //var UrseName= this.PushMessage(LineEvent.source.userId,"XXX"); //找個人的userID 私訊
                //去抓資料庫
                //this.GetUserInfo();
                isRock.LineBot.Bot bot = new isRock.LineBot.Bot(channelAccessToken);
                string LineId = ReceivedMessage.events.FirstOrDefault().source.userId;
                var userInfo = bot.GetUserInfo(LineId);
                if (LineEvent.type == "message")
                {
                    //this.ReplyMessage(LineEvent.replyToken,"我可以回答任何問題~" + LineEvent.message.text+ userInfo);
                    if (LineEvent.message.type == "text")//收到文字 
                    {
                        if (LineEvent.message.text.Contains("hello"))//== "hello") //
                            this.ReplyMessage(LineEvent.replyToken, userInfo.displayName + "今天天氣不錯");

                        if (LineEvent.message.text.Contains("雨"))
                            this.ReplyMessage(LineEvent.replyToken, userInfo.displayName + "記得拿傘");
                        else
                        {
                            this.ReplyMessage(LineEvent.replyToken, "?");
                        }
                    }
                    else
                    {
                        this.ReplyMessage(LineEvent.replyToken, "怎麼了?");
                    }
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);


                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
