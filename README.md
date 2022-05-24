# WhatsApp Web

The project use divided into three sub-projects:

1. React

2. MVC

3. WEB-API.NET (Web Service)

### React

There are 3 main components in the project:

1. OpenScreen - The first component that being rendered to the screen. This component is responsible on the login experience.

2. RegisterScreen - This component being rendered when the client doesnt have a username and password and would need to register.

3. chatScreen - This compoent responsible on showing to the user all of his contacts and the conversation with them.

This project will run on localhost:3000.

### MVC

The MVC project responsile on reviewing the web app. Each clinet can review our WhatsApp Web by giving it a 1-5 grade and a description.

This project will run on localhost:5161.

### WEB-API.NET

This is the web service, based on WEB-API .NET. and communicate with a localDB. Http queries can be sent and be responded by the service.

Thechnologies:

* JWT - Whenver a user signing in, the Service sends him a JWT token that identifies the specific user.

* SignalR - being used in order to notify every user that a new message had accured or if another user added this specific user to it's contacts.

* Enity Framework - used to communicate with the database.

This project will run on localhost:5028.

### Run Project

Before you run the project please install NodeJS, react-router-dom, react-bootstrap and @microsoft/signalr Then do the following:

1. Clone the project to your local computer.

2. In the React folder, open terminal and enter npm install.

3. Enter npm start in the terminal.

4. Run the MVC project.

5. In the package manager console run update-database in order to create a database.

6. run the WebAPI.NET project.

### Submit

The project being created by:

Adi Aviv 206962904

Guy Ben Razon 209207364

