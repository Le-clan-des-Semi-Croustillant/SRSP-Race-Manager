namespace RaceManager.Communication
{
    /// <summary>
    /// Type of message send and recive.
    /// </summary>
    public enum IMessageType
    {
        /// <summary>
        /// Type message input (recive) <see cref="IMessageType"/>
        /// </summary>
        CONNECTION,
        DISCONNECTION ,
        PLAYERINFO,
        BOATSELECT,
        BOATLISTREQUEST,
        ENDRACE
    }

    public enum OMessageType
    {
        /// <summary>
        /// Type message output (send) <see cref="OMessageType"/>
        /// </summary>
        CONNECTION,
        DISCONNECTION,
        INITRACE,
        ENVIRONMENTINFO,    
        BOATLIST,
        ENDRACE
    }
}
