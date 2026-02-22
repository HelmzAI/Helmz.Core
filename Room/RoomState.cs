namespace Helmz.Core.Room;

/// <summary>
/// Defines the roles a member can have in a room.
/// </summary>
public enum RoomMemberRole
{
    /// <summary>
    /// The daemon process that executes commands.
    /// </summary>
    Daemon,

    /// <summary>
    /// The mobile client that sends commands and approves actions.
    /// </summary>
    Mobile
}

/// <summary>
/// Defines the lifecycle states of a room.
/// </summary>
public enum RoomStatus
{
    /// <summary>
    /// The room is waiting for the second peer to join.
    /// </summary>
    WaitingForPeer,

    /// <summary>
    /// Both peers are connected and the room is active.
    /// </summary>
    Active,

    /// <summary>
    /// The room has been closed.
    /// </summary>
    Closed
}

/// <summary>
/// Represents the state of a pairing room connecting a daemon and mobile client.
/// </summary>
public sealed class RoomState
{
    /// <summary>
    /// Gets the unique identifier for this room.
    /// </summary>
    public required string RoomId { get; init; }

    /// <summary>
    /// Gets the pair code used to join this room.
    /// </summary>
    public required PairCode PairCode { get; init; }

    /// <summary>
    /// Gets or sets the current status of this room.
    /// </summary>
    public RoomStatus Status { get; set; } = RoomStatus.WaitingForPeer;

    /// <summary>
    /// Gets the UTC timestamp when this room was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
}
