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
}
