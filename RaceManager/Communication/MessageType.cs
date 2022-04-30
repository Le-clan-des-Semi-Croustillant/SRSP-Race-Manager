namespace RaceManager.Communication
{
    /// <summary>
    /// Type of message recive for an exchange with the customer
    /// </summary>
    public enum IMessageType
    {
        CONNECTION,
        DISCONNECTION,
        PLAYERINFO,
        BOATSELECT,
        BOATLISTREQUEST,
        ENDRACE,
        RACELISTUPDATE
    }

    /// <summary>
    /// Not used here
    /// </summary>
    public enum OMessageType
    {
        CONNECTION,
        DISCONNECTION,
        INITRACE,
        ENVIRONMENTINFO,  
        BOATSELECTED,
        BOATLIST,
        ENDRACE,
        RACELIST
    }
}
