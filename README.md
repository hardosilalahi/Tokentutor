# Tokentutor
a novel created by to(i)k(i)en

# Authentication JWT API 

[Schema Table](https://dbdiagram.io/d/5e58d174a902a329289b2f95)

## Description
 - Customer Service is private api only user with token can access it  
 - Product Service is public api
 - Auth Service is public api 


## REST SERVICE

### Customer 

| Methods | Path        | Param | Description           |
|---------|-------------|-------|-----------------------|
| POST    | /customer   |       | Create Customer       |
| PUT     | /customer/1 | id    | Update Customer Data  |
| DELETE  | /customer/1 | id    | Delete Customer Data  |
| GET     | /customer/1 | id    | Get Customer By Id    |
| GET     | /customer   |       | Get All Customer Data |


This is example request for create and get all customer data

POST /customer Request
```json
{
    "data": {
        "attributes": {
            "full_name": "johny",
            "username":"doe",
            "email":"john@doe.com",
            "phone_number":"0812345689",
        }
    }
}
```

GET /customer Response 
```json
{
    "message":"success retrieve data",
    "status": true,
    "data": [
        {   "id":1,
            "full_name": "johny",
            "username":"doe",
            "email":"john@doe.com",
            "phone_number":"0812345689",
        },
        {   "id":2,
            "full_name": "johny",
            "username":"doe",
            "email":"john@doe.com",
            "phone_number":"0812345689",
        }
    ]
}    
```

### Product

| Methods | Path        | Param | Description          |
|---------|-------------|-------|----------------------|
| POST    | /product    |       | Create Product       |
| PUT     | /prooduct/1 | id    | Update Product Data  |
| DELETE  | /product/1  | id    | Delete Product Data  |
| GET     | /product/1  | id    | Get Product By Id    |
| GET     | /product    |       | Get All Product Data |


POST /product Request
```json
{
  "data": {
    "attributes": {
        "name": "apple",
        "price": 100000,
    }
  }
}
```

### Auth


| Methods | Path        | Param | Description          |
|---------|-------------|-------|----------------------|
| POST    | /auth       |       | Auth Request         |

```json
{
    "data" : {
        "attributes": {
            "username": "hello",
            "password": "doe"
        }
    }
}
```

## Task 

1. Add package `Microsoft.AspNetCore.Authentication.JwtBearer`
2. Implement JWT authentication 
