using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bouyei.BeidouLSP;
using Bouyei.BeidouLSP.Structures;
using Bouyei.BeidouLSP.JT808;
using Bouyei.BeidouLSP.JT808.Request;
using Bouyei.BeidouLSP.JT808.Reponse;

namespace Bouyei.BeidouLSPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PacketConvert pConvert = new PacketConvert();
            string phone = "18212004771";

            //终端连接鉴权平台回复通用应答
            byte[] body = new REQ_PB_8001().Serialized(new PB8001()
            {
                MessageId = JT808Cmd.RSP_0102,
                Serialnumber = 0,
                Result = 0
            });

            byte[] buffer = pConvert.Serialized(new PacketFrom()
            {
                msgBody = body,
                msgId = JT808Cmd.REQ_8001,
                msgSerialnumber = 0,
                pEncryptFlag = 0,
                pSerialnumber = 1,
                pSubFlag = 0,
                pTotal = 1,
                simNumber = phone.ToBCD(),
            });

            //解析终端发回的数据包
            PacketMessage msg = pConvert.Deserialized(buffer);
            //解析消息体内容
            if (msg.pmPacketHead.phMessageId == JT808Cmd.RSP_0102)
            {
                PB0102 bodyInfo = new REP_PB_0102().Deserialized(msg.pmMessageBody);
            }
            else if (msg.pmPacketHead.phMessageId == JT808Cmd.RSP_0100)
            {
                PB0100 bodyinfo = new REP_PB_0100().Deserialized(msg.pmMessageBody);
            }
        }
    }
}
