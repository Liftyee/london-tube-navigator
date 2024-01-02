using PriorityQueue;

namespace PriorityQueueTests;

[TestFixture]
public class SizeTests
{
    private PriorityQueue<int> _queue;
    
    [SetUp]
    public void SetUp()
    {
        _queue = new PriorityQueue<int>(10, Priority.Smallest);
    }
    
    [Test]
    public void EmptyQueue_HasSizeZero()
    {
        bool result = _queue.Size() == 0;
        Assert.That(result, "Empty queue should have size 0");
    }
    
    [Test]
    public void InsertingOneItem_IncreasesSize()
    {
        _queue.Insert(1);
        bool result = _queue.Size() == 1;
        Assert.That(result, "Queue should have size 1 after inserting one item");
    }
    
    [Test]
    public void RemovingAllItems_DecreasesSizeToZero()
    {
        _queue.Insert(1);
        _queue.RemoveTop();
        bool result = _queue.Size() == 0;
        Assert.That(result, "Queue should have size 0 after removing all items");
    }
}