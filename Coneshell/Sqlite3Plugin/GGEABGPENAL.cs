using System;

namespace Sqlite3Plugin;

public class GGEABGPENAL
{
	public const int SQLITE_OK = 0;

	public const int SQLITE_ERROR = 1;

	public const int SQLITE_INTERNAL = 2;

	public const int SQLITE_PERM = 3;

	public const int SQLITE_ABORT = 4;

	public const int SQLITE_BUSY = 5;

	public const int SQLITE_LOCKED = 6;

	public const int SQLITE_NOMEM = 7;

	public const int SQLITE_READONLY = 8;

	public const int SQLITE_INTERRUPT = 9;

	public const int SQLITE_IOERR = 10;

	public const int SQLITE_CORRUPT = 11;

	public const int SQLITE_NOTFOUND = 12;

	public const int SQLITE_FULL = 13;

	public const int SQLITE_CANTOPEN = 14;

	public const int SQLITE_PROTOCOL = 15;

	public const int SQLITE_EMPTY = 16;

	public const int SQLITE_SCHEMA = 17;

	public const int SQLITE_TOOBIG = 18;

	public const int SQLITE_CONSTRAINT = 19;

	public const int SQLITE_MISMATCH = 20;

	public const int SQLITE_MISUSE = 21;

	public const int SQLITE_NOLFS = 22;

	public const int SQLITE_AUTH = 23;

	public const int SQLITE_FORMAT = 24;

	public const int SQLITE_RANGE = 25;

	public const int SQLITE_NOTADB = 26;

	public const int SQLITE_NOTICE = 27;

	public const int SQLITE_WARNING = 28;

	public const int SQLITE_ROW = 100;

	public const int SQLITE_DONE = 101;

	public static void CheckCorruption(int FOMNJFOHDAM, string ONLJIHPIGNL = null)
	{
		if (FOMNJFOHDAM == 11 || FOMNJFOHDAM == 26)
		{
			throw new AFBIOHMLCFK(FOMNJFOHDAM);
		}
		if (!string.IsNullOrEmpty(ONLJIHPIGNL) && ONLJIHPIGNL.IndexOf("unsupported file format", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			throw new AFBIOHMLCFK(26);
		}
	}
}
