using System;
using System.Runtime.InteropServices;

namespace Sqlite3Plugin;

public static class ADAKPPDHFFB
{
	private const string LibraryName = "libsqlite3";

	[DllImport("libsqlite3")]
	public static extern int sqlite3_open(byte[] BJCDCFLAIAA, out IntPtr MMGDKAGMKBN);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_open_v2(byte[] BJCDCFLAIAA, out IntPtr MMGDKAGMKBN, int KLMHLFBJBCK, byte[] MJDHPFBDCJP);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_close(IntPtr CKMHMDPHJBB);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_exec(IntPtr CKMHMDPHJBB, byte[] COIANCOFONI, IntPtr IMBJJOEJBPO, IntPtr HKCAMONHFBE, out IntPtr HLNDLAOMGNM);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_prepare_v2(IntPtr CKMHMDPHJBB, byte[] COIANCOFONI, int DHCOCMDFJCK, out IntPtr MNMCJBKBFNE, IntPtr OJPJNLIBKHL);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_bind_text(IntPtr FNMLEMMPAOC, int FMIMMEBLELD, byte[] KHKOHMGFDLN, int OOGDBLHNLMC, IntPtr DCKHHMOKOLP);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_bind_int(IntPtr FNMLEMMPAOC, int FMIMMEBLELD, int JIIMPNGIPNL);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_bind_double(IntPtr FNMLEMMPAOC, int FMIMMEBLELD, double LAEOKIKPDAD);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_bind_null(IntPtr FNMLEMMPAOC, int FMIMMEBLELD);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_reset(IntPtr FNMLEMMPAOC);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_step(IntPtr FNMLEMMPAOC);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_finalize(IntPtr FNMLEMMPAOC);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_column_int(IntPtr FNMLEMMPAOC, int FMIMMEBLELD);

	[DllImport("libsqlite3")]
	public static extern double sqlite3_column_double(IntPtr FNMLEMMPAOC, int FMIMMEBLELD);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_column_bytes(IntPtr FNMLEMMPAOC, int FMIMMEBLELD);

	[DllImport("libsqlite3")]
	public static extern IntPtr sqlite3_column_blob(IntPtr FNMLEMMPAOC, int FMIMMEBLELD);

	[DllImport("libsqlite3")]
	public static extern IntPtr sqlite3_column_text(IntPtr FNMLEMMPAOC, int FMIMMEBLELD);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_column_type(IntPtr FNMLEMMPAOC, int FMIMMEBLELD);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_vfs_register(IntPtr FNMLEMMPAOC, int HGPIFIEEKAI);

	[DllImport("libsqlite3")]
	public static extern int sqlite3_vfs_unregister(IntPtr IOGFGIEJMIA);

	[DllImport("libsqlite3")]
	public static extern IntPtr sqlite3_vfs_find(byte[] HGICADCIENN);
}
