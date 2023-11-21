# IO.Swagger.Model.TflApiPresentationEntitiesStreet
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Street name | [optional] 
**Closure** | **string** | Type of road closure. Some example values:              Open &#x3D; road is open, not blocked, not closed, not restricted. It maybe that the disruption has been moved out of the carriageway.              Partial Closure &#x3D; road is partially blocked, closed or restricted.               Full Closure &#x3D; road is fully blocked or closed. | [optional] 
**Directions** | **string** | The direction of the disruption on the street. Some example values:              All Directions              All Approaches              Clockwise              Anti-Clockwise              Northbound              Eastbound              Southbound              Westbound              Both Directions | [optional] 
**Segments** | [**List&lt;TflApiPresentationEntitiesStreetSegment&gt;**](TflApiPresentationEntitiesStreetSegment.md) | Geographic description of the sections of this street that are affected. | [optional] 
**SourceSystemId** | **long?** | The ID from the source system of the disruption that this street belongs to. | [optional] 
**SourceSystemKey** | **string** | The key of the source system of the disruption that this street belongs to. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

