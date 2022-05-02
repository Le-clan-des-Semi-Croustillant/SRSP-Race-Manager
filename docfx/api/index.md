# Developper Documentation

At your left, you can find the API documentation. It is generated from the source code with docfx. It contains the description of the source code and the documentation of the functions.

## Environment and dependencies

This project was made on Visual Studio 2022 using .Net 6.0 .
Authentication provider is auth0 (https://auth0.com/).

## Serveur API documentation

[Here is some specifications for understanding I/O of the tcp socket of the RaceManager.](~/misc/API_serveur.zip)    

| MessageType Entrée | description | Json reçu | Json Sortie | description |
| -----------     | ----------- | ----------- |  ----------- | ----------- | 
| BOATLISTREQUEST | Reçois une demande pour la liste des bateaux et des polaires existants |  `{ "TypeMessage" : "BOATLISTREQUEST" }` | [Example of data.json file send by server](~/misc/data.json) | Envoie du fichier data.json et des fichiers contenus dans boat et pol |


## Development choices

We chose to develop the back-end and front-end of the Race Manager but also the Simple simulator with the C# language. For the simple reason that it allows us to help a colleague blocking on a point more easily, indeed if the server part of the Race Manager had been made in Java. Then, it would have been more difficult for us to work efficiently on the Race Manager interface (C#) and the server (Java) at the same time. We also used the Blazor plugin to develop the Race Manager GUI, because it has a very rich and clear documentation, and it allows to have excellent rendering with a lower algorithmic complexity.

The many loggers implemented in the source code allow to see what is going on in the code, so we can debug the program more easily. We used DocFx to generate the documentation, you will find on DocFx a good part of the documentation. However, when we thought it was necessary we added comments in functions, which you can see directly in the source code.

Rather than develop a security portal to manage the connections, we preferred to use an existing service which is **Auth0**. Since we are new to computer security, we thought it would be more useful and secure to use an existing service that is more experienced than us.



## Development track
Here we will list the ways to improve V1 :

-We do not check the integrity of polar files in the Race Manager when a user wants to upload a polar file. It is possible to check this and notify the user, as we have done when the user enters a wrong port number.
-When a user downloads a polar file, he can download malicious code directly to the server, the security aspect can be improved in future versions of the Race Manager.

# Deployment

## To install and run the application on a Linux server :

- Install .NET on linux https://docs.microsoft.com/fr-fr/dotnet/core/install/linux
- Copy the [publish](https://docs.microsoft.com/fr-fr/dotnet/core/deploying/deploy-with-vs?tabs=vs156) files to `/var/www/dotnet/RaceManager/`
- Create the service file
  - sudo nano /etc/systemd/system/RaceManager.service
    ```sh
    [Unit]
    Description=Example .NET Web API App running on CentOS 7

    [Service]
    WorkingDirectory=/var/www/dotnet
    ExecStart=/var/www/dotnet/RaceManager --urls "{host}:{port}"
    #Replace {host} and the {port} by the address you want (http://localhost:5000 or http://example.com:5000) https to configure but possible to launch it in https
    Restart=always
    # Restart service after 10 seconds if the dotnet service crashes:
    RestartSec=10
    KillSignal=SIGINT
    SyslogIdentifier=dotnet-example
    User=root
    Environment=ASPNETCORE_ENVIRONMENT=Production

    [Install]
    WantedBy=multi-user.target
    ```
  - Run the following commands to start the service:
    ```sh
    sudo systemctl enable RaceManager.service #to start the service at system startup
    ```
    ```sh
    sudo systemctl daemon-reload #to reload services
    ```
    ```sh 
    sudo systemctl start RaceManager.service #to start the service
    ```
    ```sh
    sudo systemctl status RaceManager.service #to see the status of the service
    ```
  - To stop the service : 
    ```sh
    sudo systemctl kill RaceManager.service #to force stop the service
    ```
    ```sh
    sudo systemctl stop RaceManager.service #to stop the service
    ```
  - Pour désactiver le service : 
    ```sh
    sudo systemctl disable RaceManager.service #to disable the service
    ```
   - To manually launch the Race Manager:
     ```sh
     /var/www/dotnet/RaceManager --urls "{host}:{port}"
     #Remplacez {host} et le {port} par l'adresse que vous souhaitez (http://localhost:5000 ou http://example.com:5000) https à configuerer mais possible de le lancer en https
     ```
    
    He exist this tutorial for more information about the installation on linux and with Ngix/apache https://docs.microsoft.com/fr-fr/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-6.0

## [To install and run the application on a Windows server : ](https://docs.microsoft.com/fr-fr/aspnet/core/host-and-deploy/?view=aspnetcore-6.0)