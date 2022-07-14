using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
//using LitJson;

namespace Elements
{
	public static class StringUtil
	{
		private static string CULTURE_DEPENDENCY_CHARACTERS_HEAD = Regex.Escape("ー");

		public static string[] ObjectToStringArray(object _sourceObject)
		{
			return (string[])((ArrayList)_sourceObject).ToArray(typeof(string));
		}


		public static T[] StringToEnumArrayFromEnumName<T>(string _sourceString) where T : struct
		{
			if (_sourceString == "[]")
			{
				return null;
			}
			string[] array = _sourceString.Substring(1, _sourceString.Length - 2).Split(',');
			int num = array.Length;
			if (num == 0)
			{
				return null;
			}
			bool flag = true;
			T[] array2 = new T[num];
			for (int i = 0; i < num; i++)
			{
				string value = array[i];
				try
				{
					array2[i] = (T)Enum.Parse(typeof(T), value);
				}
				catch (Exception)
				{
					flag = false;
				}
			}
			if (flag)
			{
				return array2;
			}
			return null;
		}

		public static int GetNumberInString(string _string, bool _isErrorM1 = false)
		{
			int num = -1;
			for (int i = 0; i < _string.Length; i++)
			{
				if (IsHankakuNumber(_string[i]))
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				if (!_isErrorM1)
				{
					return 0;
				}
				return -1;
			}
			int j;
			for (j = num + 1; j < _string.Length && IsHankakuNumber(_string[j]); j++)
			{
			}
			return int.Parse(_string.Substring(num, j - num));
		}

		public static bool IsHankakuNumber(int _c)
		{
			if (48 <= _c)
			{
				return _c <= 57;
			}
			return false;
		}

		public static string MonthDayTime(DateTime _dateTime)
		{
			return _dateTime.ToString("MM/dd HH:mm");
		}

		public static string YearMonthDayTime(DateTime _dateTime)
		{
			return _dateTime.ToString("yyyy/MM/dd HH:mm");
		}

		public static byte[] HexString2ByteArray(this string _hexString)
		{
			byte[] array = new byte[_hexString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(_hexString.Substring(i * 2, 2), 16);
			}
			return array;
		}

		public static string ByteArray2HexString(this byte[] _byteArray)
		{
			StringBuilder stringBuilder = new StringBuilder(_byteArray.Length * 2);
			foreach (byte b in _byteArray)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}

		public static string IntListToCommaNumberString(List<int> _list)
		{
			StringBuilder stringBuilder = new StringBuilder();
			_list.ForEach(delegate (int _it)
			{
				stringBuilder.AppendFormat("{0},", _it);
			});
			return stringBuilder.ToString();
		}



		public static bool StartsWith(this string _source, string _target, bool _ignoreKanaType = false, string[] _excludeStringArray = null, char[] _splitStringArray = null)
		{
			if (_splitStringArray != null)
			{
				string[] array = _source.Split(_splitStringArray);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].StartsWith(_target, _ignoreKanaType, _excludeStringArray))
					{
						return true;
					}
				}
			}
			if (!_ignoreKanaType && _excludeStringArray == null)
			{
				return _source.StartsWith(_target);
			}
			StringBuilder source = new StringBuilder(_source);
			StringBuilder target = new StringBuilder(_target);
			if (_excludeStringArray != null)
				Array.ForEach<string>(_excludeStringArray, delegate (string str)
				{
					source.Replace(str, string.Empty);
					target.Replace(str, string.Empty);
				});
			if (_ignoreKanaType)
			{
				CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
				CompareOptions options = CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth;
				return compareInfo.IndexOf(source.ToString(), target.ToString(), options) == 0;
			}
			return source.ToString().StartsWith(target.ToString());
		}

		private static bool containsCultureDependencyHeadCharacter(string _source, string _target)
		{
			int num = 0;
			string text = "";
			for (int i = 0; i < _target.Length; i++)
			{
				char value = _target[i];
				if (CULTURE_DEPENDENCY_CHARACTERS_HEAD.IndexOf(value) < 0)
				{
					break;
				}
				num++;
				text += value;
			}
			string text2 = _source;
			string text3 = _target.Substring(num);
			CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
			CompareOptions options = CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth;
			for (int num2 = compareInfo.IndexOf(text2, text, CompareOptions.Ordinal); num2 >= 0; num2 = compareInfo.IndexOf(text2, text, CompareOptions.Ordinal))
			{
				text2 = text2.Remove(0, num2 + num);
				if (text2.Length >= text3.Length && compareInfo.Compare(text2.Substring(0, text3.Length), text3, options) == 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
