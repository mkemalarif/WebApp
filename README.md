1. change appsettingjson connection string to match local value (eg. password, users) but keep the database name
2. create database so it can run the migration (create database --databasename) with the same value in appsettingjson
3. make sure that startup project is webapplication.API, open package manager console and change default project to webapplication.Repository and execute command update-database
