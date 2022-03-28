namespace RaceManager.Communication
{
    /// <summary>
    /// Type of message send and recive.
    /// </summary>
    public enum IMessageType
    {
        CONNECTION,
        BOATLISTREQUEST,
        DISCONNECTION,
        PLAYERINFO,
        BOATSELECT,
        BOATLISTREQUEST,
        ENDRACE,
        RACELISTUPDATE // donner la liste des courses et aussi avec les liens avec les bateaux
    }

    public enum OMessageType
    {
        CONNECTION,
        DISCONNECTION,
        INITRACE,
        ENVIRONMENTINFO,  
        BOATSELECTED,
        BOATLIST,
        ENDRACE,
        RACELISTSEND
    }
}
