# NumberGambling

To run the Project:

This Solution uses CodeFirst approach, excuste update-database command to generate a local DB.
Make sure to select "NumberGambling.Infra.Data" project from the Packge Manager Console and to set "NumberGambling.API" Project as a startup project, to avoid errors


Swagger is used to Test the API, Here is an example of request and response:

request body:
{
  "points": 500,
  "number": 6,
  "userId": 8
}

response body:
{
  "account": 14000,
  "status": "Won",
  "points": "+4500",
  "userId": 8
}

NOTE: if the userId doesn't exists the API would Create new user and send the new userId with the response.
