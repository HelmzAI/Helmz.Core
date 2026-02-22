namespace Helmz.Core.Protocol;

/// <summary>
/// Defines the types of messages in the Helmz protocol.
/// </summary>
public enum MessageType
{
    /// <summary>
    /// A key exchange message for establishing end-to-end encryption.
    /// </summary>
    KeyExchange = 0,

    /// <summary>
    /// A command sent from the mobile client to the daemon.
    /// </summary>
    Command = 1,

    /// <summary>
    /// Output streamed from the daemon back to the mobile client.
    /// </summary>
    Output = 2,

    /// <summary>
    /// A request from the daemon asking for approval to perform an action.
    /// </summary>
    ActionRequest = 3,

    /// <summary>
    /// A response from the mobile client approving or denying an action.
    /// </summary>
    ActionResponse = 4,

    /// <summary>
    /// A keep-alive heartbeat message.
    /// </summary>
    Heartbeat = 5,

    /// <summary>
    /// An error notification message.
    /// </summary>
    Error = 6,

    /// <summary>
    /// A session status update message.
    /// </summary>
    SessionStatus = 7
}
