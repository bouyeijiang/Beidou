/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/21 19:10:15
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *   guid: c6bf08e8-9d0d-4ce9-819d-6b79522eebee
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouyei.BeidouLSP.JT808.Request
{
   public class REQ_PB_8400
    {
        /// <summary>
        /// 电话回拨数据体打包
        /// </summary>
        /// <param name="info">Value消息类型:0普通通话,1监听；StringValue:电话号码,最长20字节</param>
        /// <returns></returns>
        public byte[] Serialized(ByteString info)
        {
            byte[] ph = Encoding.GetEncoding("GBK").GetBytes(info.StringValue);
            byte[] data = new byte[(ph.Length > 20 ? 20 : ph.Length) + 1];

            data[0] = info.Value;
            ph.CopyTo(data, 1);
            return data;
        }
    }
}
