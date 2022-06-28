# StoreAPI

## Topic 

	API's

follow along with me in the LinkedIn Learning Course
[Here](https://www.linkedin.com/learning/building-web-apis-with-asp-dot-net-core-in-dot-net-6/rest-basics?autoSkip=true&autoplay=true&resume=false)

Tech
- .NET6
- C#
- REST
- MVC style
- Entity Framework (ORM)

Testing your API

- Postman [get it here](https://www.postman.com/downloads/)
- Bowser Dev Tools (ie: Firefox, Edge, Chrome)
- Fiddler, a proxy [get it here](https://www.telerik.com/fiddler)

## Design notes
___

Routing using attributes

| Atrribute | Description |
| --- | --- |
| [Route("/products")] | URL to call the API |
Atrribute	Description
[Route("/products")]	URL to call the API
[Route("/products/{id}")]	Controller action parameter is taken from the URL
[R
| [Route("/products/{id}")] | Controller action parameter is taken from the URL |
| [Route("/products/{id?}")] | Optional controller action used from URL |
| [Route("/[controller]")] | Use controller name in URL |



## Extra Notes
___

REST ?
- Is a design concept
- Is built on top of HTTP
- Using URIs to access a resource
- Uses HTTP verbs for operations
	
REST Constraints

1. Uniform interface
2. Client-server (independant from one another)
3. Stateless
4. Cacheable
5. Layered system
6. Code on demand

| HTTP Verb | Function |
| --- | --- |
| GET | Read data |
| POST | Create new data |
| PUT | Update existing data |
| DELETE | Delete existing data |

Model Bindings

- [FromBody], Data from the body of the HTTP request, mostly POST / PUT
- [FromRoute], Data from the route template
- [FromQuery], Data from the URL