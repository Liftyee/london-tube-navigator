# IO.Swagger.Api.BikePointApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**BikePointGet**](BikePointApi.md#bikepointget) | **GET** /BikePoint/{id} | Gets the bike point with the given id.
[**BikePointGetAll**](BikePointApi.md#bikepointgetall) | **GET** /BikePoint | Gets all bike point locations. The Place object has an addtionalProperties array which contains the nbBikes, nbDocks and nbSpaces              numbers which give the status of the BikePoint. A mismatch in these numbers i.e. nbDocks - (nbBikes + nbSpaces) !&#x3D; 0 indicates broken docks.
[**BikePointSearch**](BikePointApi.md#bikepointsearch) | **GET** /BikePoint/Search | Search for bike stations by their name, a bike point&#39;s name often contains information about the name of the street              or nearby landmarks, for example. Note that the search result does not contain the PlaceProperties i.e. the status              or occupancy of the BikePoint, to get that information you should retrieve the BikePoint by its id on /BikePoint/id.


<a name="bikepointget"></a>
# **BikePointGet**
> TflApiPresentationEntitiesPlace BikePointGet (string id)

Gets the bike point with the given id.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class BikePointGetExample
    {
        public void main()
        {
            var apiInstance = new BikePointApi();
            var id = id_example;  // string | A bike point id (a list of ids can be obtained from the above BikePoint call)

            try
            {
                // Gets the bike point with the given id.
                TflApiPresentationEntitiesPlace result = apiInstance.BikePointGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BikePointApi.BikePointGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| A bike point id (a list of ids can be obtained from the above BikePoint call) | 

### Return type

[**TflApiPresentationEntitiesPlace**](TflApiPresentationEntitiesPlace.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="bikepointgetall"></a>
# **BikePointGetAll**
> List<TflApiPresentationEntitiesPlace> BikePointGetAll ()

Gets all bike point locations. The Place object has an addtionalProperties array which contains the nbBikes, nbDocks and nbSpaces              numbers which give the status of the BikePoint. A mismatch in these numbers i.e. nbDocks - (nbBikes + nbSpaces) != 0 indicates broken docks.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class BikePointGetAllExample
    {
        public void main()
        {
            var apiInstance = new BikePointApi();

            try
            {
                // Gets all bike point locations. The Place object has an addtionalProperties array which contains the nbBikes, nbDocks and nbSpaces              numbers which give the status of the BikePoint. A mismatch in these numbers i.e. nbDocks - (nbBikes + nbSpaces) != 0 indicates broken docks.
                List&lt;TflApiPresentationEntitiesPlace&gt; result = apiInstance.BikePointGetAll();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BikePointApi.BikePointGetAll: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TflApiPresentationEntitiesPlace>**](TflApiPresentationEntitiesPlace.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="bikepointsearch"></a>
# **BikePointSearch**
> List<TflApiPresentationEntitiesPlace> BikePointSearch (string query)

Search for bike stations by their name, a bike point's name often contains information about the name of the street              or nearby landmarks, for example. Note that the search result does not contain the PlaceProperties i.e. the status              or occupancy of the BikePoint, to get that information you should retrieve the BikePoint by its id on /BikePoint/id.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class BikePointSearchExample
    {
        public void main()
        {
            var apiInstance = new BikePointApi();
            var query = query_example;  // string | The search term e.g. \"St. James\"

            try
            {
                // Search for bike stations by their name, a bike point's name often contains information about the name of the street              or nearby landmarks, for example. Note that the search result does not contain the PlaceProperties i.e. the status              or occupancy of the BikePoint, to get that information you should retrieve the BikePoint by its id on /BikePoint/id.
                List&lt;TflApiPresentationEntitiesPlace&gt; result = apiInstance.BikePointSearch(query);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling BikePointApi.BikePointSearch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **query** | **string**| The search term e.g. \&quot;St. James\&quot; | 

### Return type

[**List<TflApiPresentationEntitiesPlace>**](TflApiPresentationEntitiesPlace.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

