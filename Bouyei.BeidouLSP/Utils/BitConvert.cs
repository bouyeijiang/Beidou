﻿/*-------------------------------------------------------------
 *   auth: bouyei
 *   date: 2017/6/21 15:21:14
 *contact: 453840293@qq.com
 *profile: www.openthinking.cn
 *    Ltd: 
 *   guid: 6f3bdb9e-1d34-4645-9167-6aba2e1045f3
---------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouyei.BeidouLSP
{
    public static class BitConvert
    {
        static bool isBigEndian = true;

        /// <summary>
        /// 获取或设置字节序
        /// </summary>
        public static bool IsBigEndian
        {
            get { return isBigEndian; }
            set { isBigEndian = value; }
        }

        static BitConvert()
        {

        }

        /// <summary>
        /// 检查系统运行的字节序,true为大端,否则为小端
        /// </summary>
        /// <returns></returns>
        public static bool CheckSysIsBigEndian()
        {
            UInt16 flag = 0x4321;
            if ((byte)(flag >> 8) == 0x43)
                return false;
            else return true;
        }

        public static byte[] ToBytes(this UInt16 value)
        {
            if (isBigEndian)
            {
                return new byte[]{
                     (byte)(value >> 8),
                     (byte)value
                };
            }

            return new byte[] {
                (byte)value,
                (byte)(value>>8)
            };
        }

        public static byte[] ToBytes(this UInt32 value)
        {
            if (isBigEndian)
            {
                return new byte[] {
                 (byte)(value >> 24),
                 (byte)(value >> 16),
                 (byte)(value >> 8),
                 (byte)value
                 };
            }

            return new byte[] {
                (byte)value,
                (byte)(value >> 8),
                (byte)(value >> 16),
                (byte)(value >> 24)
            };
        }

        public static byte[] ToBytes(this UInt64 value)
        {
            if (isBigEndian)
            {
                return new byte[]{
                  (byte)(value >> 56),
                  (byte)(value >> 48),
                  (byte)(value >> 40),
                  (byte)(value >> 32),
                  (byte)(value >> 24),
                  (byte)(value >> 16),
                  (byte)(value >> 8),
                  (byte)value
             };
            }

            return new byte[] {
            (byte)(byte)value,
                  (byte)(value >> 8),
                  (byte)(value >> 16),
                  (byte)(value >> 24),
                  (byte)(value >> 32),
                  (byte)(value >> 40),
                  (byte)(value >> 48),
                  (byte)(value >> 56)
            };
        }

        public static UInt16 ToUInt16(this byte[] value)
        {
            if (isBigEndian)
            {
                return (UInt16)(((UInt16)value[0] << 8)
                | ((UInt16)value[1]));
            }

            return (UInt16)(value[0]
                | ((UInt16)((UInt16)value[1] << 8)));
        }

        public static UInt16 ToUInt16(this byte[] value, int index)
        {
            if (isBigEndian)
            {
                return (UInt16)(((UInt16)value[index] << 8)
                | ((UInt16)value[index + 1]));
            }

            return (UInt16)(value[index]
                | ((UInt16)((UInt16)value[index + 1] << 8)));
        }

        public static UInt32 ToUInt32(this byte[] value)
        {
            if (isBigEndian)
            {
                return (((UInt32)value[0] << 24)
                   | ((UInt32)value[1] << 16)
                   | ((UInt32)value[2] << 8)
                   | ((UInt32)value[3]));
            }

            return (((UInt32)value[0])
                   | ((UInt32)value[1] << 8)
                   | ((UInt32)value[2] << 16)
                   | ((UInt32)value[3] << 24));
        }

        public static UInt32 ToUInt32(this byte[] value, int index)
        {
            if (isBigEndian)
            {
                return (((UInt32)value[index] << 24)
                   | ((UInt32)value[index + 1] << 16)
                   | ((UInt32)value[index + 2] << 8)
                   | (UInt32)value[index + 3]);
            }

            return ((UInt32)value[index]
                   | ((UInt32)value[index + 1] << 8)
                   | ((UInt32)value[index + 2] << 16)
                   | ((UInt32)value[index + 3] << 24));
        }

        public static UInt64 ToUInt64(this byte[] value)
        {
            if (isBigEndian)
            {
                return (((UInt64)value[0] << 56)
                  | ((UInt64)value[1] << 48)
                  | ((UInt64)value[2] << 40)
                  | ((UInt64)value[3] << 32)
                  | ((UInt64)value[4] << 24)
                  | ((UInt64)value[5] << 16)
                  | ((UInt64)value[6] << 8)
                  | (UInt64)value[7]);
            }

            return ((UInt64)value[0]
                 | ((UInt64)value[1] << 8)
                 | ((UInt64)value[2] << 16)
                 | ((UInt64)value[3] << 24)
                 | ((UInt64)value[4] << 32)
                 | ((UInt64)value[5] << 40)
                 | ((UInt64)value[6] << 48)
                 | ((UInt64)value[7] << 56));
        }

        public static UInt64 ToUInt64(this byte[] value, int index)
        {
            if (isBigEndian)
            {
                return (((UInt64)value[index] << 56)
                  | ((UInt64)value[index + 1] << 48)
                  | ((UInt64)value[index + 2] << 40)
                  | ((UInt64)value[index + 3] << 32)
                  | ((UInt64)value[index + 4] << 24)
                  | ((UInt64)value[index + 5] << 16)
                  | ((UInt64)value[index + 6] << 8)
                  | (UInt64)value[index + 7]);
            }

            return ((UInt64)value[index]
                 | ((UInt64)value[index + 1] << 8)
                 | ((UInt64)value[index + 2] << 16)
                 | ((UInt64)value[index + 3] << 24)
                 | ((UInt64)value[index + 4] << 32)
                 | ((UInt64)value[index + 5] << 40)
                 | ((UInt64)value[index + 6] << 48)
                 | ((UInt64)value[index + 7] << 56));
        }
    }
}