using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AIComposer.AISupport
{
    public class DouBaoAI : AIBase
    {
        public DouBaoAI() : base("豆包", "豆包 - 字节跳动旗下 AI 智能助手", "https://www.doubao.com/chat/")
        {
            Key = "doubao";
        }

        public override async Task<dynamic> AskAsync(string content, IPage page)
        {
            try
            {
                await page.GetByTestId("chat_input_input").ClickAsync(_defaultClickOptions);
                await page.GetByTestId("chat_input_input").FillAsync(content, _defaultFillOptions);
                await page.GetByTestId("chat_input_send_button").ClickAsync(_defaultClickOptions);
                return new { code = 1, message = "提问成功" };
            }
            catch
            {
                return new { code = 0, message = "提问失败" };
            }
        }
    }
}
