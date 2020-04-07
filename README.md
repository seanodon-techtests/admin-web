# Technical Test - Admin Management Portal

A very simple MVC application using reusable ViewComponents and vanilla JS/CSS to achieve the goals of the test.

## Steps to install:

1. Import the .bacpac file as a data-tier application using MSSQL Management Studio
2. In the Admin.Web project, set the DefaultConnectionString in appsettings.json to point at the imported database

## Things I did not do as part of the test:

- Logging
- Cache the list of Groups used for the Add Person feature
- Set the project up for localisation (display label strings are hardcoded)
- Thorough validation/error handling
- Integration test the search logic (as it's all occurring at the DB level)
- Automatically search for people as the user was typing (and debouncing the call)
- Add any sort logic to the search results table
- Improve the search capabilities by adding a full-text index over the Person table