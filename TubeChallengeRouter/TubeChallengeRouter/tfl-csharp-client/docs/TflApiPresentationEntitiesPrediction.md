# IO.Swagger.Model.TflApiPresentationEntitiesPrediction
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The identitier for the prediction | [optional] 
**OperationType** | **int?** | The type of the operation (1: is new or has been updated, 2: should be deleted from any client cache) | [optional] 
**VehicleId** | **string** | The actual vehicle in transit (for train modes, the leading car of the rolling set) | [optional] 
**NaptanId** | **string** | Identifier for the prediction | [optional] 
**StationName** | **string** | Station name | [optional] 
**LineId** | **string** | Unique identifier for the Line | [optional] 
**LineName** | **string** | Line Name | [optional] 
**PlatformName** | **string** | Platform name (for bus, this is the stop letter) | [optional] 
**Direction** | **string** | Direction (unified to inbound/outbound) | [optional] 
**Bearing** | **string** | Bearing (between 0 to 359) | [optional] 
**DestinationNaptanId** | **string** | Naptan Identifier for the prediction&#39;s destination | [optional] 
**DestinationName** | **string** | Name of the destination | [optional] 
**Timestamp** | **DateTime?** | Timestamp for when the prediction was inserted/modified (source column drives what objects are broadcast on each iteration) | [optional] 
**TimeToStation** | **int?** | Prediction of the Time to station in seconds | [optional] 
**CurrentLocation** | **string** | The current location of the vehicle. | [optional] 
**Towards** | **string** | Routing information or other descriptive text about the path of the vehicle towards the destination | [optional] 
**ExpectedArrival** | **DateTime?** | The expected arrival time of the vehicle at the stop/station | [optional] 
**TimeToLive** | **DateTime?** | The expiry time for the prediction | [optional] 
**ModeName** | **string** | The mode name of the station/line the prediction relates to | [optional] 
**Timing** | [**TflApiPresentationEntitiesPredictionTiming**](TflApiPresentationEntitiesPredictionTiming.md) | Keep the original timestamp from MongoDb fo debugging purposes | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

