using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlmap_gui.SQLMapHelper
{
    public class General
    {
        /// <summary>
        /// 如果你想观察sqlmap对一个点是进行了怎样的尝试判断以及读取数据的，可以使用-v参数。
        /// 0、只显示python错误以及严重的信息。
        /// 1、同时显示基本信息和警告信息。（默认）
        /// 2、同时显示debug信息。
        /// 3、同时显示注入的payload。(推荐)
        /// 4、同时显示HTTP请求。
        /// 5、同时显示HTTP响应头。
        /// 6、同时显示HTTP响应页面。</summary>
        ///<param name="v"></param>
        /// <returns></returns>
        public string GetArguV(int v)
        {
            var i = v >= 0 && v < 7 ? v : 3;
            return " -v " + i.ToString();
        }

        /// <summary>
        /// 目标URL
        /// 在有些时候web服务器使用了URL重写，导致无法直接使用sqlmap测试参数，可以在想测试的参数后面加*
        ///例如：
        ///python sqlmap.py -u "http://targeturl/param1/value1*/param2/value2/"
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetArguU(string url)
        {
            return " -u \"" + url + "\" ";
        }

        /// <summary>
        /// 此参数是把数据以POST方式提交，sqlmap会像检测GET参数一样检测POST的参数。
        /// </summary>
        /// <param name="postdata">自带引号</param>
        /// <returns></returns>
        public string GetArguData(string postdata)
        {
            return " --data=\"" + postdata + "\" ";
        }

        /// <summary>
        /// 当GET或POST的数据需要用其他字符分割测试参数的时候需要用到此参数。
        /// 需要配合--data参数
        /// --data="query=foobar;id=1" --param-del=";"
        /// </summary>
        /// <param name="spliter">自带引号</param>
        /// <returns></returns>
        public string GetArguDataSpliter(string spliter)
        {
            return " --param-del=\"" + spliter + "\" ";
        }

        /// <summary>
        /// 可以通过抓包把cookie获取到，复制出来，然后加到--cookie参数里。
        /// </summary>
        /// <param name="cookie">自带引号</param>
        /// <returns></returns>
        public string GetArguCookie(string cookie)
        {
            return " --cookie \"" + cookie + "\" ";
        }

        /// <summary>
        /// 根据参数位置，他的值默认将会被URL编码，但是有些时候后端的web服务器不遵守RFC标准，
        /// 只接受不经过URL编码的值，这时候就需要用--skip-urlencode参数。
        /// </summary>
        /// <returns></returns>
        public string GetArguSkipUrlEncode()
        {
            return " --skip-urlencode ";
        }

        /// <summary>
        /// 在有些时候，需要根据某个参数的变化，而修改另个一参数，
        /// 才能形成正常的请求，这时可以用--eval参数在每次请求时根据所写python代码做完修改后请求。
        /// </summary>
        /// <param name="pycode">自带引号</param>
        /// <returns></returns>
        public string GetArguEval(string pycode)
        {
            return " --eval=\"" + pycode + "\" ";
        }


        /// <summary>
        /// sqlmap默认测试所有的GET和POST参数，当--level的值大于等于2的时候也会测试HTTP Cookie头的值，
        /// 当大于等于3的时候也会测试User-Agent和HTTP Referer头的值。但是你可以手动用-p参数设置想要测试的参数。
        /// 例如： -p "id,user-anget"
        /// </summary>
        /// <param name="argu">自带引号,逗号隔开</param>
        /// <returns></returns>
        public string GetArguSkip(string argu)
        {
            return " -p \"" + argu + "\" ";
        }

        /// <summary>
        /// 当你使用--level的值很大但是有个别参数不想测试的时候可以使用--skip参数。
        ///例如：--skip="user-angent.referer"
        /// </summary>
        /// <param name="argu">自带引号</param>
        /// <returns></returns>
        public string GetArguP(string argu)
        {
            return " --skip=\"" + argu + "\" ";
        }

        /// <summary>
        /// 默认情况系sqlmap会自动的探测web应用后端的数据库是什么，sqlmap支持的数据库有：
        /// MySQL、Oracle、PostgreSQL、Microsoft SQL Server、Microsoft Access、SQLite、Firebird、Sybase、SAP MaxDB、DB2
        /// </summary>
        /// <param name="dbms">自带引号</param>
        /// <returns></returns>
        public string GetArguDBMS(string dbms)
        {
            return " --dbms \"" + dbms + "\" ";
        }

        /// <summary>
        /// 默认情况下sqlmap会自动的探测数据库服务器系统，支持的系统有：Linux、Windows。
        /// </summary>
        /// <param name="os"></param>
        /// <returns></returns>
        public string GetArguOS(string os)
        {
            return " --os \"" + os + "\" ";
        }
    }
}
