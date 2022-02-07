namespace RaceManager.Communication
{
    /// <summary>
    /// Type of message send and recive.
    /// </summary>
    public enum IMessageType
    {
        CONNECTION = 0,
        DISCONNECTION = 1,
        PLAYERINFO = 2,
        BOATSELECT = 3,
        ENDRACE = 4
    }

    public enum OMessageType
    {
        CONNECTION = 0,
        DISCONNECTION = 1,
        INITRACE = 2,
        ENVIRONMENTINFO = 3,
        ENDRACE = 4
    }
}
