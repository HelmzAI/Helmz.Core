namespace Helmz.Core.Room;

public enum RoomMemberRole { Daemon, Mobile }

public enum RoomStatus { WaitingForPeer, Active, Closed }

public sealed class RoomState
{
    public required string RoomId { get; init; }
    public required PairCode PairCode { get; init; }
    public RoomStatus Status { get; set; } = RoomStatus.WaitingForPeer;
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
}
