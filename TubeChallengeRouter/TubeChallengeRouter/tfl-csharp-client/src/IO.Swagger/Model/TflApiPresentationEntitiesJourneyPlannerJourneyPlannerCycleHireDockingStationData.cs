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
    /// TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData :  IEquatable<TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData" /> class.
        /// </summary>
        /// <param name="originNumberOfBikes">originNumberOfBikes.</param>
        /// <param name="destinationNumberOfBikes">destinationNumberOfBikes.</param>
        /// <param name="originNumberOfEmptySlots">originNumberOfEmptySlots.</param>
        /// <param name="destinationNumberOfEmptySlots">destinationNumberOfEmptySlots.</param>
        /// <param name="originId">originId.</param>
        /// <param name="destinationId">destinationId.</param>
        public TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData(int? originNumberOfBikes = default(int?), int? destinationNumberOfBikes = default(int?), int? originNumberOfEmptySlots = default(int?), int? destinationNumberOfEmptySlots = default(int?), string originId = default(string), string destinationId = default(string))
        {
            this.OriginNumberOfBikes = originNumberOfBikes;
            this.DestinationNumberOfBikes = destinationNumberOfBikes;
            this.OriginNumberOfEmptySlots = originNumberOfEmptySlots;
            this.DestinationNumberOfEmptySlots = destinationNumberOfEmptySlots;
            this.OriginId = originId;
            this.DestinationId = destinationId;
        }
        
        /// <summary>
        /// Gets or Sets OriginNumberOfBikes
        /// </summary>
        [DataMember(Name="originNumberOfBikes", EmitDefaultValue=false)]
        public int? OriginNumberOfBikes { get; set; }

        /// <summary>
        /// Gets or Sets DestinationNumberOfBikes
        /// </summary>
        [DataMember(Name="destinationNumberOfBikes", EmitDefaultValue=false)]
        public int? DestinationNumberOfBikes { get; set; }

        /// <summary>
        /// Gets or Sets OriginNumberOfEmptySlots
        /// </summary>
        [DataMember(Name="originNumberOfEmptySlots", EmitDefaultValue=false)]
        public int? OriginNumberOfEmptySlots { get; set; }

        /// <summary>
        /// Gets or Sets DestinationNumberOfEmptySlots
        /// </summary>
        [DataMember(Name="destinationNumberOfEmptySlots", EmitDefaultValue=false)]
        public int? DestinationNumberOfEmptySlots { get; set; }

        /// <summary>
        /// Gets or Sets OriginId
        /// </summary>
        [DataMember(Name="originId", EmitDefaultValue=false)]
        public string OriginId { get; set; }

        /// <summary>
        /// Gets or Sets DestinationId
        /// </summary>
        [DataMember(Name="destinationId", EmitDefaultValue=false)]
        public string DestinationId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData {\n");
            sb.Append("  OriginNumberOfBikes: ").Append(OriginNumberOfBikes).Append("\n");
            sb.Append("  DestinationNumberOfBikes: ").Append(DestinationNumberOfBikes).Append("\n");
            sb.Append("  OriginNumberOfEmptySlots: ").Append(OriginNumberOfEmptySlots).Append("\n");
            sb.Append("  DestinationNumberOfEmptySlots: ").Append(DestinationNumberOfEmptySlots).Append("\n");
            sb.Append("  OriginId: ").Append(OriginId).Append("\n");
            sb.Append("  DestinationId: ").Append(DestinationId).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.OriginNumberOfBikes == input.OriginNumberOfBikes ||
                    (this.OriginNumberOfBikes != null &&
                    this.OriginNumberOfBikes.Equals(input.OriginNumberOfBikes))
                ) && 
                (
                    this.DestinationNumberOfBikes == input.DestinationNumberOfBikes ||
                    (this.DestinationNumberOfBikes != null &&
                    this.DestinationNumberOfBikes.Equals(input.DestinationNumberOfBikes))
                ) && 
                (
                    this.OriginNumberOfEmptySlots == input.OriginNumberOfEmptySlots ||
                    (this.OriginNumberOfEmptySlots != null &&
                    this.OriginNumberOfEmptySlots.Equals(input.OriginNumberOfEmptySlots))
                ) && 
                (
                    this.DestinationNumberOfEmptySlots == input.DestinationNumberOfEmptySlots ||
                    (this.DestinationNumberOfEmptySlots != null &&
                    this.DestinationNumberOfEmptySlots.Equals(input.DestinationNumberOfEmptySlots))
                ) && 
                (
                    this.OriginId == input.OriginId ||
                    (this.OriginId != null &&
                    this.OriginId.Equals(input.OriginId))
                ) && 
                (
                    this.DestinationId == input.DestinationId ||
                    (this.DestinationId != null &&
                    this.DestinationId.Equals(input.DestinationId))
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
                if (this.OriginNumberOfBikes != null)
                    hashCode = hashCode * 59 + this.OriginNumberOfBikes.GetHashCode();
                if (this.DestinationNumberOfBikes != null)
                    hashCode = hashCode * 59 + this.DestinationNumberOfBikes.GetHashCode();
                if (this.OriginNumberOfEmptySlots != null)
                    hashCode = hashCode * 59 + this.OriginNumberOfEmptySlots.GetHashCode();
                if (this.DestinationNumberOfEmptySlots != null)
                    hashCode = hashCode * 59 + this.DestinationNumberOfEmptySlots.GetHashCode();
                if (this.OriginId != null)
                    hashCode = hashCode * 59 + this.OriginId.GetHashCode();
                if (this.DestinationId != null)
                    hashCode = hashCode * 59 + this.DestinationId.GetHashCode();
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
