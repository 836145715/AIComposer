using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AIComposer.AISupport
{
    public class KimiAI : AIBase
    {
        public KimiAI() : base("Kimi", "Kimi AI", "https://kimi.moonshot.cn/")
        {
            Key = "kimi";
        }

        public override async Task<dynamic> AskAsync(string content, IPage page)
        {
            try
            {
                await page.GetByTestId("msh-chatinput-editor").ClickAsync(_defaultClickOptions);
                await page.GetByTestId("msh-chatinput-editor").FillAsync(content, _defaultFillOptions);
                await page.GetByTestId("msh-chatinput-send-button").ClickAsync(_defaultClickOptions);
                return new { code = 1, message = "提问成功" };
            }
            catch
            {
                return new { code = 0, message = "提问失败" };
            }
        }

    }
}
