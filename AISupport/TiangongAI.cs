using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AIComposer.AISupport
{
    public class TiangongAI : AIBase
    {
        public TiangongAI() : base("天工AI", "天工AI", "https://www.tiangong.cn/")
        {
            Key = "tiangong";
        }

        public override async Task<dynamic> AskAsync(string content, IPage page)
        {
            //await page.PauseAsync();
            try
            {
                await page.Locator("[class*=el-textarea__inner]").ClickAsync(_defaultClickOptions);
                await page.Locator("[class*=el-textarea__inner]").FillAsync(content, _defaultFillOptions);
                await page.Locator("[class*=airplane-icon] svg,[class*=i-search-text]").ClickAsync(_defaultClickOptions);
                return new { code = 1, message = "提问成功" };
            }
            catch
            {
                return new { code = 0, message = "提问失败" };
            }
        }

    }
}
