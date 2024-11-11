using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AIComposer.AISupport
{
    public class ChatGLM : AIBase
    {
        public ChatGLM() : base("智谱清言", "智谱清言", "https://chatglm.cn//")
        {
            Key = "chatglm";
        }

        public override async Task<dynamic> AskAsync(string content, IPage page)
        {
            //await page.PauseAsync();
            try
            {
                await page.GetByPlaceholder("输入@，召唤智能体").ClickAsync(_defaultClickOptions);
                await page.GetByPlaceholder("输入@，召唤智能体").FillAsync(content, _defaultFillOptions);
                await page.Locator("#search-input-box").GetByRole(AriaRole.Img).ClickAsync(_defaultClickOptions);
                return new { code = 1, message = "提问成功" };
            }
            catch
            {
                return new { code = 0, message = "提问失败" };
            }
        }
    }
}
