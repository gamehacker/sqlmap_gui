using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlmap_gui.SQLMapHelper
{
    public class Response
    {
        /// <summary>
        /// 参数：--string,--not-string,--regexp,--code
        ///默认情况下sqlmap通过判断返回页面的不同来判断真假，但有时候这会产生误差，因为有的页面在每次刷新的时候都会返回不同的代码，
        ///比如页面当中包含一个动态的广告或者其他内容，这会导致sqlmap的误判。
        ///此时用户可以提供一个字符串或者一段正则匹配，在原始页面与真条件下的页面都存在的字符串，而错误页面中不存在（使用--string参数添加字符串，--regexp添加正则），
        ///同时用户可以提供一段字符串在原始页面与真条件下的页面都不存在的字符串，而错误页面中存在的字符串（--not-string添加）。
        ///用户也可以提供真与假条件返回的HTTP状态码不一样来注入，
        ///例如，响应200的时候为真，响应401的时候为假，可以添加参数--code=200。
        /// </summary>
        /// <param name="argu">自带引号</param>
        /// <param name="type">1/2/3/4代表--string,--not-string,--regexp,--code</param>
        /// <returns></returns>
        public string GetArguResposeCompare(string argu, int type)
        {
            switch (type)
            {
                case 1: return " --string \"" + argu + "\" ";
                case 2: return " --not-string \"" + argu + "\" ";
                case 3: return " --regexp \"" + argu + "\" ";
                case 4: return " --code \"" + argu + "\" ";
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// 参数：-b,--banner
        ///大多的数据库系统都有一个函数可以返回数据库的版本号，通常这个函数是version()或者变量@@version这主要取决与是什么数据库。
        /// </summary>
        /// <returns></returns>
        public string GetArguBanner()
        {
            return " -b ";
        }

        /// <summary>
        /// 参数：-current-user
        ///在大多数据库中可以获取到管理数据的用户。
        /// </summary>
        /// <returns></returns>
        public string GetArguCurrentUser()
        {
            return " -current-user ";
        }


        /// <summary>
        /// 参数：--current-db
        ///返还当前连接的数据库。
        /// </summary>
        /// <returns></returns>
        public string GetArguCurrentDB()
        {
            return " --current-db ";
        }

        /// <summary>
        /// 参数：--is-dba
        ///判断当前的用户是否为管理，是的话会返回True。
        /// </summary>
        /// <returns></returns>
        public string GetArguIsDBA()
        {
            return " --is-dba ";
        }

        /// <summary>
        /// 参数：--users
        ///当前用户有权限读取包含所有用户的表的权限时，就可以列出所有管理用户。
        /// </summary>
        public string GetArguUsers()
        {
            return " --users ";
        }

        /// <summary>
        /// 参数：--passwords
        ///当前用户有权限读取包含用户密码的表的权限时，sqlmap会现列举出用户，然后列出hash，并尝试破解。
        /// </summary>
        /// <returns></returns>
        public string GetArguPasswords()
        {
            return " --passwords ";
        }
    }
}
