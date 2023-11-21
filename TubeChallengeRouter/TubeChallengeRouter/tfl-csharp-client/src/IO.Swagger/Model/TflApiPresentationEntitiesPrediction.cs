/* 
 * Transport for London Unified API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// DTO to capture the prediction details
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesPrediction :  IEquatable<TflApiPresentationEntitiesPrediction>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesPrediction" /> class.
        /// </summary>
        /// <param name="id">The identitier for the prediction.</param>
        /// <param name="operationType">The type of the operation (1: is new or has been updated, 2: should be deleted from any client cache).</param>
        /// <param name="vehicleId">The actual vehicle in transit (for train modes, the leading car of the rolling set).</param>
        /// <param name="naptanId">Identifier for the prediction.</param>
        /// <param name="stationName">Station name.</param>
        /// <param name="lineId">Unique identifier for the Line.</param>
        /// <param name="lineName">Line Name.</param>
        /// <param name="platformName">Platform name (for bus, this is the stop letter).</param>
        /// <param name="direction">Direction (unified to inbound/outbound).</param>
        /// <param name="bearing">Bearing (between 0 to 359).</param>
        /// <param name="destinationNaptanId">Naptan Identifier for the prediction&#39;s destination.</param>
        /// <param name="destinationName">Name of the destination.</param>
        /// <param name="timestamp">Timestamp for when the prediction was inserted/modified (source column drives what objects are broadcast on each iteration).</param>
        /// <param name="timeToStation">Prediction of the Time to station in seconds.</param>
        /// <param name="currentLocation">The current location of the vehicle..</param>
        /// <param name="towards">Routing information or other descriptive text about the path of the vehicle towards the destination.</param>
        /// <param name="expectedArrival">The expected arrival time of the vehicle at the stop/station.</param>
        /// <param name="timeToLive">The expiry time for the prediction.</param>
        /// <param name="modeName">The mode name of the station/line the prediction relates to.</param>
        /// <param name="timing">Keep the original timestamp from MongoDb fo debugging purposes.</param>
        public TflApiPresentationEntitiesPrediction(string id = default(string), int? operationType = default(int?), string vehicleId = default(string), string naptanId = default(string), string stationName = default(string), string lineId = default(string), string lineName = default(string), string platformName = default(string), string direction = default(string), string bearing = default(string), string destinationNaptanId = default(string), string destinationName = default(string), DateTime? timestamp = default(DateTime?), int? timeToStation = default(int?), string currentLocation = default(string), string towards = default(string), DateTime? expectedArrival = default(DateTime?), DateTime? timeToLive = default(DateTime?), string modeName = default(string), TflApiPresentationEntitiesPredictionTiming timing = default(TflApiPresentationEntitiesPredictionTiming))
        {
            this.Id = id;
            this.OperationType = operationType;
            this.VehicleId = vehicleId;
            this.NaptanId = naptanId;
            this.StationName = stationName;
            this.LineId = lineId;
            this.LineName = lineName;
            this.PlatformName = platformName;
            this.Direction = direction;
            this.Bearing = bearing;
            this.DestinationNaptanId = destinationNaptanId;
            this.DestinationName = destinationName;
            this.Timestamp = timestamp;
            this.TimeToStation = timeToStation;
            this.CurrentLocation = currentLocation;
            this.Towards = towards;
            this.ExpectedArrival = expectedArrival;
            this.TimeToLive = timeToLive;
            this.ModeName = modeName;
            this.Timing = timing;
        }
        
        /// <summary>
        /// The identitier for the prediction
        /// </summary>
        /// <value>The identitier for the prediction</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// The type of the operation (1: is new or has been updated, 2: should be deleted from any client cache)
        /// </summary>
        /// <value>The type of the operation (1: is new or has been updated, 2: should be deleted from any client cache)</value>
        [DataMember(Name="operationType", EmitDefaultValue=false)]
        public int? OperationType { get; set; }

        /// <summary>
        /// The actual vehicle in transit (for train modes, the leading car of the rolling set)
        /// </summary>
        /// <value>The actual vehicle in transit (for train modes, the leading car of the rolling set)</value>
        [DataMember(Name="vehicleId", EmitDefaultValue=false)]
        public string VehicleId { get; set; }

        /// <summary>
        /// Identifier for the prediction
        /// </summary>
        /// <value>Identifier for the prediction</value>
        [DataMember(Name="naptanId", EmitDefaultValue=false)]
        public string NaptanId { get; set; }

        /// <summary>
        /// Station name
        /// </summary>
        /// <value>Station name</value>
        [DataMember(Name="stationName", EmitDefaultValue=false)]
        public string StationName { get; set; }

        /// <summary>
        /// Unique identifier for the Line
        /// </summary>
        /// <value>Unique identifier for the Line</value>
        [DataMember(Name="lineId", EmitDefaultValue=false)]
        public string LineId { get; set; }

        /// <summary>
        /// Line Name
        /// </summary>
        /// <value>Line Name</value>
        [DataMember(Name="lineName", EmitDefaultValue=false)]
        public string LineName { get; set; }

        /// <summary>
        /// Platform name (for bus, this is the stop letter)
        /// </summary>
        /// <value>Platform name (for bus, this is the stop letter)</value>
        [DataMember(Name="platformName", EmitDefaultValue=false)]
        public string PlatformName { get; set; }

        /// <summary>
        /// Direction (unified to inbound/outbound)
        /// </summary>
        /// <value>Direction (unified to inbound/outbound)</value>
        [DataMember(Name="direction", EmitDefaultValue=false)]
        public string Direction { get; set; }

        /// <summary>
        /// Bearing (between 0 to 359)
        /// </summary>
        /// <value>Bearing (between 0 to 359)</value>
        [DataMember(Name="bearing", EmitDefaultValue=false)]
        public string Bearing { get; set; }

        /// <summary>
        /// Naptan Identifier for the prediction&#39;s destination
        /// </summary>
        /// <value>Naptan Identifier for the prediction&#39;s destination</value>
        [DataMember(Name="destinationNaptanId", EmitDefaultValue=false)]
        public string DestinationNaptanId { get; set; }

        /// <summary>
        /// Name of the destination
        /// </summary>
        /// <value>Name of the destination</value>
        [DataMember(Name="destinationName", EmitDefaultValue=false)]
        public string DestinationName { get; set; }

        /// <summary>
        /// Timestamp for when the prediction was inserted/modified (source column drives what objects are broadcast on each iteration)
        /// </summary>
        /// <value>Timestamp for when the prediction was inserted/modified (source column drives what objects are broadcast on each iteration)</value>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Prediction of the Time to station in seconds
        /// </summary>
        /// <value>Prediction of the Time to station in seconds</value>
        [DataMember(Name="timeToStation", EmitDefaultValue=false)]
        public int? TimeToStation { get; set; }

        /// <summary>
        /// The current location of the vehicle.
        /// </summary>
        /// <value>The current location of the vehicle.</value>
        [DataMember(Name="currentLocation", EmitDefaultValue=false)]
        public string CurrentLocation { get; set; }

        /// <summary>
        /// Routing information or other descriptive text about the path of the vehicle towards the destination
        /// </summary>
        /// <value>Routing information or other descriptive text about the path of the vehicle towards the destination</value>
        [DataMember(Name="towards", EmitDefaultValue=false)]
        public string Towards { get; set; }

        /// <summary>
        /// The expected arrival time of the vehicle at the stop/station
        /// </summary>
        /// <value>The expected arrival time of the vehicle at the stop/station</value>
        [DataMember(Name="expectedArrival", EmitDefaultValue=false)]
        public DateTime? ExpectedArrival { get; set; }

        /// <summary>
        /// The expiry time for the prediction
        /// </summary>
        /// <value>The expiry time for the prediction</value>
        [DataMember(Name="timeToLive", EmitDefaultValue=false)]
        public DateTime? TimeToLive { get; set; }

        /// <summary>
        /// The mode name of the station/line the prediction relates to
        /// </summary>
        /// <value>The mode name of the station/line the prediction relates to</value>
        [DataMember(Name="modeName", EmitDefaultValue=false)]
        public string ModeName { get; set; }

        /// <summary>
        /// Keep the original timestamp from MongoDb fo debugging purposes
        /// </summary>
        /// <value>Keep the original timestamp from MongoDb fo debugging purposes</value>
        [DataMember(Name="timing", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesPredictionTiming Timing { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesPrediction {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  OperationType: ").Append(OperationType).Append("\n");
            sb.Append("  VehicleId: ").Append(VehicleId).Append("\n");
            sb.Append("  NaptanId: ").Append(NaptanId).Append("\n");
            sb.Append("  StationName: ").Append(StationName).Append("\n");
            sb.Append("  LineId: ").Append(LineId).Append("\n");
            sb.Append("  LineName: ").Append(LineName).Append("\n");
            sb.Append("  PlatformName: ").Append(PlatformName).Append("\n");
            sb.Append("  Direction: ").Append(Direction).Append("\n");
            sb.Append("  Bearing: ").Append(Bearing).Append("\n");
            sb.Append("  DestinationNaptanId: ").Append(DestinationNaptanId).Append("\n");
            sb.Append("  DestinationName: ").Append(DestinationName).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  TimeToStation: ").Append(TimeToStation).Append("\n");
            sb.Append("  CurrentLocation: ").Append(CurrentLocation).Append("\n");
            sb.Append("  Towards: ").Append(Towards).Append("\n");
            sb.Append("  ExpectedArrival: ").Append(ExpectedArrival).Append("\n");
            sb.Append("  TimeToLive: ").Append(TimeToLive).Append("\n");
            sb.Append("  ModeName: ").Append(ModeName).Append("\n");
            sb.Append("  Timing: ").Append(Timing).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as TflApiPresentationEntitiesPrediction);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesPrediction instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesPrediction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesPrediction input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.OperationType == input.OperationType ||
                    (this.OperationType != null &&
                    this.OperationType.Equals(input.OperationType))
                ) && 
                (
                    this.VehicleId == input.VehicleId ||
                    (this.VehicleId != null &&
                    this.VehicleId.Equals(input.VehicleId))
                ) && 
                (
                    this.NaptanId == input.NaptanId ||
                    (this.NaptanId != null &&
                    this.NaptanId.Equals(input.NaptanId))
                ) && 
                (
                    this.StationName == input.StationName ||
                    (this.StationName != null &&
                    this.StationName.Equals(input.StationName))
                ) && 
                (
                    this.LineId == input.LineId ||
                    (this.LineId != null &&
                    this.LineId.Equals(input.LineId))
                ) && 
                (
                    this.LineName == input.LineName ||
                    (this.LineName != null &&
                    this.LineName.Equals(input.LineName))
                ) && 
                (
                    this.PlatformName == input.PlatformName ||
                    (this.PlatformName != null &&
                    this.PlatformName.Equals(input.PlatformName))
                ) && 
                (
                    this.Direction == input.Direction ||
                    (this.Direction != null &&
                    this.Direction.Equals(input.Direction))
                ) && 
                (
                    this.Bearing == input.Bearing ||
                    (this.Bearing != null &&
                    this.Bearing.Equals(input.Bearing))
                ) && 
                (
                    this.DestinationNaptanId == input.DestinationNaptanId ||
                    (this.DestinationNaptanId != null &&
                    this.DestinationNaptanId.Equals(input.DestinationNaptanId))
                ) && 
                (
                    this.DestinationName == input.DestinationName ||
                    (this.DestinationName != null &&
                    this.DestinationName.Equals(input.DestinationName))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
                ) && 
                (
                    this.TimeToStation == input.TimeToStation ||
                    (this.TimeToStation != null &&
                    this.TimeToStation.Equals(input.TimeToStation))
                ) && 
                (
                    this.CurrentLocation == input.CurrentLocation ||
                    (this.CurrentLocation != null &&
                    this.CurrentLocation.Equals(input.CurrentLocation))
                ) && 
                (
                    this.Towards == input.Towards ||
                    (this.Towards != null &&
                    this.Towards.Equals(input.Towards))
                ) && 
                (
                    this.ExpectedArrival == input.ExpectedArrival ||
                    (this.ExpectedArrival != null &&
                    this.ExpectedArrival.Equals(input.ExpectedArrival))
                ) && 
                (
                    this.TimeToLive == input.TimeToLive ||
                    (this.TimeToLive != null &&
                    this.TimeToLive.Equals(input.TimeToLive))
                ) && 
                (
                    this.ModeName == input.ModeName ||
                    (this.ModeName != null &&
                    this.ModeName.Equals(input.ModeName))
                ) && 
                (
                    this.Timing == input.Timing ||
                    (this.Timing != null &&
                    this.Timing.Equals(input.Timing))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.OperationType != null)
                    hashCode = hashCode * 59 + this.OperationType.GetHashCode();
                if (this.VehicleId != null)
                    hashCode = hashCode * 59 + this.VehicleId.GetHashCode();
                if (this.NaptanId != null)
                    hashCode = hashCode * 59 + this.NaptanId.GetHashCode();
                if (this.StationName != null)
                    hashCode = hashCode * 59 + this.StationName.GetHashCode();
                if (this.LineId != null)
                    hashCode = hashCode * 59 + this.LineId.GetHashCode();
                if (this.LineName != null)
                    hashCode = hashCode * 59 + this.LineName.GetHashCode();
                if (this.PlatformName != null)
                    hashCode = hashCode * 59 + this.PlatformName.GetHashCode();
                if (this.Direction != null)
                    hashCode = hashCode * 59 + this.Direction.GetHashCode();
                if (this.Bearing != null)
                    hashCode = hashCode * 59 + this.Bearing.GetHashCode();
                if (this.DestinationNaptanId != null)
                    hashCode = hashCode * 59 + this.DestinationNaptanId.GetHashCode();
                if (this.DestinationName != null)
                    hashCode = hashCode * 59 + this.DestinationName.GetHashCode();
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.TimeToStation != null)
                    hashCode = hashCode * 59 + this.TimeToStation.GetHashCode();
                if (this.CurrentLocation != null)
                    hashCode = hashCode * 59 + this.CurrentLocation.GetHashCode();
                if (this.Towards != null)
                    hashCode = hashCode * 59 + this.Towards.GetHashCode();
                if (this.ExpectedArrival != null)
                    hashCode = hashCode * 59 + this.ExpectedArrival.GetHashCode();
                if (this.TimeToLive != null)
                    hashCode = hashCode * 59 + this.TimeToLive.GetHashCode();
                if (this.ModeName != null)
                    hashCode = hashCode * 59 + this.ModeName.GetHashCode();
                if (this.Timing != null)
                    hashCode = hashCode * 59 + this.Timing.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
