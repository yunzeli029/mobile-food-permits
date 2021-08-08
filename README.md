<p align="center">
  <a href="" rel="noopener">
 <img width=200px height=200px src="https://i.imgur.com/6wj0hh6.jpg" alt="Project logo"></a>
</p>

<h3 align="center">Mobile food permits service</h3>

---


## 📝 Table of Contents

- [About](#about)
- [Getting Started](#getting_started)
- [Examples](#example)
- [Built Using](#built_using)
- [TODO](./TODO.md)

## 🧐 About <a name = "about"></a>
 A backend service that provides access to all mobile food permits (food trucks) - request, expired, suspended or approved.


## Definitions
|Type            | Description                                                         |
|----------------|---------------------------------------------------------------------|
|ItemValueFilter | A type of filter to filter items by values of FoodPermit properties |
|ItemGeoFilter   | A geo filter to filter items by insecting with a Circle             |

## 🏁 Getting Started <a name = "getting_started"></a>

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

```
- Docker
```
Please ensure you have Docker installed, running with Linux containers.

### Installing

The food permit service is dependant on MobileFoodPermits.Service.csproj.

To run a successful containerized version of the FoodPermit service, open the root directory where the docker-compose.yml resides. Open a terminal and run the below command

```
docker-compose up --build
```

if this command had already been run previously and you do not require a rebuild simply run the commmand

```
docker-compose up
```

### Run with own data file

The default data file is stored in data/Mobile_Food_Permit_Map.csv. If you want to use own file, you will need to store the file in the data folder and update the FileSettings:FileName in src\MobileFoodPermits.Service\appsettings.json file with your file name. 

Note: If you want to reference any file that is not stored in data folder, you need to update the volumes in docker-compose.yml.

### Examples <a name = "example"></a>

- Get all shortNames

```
curl --location --request GET "http://localhost:5000/api/food-permits-shortname"
```

- Filter By ShortNames
```
curl --location --request POST "http://localhost:5000/api/food-permits/search" \
--header "Content-Type: application/json" \
--data-raw '{
  "Filter":{
      "shortName": "APT",
      "values":["Izzy", "Datam"],
      "comparison": "contains"
  }
}'
```

- Filter By ShortNames with Equals Operation
```
curl --location --request POST "http://localhost:5000/api/food-permits/search" \
--header "Content-Type: application/json" \
--data-raw '{
  "Filter":{
      "shortName": "ST",
      "values":["APPROVED", "Expired"],
      "comparison": "equals"
  }
}'
```

- Filter By Geo

```
curl --location --request POST "http://localhost:5000/api/food-permits/search" \
--header "Content-Type: application/json" \
--data-raw '{
    "Filter":{
        "Latitude": 37.78844616,
        "Longitude":-122.3986412,
        "Radius": 50
    }
}'
```

## ⛏️ Built Using <a name = "built_using"></a>

- [NetTopologySuite](https://github.com/NetTopologySuite/NetTopologySuite) - GIS solution
- [FluentValidation](https://fluentvalidation.net/) - Build strongly-typed validation rules
- [LazyCache](https://github.com/alastairtree/LazyCache) -  In-memory caching service

## ✍️ Authors <a name = "authors"></a>

- Eric - Idea & Initial work