using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlmap_gui.SQLMapHelper
{
    public class Header
    {
        /// <summary>
        /// 默认是sqlmap/1.0-dev-xxxxxxx (http://sqlmap.org)，可用这个函数修改
        /// 同时也可以使用--random-agnet参数来随机的从./txt/user-agents.txt中获取。
        /// </summary>
        /// <param name="useragent"></param>
        /// <param name="israndom">true为random-agent</param>
        /// <returns></returns>
        public string GetArguUserAgent(string useragent, bool israndom = false)
        {
            return !israndom ? " --user-anget " + useragent + " " : " --random-agnet ";
        }

        /// <summary>
        /// sqlmap可以在请求中伪造HTTP中的referer，当--level参数设定为3或者3以上的时候会尝试对referer注入。
        /// </summary>
        /// <param name="referer"></param>
        /// <returns></returns>
        public string GetArguReferer(string referer)
        {
            return " --referer " + referer + " ";
        }

        /// <summary>
        /// 可以通过--headers参数来增加额外的http头
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public string GetArguHeaders(string header)
        {
            return " --headers " + header + " ";
        }

    }
}
