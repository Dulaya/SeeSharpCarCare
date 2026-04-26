# See Sharp Car Care
A full-stack C#/.Net and TypeScript/React application for managing automotive work orders.

## Installation
> git clone https://github.com/Dulaya/SeeSharpCarCare.git

After cloning the git repository, open a terminal. In the first terminal, `cd` into the API directory by  `cd SeeSharpCarCare\SeeSharpCarCare.API` Create an `appsettings.Development.json` file in the same directory as `program.cs` in order to connect to database. Make sure a local or cloud database connection is available. 

	// appsettings.Development.json
	{
		"Logging": {
			"LogLevel": {
				"Default": "Information",
				"Microsoft.AspNetCore": "Warning"
			}
		},
			"ConnectionStrings": {
				"DevConnection":"YOUR_DATABASE_CONNECT_STRING_HERE;"
			}
	}

Restore the project `dotnet restore` Build the project `dotnet build` Start the server by running command `dotnet run` Go to http://localhost:5299/swagger/index.html to tests the APIs.

Optional: In another terminal, `cd` into the UI directory by `cd SeeSharpCarCare\SeeSharpCarCare.UI` Before starting the UI development server, the required packages are need to be installed via the command `npm install` From here, start the UI development server by `npm run dev` Note: Node.js and NPM is required to run the UI. Go to http://localhost:5173/ to test UI.

