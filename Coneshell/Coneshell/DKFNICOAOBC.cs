using System;
using System.Text;
using Sqlite3Plugin;

namespace Coneshell;

public class DKFNICOAOBC : IOOJBIAKBHA
{
	protected IntPtr vfsHandle = IntPtr.Zero;

	public bool OpenCustomVFS(string KCCLLCOPPHF, byte[] AIAPAJCMNHD)
	{
		vfsHandle = EIKMHAKFHOB._i(AIAPAJCMNHD, AIAPAJCMNHD.Length, Encoding.UTF8.GetBytes(KCCLLCOPPHF + "\0"));
		if (vfsHandle == IntPtr.Zero)
		{
			return false;
		}
		if (ADAKPPDHFFB.sqlite3_vfs_register(vfsHandle, 0) != 0)
		{
			CloseDB();
			return false;
		}
		if (!Open(KCCLLCOPPHF, KCCLLCOPPHF))
		{
			CloseDB();
			return false;
		}
		return true;
	}

	public override void CloseDB()
	{
		base.CloseDB();
		if (vfsHandle != IntPtr.Zero)
		{
			ADAKPPDHFFB.sqlite3_vfs_unregister(vfsHandle);
			EIKMHAKFHOB._j(vfsHandle);
			vfsHandle = IntPtr.Zero;
		}
	}
}
