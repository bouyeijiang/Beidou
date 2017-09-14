北斗车载终端设备通信数据包协议打包和解析库，该库针对(JT/T808协议)进行解析和打包，使用该库需要先了解JT/T808协议和终端设备与服务端平台的通信流程；


大概流程如下：
1、终端通过tcp或udp连接服务端平台
2、终端发送鉴权数据包验证(0102指令)
3、平台应答鉴权数据包(8001指令)
4、终端开始定时发送定位数据包(0200指令)
5、连接完成正常收到定位数据包后就可以开始其他功能和业务的发包操作;

            IPackeEncodingProvider pConvert = PacketEncodingProvider.CreateProvider();
            string phone = "18212001111";

            //终端连接鉴权平台回复通用应答
            byte[] body = new REQ_PB_8001().Encode(new PB8001()
            {
                MessageId = JT808Cmd.RSP_0102,
                Serialnumber = 0,
                Result = 0
            });

            byte[] buffer = pConvert.Encode(new PacketFrom()
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
            PacketMessage msg = pConvert.Decode(buffer, 0, buffer.Length);
            //解析消息体内容
            if (msg.pmPacketHead.phMessageId == JT808Cmd.RSP_0102)
            {
                PB0102 bodyInfo = new REP_PB_0102().Decode(msg.pmMessageBody);
            }
            else if (msg.pmPacketHead.phMessageId == JT808Cmd.RSP_0100)
            {
                PB0100 bodyinfo = new REP_PB_0100().Decode(msg.pmMessageBody);
            }