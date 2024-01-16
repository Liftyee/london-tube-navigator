# IO.Swagger.Model.TflApiPresentationEntitiesRoadDisruption
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Unique identifier for the road disruption | [optional] 
**Url** | **string** | URL to retrieve this road disruption | [optional] 
**Point** | **string** | Latitude and longitude (WGS84) of the centroid of the disruption, stored in a geoJSON-formatted string. | [optional] 
**Severity** | **string** | A description of the severity of the disruption. | [optional] 
**Ordinal** | **int?** | An ordinal of the disruption based on severity, level of interest and corridor. | [optional] 
**Category** | **string** | Describes the nature of disruption e.g. Traffic Incidents, Works | [optional] 
**SubCategory** | **string** | Describes the sub-category of disruption e.g. Collapsed Manhole, Abnormal Load | [optional] 
**Comments** | **string** | Full text of comments describing the disruption, including details of any road closures and diversions, where appropriate. | [optional] 
**CurrentUpdate** | **string** | Text of the most recent update from the LSTCC on the state of the               disruption, including the current traffic impact and any advice to               road users. | [optional] 
**CurrentUpdateDateTime** | **DateTime?** | The time when the last CurrentUpdate description was recorded,               or null if no CurrentUpdate has been applied. | [optional] 
**CorridorIds** | **List&lt;string&gt;** | The Ids of affected corridors, if any. | [optional] 
**StartDateTime** | **DateTime?** | The date and time which the disruption started. For a planned disruption (i.e. planned road works) this date will be in the future.              For unplanned disruptions, this will default to the date on which the disruption was first recorded, but may be adjusted by the operator. | [optional] 
**EndDateTime** | **DateTime?** | The date and time on which the disruption ended. For planned disruptions, this date will have a valid value. For unplanned               disruptions in progress, this field will be omitted. | [optional] 
**LastModifiedTime** | **DateTime?** | The date and time on which the disruption was last modified in the system. This information can reliably be used by a developer to quickly              compare two instances of the same disruption to determine if it has been changed. | [optional] 
**LevelOfInterest** | **string** | This describes the level of potential impact on traffic operations of the disruption.               High &#x3D; e.g. a one-off disruption on a major or high profile route which will require a high level of operational attention               Medium &#x3D; This is the default value               Low &#x3D; e.g. a frequently occurring disruption which is well known | [optional] 
**Location** | **string** | Main road name / number (borough) or preset area name where the disruption is located. This might be useful for a map popup where space is limited. | [optional] 
**Status** | **string** | This describes the status of the disruption.                Active &#x3D; currently in progress               Active Long Term &#x3D; currently in progress and long term              Scheduled &#x3D; scheduled to start within the next 180 days              Recurring Works &#x3D; planned maintenance works that follow a regular routine or pattern and whose next occurrence is to start within the next 180 days.              Recently Cleared &#x3D; recently cleared in the last 24 hours              Note that the status of Scheduled or Recurring Works disruptions will change to Active when they start, and will change status again when they end. | [optional] 
**Geography** | [**SystemDataSpatialDbGeography**](SystemDataSpatialDbGeography.md) | Geography version of Point for output as GeoJSON.              Can not use Geometry in a consistent way as non-TIMS disruptions do not have a polygon | [optional] 
**Geometry** | [**SystemDataSpatialDbGeography**](SystemDataSpatialDbGeography.md) | GeoJSON formatted latitude/longitude (WGS84) pairs forming an enclosed polyline or polygon. The polygon will only be included where affected streets information              is not available for the disruption, would be inappropriate (e.g. a very large number of streets), or is centred on an area without streets (e.g. a football stadium). | [optional] 
**Streets** | [**List&lt;TflApiPresentationEntitiesStreet&gt;**](TflApiPresentationEntitiesStreet.md) | A collection of zero or more streets affected by the disruption. | [optional] 
**IsProvisional** | **bool?** | True if the disruption is planned on a future date that is open to change | [optional] 
**HasClosures** | **bool?** | True if any of the affected Streets have a \&quot;Full Closure\&quot; status, false otherwise. A RoadDisruption that has HasClosures is considered a               Severe or Serious disruption for severity filtering purposes. | [optional] 
**LinkText** | **string** | The text of any associated link | [optional] 
**LinkUrl** | **string** | The url of any associated link | [optional] 
**RoadProject** | [**TflApiPresentationEntitiesRoadProject**](TflApiPresentationEntitiesRoadProject.md) | Any associated road project | [optional] 
**PublishStartDate** | **DateTime?** | TDM Additional properties | [optional] 
**PublishEndDate** | **DateTime?** |  | [optional] 
**TimeFrame** | **string** |  | [optional] 
**RoadDisruptionLines** | [**List&lt;TflApiPresentationEntitiesRoadDisruptionLine&gt;**](TflApiPresentationEntitiesRoadDisruptionLine.md) |  | [optional] 
**RoadDisruptionImpactAreas** | [**List&lt;TflApiPresentationEntitiesRoadDisruptionImpactArea&gt;**](TflApiPresentationEntitiesRoadDisruptionImpactArea.md) |  | [optional] 
**RecurringSchedules** | [**List&lt;TflApiPresentationEntitiesRoadDisruptionSchedule&gt;**](TflApiPresentationEntitiesRoadDisruptionSchedule.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

