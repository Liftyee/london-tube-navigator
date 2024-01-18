namespace PriorityQueueTests;

[TestFixture]
public class ExceptionTests
{
    private PriorityQueue<int> _queue;
    
    // create a small capacity queue for us to test with
    [SetUp] 
    public void SetUp()
    {
        _queue = new PriorityQueue<int>(3, Priority.Smallest);
    }
    
    [Test]
    public void InsertingIntoFullQueue_ThrowsException()
    {
        _queue.Insert(1);
        _queue.Insert(2);
        _queue.Insert(3);
        Assert.Throws<InvalidOperationException>(() => _queue.Insert(4));
    }
    
    [Test]
    public void RemovingFromEmptyQueue_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => _queue.Pop());
    }

    [Test]
    public void TopOfEmptyQueue_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => _queue.Top());
    }
}