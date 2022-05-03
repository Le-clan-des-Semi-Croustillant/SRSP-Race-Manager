# Authentication provider (Auth0)
## Create your own authentication provider

1. [Create a new Auth0 account](https://auth0.com/signup) if you don't have one  

2. [Create a new app ](https://manage.auth0.com/#/applications) (regular wab application) in your Auth0 account with the name you want to use for your application (we recommend naming your application with the name of your domain).  

3. Go in your new app settings and note the `Client ID` and `Domain`, you will need them later.  

4. Still in your new app settings, go to Application URL and enter callbacks urls (ex: `http://localhost:5078/callback`) and logout urls (ex: `http://localhost:5078/`) and save settings.  

5. Create a new API with name `rm-perm` and `https://racemanager` as identifier.  

6. Go in the API settings and turn on `Enable RBAC` and `Add Permissions in the Access Token`  

7. Add a new permission in your API, enter `access:rm` as scope and the description you want.  

8. Go in User Management section then in Roles. Create a new one named `RaceManager`   
 
9. Click on this new role and go in permission section, then add permission and select `access:rm` of `rm-perm`  

   
## Use the brand new authentication provider
1. Go in `appsettings.json` and add these lines
```json
"Auth0": {
	"Domain": "<THE AUTH0 DOMAINE NAME>",
    "ClientId": "THE AUTH0 CLIENT ID",
    "Audience": "https://racemanager"
  }
```
2. In the Auth0 database you can attach the `RaceManager` to any user for giving administrator access to the Race Manager.


See the [auth0 documentation](https://benjaminvertonghen.medium.com/role-based-acces-control-with-blazor-and-auth0-i-ffd9656e6f01) for more information about the authentication provider.
