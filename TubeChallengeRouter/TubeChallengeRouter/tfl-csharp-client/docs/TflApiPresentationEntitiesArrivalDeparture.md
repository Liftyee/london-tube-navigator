# IO.Swagger.Model.TflApiPresentationEntitiesArrivalDeparture
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PlatformName** | **string** | Platform name (for bus, this is the stop letter) | [optional] 
**DestinationNaptanId** | **string** | Naptan Identifier for the prediction&#39;s destination | [optional] 
**DestinationName** | **string** | Name of the destination | [optional] 
**NaptanId** | **string** | Identifier for the prediction | [optional] 
**StationName** | **string** | Station name | [optional] 
**EstimatedTimeOfArrival** | **DateTime?** | Estimated time of arrival | [optional] 
**ScheduledTimeOfArrival** | **DateTime?** | Estimated time of arrival | [optional] 
**EstimatedTimeOfDeparture** | **DateTime?** | Estimated time of arrival | [optional] 
**ScheduledTimeOfDeparture** | **DateTime?** | Estimated time of arrival | [optional] 
**MinutesAndSecondsToArrival** | **string** | Estimated time of arrival | [optional] 
**MinutesAndSecondsToDeparture** | **string** | Estimated time of arrival | [optional] 
**Cause** | **string** | Reason for cancellation or delay | [optional] 
**DepartureStatus** | **string** | Status of departure | [optional] 
**Timing** | [**TflApiPresentationEntitiesPredictionTiming**](TflApiPresentationEntitiesPredictionTiming.md) | Keep the original timestamp from MongoDb fo debugging purposes | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

