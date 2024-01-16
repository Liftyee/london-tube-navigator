# IO.Swagger.Model.TflApiPresentationEntitiesDisruptedRoute
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The Id of the route | [optional] 
**LineId** | **string** | The Id of the Line | [optional] 
**RouteCode** | **string** | The route code | [optional] 
**Name** | **string** | Name such as \&quot;72\&quot; | [optional] 
**LineString** | **string** | The co-ordinates of the route&#39;s path as a geoJSON lineString | [optional] 
**Direction** | **string** | Inbound or Outbound | [optional] 
**OriginationName** | **string** | The name of the Origin StopPoint | [optional] 
**DestinationName** | **string** | The name of the Destination StopPoint | [optional] 
**Via** | [**TflApiPresentationEntitiesRouteSectionNaptanEntrySequence**](TflApiPresentationEntitiesRouteSectionNaptanEntrySequence.md) | (where applicable) via Charing Cross / Bank / King&#39;s Cross / Embankment / Newbury Park / Woodford | [optional] 
**IsEntireRouteSection** | **bool?** | Whether this represents the entire route section | [optional] 
**ValidTo** | **DateTime?** | The DateTime that the Service containing this Route is valid until. | [optional] 
**ValidFrom** | **DateTime?** | The DateTime that the Service containing this Route is valid from. | [optional] 
**RouteSectionNaptanEntrySequence** | [**List&lt;TflApiPresentationEntitiesRouteSectionNaptanEntrySequence&gt;**](TflApiPresentationEntitiesRouteSectionNaptanEntrySequence.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

