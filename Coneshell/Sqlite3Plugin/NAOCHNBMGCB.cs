using System;
using System.Text;

namespace Sqlite3Plugin;

public class NAOCHNBMGCB : ODBKLOJPCHG
{
	public NAOCHNBMGCB(IOOJBIAKBHA FNBAJFJIIFN, string HPGHIONJCPL)
		: base(FNBAJFJIIFN, HPGHIONJCPL)
	{
	}

	public bool BindText(int KFPPPAAGDDL, string DOBHGLKJFEF)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(DOBHGLKJFEF);
		int num = ADAKPPDHFFB.sqlite3_bind_text(_stmt, KFPPPAAGDDL, bytes, bytes.Length, IntPtr.Zero);
		if (num != 0)
		{
			GGEABGPENAL.CheckCorruption(num);
		}
		return num == 0;
	}

	public bool BindInt(int KFPPPAAGDDL, int JIIMPNGIPNL)
	{
		int num = ADAKPPDHFFB.sqlite3_bind_int(_stmt, KFPPPAAGDDL, JIIMPNGIPNL);
		if (num != 0)
		{
			GGEABGPENAL.CheckCorruption(num);
		}
		return num == 0;
	}

	public bool BindDouble(int KFPPPAAGDDL, double LAEOKIKPDAD)
	{
		int num = ADAKPPDHFFB.sqlite3_bind_double(_stmt, KFPPPAAGDDL, LAEOKIKPDAD);
		if (num != 0)
		{
			GGEABGPENAL.CheckCorruption(num);
		}
		return num == 0;
	}

	public bool Reset()
	{
		int num = ADAKPPDHFFB.sqlite3_reset(_stmt);
		if (num != 0)
		{
			GGEABGPENAL.CheckCorruption(num);
		}
		return num == 0;
	}
}
