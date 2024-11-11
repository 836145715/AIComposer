using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AIComposer.AISupport
{
    public class ChatGpt : AIBase
    {
        public ChatGpt() : base("ChatGPT", "ChatGPT - 由 OpenAI 开发的智能助手", "https://chatgpt.com/")
        {
            Key = "chatgpt";
        }

        public override async Task<dynamic> AskAsync(string content, IPage page)
        {
            try
            {
                //await page.PauseAsync();
                //await page.GetByRole(AriaRole.Paragraph).ClickAsync();
                await page.Locator("#prompt-textarea").ClickAsync(_defaultClickOptions);
                await page.Locator("#prompt-textarea").FillAsync(content,_defaultFillOptions);
                await page.GetByTestId("send-button").ClickAsync(_defaultClickOptions);
                return new { code = 1, message = "提问成功" };
            }
            catch
            {
                return new { code = 0, message = "提问失败" };
            }
        }
    }
}
