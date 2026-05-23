using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities: "low"(1), "high"(3), "medium"(2)
    // Expected Result: Dequeue returns "high" first, then "medium", then "low"
    // Defect(s) Found: Three bugs found in Dequeue:
    //   Bug 1 - Loop used Count-1 so the last item in the list was never checked
    //   Bug 2 - Used >= instead of > so equal-priority items violated FIFO order
    //   Bug 3 - RemoveAt was missing so items were never actually removed from the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 3);
        priorityQueue.Enqueue("medium", 2);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items where two share the highest priority:
    //           "first"(5), "second"(5), "third"(1)
    // Expected Result: "first" is dequeued before "second" because it arrived first (FIFO among equals)
    // Defect(s) Found: The >= operator caused "second" to be selected over "first"
    //                  when priorities were equal, violating the FIFO rule. Fixed with >.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 1);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty PriorityQueue
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: No defect. Exception was thrown correctly.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Highest priority item is the LAST one enqueued: "a"(1), "b"(2), "c"(5)
    // Expected Result: "c" is dequeued first
    // Defect(s) Found: Original loop used Count-1 which skipped the last element entirely.
    //                  This meant "c" (the highest priority item) was never found.
    //                  Fixed by changing loop condition from Count-1 to Count.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 2);
        priorityQueue.Enqueue("c", 5);

        Assert.AreEqual("c", priorityQueue.Dequeue());
    }
}