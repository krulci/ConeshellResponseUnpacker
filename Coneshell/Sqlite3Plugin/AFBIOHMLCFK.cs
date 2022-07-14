using System;

namespace Sqlite3Plugin;

public class AFBIOHMLCFK : Exception
{
	public AFBIOHMLCFK(int FOMNJFOHDAM)
		: base($"Database is corrupted: code {FOMNJFOHDAM}")
	{
	}
}
