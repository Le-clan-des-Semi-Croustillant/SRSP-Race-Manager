# Developper Documentation

At your left, you can find the API documentation. It is generated from the source code with docfx. It contains the description of the source code and the documentation of the functions.

## Environment and dependencies

This project was made on Visual Studio 2022 using .Net 6.0 as a Blazor Server project (ASP.Net), you will need ASP.Net Core package.
Authentication provider is auth0 (https://auth0.com/).  


> [!WARNING]
> In order to host the Race Manager using auth0, you need to configure the authentication provider. see [Authentication](../admindoc/auth0.md)  

> [!NOTE]
> There is a version without the authentication provider, you can use it to test the application or for local utilisation.

## Documentation

The documentation is generated from the source code with [docfx](https://dotnet.github.io/docfx/index.html). It contains the description of the source code and the documentation of the functions. In the docfx folder you will find 3 scripts:
- `installDocfx.ps1` : to install docfx (administrator rights required)
- `generateDocs.ps1` : to generate the documentation
- `cleanObj.ps1` : to clean the obj folder  
  
> [!NOTE]  
> \- If any script fails, you can try to past the content of this script in powershell  
> \- If for some reason you can't install docfx, you can [install docfx manually](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool).  
> \- If generatedDocs.ps1 fails, you can try to clean the obj folder with cleanObj.ps1.  
> \- If you have any question, please consider the official documentation of [docfx](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html). 


## Serveur API documentation

[Here is some specifications for understanding I/O of the tcp socket of the RaceManager.](~/misc/API_serveur.zip)    

| MessageType Entrée | description | Json reçu | Json Sortie | description |
| -----------     | ----------- | ----------- |  ----------- | ----------- | 
| BOATLISTREQUEST | Reçois une demande pour la liste des bateaux et des polaires existants |  `{ "TypeMessage" : "BOATLISTREQUEST" }` | [Example of data.json file send by server](~/misc/data.json) | Envoie du fichier data.json et des fichiers contenus dans boat et pol |


## Development choices

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; We chose to develop the back-end and front-end of the Race Manager but also the Simple simulator with the C# language. For the simple reason that it allows us to help a colleague blocking on a point more easily, indeed if the server part of the Race Manager had been made in Java. Then, it would have been more difficult for us to work efficiently on the Race Manager interface (C#) and the server (Java) at the same time. We also used the Blazor server framework to develop the Race Manager, because it has a very rich and clear documentation, and it allows to have excellent rendering with a lower algorithmic complexity.  

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The many loggers implemented in the source code allow to see what is going on in the code, so we can debug the program more easily. We used DocFx to generate the documentation, you will find on DocFx a good part of the documentation. However, when we thought it was necessary we added comments in functions, which you can see directly in the source code.  

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Rather than develop a security portal to manage the connections, we preferred to use an existing service which is **Auth0**. Since we are new to computer security, we thought it would be more useful and secure to use an existing service that is more experienced than us.  

> [!NOTE]
> Auth0 is not quite appropriate for our needs, but it is a good choice for a static website authentication service, that's why you will find a [branch without Auth0](https://github.com/Le-clan-des-Semi-Croustillant/SRSP-Race-Manager/tree/simple-autht) and its [prerelease](https://github.com/Le-clan-des-Semi-Croustillant/SRSP-Race-Manager/releases/tag/RaceManagerv1.1).



## Development track
Here we will list the ways to improve V1 :

- We do not check the integrity of polar files in the Race Manager when a user wants to upload a polar file. It is possible to check this and notify the user, as we have done when the user enters a wrong port number.
- When a user downloads a polar file, he can download malicious code directly to the server, the security aspect can be improved in future versions of the Race Manager.