# Developper Documentation

At your left, you can find the API documentation. It is generated from the source code with docfx. It contains the description of the source code and the documentation of the functions.

## Environment and dependencies

This project was made on Visual Studio 2022 using .Net 6.0 .
Authentication provider is auth0 (https://auth0.com/).

## Serveur API documentation

[Here is some specifications for understanding I/O of the tcp socket of the RaceManager.](~/misc/API_serveur.zip)  


## Overview  

  

| MessageType Entrée | description | Json reçu | MessageType Sortie | description |
| -----------     | ----------- | ----------- |  ----------- | ----------- | 
| BOATLISTREQUEST | Reçois une demande pour la liste des bateaux et des polaires existants |  `{ "TypeMessage" : "BOATLISTREQUEST" }` | BOATLIST | Envoie du fichier data.json et des fichiers contenus dans boat et pol |
| RACELISTUPDATE | Reçois une demande pour la liste des courses | `{ "TypeMessage" : "RACELISTUPDATE" }` | RACELIST | Envoie du fichier data.json et des fichiers contenus dans race |