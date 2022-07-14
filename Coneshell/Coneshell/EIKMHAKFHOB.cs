using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Coneshell;

public static class EIKMHAKFHOB
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate IntPtr KKPBEJFODNJ();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int LMGILLAGDKG(byte[] OANKCDECKGM, byte[] CBOIJPBHAOA);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void PJOMEBAODIO();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int AELFJENOLLD(int AGOEHCLGMPH, int POJALKPJAOM);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int OJKHCJHLGAP(IntPtr ENKLOIFGMFC, byte[] IPNHFNIGDKF, int AGOEHCLGMPH, byte[] IEAFKHGKFDA, int POJALKPJAOM);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int EAJGFHCFKEA(int AGOEHCLGMPH);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int LFCFINDLALH(IntPtr ENKLOIFGMFC, byte[] IPNHFNIGDKF, int AGOEHCLGMPH);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int BHBDNHLDKNN(IntPtr ENKLOIFGMFC, int HCHCMLNGDIM, IntPtr IPNHFNIGDKF, int AGOEHCLGMPH);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate IntPtr FOLPONLJCAP(byte[] AIAPAJCMNHD, long JPCPCPKDKAN, byte[] CIAJGHECFHJ);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void LPGJJABFLKN(IntPtr IOGFGIEJMIA);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int ONEGJAFOLEC();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int EKFFPFMKCEN();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void JEGFOJNGCGJ(byte[] AIAPAJCMNHD);

	private static bool initialized;

	private const string library_name = "coneshell";

	internal static KKPBEJFODNJ _a;

	internal static LMGILLAGDKG _b;

	internal static PJOMEBAODIO _c;

	internal static AELFJENOLLD _d;

	internal static OJKHCJHLGAP _e;

	internal static EAJGFHCFKEA _f;

	internal static LFCFINDLALH _g;

	internal static BHBDNHLDKNN _h;

	internal static FOLPONLJCAP _i;

	internal static LPGJJABFLKN _j;

	internal static ONEGJAFOLEC _k;

	internal static EKFFPFMKCEN _l;

	internal static JEGFOJNGCGJ _m;

	[DllImport("coneshell")]
	internal static extern IntPtr _fx00();

	internal static void LoadLibrary()
	{
		if (!initialized)
		{
			_a = GetProc<KKPBEJFODNJ>(_fx00());
			_k = GetProc<ONEGJAFOLEC>(_a());
			_l = GetProc<EKFFPFMKCEN>(_a());
			_h = GetProc<BHBDNHLDKNN>(_a());
			_m = GetProc<JEGFOJNGCGJ>(_a());
			_c = GetProc<PJOMEBAODIO>(_a());
			_b = GetProc<LMGILLAGDKG>(_a());
			_f = GetProc<EAJGFHCFKEA>(_a());
			_d = GetProc<AELFJENOLLD>(_a());
			_j = GetProc<LPGJJABFLKN>(_a());
			_i = GetProc<FOLPONLJCAP>(_a());
			_g = GetProc<LFCFINDLALH>(_a());
			_e = GetProc<OJKHCJHLGAP>(_a());
			initialized = true;
			EIJGKLKKOIF.RuntimeSetup();
		}
	}

	private static T GetProc<T>(IntPtr JNMLPIINEFP) where T : class
	{
		return Marshal.GetDelegateForFunctionPointer(JNMLPIINEFP, typeof(T)) as T;
	}

	[Conditional("UNITY_EDITOR_WIN")]
	internal static void UnloadLibrary()
	{
	}
}
