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
    /// TflApiPresentationEntitiesRoadDisruptionImpactArea
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesRoadDisruptionImpactArea :  IEquatable<TflApiPresentationEntitiesRoadDisruptionImpactArea>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesRoadDisruptionImpactArea" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="roadDisruptionId">roadDisruptionId.</param>
        /// <param name="polygon">polygon.</param>
        /// <param name="startDate">startDate.</param>
        /// <param name="endDate">endDate.</param>
        /// <param name="startTime">startTime.</param>
        /// <param name="endTime">endTime.</param>
        public TflApiPresentationEntitiesRoadDisruptionImpactArea(int? id = default(int?), string roadDisruptionId = default(string), SystemDataSpatialDbGeography polygon = default(SystemDataSpatialDbGeography), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), string startTime = default(string), string endTime = default(string))
        {
            this.Id = id;
            this.RoadDisruptionId = roadDisruptionId;
            this.Polygon = polygon;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets RoadDisruptionId
        /// </summary>
        [DataMember(Name="roadDisruptionId", EmitDefaultValue=false)]
        public string RoadDisruptionId { get; set; }

        /// <summary>
        /// Gets or Sets Polygon
        /// </summary>
        [DataMember(Name="polygon", EmitDefaultValue=false)]
        public SystemDataSpatialDbGeography Polygon { get; set; }

        /// <summary>
        /// Gets or Sets StartDate
        /// </summary>
        [DataMember(Name="startDate", EmitDefaultValue=false)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>
        [DataMember(Name="endDate", EmitDefaultValue=false)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or Sets StartTime
        /// </summary>
        [DataMember(Name="startTime", EmitDefaultValue=false)]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or Sets EndTime
        /// </summary>
        [DataMember(Name="endTime", EmitDefaultValue=false)]
        public string EndTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesRoadDisruptionImpactArea {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  RoadDisruptionId: ").Append(RoadDisruptionId).Append("\n");
            sb.Append("  Polygon: ").Append(Polygon).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesRoadDisruptionImpactArea);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesRoadDisruptionImpactArea instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesRoadDisruptionImpactArea to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesRoadDisruptionImpactArea input)
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
                    this.RoadDisruptionId == input.RoadDisruptionId ||
                    (this.RoadDisruptionId != null &&
                    this.RoadDisruptionId.Equals(input.RoadDisruptionId))
                ) && 
                (
                    this.Polygon == input.Polygon ||
                    (this.Polygon != null &&
                    this.Polygon.Equals(input.Polygon))
                ) && 
                (
                    this.StartDate == input.StartDate ||
                    (this.StartDate != null &&
                    this.StartDate.Equals(input.StartDate))
                ) && 
                (
                    this.EndDate == input.EndDate ||
                    (this.EndDate != null &&
                    this.EndDate.Equals(input.EndDate))
                ) && 
                (
                    this.StartTime == input.StartTime ||
                    (this.StartTime != null &&
                    this.StartTime.Equals(input.StartTime))
                ) && 
                (
                    this.EndTime == input.EndTime ||
                    (this.EndTime != null &&
                    this.EndTime.Equals(input.EndTime))
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
                if (this.RoadDisruptionId != null)
                    hashCode = hashCode * 59 + this.RoadDisruptionId.GetHashCode();
                if (this.Polygon != null)
                    hashCode = hashCode * 59 + this.Polygon.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
                if (this.StartTime != null)
                    hashCode = hashCode * 59 + this.StartTime.GetHashCode();
                if (this.EndTime != null)
                    hashCode = hashCode * 59 + this.EndTime.GetHashCode();
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
