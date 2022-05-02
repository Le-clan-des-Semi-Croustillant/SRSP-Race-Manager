# Serveur API documentation

[Here is some specifications for understanding I/O of the tcp socket of the RaceManager.](~/misc/API_serveur.zip)  


## Overview  

  

| MessageType Entrée | description | Json reçu | MessageType Sortie | description |
| -----------     | ----------- | ----------- |  ----------- | ----------- | 
| BOATLISTREQUEST | Reçois une demande pour la liste des bateaux et des polaires existants |  `{ "TypeMessage" : "BOATLISTREQUEST" }` | BOATLIST | Envoie du fichier data.json et des fichiers contenus dans boat et pol |
| RACELISTUPDATE | Reçois une demande pour la liste des courses | `{ "TypeMessage" : "RACELISTUPDATE" }` | RACELIST | Envoie du fichier data.json et des fichiers contenus dans race |


<!-- | MessageType Entrée |  Json reçu |  MessageType Sortie |
| ----------- | ----------- | ----------- |
| BOATLISTREQUEST | { "TypeMessage" : "BOATLISTREQUEST" } |  BOATLIST |
| RACELISTUPDATE  | { "TypeMessage" : "RACELISTUPDATE" }  |  RACELIST | -->
