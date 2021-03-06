﻿using System;

namespace ICSP.Core.Extensions
{
  public static class ArrayExtensions
  {
    public static T[] Range<T>(this T[] data, int startIndex, int length)
    {
      T[] result = new T[length];

      Array.Copy(data, startIndex, result, 0, length);

      return result;
    }

    public static ushort GetBigEndianInt16(this byte[] data, int startIndex)
    {
      return (ushort)((data[startIndex] << 8)
           | data[startIndex + 1]);
    }

    public static int GetBigEndianInt32(this byte[] data, int startIndex)
    {
      return (data[startIndex] << 24)
          | (data[startIndex + 1] << 16)
          | (data[startIndex + 2] << 8)
          | data[startIndex + 3];
    }

    public static long GetBigEndianInt64(this byte[] data, int startIndex)
    {
      return (data[startIndex] << 56)
          | (data[startIndex + 1] << 48)
          | (data[startIndex + 2] << 40)
          | (data[startIndex + 3] << 32)
          | (data[startIndex + 4] << 24)
          | (data[startIndex + 5] << 16)
          | (data[startIndex + 6] << 8)
          | data[startIndex + 7];
    }

    public static byte[] Int32ToBigEndian(int value)
    {
      return new byte[] { (byte)(value >> 24), (byte)(value >> 16), (byte)(value >> 8), (byte)value };
    }

    public static byte[] Int16ToBigEndian(ushort value)
    {
      return new byte[] { (byte)(value >> 8), (byte)value };
    }

    public static byte[] Int16To8Bit(int value)
    {
      return new byte[] { (byte)value };
    }
    /// <summary>
    /// Swaps two array elements.
    /// </summary>
    /// <typeparam name="T">Array type.</typeparam>
    /// <param name="array">Target array.</param>
    /// <param name="index1">The first element of the array.</param>
    /// <param name="index2">The second element of the array.</param>
    public static void Swap<T>(this T[] array, int index1, int index2)
    {
      T temp = array[index1];

      array[index1] = array[index2];
      array[index2] = temp;
    }
  }
}
