using PriorityQueue;

namespace PriorityQueueTests;

[TestFixture]
public class OrderingTests
{
    private PriorityQueue<int> _minQueue;
    private PriorityQueue<int> _maxQueue;
    
    [SetUp]
    public void SetUp()
    {
        _minQueue = new PriorityQueue<int>(10, Priority.Smallest);
        _maxQueue = new PriorityQueue<int>(10, Priority.Largest);
    }
    
    [Test]
    public void MinQueue_OrdersSmallestFirst()
    {
        _minQueue.Insert(3);
        _minQueue.Insert(4);
        _minQueue.Insert(2);
        Assert.That(_minQueue.Top(), Is.EqualTo(2));
        
        _minQueue.Insert(1);
        _minQueue.Insert(6);
        Assert.That(_minQueue.Top(), Is.EqualTo(1));
        
        _minQueue.RemoveTop(); // should remove 1
        Assert.That(_minQueue.Top(), Is.EqualTo(2));
        
        _minQueue.RemoveTop(); // should remove 2
        Assert.That(_minQueue.Top(), Is.EqualTo(3));
    }
    
    [Test]
    public void MaxQueue_OrdersLargestFirst()
    {
        _maxQueue.Insert(3);
        _maxQueue.Insert(4);
        _maxQueue.Insert(2);
        Assert.That(_maxQueue.Top(), Is.EqualTo(4));
        
        _maxQueue.Insert(5);
        _maxQueue.Insert(1);
        Assert.That(_maxQueue.Top(), Is.EqualTo(5));
        
        _maxQueue.RemoveTop(); // should remove 5
        Assert.That(_maxQueue.Top(), Is.EqualTo(4));
        
        _maxQueue.RemoveTop(); // should remove 4
        Assert.That(_maxQueue.Top(), Is.EqualTo(3));
    }

    [Test]
    public void Queue_HandlesDuplicates()
    {
        _minQueue.Insert(2);
        _minQueue.Insert(3);
        _minQueue.Insert(2);
        _minQueue.Insert(3);
    }
}