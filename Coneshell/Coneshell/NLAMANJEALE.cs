using System;
using Elements;

namespace Coneshell;

public static class NLAMANJEALE
{
	public static byte[] KeepPackNonce;

	public static int AFGBOOMJMOC
	{
		get
		{
			EIKMHAKFHOB.LoadLibrary();
			return EIKMHAKFHOB._k();
		}
	}

	public static void InitializeContext(byte[] OANKCDECKGM, byte[] CBOIJPBHAOA)
	{
		EIKMHAKFHOB.LoadLibrary();
		if (EIKMHAKFHOB._b(OANKCDECKGM, CBOIJPBHAOA) != 0)
		{
			throw new ApplicationException("Failed to initialize context");
		}
	}

	public static void ResetContext()
	{
		EIKMHAKFHOB.LoadLibrary();
		EIKMHAKFHOB._c();
	}

	public unsafe static byte[] Pack(byte[] IONGOKDBLFH)
	{
		EIKMHAKFHOB.LoadLibrary();
		byte[] array = new byte[16];
		new Random().NextBytes(array);
		KeepPackNonce = array.CopyAsNewInstance();
		byte[] array2 = new byte[EIKMHAKFHOB._d(IONGOKDBLFH.Length, 0)];
		int num;
		fixed (byte* ptr = array2)
		{
			num = EIKMHAKFHOB._e((IntPtr)ptr, IONGOKDBLFH, IONGOKDBLFH.Length, array, 0);
		}
		if (num < 0)
		{
			throw new ApplicationException("Failed to pack payload");
		}
		Array.Resize(ref array2, num);
		return array2;
	}

	public unsafe static byte[] Unpack(byte[] LNIJKNGEPAJ)
	{
		EIKMHAKFHOB.LoadLibrary();
		byte[] array = new byte[EIKMHAKFHOB._f(LNIJKNGEPAJ.Length)];
		int num;
		fixed (byte* ptr = array)
		{
			num = EIKMHAKFHOB._g((IntPtr)ptr, LNIJKNGEPAJ, LNIJKNGEPAJ.Length);
		}
		if (num < 0)
		{
			throw new ApplicationException($"Failed to unpack server response ({LNIJKNGEPAJ[0]:X2}{LNIJKNGEPAJ[1]:X2}{LNIJKNGEPAJ[2]:X2}{LNIJKNGEPAJ[3]:X2})");
		}
		int num2 = array[0] + (array[1] << 8) + (array[2] << 16) + (array[3] << 24);
		byte[] array3;
		if (num2 > 0)
		{
			byte[] array2 = new byte[num2];
			int num3;
			fixed (byte* ptr2 = array2)
			{
				fixed (byte* ptr3 = array)
				{
					num3 = EIKMHAKFHOB._h((IntPtr)ptr2, num2, (IntPtr)(ptr3 + 4), num - 4);
				}
			}
			if (num3 < 0)
			{
				throw new ApplicationException("Failed to decompress");
			}
			array3 = array2;
		}
		else
		{
			array3 = new byte[num - 4];
			Array.Copy(array, 4, array3, 0, num - 4);
		}
		return array3;
	}
}
