namespace Enums
{
    public enum CupStatus
    {
        Despawned = -1,
        Making,
        WaitForTransfer,
        WaitForPackaging,
    }
    /// <summary>
    /// Four directions of the screen
    /// </summary>
    public enum Direction
    {
        None = -1,
        North,
        East,
        South,
        West
    }
    /// <summary>
    /// Type of containers
    /// </summary>
    public enum CupType
    {
        CoffeeCup = 0,
        Bottle
    }
    /// <summary>
    /// The status of the order
    /// Waiting: Order is not shown to the player yet
    /// Making: Order is shown to the player
    /// Finished: The player finished the order
    /// </summary>
    public enum OrderStatus
    {

        Waiting = 0,
        Making,
        Finished
    }
}