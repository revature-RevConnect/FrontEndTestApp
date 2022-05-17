# FrontEndTestApp
Dan's testing frontend for P3 as reference

Backend API in C# with EF 

FrontEnd UI in Angular

To actually use and run this the user will need to implement their own connectionstring to a database in the API, run the migrations to set up database models, as well as set the Authority and Audience to a registered API with Auth0

On the Frontend a url will have to be specified for the api service, this should be wherever you host your api
In the appModule.ts file all of the paths under the Auth Module will need to be set to a registered APP and API from Auth0, following the quickstarts will give you this information after you create and app in Auth0

You will also need to run    npm install @auth0/auth0-angular   to get the auth0 modules 

Following the quickstarts for an App and and API in Auth0 should walk you through the basic set ups for getting this information.

Besides all that these files can be used as references for people trying to get a frontend and backend set up and want some references to look at and compare against
