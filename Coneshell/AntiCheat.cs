using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unpacker
{
    public static class AntiCheat
    {
		private static string cryptoKey = "e806f6";
		public static ODIOCLPJGAG lockToDevice = ODIOCLPJGAG.None;
		public static bool readForeignSaves = false;

		public static bool emergencyMode = false;
		private static uint deviceIdHash;

		private static uint NINDOMAMBAD
		{
			get
			{
				if (deviceIdHash == 0)
				{
					deviceIdHash = CalculateChecksum(BOFDLLABFNL);
				}
				return deviceIdHash;
			}
		}
		private static string deviceId;

		public static string BOFDLLABFNL
		{
			get
			{
				if (string.IsNullOrEmpty(deviceId))
				{
					deviceId = GetDeviceId();
				}
				return deviceId;
			}
			set
			{
				deviceId = value;
			}
		}
		private static string deprecatedDeviceId;

		private static string JEFOAOINNJD
		{
			get
			{
				if (string.IsNullOrEmpty(deprecatedDeviceId))
				{
					deprecatedDeviceId = DeprecatedCalculateChecksum(BOFDLLABFNL);
				}
				return deprecatedDeviceId;
			}
		}
		private static string GetDeviceId()
		{
			return "";
		}

		public static string EncryptKey(string HDAJOEOLHGG)
		{
			HDAJOEOLHGG = EncryptDecrypt(HDAJOEOLHGG, cryptoKey);
			HDAJOEOLHGG = Convert.ToBase64String(Encoding.UTF8.GetBytes(HDAJOEOLHGG));
			return HDAJOEOLHGG;
		}
		public static string EncryptDecrypt(string PDGAOEAMDCL, string HDAJOEOLHGG)
		{
			if (string.IsNullOrEmpty(PDGAOEAMDCL))
			{
				return "";
			}
			if (string.IsNullOrEmpty(HDAJOEOLHGG))
			{
				HDAJOEOLHGG = cryptoKey;
			}
			int length = HDAJOEOLHGG.Length;
			int length2 = PDGAOEAMDCL.Length;
			char[] array = new char[length2];
			for (int i = 0; i < length2; i++)
			{
				array[i] = (char)(PDGAOEAMDCL[i] ^ HDAJOEOLHGG[i % length]);
			}
			return new string(array);
		}
		public static int GetInt(string HDAJOEOLHGG, string en_val)
		{
			string text = EncryptKey(HDAJOEOLHGG);			
			string encryptedPrefsString = en_val;
			if (!(encryptedPrefsString == "{not_found}"))
			{
				return DecryptIntValue(HDAJOEOLHGG, encryptedPrefsString, 0);
			}
			return 0;
		}
		internal static int DecryptIntValue(string HDAJOEOLHGG, string JHJLBKDKCIB, int JLLDHLJOAOI)
		{
			if (JHJLBKDKCIB.IndexOf(':') > -1)
			{
				string text = DeprecatedDecryptValue(JHJLBKDKCIB);
				if (text == "")
				{
					return JLLDHLJOAOI;
				}
				int.TryParse(text, out var result);
				//SetInt(HDAJOEOLHGG, result);
				return result;
			}
			byte[] array = DecryptData(HDAJOEOLHGG, JHJLBKDKCIB);
			if (array == null)
			{
				return JLLDHLJOAOI;
			}
			return BitConverter.ToInt32(array, 0);
		}
		internal static string DecryptStringValue(string HDAJOEOLHGG, string JHJLBKDKCIB, string JLLDHLJOAOI)
		{
			if (JHJLBKDKCIB.IndexOf(':') > -1)
			{
				string text = DeprecatedDecryptValue(JHJLBKDKCIB);
				if (text == "")
				{
					return JLLDHLJOAOI;
				}
				//SetString(HDAJOEOLHGG, text);
				return text;
			}
			byte[] array = DecryptData(HDAJOEOLHGG, JHJLBKDKCIB);
			if (array == null)
			{
				return JLLDHLJOAOI;
			}
			return Encoding.UTF8.GetString(array, 0, array.Length);
		}
		public enum ODIOCLPJGAG : byte
		{
			None,
			Soft,
			Strict
		}
		private static uint CalculateChecksum(string PBAIIOCIFDP)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(PBAIIOCIFDP + cryptoKey);
			return CEENGIAFKBO.CalculateHash(bytes, bytes.Length, 0u);
		}
		public static string GetString(string key, string ency_Value)
		{
			string text = EncryptKey(key);
			
			string encryptedPrefsString = ency_Value;
			if (!(encryptedPrefsString == "{not_found}"))
			{
				return DecryptStringValue(key, encryptedPrefsString, "404");
			}
			return "404";
		}
		internal static byte[] DecryptData(string HDAJOEOLHGG, string JHJLBKDKCIB)
		{
			byte[] array;
			try
			{
				array = Convert.FromBase64String(JHJLBKDKCIB);
			}
			catch (Exception)
			{
				SavesTampered();
				return null;
			}
			if (array.Length == 0)
			{
				SavesTampered();
				return null;
			}
			int num = array.Length;
			if (array[num - 6] != 2)
			{
				SavesTampered();
				return null;
			}
			ODIOCLPJGAG oDIOCLPJGAG = (ODIOCLPJGAG)array[num - 5];
			byte[] array2 = new byte[4];
			Buffer.BlockCopy(array, num - 4, array2, 0, 4);
			uint num2 = (uint)(array2[0] | (array2[1] << 8) | (array2[2] << 16) | (array2[3] << 24));
			uint num3 = 0u;
			int num4;
			if (oDIOCLPJGAG != 0)
			{
				num4 = num - 11;
				if (lockToDevice != 0)
				{
					byte[] array3 = new byte[4];
					Buffer.BlockCopy(array, num4, array3, 0, 4);
					num3 = (uint)(array3[0] | (array3[1] << 8) | (array3[2] << 16) | (array3[3] << 24));
				}
			}
			else
			{
				num4 = num - 7;
			}
			byte[] array4 = new byte[num4];
			Buffer.BlockCopy(array, 0, array4, 0, num4);
			byte[] array5 = EncryptDecryptBytes(array4, num4, HDAJOEOLHGG + cryptoKey);
			if (CEENGIAFKBO.CalculateHash(array5, num4, 0u) != num2)
			{
				SavesTampered();
				return null;
			}
			if (lockToDevice == ODIOCLPJGAG.Strict && num3 == 0 && !emergencyMode && !readForeignSaves)
			{
				return null;
			}
			if (num3 != 0 && !emergencyMode)
			{
				uint num5 = NINDOMAMBAD;
				if (num3 != num5)
				{
					PossibleForeignSavesDetected();
					if (!readForeignSaves)
					{
						return null;
					}
				}
			}
			return array5;
		}
		private static byte[] EncryptDecryptBytes(byte[] DOJDGDHBMIP, int IFDIBKBFMLF, string HDAJOEOLHGG)
		{
			int length = HDAJOEOLHGG.Length;
			byte[] array = new byte[IFDIBKBFMLF];
			for (int i = 0; i < IFDIBKBFMLF; i++)
			{
				array[i] = (byte)(DOJDGDHBMIP[i] ^ HDAJOEOLHGG[i % length]);
			}
			return array;
		}
		private static string DeprecatedDecryptValue(string PDGAOEAMDCL)
		{
			string[] array = PDGAOEAMDCL.Split(':');
			if (array.Length < 2)
			{
				SavesTampered();
				return "";
			}
			string text = array[0];
			string a = array[1];
			byte[] array2;
			try
			{
				array2 = Convert.FromBase64String(text);
			}
			catch
			{
				SavesTampered();
				return "";
			}
			string result = EncryptDecrypt(Encoding.UTF8.GetString(array2, 0, array2.Length), cryptoKey);
			if (array.Length == 3)
			{
				if (a != DeprecatedCalculateChecksum(text + JEFOAOINNJD))
				{
					SavesTampered();
				}
			}
			else if (array.Length == 2)
			{
				if (a != DeprecatedCalculateChecksum(text))
				{
					SavesTampered();
				}
			}
			else
			{
				SavesTampered();
			}
			if (lockToDevice != 0 && !emergencyMode)
			{
				if (array.Length >= 3)
				{
					if (array[2] != JEFOAOINNJD)
					{
						if (!readForeignSaves)
						{
							result = "";
						}
						PossibleForeignSavesDetected();
					}
				}
				else if (lockToDevice == ODIOCLPJGAG.Strict)
				{
					if (!readForeignSaves)
					{
						result = "";
					}
					PossibleForeignSavesDetected();
				}
				else if (a != DeprecatedCalculateChecksum(text))
				{
					if (!readForeignSaves)
					{
						result = "";
					}
					PossibleForeignSavesDetected();
				}
			}
			return result;
		}
		private static string DeprecatedCalculateChecksum(string PBAIIOCIFDP)
		{
			int num = 0;
			byte[] bytes = Encoding.UTF8.GetBytes(PBAIIOCIFDP + cryptoKey);
			int num2 = bytes.Length;
			int num3 = cryptoKey.Length ^ 0x40;
			for (int i = 0; i < num2; i++)
			{
				byte b = bytes[i];
				num += b + b * (i + num3) % 3;
			}
			return num.ToString("X2");
		}

		private static void SavesTampered()
        {

        }
		private static void PossibleForeignSavesDetected()
        {

        }
	}
	internal class CEENGIAFKBO
	{
		private const uint PRIME32_1 = 2654435761u;

		private const uint PRIME32_2 = 2246822519u;

		private const uint PRIME32_3 = 3266489917u;

		private const uint PRIME32_4 = 668265263u;

		private const uint PRIME32_5 = 374761393u;

		public static uint CalculateHash(byte[] DFFKEFLPKGO, int CIDIMJFKENL, uint FFIIABDADEN)
		{
			int i = 0;
			uint num7;
			if (CIDIMJFKENL >= 16)
			{
				int num = CIDIMJFKENL - 16;
				uint num2 = (uint)((int)FFIIABDADEN + -1640531535 + -2048144777);
				uint num3 = FFIIABDADEN + 2246822519u;
				uint num4 = FFIIABDADEN;
				uint num5 = FFIIABDADEN - 2654435761u;
				do
				{
					uint num6 = (uint)(DFFKEFLPKGO[i++] | (DFFKEFLPKGO[i++] << 8) | (DFFKEFLPKGO[i++] << 16) | (DFFKEFLPKGO[i++] << 24));
					num2 += (uint)((int)num6 * -2048144777);
					num2 = (num2 << 13) | (num2 >> 19);
					num2 *= 2654435761u;
					num6 = (uint)(DFFKEFLPKGO[i++] | (DFFKEFLPKGO[i++] << 8) | (DFFKEFLPKGO[i++] << 16) | (DFFKEFLPKGO[i++] << 24));
					num3 += (uint)((int)num6 * -2048144777);
					num3 = (num3 << 13) | (num3 >> 19);
					num3 *= 2654435761u;
					num6 = (uint)(DFFKEFLPKGO[i++] | (DFFKEFLPKGO[i++] << 8) | (DFFKEFLPKGO[i++] << 16) | (DFFKEFLPKGO[i++] << 24));
					num4 += (uint)((int)num6 * -2048144777);
					num4 = (num4 << 13) | (num4 >> 19);
					num4 *= 2654435761u;
					num6 = (uint)(DFFKEFLPKGO[i++] | (DFFKEFLPKGO[i++] << 8) | (DFFKEFLPKGO[i++] << 16) | (DFFKEFLPKGO[i++] << 24));
					num5 += (uint)((int)num6 * -2048144777);
					num5 = (num5 << 13) | (num5 >> 19);
					num5 *= 2654435761u;
				}
				while (i <= num);
				num7 = ((num2 << 1) | (num2 >> 31)) + ((num3 << 7) | (num3 >> 25)) + ((num4 << 12) | (num4 >> 20)) + ((num5 << 18) | (num5 >> 14));
			}
			else
			{
				num7 = FFIIABDADEN + 374761393;
			}
			num7 += (uint)CIDIMJFKENL;
			while (i <= CIDIMJFKENL - 4)
			{
				num7 += (uint)((DFFKEFLPKGO[i++] | (DFFKEFLPKGO[i++] << 8) | (DFFKEFLPKGO[i++] << 16) | (DFFKEFLPKGO[i++] << 24)) * -1028477379);
				num7 = ((num7 << 17) | (num7 >> 15)) * 668265263;
			}
			for (; i < CIDIMJFKENL; i++)
			{
				num7 += (uint)(DFFKEFLPKGO[i] * 374761393);
				num7 = ((num7 << 11) | (num7 >> 21)) * 2654435761u;
			}
			num7 ^= num7 >> 15;
			num7 *= 2246822519u;
			num7 ^= num7 >> 13;
			num7 *= 3266489917u;
			return num7 ^ (num7 >> 16);
		}
	}

}
