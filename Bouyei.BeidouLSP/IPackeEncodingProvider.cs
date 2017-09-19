﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouyei.BeidouLSP
{
    using Structures;

    public interface IPackeEncodingProvider
    {
        byte[] Encode(PacketFrom item);

        PacketMessage Decode(byte[] buffer, int offset, int count);
    }
}