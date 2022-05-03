# Logger

The logger is used to log the application. It is used to log the errors and the information.
Into the ```appsettings.json``` you can set several parameters, you can set loggers levels for example.  

```json
"Logging": {
	"LogLevel": {
	// The values can be: "Debug", "Information", "Warning", "Error"
	"Default": "Warning", // Default log level for all loggers if not specified
	"Program": "Information", // Log level for the logger "Program" (initialisation of the application)) 
	"Microsoft.AspNetCore": "Warning"
	"AsyncServer": "Information", // Log level for the "Server"
	// {...}
	}
}
```

