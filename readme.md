���������ն��豸ͨ�����ݰ�Э�����ͽ����⣬�ÿ����(JT/T808Э��)���н����ʹ����ʹ�øÿ���Ҫ���˽�JT/T808Э����ն��豸������ƽ̨��ͨ�����̣�


����������£�
1���ն�ͨ��tcp��udp���ӷ����ƽ̨
2���ն˷��ͼ�Ȩ���ݰ���֤(0102ָ��)
3��ƽ̨Ӧ���Ȩ���ݰ�(8001ָ��)
4���ն˿�ʼ��ʱ���Ͷ�λ���ݰ�(0200ָ��)
5��������������յ���λ���ݰ���Ϳ��Կ�ʼ�������ܺ�ҵ��ķ�������;

            IPackeEncodingProvider pConvert = PacketEncodingProvider.CreateProvider();
            string phone = "18212001111";

            //�ն����Ӽ�Ȩƽ̨�ظ�ͨ��Ӧ��
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

            //�����ն˷��ص����ݰ�
            PacketMessage msg = pConvert.Decode(buffer, 0, buffer.Length);
            //������Ϣ������
            if (msg.pmPacketHead.phMessageId == JT808Cmd.RSP_0102)
            {
                PB0102 bodyInfo = new REP_PB_0102().Decode(msg.pmMessageBody);
            }
            else if (msg.pmPacketHead.phMessageId == JT808Cmd.RSP_0100)
            {
                PB0100 bodyinfo = new REP_PB_0100().Decode(msg.pmMessageBody);
            }