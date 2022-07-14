using System;

namespace Elements;

public static class CollectionsUtil
{
	public static void ArrayRemoveAt<T>(T[] _contents, int _index, int _count)
	{
		for (int i = _index; i < _count - 1; i++)
		{
			_contents[i] = _contents[i + 1];
		}
		_contents[_count - 1] = default(T);
	}

	public static T[] CopyAsNewInstance<T>(this T[] _sourceArray)
	{
		T[] array = new T[_sourceArray.Length];
		Array.Copy(_sourceArray, array, _sourceArray.Length);
		return array;
	}
}
