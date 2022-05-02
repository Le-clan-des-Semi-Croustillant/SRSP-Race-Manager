# Welcome to the developer documentation.
## Server data specification
Check the [server data specification page](serverapi.md) 

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

## Logger
```appsetting.json``` on file off the root of the project
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Program": "Information",
      "AsyncServer": "Information",
      "Settings": "Information",
      "ServerHub": "Warning",
      "BoatTypesManagement": "Warning",
      "JsonManage": null,
      "LocaleManager": null,
      "BoatType": null,
      "Polar": null,
      "RealField": null,
      "BoatTypeField": null,
      "FileManageData": null,
      "BoatTypesListHub": null,
      "RealFieldHub": null,
      
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Auth0": {
    "Domain": "lcsc.eu.auth0.com",
    "ClientId": "qGMgxqmeGn2OpbCD3OQGkJI4XDkUwDSv",
    "Audience": "https://racemanager"

  }
}```