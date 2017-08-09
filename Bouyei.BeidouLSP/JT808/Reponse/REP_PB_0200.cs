/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/22 16:31:29
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *    Ltd: 
 *   guid: c122ee15-9007-48f8-b34a-0451dd304264
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouyei.BeidouLSP.JT808.Reponse
{
    /// <summary>
    /// 0x0200消息指令解析(位置信息汇报)
    /// </summary>
    public class REP_PB_0200
    {
        public REP_PB_0200()
        {
        }
        /// <summary>
        /// 终端位置信息汇报消息体解析
        /// </summary>
        /// <param name="msgBody"></param>
        /// <returns></returns>
        public PB0200 Decode(byte[] msgBody)
        {
            PB0200 item = new PB0200();
            int indexOffset = 0, blen = 0;
            byte id, len;

            item.AlarmIndication = msgBody.ToUInt32(indexOffset);

            item.StatusIndication = msgBody.ToUInt32(indexOffset += 4);

            item.Latitude = msgBody.ToUInt32(indexOffset += 4);

            item.Longitude = msgBody.ToUInt32(indexOffset += 4);

            item.Altitude = msgBody.ToUInt16(indexOffset += 4);

            item.Speed = msgBody.ToUInt16(indexOffset += 2);

            item.Direction = msgBody.ToUInt16(indexOffset += 2);

            item.LocationTime = msgBody.Copy(indexOffset += 2, 6);

            indexOffset += 6;

            //解析附加信息体
            blen = (msgBody.Length - 1);
            if (blen > indexOffset)
            {
                item.AttachItems = new List<ByteBytes>((blen >> 1));

                while (blen > indexOffset)
                {
                    //附加信息ID
                    id = msgBody[indexOffset];
                    //附加信息长度
                    len = msgBody[indexOffset += 1];
                    if (len == 0) continue;

                    item.AttachItems.Add(new ByteBytes()
                    {
                        Value = id,
                        BytesValue = msgBody.Copy(indexOffset += 1, len)
                    });

                    indexOffset += len;
                }
            }
            return item;
        }
    }
}
