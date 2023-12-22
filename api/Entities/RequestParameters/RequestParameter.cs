namespace Entities;

public abstract class RequestParameter
{
    private int maxLimit = 50;

    // Auto-implemented property
    public int PageNumber { get; set; }

    // Full-prop
    private int _pageSize;

    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = value<50 ? value : maxLimit; }
    }

}
