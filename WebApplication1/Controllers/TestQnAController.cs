using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudyHostExampleLinebot.Controllers
{
    public class TestQnAController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "~~~請改成你的Linebot的ChannelAccessToken~~~";
        const string AdminUserId = "~~~改成你的AdminUserId~~~";
        const string QnAKBId = "~~~改成你的QnA Service KB ID ~~~";
        const string QnAKey = "~~~改成你的QnA Service Key~~~";
        const string QnAdomain = "~~~改成你的QnA Service Domain~~~"; //ex.westus
        const string UnknowAnswer = "不好意思，您可以換個方式問嗎? 我不太明白您的意思...";

        [Route("api/TestQnA")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken; //
                //取得Line Event(範例，只取第一個) 
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                //"000000"特例 確定他是成功的
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();  
                //this.PushMessage(LineEvent.source.userId,"XXX"); //找個人的userID 私訊
                //回覆訊息

                if (LineEvent.type == "message")
                {
                    var repmsg = ""; //判斷收到訊息的類型
                    if (LineEvent.message.type == "text") //收到文字
                    {
                        //建立 MsQnAMaker Client
                        var helper = new isRock.MsQnAMaker.Client(
                            QnAdomain, QnAKBId, QnAKey);
                        var QnAResponse = helper.GetResponse(LineEvent.message.text.Trim());
                        var ret = (from c in QnAResponse.answers
                                   orderby c.score descending
                                   select c
                                ).Take(1);

                        var responseText = UnknowAnswer;
                        if (ret.FirstOrDefault().score > 0)
                            responseText = ret.FirstOrDefault().answer;
                        //回覆
                        this.ReplyMessage(LineEvent.replyToken, responseText);
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
