using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AIComposer.AISupport
{
    public class PoeAI : AIBase
    {
        public PoeAI() : base("PoeAI", "PoeAI", "https://poe.com/")
        {
            Key = "poe.com";
        }

        public override async Task<dynamic> AskAsync(string content, IPage page)
        {
            //await page.PauseAsync();
            try
            {
                await page.Locator("[class*=GrowingTextArea_textArea]").ClickAsync(_defaultClickOptions);
                await page.Locator("[class*=GrowingTextArea_textArea]").FillAsync(content, _defaultFillOptions);
                await page.Locator("[class*=ChatMessageInputContainer_sendButton]").ClickAsync(_defaultClickOptions);
                return new { code = 1, message = "提问成功" };
            }
            catch
            {
                return new { code = 0, message = "提问失败" };
            }
        }
    }
}
