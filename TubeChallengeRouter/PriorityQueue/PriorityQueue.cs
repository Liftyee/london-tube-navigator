using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Xml.Serialization;

namespace PriorityQueue;

public enum Priority
{
    Smallest,
    Largest
}

public sealed class PriorityQueue<T> where T : IComparable<T>
{
    private int _nodeCount;
    private T[] _nodes; // this array is used like a binary tree: node at index N has left child 2N and right child 2N+1
    private readonly Priority _priority;
    public int Count => _nodeCount;
    
    public PriorityQueue(int size, Priority prio)
    {
        _nodes = new T[size+1]; // add one because of our dummy first element
        _priority = prio;
        _nodeCount = 0;
        _nodes[0] = default(T); // the first element is not used in our indexing system
    }

    // Insert an item into the queue.
    public void Insert(T item)
    {
        if (_nodeCount == _nodes.Length - 1)
        {
            throw new InvalidOperationException("Cannot insert into full queue");
        }
        _nodes[_nodeCount + 1] = item;
        _nodeCount++;
        push_up(Count);
    }

    // Pop the top item from the queue (return and delete).
    public T Pop()
    {
        if (_nodeCount == 0)
        {
            throw new InvalidOperationException("Cannot remove from empty queue");
        }
        T top = Top();
        SwapIndices(Count, 1);
        _nodes[Count] = default(T);
        _nodeCount--;
        push_down(1);
        return top;
    }

    // Recursive method to cause items in the heap to "float up" to their correct position.
    private void push_up(int currentPosition)
    {
        if (currentPosition == 1)
        {
            return;
        }

        int parentPosition = currentPosition / 2; // the FLOOR of integer division rounds down to give us the right node
        if (OutOfOrder(_nodes[currentPosition], _nodes[parentPosition]))
        {
            SwapIndices(currentPosition, parentPosition);
            push_up(parentPosition);
        }
    }

    // Recursive method to cause items in the heap to "sink down" to their correct position.
    private void push_down(int currentPosition)
    {
        int leftPosition = currentPosition * 2;
        if (leftPosition > Count)
        {
            return; // if the left pos is out of bounds, the right will too (we are at a leaf node)
        }

        int rightPosition = currentPosition * 2 + 1;
        int targetPosition = leftPosition;
        if (rightPosition <= Count && OutOfOrder(_nodes[rightPosition], _nodes[leftPosition]))
        {
            targetPosition = rightPosition;
        }
        
        if (OutOfOrder(_nodes[targetPosition], _nodes[currentPosition]))
        {
            SwapIndices(targetPosition, currentPosition);
            push_down(targetPosition);
        }
    }

    // Compare two heap nodes to see whether they are out of order.
    private bool OutOfOrder(T node1, T node2)
    {
        // Whether they are in order depends on the priority setting of the queue.
        if (_priority == Priority.Largest)
        {
            return node1.CompareTo(node2) > 0;
        }
        else
        {
            return node1.CompareTo(node2) < 0;
        }
    }
    
    // Swap two nodes in the heap, given their indices.
    private void SwapIndices(int pos1, int pos2)
    {
        T temp = _nodes[pos1];
        _nodes[pos1] = _nodes[pos2];
        _nodes[pos2] = temp;
    }
    
    // Get first element of queue without deleting
    public T Top()
    {
        if (_nodeCount == 0)
        {
            throw new InvalidOperationException("Cannot get top of empty queue");
        }
        return _nodes[1];
    }
}