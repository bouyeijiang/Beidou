/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/21 12:58:56
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *    Ltd: 
 *   guid: 35eb8f54-898e-4ff7-a440-59a0bcae6695
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouyei.BeidouLSP
{
    public static class Extension
    {
        public static void CopyTo(this byte[] src, int srcIndex, byte[] dst, int dstIndex, int count)
        {
            unsafe
            {
                fixed (byte* _src = src, _dst = dst)
                {
                    MemoryCopy(_src + srcIndex, _dst + dstIndex, count);
                }
            }
        }

        public static byte[] Copy(this byte[] src, int srcIndex, int count)
        {
            byte[] dst = new byte[count];
            unsafe
            {
                fixed (byte* _src = src, _dst = dst)
                {
                    MemoryCopy(_src + srcIndex, _dst, count);
                }
            }
            return dst;
        }

        public static int CompareTo(this byte[] src, byte[] dst)
        {
            int count = src.Length - dst.Length;
            if (count != 0) return count;

            count = dst.Length;

            unsafe
            {
                fixed (byte* _src = src, _dst = dst)
                {
                    return BytesCompareTo(_src, _dst, count);
                }
            }
        }

        internal static unsafe int BytesCompareTo(byte* src, byte* dst, int count)
        {

            int index = 0, temp = 0;
            do
            {
                temp = (*(src + index)) - (*(dst + index));
                if (temp > 0) return temp;
                else if (temp < 0) return temp;
                ++index;
            }
            while (index < count);
            return temp;
        }

        internal static unsafe ulong BlockCompareTo(byte* src, byte* dst, int count)
        {
            ulong temp = 0;
            int c = count;
            if (c >= 16)
            {
                do
                {
                    temp = *((ulong*)src) - *((ulong*)dst);
                    if (temp != 0) return temp;

                    temp = *((ulong*)(src + 8)) - *((ulong*)(dst + 8));
                    if (temp != 0) return temp;

                    dst += 16;
                    src += 16;
                }
                while ((c -= 16) >= 16);
            }
            if (c > 0)
            {
                if ((c & 8) != 0)
                {
                    temp = *((ulong*)src) - *((ulong*)dst);
                    if (temp != 0) return temp;

                    dst += 8;
                    src += 8;
                }
                if ((c & 4) != 0)
                {
                    temp = *((uint*)src) - *((uint*)dst);
                    if (temp != 0) return temp;

                    dst += 4;
                    src += 4;
                }
                if ((c & 2) != 0)
                {
                    temp = (ulong)(*((ushort*)src) - *((ushort*)dst));
                    if (temp != 0) return temp;

                    dst += 2;
                    src += 2;
                }
                if ((c & 1) != 0)
                {
                    temp = (ulong)(src[0] - dst[0]);
                    if (temp != 0) return temp;

                    //dst++;
                    //src++;
                }
            }
            return temp;
        }

        internal static unsafe void MemoryCopy(byte* src, byte* dest, int count)
        {
            if (count >= 16)
            {
                do
                {
                    *((ulong*)dest) = *((ulong*)src);
                    *((ulong*)(dest + 8)) = *((ulong*)(src + 8));
                    dest += 16;
                    src += 16;
                }
                while ((count -= 16) >= 16);
            }
            if (count > 0)
            {
                if ((count & 8) != 0)
                {
                    *((ulong*)dest) = *((ulong*)src);
                    dest += 8;
                    src += 8;
                }
                if ((count & 4) != 0)
                {
                    *((uint*)dest) = *((uint*)src);
                    dest += 4;
                    src += 4;
                }
                if ((count & 2) != 0)
                {
                    *((ushort*)dest) = *((ushort*)src);
                    dest += 2;
                    src += 2;
                }
                if ((count & 1) != 0)
                {
                    dest[0] = src[0];
                    //dest++;
                    //src++;
                }
            }

        }
    }
}
