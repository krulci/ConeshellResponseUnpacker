using System;
using System.Runtime.CompilerServices;

namespace Coneshell;

public static class NLAMANJEALE
{
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
		//IL_0047: Incompatible stack types: I vs Ref
		EIKMHAKFHOB.LoadLibrary();
		byte[] array = new byte[16];
		Random random = new Random();
		random.NextBytes(array);
		int num = EIKMHAKFHOB._d(IONGOKDBLFH.Length, 0);
		byte[] array2 = new byte[num];
		int num2;
		fixed (byte* ptr = &(array2 != null && array2.Length != 0 ? ref array2[0] : ref *(byte*)null))
		{
			num2 = EIKMHAKFHOB._e((IntPtr)ptr, IONGOKDBLFH, IONGOKDBLFH.Length, array, 0);
		}
		if (num2 < 0)
		{
			throw new ApplicationException("Failed to pack payload");
		}
		Array.Resize(ref array2, num2);
		return array2;
	}

	public unsafe static byte[] Unpack(byte[] LNIJKNGEPAJ)
	{
		//IL_0031: Incompatible stack types: I vs Ref
		//IL_00e0: Incompatible stack types: I vs Ref
		//IL_00fe: Incompatible stack types: I vs Ref
		EIKMHAKFHOB.LoadLibrary();
		int num = EIKMHAKFHOB._f(LNIJKNGEPAJ.Length);
		byte[] array = new byte[num];
		int num2;
		fixed (byte* ptr = &(array != null && array.Length != 0 ? ref array[0] : ref *(byte*)null))
		{
			num2 = EIKMHAKFHOB._g((IntPtr)ptr, LNIJKNGEPAJ, LNIJKNGEPAJ.Length);
		}
		if (num2 < 0)
		{
			string message = $"Failed to unpack server response ({LNIJKNGEPAJ[0]:X2}{LNIJKNGEPAJ[1]:X2}{LNIJKNGEPAJ[2]:X2}{LNIJKNGEPAJ[3]:X2})";
			throw new ApplicationException(message);
		}
		int num3 = array[0] + (array[1] << 8) + (array[2] << 16) + (array[3] << 24);
		byte[] array3;
		if (num3 > 0)
		{
			byte[] array2 = new byte[num3];
			int num4;
			fixed (byte* ptr2 = &(array2 != null && array2.Length != 0 ? ref array2[0] : ref *(byte*)null))
			{
				fixed (byte* ptr3 = &(array != null && array.Length != 0 ? ref array[0] : ref *(byte*)null))
				{
					num4 = EIKMHAKFHOB._h((IntPtr)ptr2, num3, (IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.Add(ref *ptr3, 4)), num2 - 4);
				}
			}
			if (num4 < 0)
			{
				throw new ApplicationException("Failed to decompress");
			}
			array3 = array2;
		}
		else
		{
			array3 = new byte[num2 - 4];
			Array.Copy(array, 4, array3, 0, num2 - 4);
		}
		return array3;
	}
}
