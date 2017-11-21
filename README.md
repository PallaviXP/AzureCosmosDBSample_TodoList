
# Important:-

This application runs on Azure cosmos db emulator. You need to set emulator on your machine. The keys present in the web.config file are pointing to emulator local database.
You can point to actual database by changing just emulator keys.

For this example create below document db:-

Create Database id :- todoitemdb
Create collection :- todoitemcollection1
partition key :- /category

Document looks like as below
{
    "id": "3",
    "category": "office",
    "name": "furniture",
    "description": "fix the window issue.",
    "isComplete": false
}



# Web application development with ASP.NET MVC using DocumentDB
This sample shows you how to use the Microsoft Azure DocumentDB service to store and access data from an ASP.NET MVC application hosted on Azure Websites. 

Ref: https://azure.microsoft.com/en-us/documentation/articles/documentdb-dotnet-application/

## Running this sample

perquisites:
	- An active Azure DocumentDB account 
	- Azure SDK for Visual Studio

Retrieve the URI and PRIMARY KEY (or SECONDARY KEY) values from the Keys blade of your DocumentDB account in the Azure Preview portal. 

## About Code:
ASP.NET MVC application that connects to Azure DocumentDB.
