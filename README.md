# Week 5

This homework includes the fourth task of **REST API** for a simple warehouse management system. 

## Our Goals

Restful api oluşturun
- Daha önce oluşturduğunuz apilerden birini kullanın
- tek bir endpoint ten arama, filtreleme ve sıralama işlemlerini yaptırın.
- apiye ait basit ayarları in memory cache de tutan ve kullanımını sağlayan bir yapı geliştirin
- endpointlerinizden en az birinde response cache mekanizmasını kullanın
- distributed cache olarak redis e yazan ve okuyan bir cache yönetim servisi yazın. sorgu adedi 100 ve üzeri olursa istenilen zaman aralığında cache yazsın ve okusun

## Key Points

- Pagination & Sorting & Filtering used on ContainerController for api/containers/WithParams
	* For Searching, every column checked if it contains SearchQuery

```c

if (!String.IsNullOrEmpty(Params.SearchQuery))
            {
                foreach (var item in query)
                {
                    var columns = item.GetType().GetProperties().ToList();
                    foreach (var column in columns)
                    {

                        if (column.GetValue(item) != null)

                        {
                            var value = column.GetValue(item);
                            bool stringFound = value.ToString().Contains(Params.SearchQuery);
                            if (stringFound)
                                result.Add(item);

                        }

                    }

                }

```

- For Sorting, if the direction is Desc; results ordered descending. Otherwise results ordered Ascending. In this way, the default direction is set to ascending 


```c

 if (!string.IsNullOrWhiteSpace(Params.Sort))
            {


                var entity = typeof(T);

                var property = entity.GetProperty(char.ToUpper(Params.Sort[0]) + Params.Sort.Substring(1).ToLower());


                result = Params.SortingDirection == Common.SortingDirection.DESC
                    ? result.OrderByDescending(x => property.GetValue(x, null)).ToList() 
                    : result.OrderBy(x => property.GetValue(x, null)).ToList();
            }

          

AddRange(result);

```

- For Pagination, Linq parameters used to get right data.


```c

 result = query.Skip((Params.Page - 1) * Params.PageSize).Take(Params.PageSize).ToList();

```

- This project does not include so many parameters in appsettings.json. So, I decided to use memory cache on ProductController for GetProducts
	* Product lists doesn't change so much in warehouses. So, it is suitable for caching them in memory.

```c

if (_memoryCache.TryGetValue("products", out List<Product> productsCache))
            return productsCache;

            var products = productList.OrderBy(p => p.Id).ToList<Product>();
            _memoryCache.Set("products", products, new MemoryCacheEntryOptions { 
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7),
                Priority = CacheItemPriority.High
            });
            return products;

```



- After adding, updating or deleting any product, cache deleted to recreate new cache.

```c
	 if (_memoryCache.TryGetValue("products", out List<Product> productsCache))
                _memoryCache.Remove("products");

```

- ResponseCaching used on ContainerController to cache query of getting containers by weight.


```c
 [ResponseCache(Duration = 1000, Location = ResponseCacheLocation.Any )]
 
```

- Distributed cache created for Stock lists. And caching not used until the count of records more than 100.


```c
 var cachedStocks = _distributedCache.Get("stockList");


            if (cachedStocks == null)
            {
                var stocks = stockList.OrderBy(u => u.ProductId).ToList<Stock>();

                if (stocks.Count >= 100)
                {
                    var cacheOptions = new DistributedCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(30)
                    };

                    _distributedCache.Set("stockList", Encoding.UTF8.GetBytes(stocks.ToString()), cacheOptions);

                }

                return stocks;
            }
            else
            {
                return JsonConvert.DeserializeObject<List<Stock>>(Encoding.UTF8.GetString(cachedStocks));

            }
```

- Cache removed on update, create and delete methods as well.

```c
 _distributedCache.Remove("stockList");
```


## External References

- [Redis Download](https://github.com/microsoftarchive/redis/releases/tag/win-3.0.504)

# Week 4

This homework includes the third task of **REST API** for a simple warehouse management system. 

## Our Goals

Restful api oluşturun
- Daha önce oluşturduğunuz apilerden birini kullanın
- kullanıcı işlemleri için Asp.NET Core Identity altyapısını kullanın
- api de yetkilendirme işlemleri için JWT kullanın
- bir tane result filter oluşturun ve her response da header a verinin oluşturulma/getirilme tarihi saati yazılsın

- **Bonus**
- rol bazlı yapı tanımlayın

## External References
- [Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Naming Convention](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/naming-rules)
- [Authentication And Authorization](https://www.c-sharpcorner.com/article/authentication-and-authorization-in-asp-net-core-web-api-with-json-web-tokens/#:~:text=Authentication%20is%20the%20process%20of,specific%20modules%20in%20an%20application.)
- [Example Project](https://www.youtube.com/watch?v=ZXdFisA_hOY)


# Week 2

This homework includes the second task of **REST API** for a simple warehouse management system. 

## Our Goals
- ilk hafta geliştirdiğiniz api kullanılacaktır.
- Rest standartlarına uygun olmalıdır.
- solid prensiplerine uyulmalıdır.
- Fake servisler geliştirilerek Dependency injection kullanılmalıdır.
- api nizde kullaınılmak üzere extension geliştirin.
- Projede swagger implementasyonu gerçekleştirilmelidir.
- global loglama yapan bir middleware(sadece actiona girildi gibi çok basit düzeyde)
- **Bonus**
- Fake bir kullanıcı giriş sistemi yapın ve custom bir attribute ile bunu kontrol edin.
- global exception middleware i oluşturun.

## Key Points

- Although it has been used on Patika.Dev tutorials, AUTOMAPPER library HAS NOT included on project. This project only includes the features we learned during bootcamp.
There are some other features as it; Fluent Validation, ViewModels, Automapper etc. These features will be implemented during next weeks.

- Created a middleware for global logging. (Middlewares/CustomLoggingMiddleware.cs) There are two different informations that we are logging. 
When the request comes from client, we log request method and request path. Then we wait until progress finish. At the end of progress, we log responded statuscode too.
We create a dependency injection called ILoggerService. With this service, it is possible to log on console or on text file. Maybe another feature like sending sms, email etc.


```c
		 public async Task Invoke(HttpContext context)
		{

			string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
			_loggerService.Log(message);

			// Call the next delegate/middleware in the pipeline
			await _next(context);

				message = "[Request] HTTP "
					+ context.Request.Method + " - "
					+ context.Request.Path
					+ " responded " + context.Response.StatusCode;
			_loggerService.Log(message);


		}

```
- Created AccountController to check log-in with CustomPermission attribute (Role : admin , Password : 1234) For now, we check values with hardcoded password. 
 ```c      
		[HttpGet]
		[CustomPermission("admin")]
		public IActionResult IsLoggedIn(string username, string password)
		{
		   ...

			if(permissions.Any(p => p == username) && password == pass)
			return Ok();
			return Unauthorized();
		}
```
- Global Exception middleware created. Although it is possible to use it with LoggingMiddleware, created seperate middleware to catch exceptions.
If there is an exception during progress, it is going to return status codes we defined. 

 ```c      
		private Task HandleException(HttpContext context, Exception ex)
		{
		   ...

		}
```

- Logger Service created to log actions with different methods (Used dependency injection) This service is created and used instead of console.writeline . 
It makes possible to extend application easily. The default service is logging the actions to text file.
```c
  public interface ILoggerService
		{
			public void Log(string message);
		}
```

```c
 public class TextFileLogger : ILoggerService
	{
		public void Log(string message)
		{
		   ...

		}
	}
```
- StorageService created to assign pallets to locations and manage stocks with different methods (Used dependency injection)
There are two type of warehouse we designed. First one has "Warehouse Storage" Which has racks and places to store containers. 
And the second one is "CrossDocking Storage" which all containers directly goes for shipping. With this service, we decide the location of containers and stock counts.
Warehouse Type never changes, so we define this service singleton.

```c
 public interface IStorageService
	{
			public void Locate(Container container);

		public void AddToStock(Container container);
	}
```

```c
	 public class WarehouseStorage : IStorageService
	{
		private static List<Stock> StockList = DataGenerator.StockList;
		public void AddToStock(Container container)
		{
		   ...
		}

		public void Locate(Container container)
		{
		   ...
		}
	}
```

- CustomContainerValidateExtension added and used for comparing old and new record before being updated

```c
public static void ValidateWith(this Container existingContainer, Container newContainer)
			{
				...
			}
```

- Queries and Commands are moved to seperate classes.


## External References

[Patika Net-Core Module](https://app.patika.dev/moduller/net-core)





# Week 1

## Entities

There are 5 entities I used during the project. 
The short description ;
- **Uom** :
	 * Unit of Measurement; a quantity used as a standard of measurement. 
	 * In this project, UOM used to quantify the container items.
	 * Box(BX), Carton(CTN), Piece(PC), Pack(PK)

- **Rotation** :
	 * Measure the number of times inventory is sold or used in a time period.  
	 * In this project, Rotation will be used to determine where containers should be placed in the warehouse.
	 * Category A, Category B, Category C (CatA > Cat B > Cat C)
	 * Cat A products should be placed easier places to reach which means Cat C products might be at the last position of warehouse

- **Location** :
	 * Locations are the places where containers can be located
	 * rotationId defines the type of location to check rotation availability for containers

- **Product** :
	 *  The product shows the list of materials produced in the facility.
	 * Every product has a rotation which defines the cycle of product.
	 * lifeTime might be used to check expiration date 
	 * isActive can be used to disable checking of that products

- **Containers** :
	 * Containers defines the products we have in our stock. 
	 * A container information should includes; 
	 * unit information (uomId)
	 * quantity of unit (quantity)
	 * product in container (productId)
	 * where it is located (locationId)
	 * weight information (weight)
	 * and creationDate to calculate expiration date (expiration date = creationDate + lifeTime)

## Data Generator
   - Database isn't used in this project.
   - So, I defined some accessible lists here. 
   - It will allow us to access different entities when we need in controllers. 

## Key Points

- Route Names are based on nouns and not verbs.
- Defined all necessary HTTP Methods for all entities (GET, POST, PUT, DELETE, PATCH)
- HTTP status codes returned as it describes [here](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design#get-methods)
- Required fields defined on Entities.
- Created Model Binding both FromBody and FromQuery

Some examples ;

- Listing some records
```c
		//Get all containers by max weight ordered by weight
		//GET api/products/list?maxWeight=100
		[HttpGet("list")]
		public IActionResult GetContainersByMaxWeight([FromQuery] int maxWeight)
		{

			var containers = ContainerList
									.Where(b => b.weight <= maxWeight)
									.OrderBy(b => b.weight)
									.ToList();
			if (containers.Count == 0)
				return NotFound("There is no container lighter than the value entered!");

			return Ok(containers); //http 200
```

- Defining required fields
```c
public class Product
	{
		[Required]
		public int productId { get; set; }

		[Required]
		public string productCode { get; set; }

		public string description { get; set; }
		public int rotationId { get; set; }

		[Required]
		public bool isActive { get; set; }

		public int lifeTime { get; set; }

	}
```
- Returning right http status codes
```c
	public IActionResult CreateUom([FromBody] Uom newUom)
		{
				if (newUom is null) //if the user not send any data, we will return bad request
				return BadRequest("No data entered!");

			
			//check if we already have this uomCode in our list
			var uom = UomList.SingleOrDefault(b => b.uomCode == newUom.uomCode);

		
			if (uom is not null)
				return BadRequest("You already have this uomCode in your list!");


			UomList.Add(newUom);
			return Created("~api/uoms", newUom); //http 201 
		}
```



## External References 
[Microsoft RESTful web API design](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design)

