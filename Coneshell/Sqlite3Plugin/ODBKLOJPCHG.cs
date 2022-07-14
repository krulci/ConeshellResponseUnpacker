using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Sqlite3Plugin;

public class ODBKLOJPCHG : IDisposable
{
	protected IOOJBIAKBHA _proxy;

	protected IntPtr _stmt = IntPtr.Zero;

	public ODBKLOJPCHG(IOOJBIAKBHA FNBAJFJIIFN, string HPGHIONJCPL)
	{
		_Setup(FNBAJFJIIFN, HPGHIONJCPL);
	}

	protected void _Setup(IOOJBIAKBHA FNBAJFJIIFN, string HPGHIONJCPL)
	{
		_proxy = FNBAJFJIIFN;
		byte[] bytes = Encoding.UTF8.GetBytes(HPGHIONJCPL);
		IntPtr MNMCJBKBFNE;
		int num = ADAKPPDHFFB.sqlite3_prepare_v2(FNBAJFJIIFN.CPJHOACKHFI, bytes, bytes.Length, out MNMCJBKBFNE, IntPtr.Zero);
		if (num != 0)
		{
			GGEABGPENAL.CheckCorruption(num);
			throw new Exception($"sqlite3_prepare_v2 failed(code {num}) with sql: {HPGHIONJCPL}");
		}
		_stmt = MNMCJBKBFNE;
	}

	public virtual void Dispose()
	{
		if (_stmt != IntPtr.Zero)
		{
			int num = ADAKPPDHFFB.sqlite3_finalize(_stmt);
			_stmt = IntPtr.Zero;
			if (num != 0)
			{
				GGEABGPENAL.CheckCorruption(num);
			}
		}
	}

	public bool Step()
	{
		int num = ADAKPPDHFFB.sqlite3_step(_stmt);
		bool num2 = num == 100;
		if (!num2)
		{
			GGEABGPENAL.CheckCorruption(num);
		}
		return num2;
	}

	public int GetInt(int KFPPPAAGDDL)
	{
		return ADAKPPDHFFB.sqlite3_column_int(_stmt, KFPPPAAGDDL);
	}

	public double GetDouble(int KFPPPAAGDDL)
	{
		return ADAKPPDHFFB.sqlite3_column_double(_stmt, KFPPPAAGDDL);
	}

	public string GetText(int KFPPPAAGDDL)
	{
		return Marshal.PtrToStringAnsi(ADAKPPDHFFB.sqlite3_column_text(_stmt, KFPPPAAGDDL));
	}

	public byte[] GetBlob(int KFPPPAAGDDL)
	{
		int num = ADAKPPDHFFB.sqlite3_column_bytes(_stmt, KFPPPAAGDDL);
		if (num == 0)
		{
			return null;
		}
		IntPtr source = ADAKPPDHFFB.sqlite3_column_blob(_stmt, KFPPPAAGDDL);
		byte[] array = new byte[num];
		Marshal.Copy(source, array, 0, num);
		return array;
	}

	public bool IsNull(int KFPPPAAGDDL)
	{
		return ADAKPPDHFFB.sqlite3_column_type(_stmt, KFPPPAAGDDL) == 5;
	}
}
