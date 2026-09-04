namespace DSAandAlgo.Shared;

public class MovingAverage
{
    private readonly Queue<int> _queue;
    private readonly int _maxSize;
    private double _sum;

    public MovingAverage(int size)
    {
        _queue = new Queue<int>();
        _maxSize = size;
        _sum = 0;
    }

    public double Next(int val)
    {
        _queue.Enqueue(val);
        _sum += val;

        if (_queue.Count > _maxSize)
            _sum -= _queue.Dequeue();

        return _sum / _queue.Count;
    }
}
