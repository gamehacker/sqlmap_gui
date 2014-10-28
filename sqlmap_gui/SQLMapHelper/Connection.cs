using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlmap_gui.SQLMapHelper
{
    public class Connection
    {
        /// <summary>
        ///--proxy,--proxy-cred和--ignore-proxy
        ///type=1:使用--proxy代理是格式为：http://url:port。
        ///type=2:当HTTP(S)代理需要认证是可以使用--proxy-cred参数：username:password。
        ///type=3:--ignore-proxy拒绝使用本地局域网的HTTP(S)代理。
        /// </summary>
        /// <param name="argu"></param>
        /// <param name="proxytype"></param>
        /// <returns></returns>
        public string GetArguProxy(string argu, int proxytype)
        {
            if (proxytype == 1)
            {
                return " --proxy " + argu + " ";
            }
            else if (proxytype == 2)
            {
                return " --proxy-cred " + argu + " ";
            }
            else if (proxytype == 3)
            {
                return " --ignore-proxy ";
            }
            else
            {
                throw new ArgumentException("无效的类型");
            }
        }

        /// <summary>
        /// 可以设定两个HTTP(S)请求间的延迟，设定为0.5的时候是半秒，默认是没有延迟的。
        /// 单位秒
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public string GetArguDelay(int second)
        {
            return " --delay " + second.ToString() + " ";
        }

        /// <summary>
        /// 可以设定一个HTTP(S)请求超过多久判定为超时，10.5表示10.5秒，默认是30秒。
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public string GetArguTimeOut(int second)
        {
            return " --timeout " + second.ToString() + " ";
        }

        /// <summary>
        /// 重试次数，默认3次
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public string GetArguRetry(int times)
        {
            return " --retries " + times.ToString() + " ";
        }

        /// <summary>
        /// 有的web应用程序会在你多次访问错误的请求时屏蔽掉你以后的所有请求，
        /// 这样在sqlmap进行探测或者注入的时候可能造成错误请求而触发这个策略，导致以后无法进行。
        /// --safe-url,--safe-freq
        /// 绕过这个策略有两种方式：
        ///1、--safe-url：提供一个安全不错误的连接，每隔一段时间都会去访问一下。
        ///2、--safe-freq：提供一个安全不错误的连接，每次测试请求之后都会再访问一边安全连接。
        /// </summary>
        /// <param name="argu"></param>
        /// <returns></returns>
        public string GetArguSafeurl(string argu, int type)
        {
            if (type == 1)
            {
                return " --safe-url " + argu + " ";
            }
            else if (type == 2)
            {
                return " --safe-freq " + argu + " ";
            }
            else
                throw new ArgumentException("无效的类型");
        }
    }
}
