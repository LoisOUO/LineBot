using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot("CVfzZeskAfcQeyevyc7k4bBONPU3oCtT0oydYm9MrDXKYK2oHC0KtjGF1wAjogrhrKM42B3Fu7DWHFNzEC9rDliPH09/3uAkIDXarQpSMACeX8fupBUpZXamhLdWsO+/PaQFpBoWHSYhRYXK6DmNUAdB04t89/1O/w1cDnyilFU=");
           bot.PushMessage("U26dd87213fa1f3d11d0a0a4d57a54cb5","!!!!");
            bot.PushMessage("U26dd87213fa1f3d11d0a0a4d57a54cb5", 1,2);
            bot.PushMessage("U26dd87213fa1f3d11d0a0a4d57a54cb5", new Uri("https://i1.wp.com/storage.googleapis.com/petsmao-images/images/2017/10/c235445f7b255b5b.jpg?fit=600%2C450&ssl=1"));
        }
    }
}