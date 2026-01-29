# ExtensivSharp

A C# client library for the [Extensiv](https://extensiv.com/) (formerly 3PL Central) Warehouse Management System REST API.

## Features

- OAuth authentication with Extensiv's auth server
- Strongly-typed request/response models
- Fluent RQL (Resource Query Language) query builder
- Support for orders, inventory, items, and receivers endpoints
- Built for dependency injection with `IHttpClientFactory`

## Requirements

- .NET 10.0 or later
- Extensiv API credentials (API key and user login)

## Installation

Add a reference to the project or include it in your solution.

## Dependencies

- `Microsoft.Extensions.Http` (v9.0.0)
- `Newtonsoft.Json` (v13.0.3)

## Quick Start

### Authentication

```csharp
using ExtensivSharp.Services;
using ExtensivSharp.Models.Auth;

var authRequest = new ExtensivAuthRequest
{
    Key = "your-base64-encoded-api-key",
    UserId = "your-user-login"
};

var authResponse = await AuthenticationService.GetAuthenticationKey(authRequest);
string token = authResponse.AccessToken;
```

### Fetching Orders

```csharp
using ExtensivSharp.Endpoints.Orders;

var getOrders = new GET_Orders
{
    AuthorizationToken = token,
    PageSize = 50,
    PageNumber = 1,
    Detail = SpecifyDetailType.All
};

var result = await getOrders.GetAsync(httpClientFactory);

if (result.Success)
{
    foreach (var order in result.Data.ResourceList)
    {
        Console.WriteLine($"Order: {order.ReferenceNum}");
    }
}
```

### Using the RQL Query Builder

The library includes a fluent query builder for Extensiv's Resource Query Language:

```csharp
using ExtensivSharp.RQL;

var query = new RqlQueryBuilder()
    .Where("Status", "==", "Open")
    .Where("CreationDate", ">=", "2024-01-01")
    .In("Facility", "WH1", "WH2", "WH3")
    .HasValue("ShipDate", false)
    .Build();

var getOrders = new GET_Orders
{
    AuthorizationToken = token,
    RqlFilter = query
};
```

**Available RQL Methods:**
- `Where(field, operator, value)` - Add an AND condition
- `Or(field, operator, value)` - Add an OR condition
- `In(field, values...)` - Match any of the provided values
- `NotIn(field, values...)` - Exclude the provided values
- `HasValue(field, bool)` - Check if field has/doesn't have a value

## Available Endpoints

### Orders
| Class | Description |
|-------|-------------|
| `GET_Orders` | Retrieve a list of orders with filtering and pagination |
| `GET_Order` | Get a single order by ID |
| `GET_OrderByReferenceNumber` | Get an order by reference number |
| `GET_OrderItem` | Get order line items |
| `POST_Order` | Create a new order |
| `PUT_Order` | Update an existing order |
| `PUT_OrderItem` | Update order line items |
| `PUT_Allocate` | Allocate inventory to an order |
| `PUT_Deallocate` | Deallocate inventory from an order |
| `DELETE_OrderItem` | Remove an order line item |

### Inventory
| Class | Description |
|-------|-------------|
| `GET_StockSummaries` | Get inventory stock summaries |
| `GET_PurchaseOrders` | Retrieve purchase orders |
| `GET_Receivers` | Get receiver records |
| `GET_ReceiverItems` | Get items on a receiver |
| `GET_ReceiveItems` | Get received items |
| `PUT_UpdateSingleInventoryItems` | Update inventory item details |

### Items
| Class | Description |
|-------|-------------|
| `GET_Items` | Retrieve item master data |

## Project Structure

```
ExtensivSharp/
├── Endpoints/
│   ├── Orders/        # Order-related API endpoints
│   ├── Inventory/     # Inventory and receiver endpoints
│   └── Items/         # Item master endpoints
├── Models/
│   ├── Auth/          # Authentication models
│   ├── Order/         # Order data models
│   ├── Inventory/     # Inventory models
│   ├── Items/         # Item models
│   ├── Receivers/     # Receiver models
│   ├── Generic/       # Shared identifier types
│   ├── Helper/        # API result wrapper and utilities
│   └── Webhooks/      # Webhook payload models
├── RQL/
│   └── RqlQueryBuilder.cs  # Fluent RQL query builder
└── Services/
    └── AuthenticationService.cs  # OAuth token generation
```

## Response Handling

All endpoint methods return an `ExtensivApiResult<T>` wrapper:

```csharp
public class ExtensivApiResult<T>
{
    public bool Success { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Etag { get; set; }
    public T? Data { get; set; }
}
```

## API Documentation

For full API documentation, refer to the [Extensiv API Reference](https://developer.extensiv.com/).

## License

MIT License
