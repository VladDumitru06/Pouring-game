
using Enums;
public class Order
{
    /// <summary>
    /// The type of cup required for the order
    /// </summary>
    public CupType cupType;
    /// <summary>
    /// The current status of the order
    /// </summary>
    public OrderStatus orderStatus;
    /// <summary>
    /// Capacity of the order
    /// </summary>
    public int capacity;
    /// <summary>
    /// How long it takes until the order should be ready
    /// </summary>
    public int timeLimit;
    public Order() { }
    public Order(CupType cupType,OrderStatus orderStatus,int capacity,int timeLimit)
    {
        this.cupType = cupType;
        this.orderStatus = orderStatus;
        this.capacity = capacity;
        this.timeLimit = timeLimit;
    }
}
