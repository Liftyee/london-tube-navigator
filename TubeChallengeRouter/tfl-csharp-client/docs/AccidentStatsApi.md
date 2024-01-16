# IO.Swagger.Api.AccidentStatsApi

All URIs are relative to *https://api.digital.tfl.gov.uk*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AccidentStatsGet**](AccidentStatsApi.md#accidentstatsget) | **GET** /AccidentStats/{year} | Gets all accident details for accidents occuring in the specified year


<a name="accidentstatsget"></a>
# **AccidentStatsGet**
> List<TflApiPresentationEntitiesAccidentStatsAccidentDetail> AccidentStatsGet (int? year)

Gets all accident details for accidents occuring in the specified year

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AccidentStatsGetExample
    {
        public void main()
        {
            var apiInstance = new AccidentStatsApi();
            var year = 56;  // int? | The year for which to filter the accidents on.

            try
            {
                // Gets all accident details for accidents occuring in the specified year
                List&lt;TflApiPresentationEntitiesAccidentStatsAccidentDetail&gt; result = apiInstance.AccidentStatsGet(year);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccidentStatsApi.AccidentStatsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **year** | **int?**| The year for which to filter the accidents on. | 

### Return type

[**List<TflApiPresentationEntitiesAccidentStatsAccidentDetail>**](TflApiPresentationEntitiesAccidentStatsAccidentDetail.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

