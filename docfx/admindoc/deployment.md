# Deployment

Available platforms : Windows, Linux (x86 and armhf)

## Local usage :
Just launch the exectuable in the executable directory as a normal app, use `--urls "http://localhost:5000"` if you want to specify the port.

## Linux Server :

1. Install .NET on linux https://docs.microsoft.com/fr-fr/dotnet/core/install/linux
2. Unzip the [last releases](https://github.com/Le-clan-des-Semi-Croustillant/SRSP-Race-Manager/releases/) to `/var/www/dotnet/RaceManager/`
3. You can deploy the application by using a service or by the normal way as detailed below
4. [Set the authentication authority with Auth0](auth0.md)
   
> [!NOTE]
> If you want to deploy the application on arm64 linux, you have to install armhf dependancies.

### Deploy using a service
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
     /var/www/dotnet/RaceManager --urls "{host}:{port}" #launch this commant to /var/www/dotnet/RaceManager
     #Replace {host} and the {port} by the address you want (http://localhost:5000 or http://example.com:5000) https to configure but possible to launch it in https
     ```
    
    He exist this tutorial for more information about the installation on linux and with Ngix/apache https://docs.microsoft.com/fr-fr/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-6.0  

## Deploy on a Windows server : 
See the [Microsoft documentation](https://docs.microsoft.com/fr-fr/aspnet/core/host-and-deploy/?view=aspnetcore-6.0)  
  
