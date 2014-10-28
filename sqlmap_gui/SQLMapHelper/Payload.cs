using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlmap_gui.SQLMapHelper
{
    public class Payload
    {
        /// <summary>
        /// 当你想指定一个报错的数值时，可以使用这个参数，
        /// 例如默认情况系id=13，sqlmap会变成id=-13来报错，你可以指定比如id=9999999来报错。
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public string GetArguInvalidBigNum(Int64 payload)
        {
            return "  --invalid-bignum " + payload.ToString() + " ";
        }

        /// <summary>
        /// 当你想指定一个报错的数值时，可以使用这个参数，
        /// 例如默认情况系id=13，sqlmap会变成id=-13来报错
        /// 改成指定id=13把原来的id=-13的报错改成id=13 AND 18=19。
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public string GetArguInvalidLogical(string payload)
        {
            return " --invalid-logical " + payload + " ";
        }

        /// <summary>
        /// 在有些环境中，需要在注入的payload的前面或者后面加一些字符，来保证payload的正常执行。
        ///例如，代码中是这样调用数据库的：
        ///$query = "SELECT * FROM users WHERE id=(’" . $_GET[’id’] . "’) LIMIT 0, 1"; 
        ///这时你就需要--prefix和--suffix参数了：
        ///python sqlmap.py -u "http://192.168.136.131/sqlmap/mysql/get_str_brackets.php?id=1" -p id --prefix "’)" --suffix "AND (’abc’=’abc"
        ///这样执行的SQL语句变成：
        ///$query = "SELECT * FROM users WHERE id=(’1’) <PAYLOAD> AND (’abc’=’abc’) LIMIT 0, 1"; 
        /// </summary>
        /// <param name="pre">不用带引号</param>
        /// <param name="after">不用带引号</param>
        /// <returns></returns>
        public string GetArguFix(string pre, string after)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(pre))
            {
                result = " --prefix " + "\"" + pre + "\" ";
            }
            if (!string.IsNullOrEmpty(after))
            {
                result += " --suffix " + "\"" + after + "\" ";
            }
            return result;
        }

        /// <summary>
        /// sqlmap除了使用CHAR()函数来防止出现单引号之外没有对注入的数据修改，你可以使用--tamper参数对数据做修改来绕过WAF等设备。
        /// 可以查看 tamper/ 目录下的有哪些可用的脚本
        /// </summary>
        /// <param name="tamperfile">多个用,隔开</param>
        /// <returns></returns>
        public string GetArguTamper(string tamperfile)
        {
            return " --tamper " + tamperfile + " ";
        }


        /// <summary>
        /// 共有五个等级，默认为1，sqlmap使用的payload可以在xml/payloads.xml中看到，你也可以根据相应的格式添加自己的payload。
        ///这个参数不仅影响使用哪些payload同时也会影响测试的注入点，GET和POST的数据都会测试，
        ///HTTP Cookie在level为2的时候就会测试，HTTP User-Agent/Referer头在level为3的时候就会测试。
        ///总之在你不确定哪个payload或者参数为注入点的时候，为了保证全面性，建议使用高的level值。
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string GetArguLevel(int level)
        {
            if (level > 5 || level < 0)
            {
                throw new ArgumentException();
            }
            return " --level " + level.ToString() + " ";
        }

        /// <summary>
        /// 参数：--risk
        ///共有四个风险等级，默认是1会测试大部分的测试语句，2会增加基于事件的测试语句，3会增加OR语句的SQL注入测试。
        ///在有些时候，例如在UPDATE的语句中，注入一个OR的测试语句，可能导致更新的整个表，可能造成很大的风险。
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string GetArguRisk(int level)
        {
            if (level > 3 || level < 0)
            {
                throw new ArgumentException();
            }
            return " --risk " + level.ToString() + " ";
        }

        /// <summary>
        /// 当使用继续时间的盲注时，时刻使用--time-sec参数设定延时时间，默认是5秒。
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public string GetArguTimeSec(int second)
        {
            return " --time-sec  " + second.ToString() + " ";
        }

        /// <summary>
        /// 参数：--union-cols
        ///默认情况下sqlmap测试UNION查询注入会测试1-10个字段数，当--level为5的时候他会增加测试到50个字段数。
        ///设定--union-cols的值应该是一段整数，如：12-16，是测试12-16个字段数。
        /// </summary>
        /// <param name="colsnum"></param>
        /// <returns></returns>
        public string GetArguUnionCols(string colsnum)
        {
            return " --union-cols " + colsnum + " ";
        }

        /// <summary>
        /// 参数：--union-char
        ///默认情况下sqlmap针对UNION查询的注入会使用NULL字符，但是有些情况下会造成页面返回失败，而一个随机整数是成功的，这是你可以用--union-char只定UNION查询的字符。
        /// </summary>
        /// <param name="unionchar"></param>
        /// <returns></returns>
        public string GetArguUnionChar(string unionchar)
        {
            return " --union-char \"" + unionchar + "\" ";
        }


        /// <summary>
        /// 参数：--second-order
        ///有些时候注入点输入的数据看返回结果的时候并不是当前的页面，而是另外的一个页面，
        ///这时候就需要你指定到哪个页面获取响应判断真假。--second-order后门跟一个判断页面的URL地址。
        /// </summary>
        /// <returns></returns>
        public string GetArguSecondOrder(string url)
        {
            return " --second-order \"" + url + "\" ";
        }
    }
}
