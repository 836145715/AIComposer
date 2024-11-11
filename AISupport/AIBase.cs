using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AIComposer.AISupport
{
    public abstract class AIBase
    {
        public string Name { get; }
        public string Description { get; }
        public string Url { get; }

        public string Key { get; set; }

        protected LocatorClickOptions _defaultClickOptions;
        protected LocatorFillOptions _defaultFillOptions;

        protected int _defaultTimeout;

        private AIBase()
        {

        }

        public AIBase(string name, string description, string url, int defaultTimeout = 3000)
        {
            Name = name;
            Description = description;
            Url = url;
            _defaultTimeout = defaultTimeout;

            _defaultClickOptions = new LocatorClickOptions()
            {
                Timeout = _defaultTimeout
            };
            _defaultFillOptions = new LocatorFillOptions()
            {
                Timeout = _defaultTimeout
            };
        }

        public abstract Task<dynamic> AskAsync(string content, IPage page);

    }
}
