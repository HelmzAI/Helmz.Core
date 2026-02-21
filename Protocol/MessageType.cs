namespace Helmz.Core.Protocol;

public enum MessageType
{
    KeyExchange = 0,
    Command = 1,
    Output = 2,
    ActionRequest = 3,
    ActionResponse = 4,
    Heartbeat = 5,
    Error = 6,
    SessionStatus = 7
}
