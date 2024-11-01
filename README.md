# Getting Started with Create React App

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.\
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can’t go back!**

If you aren’t satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you’re on your own.

You don’t have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn’t feel obligated to use this feature. However we understand that this tool wouldn’t be useful if you couldn’t customize it when you are ready for it.

## Setting Up the Backend with .NET
### `Prerequisites`
    Make sure you have .NET SDK installed on your machine.
    Install SQL Server Management Studio (SSMS).


    Connecting to SQL Server with SSMS
### `Open SQL Server Management Studio :-`
### Connect to the Server:

In the "Connect to Server" dialog, enter your server name. If you’re running it locally, you can use localhost or .\SQLEXPRESS.
Choose the authentication method (Windows Authentication or SQL Server Authentication) and provide credentials if necessary.

    Create a Database (if needed):
    Right-click on the "Databases" node in Object Explorer and select "New Database."
    Enter a name for your database and click "OK."

### Starting the .NET Backend Service
### Open your .NET project in Visual Studio or your preferred IDE.
### Configure the Database Connection:
Open the appsettings.json file in your project:-
Update the connection string to point to your SQL Server database. For example:

     "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;"
    }
### Run Migrations (if using Entity Framework):
### Open a terminal or command prompt

    dotnet ef database update
### Start the Backend Service:
### In your IDE, run the project. If using the command line, execute:    
    dotnet run

### The backend service should now be running, typically at [http://localhost:5046/swagger/index.html]

## Learn More

You can learn more in the [Create React App documentation](https://facebook.github.io/create-react-app/docs/getting-started).

To learn React, check out the [React documentation](https://reactjs.org/).
