# Intelligent Reach API Test  


# Introduction

This simplified Solution is built of three projects,
 - ApiTest - This houses a ProductsController we want to build out.
 - ApiTest.Contracts - This project contains all the relevant POCO's that we return or take from the Controller.
 - ApiTest.Entity - This is the database project that houses the database and database objects - made with Entity Framework

Note: Here we are using an InMemory Database for simplicity so if you stop and relaunch the application all data is lost - this is expected.

# Your Task

Fill out the 4 methods in ProductsController
Design the endpoints how you would like them to be in terms of validation, pattern, etc. Use best practices.

 - You may change anything you like while doing so and add any classes/services/projects you need.
 - Do not change the routes for the endpoints or the contracts.
 - An InMemory DB Context is provided already to save, update, and get products. Feel free to change this as desired.
 - Please use GIT and commit your code as you would like it to be.
 - Return the test without the bin/obj folders to andikat.jacobdennis@searchspring.com with the code zipped or in a link to a github.
 - In the email returning the test please send with it with one of your favourite TV shows.

# How the endpoints should work

POST - CreateProduct
 - The CreateProduct should save the product into the InMemory Context when called.
 - It should fail if the product already exists.
 - It should set Created and LastUpdated properties to Now regardless of what is passed in.

GET - GetProduct
 - This should return the product with the matching Id
 - This should return a 404 NotFound Result when there is no matching Id.

GET - GetProducts
 - This should return all products created so far

PATCH - UpdateProduct
 - This should update the product with the matching id from the route
 - This should not be able to update Id or Created or LastUpdated properties
 - If a change is made LastUpdated should be set to Now.

# Extra's

Please only spend an hour or two on this test,
You may spend as much time as you like but if you get finished early you might want to extend the API in the following ways

GET - GetProducts - Could have optional pagination.
GET - GetProducts - Could have optional filtering for products recently updated using products LastUpdated property.
POST/PATCH - To create a Hash of the product and store it in the Hash field.
Add Unit Tests
