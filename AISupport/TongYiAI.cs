using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AIComposer.AISupport
{
    public class TongYiAI : AIBase
    {
        public TongYiAI() : base("通义千问", "通义千问", "https://tongyi.aliyun.com/qianwen")
        {
            Key = "tongyi";
        }

        public override async Task<dynamic> AskAsync(string content, IPage page)
        {
            try
            {
                await page.GetByPlaceholder("“/”唤起指令中心，Shift+Enter").ClickAsync(_defaultClickOptions);
                await page.GetByPlaceholder("“/”唤起指令中心，Shift+Enter").FillAsync(content, _defaultFillOptions);
                await page.Locator("[class*=operateBtn]").ClickAsync(_defaultClickOptions);
                return new { code = 1, message = "提问成功" };
            }
            catch
            {
                return new { code = 0, message = "提问失败" };
            }
        }
    }
}
