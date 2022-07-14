using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Cute
{
	public class NAPGOPBJNMP
	{
		public const int FBENCRYPT_BLOCK_SIZE = 32;

		private static string encode_buf;

		private static Random cRandom = new Random();

		private static SHA1CryptoServiceProvider sha1 = null;

		private static UTF8Encoding utf8 = null;

		private const int BLOCK_SIZE = 128;

		private const int KEY_SIZE = 256;

		private static int random()
		{
			return cRandom.Next(1, 9);
		}

		public static string generateIvString()
		{
			string text = "";
			for (int i = 0; i < 32; i++)
			{
				text += $"{random()}";
			}
			return text;
		}

		public static string encode(string AOMLFJMDGHH)
		{
			int length = AOMLFJMDGHH.Length;
			encode_buf = $"{length:x4}";
			foreach (char value in AOMLFJMDGHH)
			{
				encode_buf += string.Format("{0,1:x}", random());
				encode_buf += string.Format("{0,1:x}", random());
				encode_buf += (char)(Convert.ToInt32(value) + 10);
				encode_buf += string.Format("{0,1:x}", random());
			}
			encode_buf += generateIvString();
			return encode_buf;
		}

		public static string decode(string AOMLFJMDGHH)
		{
			if (AOMLFJMDGHH == null || AOMLFJMDGHH.Length < 4)
			{
				return AOMLFJMDGHH;
			}
			int num = int.Parse(AOMLFJMDGHH.Substring(0, 4), NumberStyles.AllowHexSpecifier);
			string text = "";
			int num2 = 2;
			string text2 = AOMLFJMDGHH.Substring(4, AOMLFJMDGHH.Length - 4);
			foreach (char value in text2)
			{
				if (num2 % 4 == 0)
				{
					text += (char)(Convert.ToInt32(value) - 10);
				}
				num2++;
				if (text.Length >= num)
				{
					break;
				}
			}
			return text;
		}

		public static string ComputeSHA1(string FFIIABDADEN)
		{
			if (sha1 == null)
			{
				sha1 = new SHA1CryptoServiceProvider();
			}
			if (utf8 == null)
			{
				utf8 = new UTF8Encoding();
			}
			if (string.IsNullOrEmpty(FFIIABDADEN))
			{
				return "";
			}
			byte[] bytes = utf8.GetBytes(FFIIABDADEN);
			byte[] array = sha1.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				stringBuilder.Append(Convert.ToString(array[i], 16).PadLeft(2, '0'));
			}
			sha1.Initialize();
			return stringBuilder.ToString();
		}

		public static string MakeMd5(string PBAIIOCIFDP)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.UTF8.GetBytes(PBAIIOCIFDP + "r!I@nt8e5i=");
			byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			mD5CryptoServiceProvider.Clear();
			return stringBuilder.ToString();
		}
	}
}
