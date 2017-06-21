/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/21 15:25:11
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *    Ltd: 
 *   guid: 3e890151-9200-4827-b13d-0e6706a7ef4a
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouyei.BeidouLSP.JT808.Request
{
    /// <summary>
    /// 0x8106消息指令 查询指定终端参数
    /// </summary>
    public class R_PB_8106
    {
        public R_PB_8106()
        {
        }

        public byte[] Serialized(PB8106 info)
        {
            byte[] buffer = new byte[((byte)info.IDList.Count << 2) + 1];
            buffer[0] = (byte)info.IDList.Count;
            byte[] temp = null;
            int index = 1;

            for (int i = 0; i < info.IDList.Count; ++i)
            {
                temp = info.IDList[i].ToBytes();
                temp.CopyTo(buffer, index);
                index += 4;
            }
            return buffer;
        }
    }
}
