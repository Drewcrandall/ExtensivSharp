# ExtensivSharp

A C# client library for the [Extensiv](https://extensiv.com/) (formerly 3PL Central) Warehouse Management System REST API.

## Features

- OAuth authentication with Extensiv's auth server
- Strongly-typed request/response models
- Fluent RQL (Resource Query Language) query builder
- Full outbound surface: picking, movable units, allocation, load-out, packing and shipping
- Orders, inventory, items, receivers and facility properties
- Built for dependency injection with `IHttpClientFactory`

## Requirements

- .NET 10.0 or later
- Extensiv API credentials (API key and user login)

## Installation

```
dotnet add package ExtensivSharp
```

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
| `POST_OrderItem` | Add a new line item to an existing order |
| `PUT_Order` | Update an existing order |
| `PUT_OrderItem` | Update order line items |
| `PUT_Allocate` | Allocate an order, automatically or from an explicit list of receive items |
| `PUT_OrderItemAllocate` | Allocate a single order item from an explicit list of receive items |
| `PUT_Deallocate` | Deallocate inventory from an order |
| `DELETE_OrderItem` | Remove an order line item |
| `POST_OrderComplete` | Complete an order |
| `POST_OrderConfirm` | Confirm an order, after which it is deemed shipped and immutable |

### Picking
| Class | Description |
|-------|-------------|
| `GET_PickCandidates` | Order-centric list of orders available to pick |
| `GET_PickJobs` | Job-centric list of pick jobs |
| `GET_PickJob` | Get a single pick job |
| `POST_PickJob` | Create a pick job over one or more orders |
| `PUT_PickJob` | Update a pick job |
| `GET_PickList` | Get a job's consolidated pick list, and the ETag that seeds the pick chain |
| `PUT_StartPick` | Mark a pick job started |
| `POST_Pick` | Record a pick against one pick line |
| `POST_Unpick` | Back out a previously recorded pick |
| `POST_Mispick` | Record that what was picked differs from the pick line |
| `PUT_PickItem` | Associate a picker with one pick line |
| `PUT_PickItemAssign` | Mark one pick line assigned |
| `PUT_BatchAssigner` | Assign every pick job in a batch to one user |
| `POST_PickJobPause` | Record a pick-paused event |
| `PUT_PickJobComplete` | Complete a pick job and set its done date |
| `POST_LoadPickItem` | Record a load-out of one pick line |
| `PUT_PickJobLoad` | Load a whole pick job |
| `GET_OrdersByBin` | Get the open orders occupying a bin |

### Movable Units
| Class | Description |
|-------|-------------|
| `GET_Pallets` | List movable units; filter by label with RQL |
| `GET_Pallet` | Get a single movable unit |
| `POST_Pallet` | Create a movable unit |
| `PUT_Pallet` | Update a movable unit |
| `GET_PalletTypes` | List movable unit types |

Movable unit *contents* come from `GET_StockDetails`, not from these. The pallet rels return
metadata only.

### Inventory
| Class | Description |
|-------|-------------|
| `GET_StockDetails` | Inventory by receive item, with track-bys, location and movable unit |
| `GET_StockSummaries` | Inventory summarized by SKU |
| `GET_PurchaseOrders` | Retrieve purchase orders |
| `GET_Receivers` | Get receiver records |
| `GET_ReceiverItems` | Get items on a receiver |
| `GET_ReceiveItems` | Get received items |
| `PUT_Shaker` | Update inventory track-by details (lot number, serial number, expiration date) |

### Packing and Shipping
| Class | Description |
|-------|-------------|
| `GET_Packages` / `GET_Package` | Read an order's packages |
| `POST_Package` | Create a package |
| `PUT_Packages` / `PUT_Package` | Update packages |
| `DELETE_Packages` / `DELETE_Package` | Delete packages |
| `GET_PackageContents` / `GET_PackageContent` | Read a package's contents |
| `POST_PackageContent` | Add contents to a package, with a whole serial array in one call |
| `PUT_PackageContents` / `PUT_PackageContent` | Update package contents |
| `DELETE_PackageContents` / `DELETE_PackageContent` | Delete package contents |
| `PUT_PackagesGenerate` | Generate packages from the order's packaging setup |
| `PUT_PackagesSummarize` | Recalculate package summary information |
| `PUT_PackagesConsolidate` | Consolidate an order's packages into one |
| `GET_PackageUcc128Label` | Render a package's UCC-128 carton label as ZPL |
| `POST_OrderPackStarter` | Mark an order as having started packing |
| `PUT_OrderPackDateSetter` | Set the order's pack-done date to now |
| `POST_OrderPackEvent` | Save a pack event against an order |

### Items
| Class | Description |
|-------|-------------|
| `GET_Items` | Retrieve item master data |
| `GET_Aliases` | Retrieve item aliases |

### Properties
| Class | Description |
|-------|-------------|
| `GET_Facilities` | List facilities, including `CrossCustomerPickEnabled` |
| `GET_LocationsByFacility` | List a facility's locations |
| `GET_Carriers` | Retrieve carrier configuration |
| `GET_PalletTypes` | List movable unit types |

## Picking a Whole Movable Unit

Extensiv has no bulk pick endpoint. `POST /orders/pickjobs/{jid}/pickitems/picker` takes exactly one
`pickItemId`, requires `If-Match`, and returns the entire updated pick list with a **new ETag**. So
picks cannot be issued in parallel - they have to be chained.

What makes movable-unit picking possible anyway is that pick lists are consolidated by
`Location + ItemTraits`, and `ItemTraits` carries the movable unit. For serialized inventory that
means one pick line per serial, each tagged with the unit it sits on:

```csharp
// 1. Read the unit's contents and allocate the whole thing in one request.
var stock = await new GET_StockDetails
{
    AuthorizationToken = token,
    CustomerId = customerId,
    FacilityId = facilityId,
    PageSize = 500,
    RqlFilter = $"palletidentifier.namekey.name=={scannedLabel}"
}.GetAsync(factory);

// 2. Create and start the pick job, then read the pick list for its ETag.
var list = await new GET_PickList { AuthorizationToken = token, PickJobId = jobId }.GetAsync(factory);

// 3. Filter to the scanned unit and chain the picks, threading the ETag through.
var etag = list.Etag;
var lines = list.Data.Items
    .Where(i => i.PickItem?.ItemTraits?.PalletIdentifier?.NameKey?.Name == scannedLabel)
    .Where(i => i.PickItem!.PickedQty < i.PickItem.Qty);

foreach (var line in lines)
{
    var pick = await new POST_Pick
    {
        AuthorizationToken = token,
        PickJobId = jobId,
        IsMatch = etag,
        PickInfo = new PickInfo { PickItemId = line.PickItemId, Qty = line.PickItem!.Qty }
    }.PostAsync(factory);

    if (!pick.Success)
    {
        // 412 means the ETag went stale because something else touched the job.
        // Re-read the pick list and resume from the lines still short of their quantity.
        break;
    }

    etag = pick.Etag;
}
```

This library deliberately does not wrap that loop. Partial failure mid-run is a real physical state -
the operator is holding a half-picked unit - and how to recover is an application decision.

## Project Structure

```
ExtensivSharp/
├── Endpoints/
│   ├── Orders/        # Orders, picking, packing and shipping
│   ├── Inventory/     # Inventory, receivers and movable units
│   ├── Items/         # Item master
│   └── Properties/    # Facilities, locations, carriers, movable unit types
├── Models/
│   ├── Auth/          # Authentication models
│   ├── Order/         # Order, package and allocation models
│   ├── Pick/          # Pick job, pick list and pick action models
│   ├── Inventory/     # Inventory, stock detail and pallet models
│   ├── Items/         # Item models
│   ├── Receivers/     # Receiver models
│   ├── Properties/    # Facility, location and pallet type models
│   ├── Generic/       # Shared identifiers, ItemTraits, allocations
│   ├── Helper/        # API result wrapper
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
    public T Data { get; set; } = default!;
}
```

On failure, `Message` carries the raw response body from Extensiv - which for a 400 or 403 is a typed
error envelope with `ErrorCode` and `Hint` - falling back to the HTTP reason phrase when the body is
empty. `StatusCode` carries the semantics. The codes worth handling explicitly:

| Status | Meaning |
|--------|---------|
| 412 | The `If-Match` ETag no longer matches the resource. Re-read and retry. |
| 428 | `If-Match` was required and not supplied. |
| 429 | Throttled. Extensiv limits requests per minute but does not publish the limit. |

Every endpoint that receives an ETag returns it on `Etag`, including the ones whose response body is
empty, so a chain of mutations never has to re-read a resource just to get a fresh tag.

## Breaking Changes in 1.4.0

- `HttpStatusCodeHelper` has been removed. It mapped statuses to canned English strings and discarded
  Extensiv's own error payload on exactly the codes that matter. `Message` now carries the response
  body verbatim.
- `Package.PackageContents` is now projected onto a `_embedded` wrapper rather than being a wire
  property. Extensiv carries package contents under `_embedded` on both requests and responses, so
  the old mapping never bound. Reading and setting `PackageContents` still works.
- `PackageContent.Qty` is now `decimal` rather than `double`, matching the API specification.
- `Models.Order.NameKey` and `Models.Inventory.NameKey` have been removed in favour of
  `Models.Generic.NameKey`; all three were identical.
- `Models.Inventory.PalletIdentifier` has moved to `Models.Generic.PalletIdentifier`.
- `RqlQueryBuilder.Build()` now returns a raw RQL expression. It previously URL-encoded values a
  second time on top of the RQL-level escaping, which double-encoded any value containing `%`, `!`,
  parentheses, `*`, `=`, `,` or `;`. Callers URL-encode the built expression exactly once.

## API Documentation

For full API documentation, refer to the [Extensiv API Reference](https://developer.extensiv.com/) or [REL](https://3w.extensiv.com/rels/) documentation

## License

MIT License

---

*Last Modified: 2026-08-18*
