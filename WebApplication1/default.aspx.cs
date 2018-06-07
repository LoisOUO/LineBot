using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "CVfzZeskAfcQeyevyc7k4bBONPU3oCtT0oydYm9MrDXKYK2oHC0KtjGF1wAjogrhrKM42B3Fu7DWHFNzEC9rDliPH09/3uAkIDXarQpSMACeX8fupBUpZXamhLdWsO+/PaQFpBoWHSYhRYXK6DmNUAdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U26dd87213fa1f3d11d0a0a4d57a54cb5";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1, 2);
        }
    }
}