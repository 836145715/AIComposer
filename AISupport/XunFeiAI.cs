using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AIComposer.AISupport
{
    public class XunFeiAI : AIBase
    {
        public XunFeiAI() : base("讯飞星火AI", "讯飞星火AI", "https://xinghuo.xfyun.cn/desk")
        {
            Key = "xinghuo";
        }

        public override async Task<dynamic> AskAsync(string content, IPage page)
        {
            try
            {
                //await page.PauseAsync();
                return new { code = -1, message = "暂不支持" };
            }
            catch
            {
                return new { code = 0, message = "提问失败" };
            }
        }
    }
}
