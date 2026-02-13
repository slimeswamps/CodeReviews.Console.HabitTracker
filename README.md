# Habit Tracker
Console based C# application using ADO.NET to created CRUD operations against an SQLite database.

Project from: [C# Academy](https://thecsharpacademy.com/)

## Requirements:
- [x] This is an application where you’ll log occurrences of a habit.
- [x] This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)
- [x] Users need to be able to input the date of the occurrence of the habit
- [x] The application should store and retrieve data from a real database
- [x] When the application starts, it should create a sqlite database, if one isn’t present.
- [x] It should also create a table in the database, where the habit will be logged.
- [x] The users should be able to insert, delete, update and view their logged habit.
- [x] You should handle all possible errors so that the application never crashes.
- [x] You can only interact with the database using ADO.NET. You can’t use mappers such as Entity Framework or Dapper.
- [x] Follow the DRY Principle, and avoid code repetition.
- [x] Your project needs to contain a Read Me file where you'll explain how your app works and tell a little bit about your thought progress.

## Features:
* Database
  - Using a SQLite database
  - If the database doesn't exist it is created at the start

* A text based UI where users type to choose a option
  
    <img width="376" height="192" alt="Main menu habit tracker" src="https://github.com/user-attachments/assets/155078c3-d838-40b5-bc93-7ecc9085424d" />

* Viewing records
  
    <img width="547" height="202" alt="viewrecords habit tracker" src="https://github.com/user-attachments/assets/1efbc87f-a43e-485a-810f-109c8f2a7ecf" />
  
  - Creates a list with all the records in the database

* Creating new record
  
    <img width="791" height="162" alt="createrecord habit tracker" src="https://github.com/user-attachments/assets/be59c3da-badb-437d-a6d2-c2c559dc5e90" />
    
  - Asks user for number of glasses drank
  - Automatically gets the date
 
* Updating a record
  
    <img width="653" height="353" alt="updaterecord habit tracker" src="https://github.com/user-attachments/assets/0cd6f92f-2ac8-4ce1-92a4-774ffae42d51" />
    
  - Asks the user which record to update by entering the **ID**
  - Asking the user to enter the corrected number of glasses drank
 
* Deleting a record
  
    <img width="642" height="275" alt="image" src="https://github.com/user-attachments/assets/82755861-4e2d-460d-b0da-5bdf3c0ef655" />
    
  - Asks user which record to delete by entering the **ID**

## My Thoughts:
* Challenges
  - I really enjoyed this project and using a database with C# to store data so it can be recalled even when the application is closed and reopened
  - I had to learn how to use ADO.NET to interact with a database
  - I was quite challenged by DateTime as I only need the date without the time but I was able to use the [documentation](https://learn.microsoft.com/en-us/dotnet/api/?view=net-10.0) to find a solution

* What I would improve
  - I would like to remake the UI using *Spectre Console* to improve the apperance
  - I would like to allow for multiple habits to be tracked within the table
