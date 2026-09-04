namespace DSAandAlgo.Shared;

public class NestedInteger
{
    private int? _value;
    private List<NestedInteger>? _list;

    public NestedInteger()
    {
        _list = new List<NestedInteger>();
        _value = null;
    }

    public NestedInteger(int value)
    {
        _value = value;
        _list = null;
    }

    public bool IsInteger() => _value.HasValue;

    public int GetInteger() => _value ?? 0;

    public void SetInteger(int value)
    {
        _value = value;
        _list = null;
    }

    public void Add(NestedInteger ni)
    {
        if (_list == null)
        {
            _list = new List<NestedInteger>();
            _value = null;
        }
        _list.Add(ni);
    }

    public IList<NestedInteger> GetList() => _list ?? new List<NestedInteger>();
}
