using System;
using System.Net;

namespace Race_Manager.Views.Home
{
    public class Maconfig
    {
        public static void Main(string[] args)
        {
            // Récupérer le nom de l'hôte
            string host = Dns.GetHostName();
            Console.WriteLine("Le nom de l'hôte est :" + host);
            // Récupérer l'adresse IP
            string ip = Dns.GetHostByName(host).AddressList[0].ToString();
            Console.WriteLine("Mon adresse IP est :" + ip);
        }
    }
}



  
