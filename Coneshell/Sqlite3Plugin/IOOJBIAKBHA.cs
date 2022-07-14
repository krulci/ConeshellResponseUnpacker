using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Sqlite3Plugin;

public class IOOJBIAKBHA : IDisposable
{
	public IntPtr CPJHOACKHFI { get; private set; }

	public string FLDJBDPJIKK { get; private set; }

	~IOOJBIAKBHA()
	{
		CloseDB();
	}

	public IOOJBIAKBHA()
	{
		FLDJBDPJIKK = null;
		CPJHOACKHFI = IntPtr.Zero;
	}

	public bool Open(string OBODHBGPMEL, string KCCLLCOPPHF = null)
	{
		FLDJBDPJIKK = OBODHBGPMEL;
		IntPtr MMGDKAGMKBN = IntPtr.Zero;
		byte[] bytes = Encoding.UTF8.GetBytes(OBODHBGPMEL + "\0");
		byte[] mJDHPFBDCJP = null;
		if (!string.IsNullOrEmpty(KCCLLCOPPHF))
		{
			mJDHPFBDCJP = Encoding.UTF8.GetBytes(KCCLLCOPPHF + "\0");
		}
		int num = ADAKPPDHFFB.sqlite3_open_v2(bytes, out MMGDKAGMKBN, 1, mJDHPFBDCJP);
		CPJHOACKHFI = MMGDKAGMKBN;
		bool num2 = num == 0;
		if (num2)
		{
			Exec("pragma journal_mode=OFF");
			Exec("pragma synchronous=0");
			Exec("pragma locking_mode=EXCLUSIVE");
		}
		return num2;
	}

	public bool OpenWritable(string OBODHBGPMEL)
	{
		FLDJBDPJIKK = OBODHBGPMEL;
		IntPtr MMGDKAGMKBN = IntPtr.Zero;
		bool flag = true;
		try
		{
			int num = ADAKPPDHFFB.sqlite3_open(Encoding.UTF8.GetBytes(OBODHBGPMEL + "\0"), out MMGDKAGMKBN);
			CPJHOACKHFI = MMGDKAGMKBN;
			flag = num == 0;
			if (flag)
			{
				Exec("pragma journal_mode=MEMORY");
				Exec("pragma synchronous=1");
				Exec("pragma locking_mode=EXCLUSIVE");
				return flag;
			}
			return flag;
		}
		catch (Exception ex)
		{
			if (MMGDKAGMKBN != IntPtr.Zero)
			{
				ADAKPPDHFFB.sqlite3_close(MMGDKAGMKBN);
				CPJHOACKHFI = IntPtr.Zero;
			}
			throw ex;
		}
	}

	public bool Begin()
	{
		return Exec("BEGIN;");
	}

	public bool Commit()
	{
		return Exec("COMMIT;");
	}

	public bool Rollback()
	{
		return Exec("ROLLBACK;");
	}

	public bool Vacuum()
	{
		return Exec("VACUUM;");
	}

	public virtual void Dispose()
	{
		CloseDB();
	}

	protected virtual void Dispose(bool FDFGPOKGKFO)
	{
		CloseDB();
	}

	private void Terminate()
	{
		CloseDB();
	}

	public virtual void CloseDB()
	{
		if (CPJHOACKHFI != IntPtr.Zero)
		{
			ADAKPPDHFFB.sqlite3_close(CPJHOACKHFI);
			CPJHOACKHFI = IntPtr.Zero;
		}
	}

	public bool Exec(string HPGHIONJCPL)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(HPGHIONJCPL + "\0");
		IntPtr HLNDLAOMGNM;
		int num = ADAKPPDHFFB.sqlite3_exec(CPJHOACKHFI, bytes, IntPtr.Zero, IntPtr.Zero, out HLNDLAOMGNM);
		if (num != 0)
		{
			string oNLJIHPIGNL = ((HLNDLAOMGNM == IntPtr.Zero) ? "" : Marshal.PtrToStringAnsi(HLNDLAOMGNM));
			GGEABGPENAL.CheckCorruption(num, oNLJIHPIGNL);
		}
		return num == 0;
	}

	public ODBKLOJPCHG Query(string HPGHIONJCPL)
	{
		return new ODBKLOJPCHG(this, HPGHIONJCPL);
	}

	public NAOCHNBMGCB PreparedQuery(string HPGHIONJCPL)
	{
		return new NAOCHNBMGCB(this, HPGHIONJCPL);
	}
}
