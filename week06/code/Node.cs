public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // Only insert if the value is different from the current node (no duplicates)
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing — duplicates are not allowed
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Base case: the current node contains the value
        if (value == Data)
            return true;

        // If value is smaller, search the left subtree
        if (value < Data)
        {
            if (Left is null)
                return false; // Dead end, value not found
            return Left.Contains(value);
        }

        // If value is larger, search the right subtree
        if (Right is null)
            return false; // Dead end, value not found
        return Right.Contains(value);
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Find the height of the left and right subtrees
        int leftHeight = Left is null ? 0 : Left.GetHeight();
        int rightHeight = Right is null ? 0 : Right.GetHeight();

        // Return the larger height plus 1 for the current node
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}