namespace RaceManager.Communication
{
    /// <summary>
    /// Type of message send and recive.
    /// </summary>
    public enum IMessageType
    {
        CONNECTION,
        DISCONNECTION ,
        PLAYERINFO,
        BOATSELECT,
        BOATLISTREQUEST,
        ENDRACE
    }

    public enum OMessageType
    {
        CONNECTION,
        DISCONNECTION,
        INITRACE,
        ENVIRONMENTINFO,  
        BOATSELECTED,
        BOATLIST,
        ENDRACE
    }
}
