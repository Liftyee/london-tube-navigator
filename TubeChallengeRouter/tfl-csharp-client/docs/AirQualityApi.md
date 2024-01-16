# IO.Swagger.Api.AirQualityApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AirQualityGet**](AirQualityApi.md#airqualityget) | **GET** /AirQuality | Gets air quality data feed


<a name="airqualityget"></a>
# **AirQualityGet**
> SystemObject AirQualityGet ()

Gets air quality data feed

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AirQualityGetExample
    {
        public void main()
        {
            var apiInstance = new AirQualityApi();

            try
            {
                // Gets air quality data feed
                SystemObject result = apiInstance.AirQualityGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AirQualityApi.AirQualityGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**SystemObject**](SystemObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

