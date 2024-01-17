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
    /// TflApiPresentationEntitiesTimetableRoute
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesTimetableRoute :  IEquatable<TflApiPresentationEntitiesTimetableRoute>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesTimetableRoute" /> class.
        /// </summary>
        /// <param name="stationIntervals">stationIntervals.</param>
        /// <param name="schedules">schedules.</param>
        public TflApiPresentationEntitiesTimetableRoute(List<TflApiPresentationEntitiesStationInterval> stationIntervals = default(List<TflApiPresentationEntitiesStationInterval>), List<TflApiPresentationEntitiesSchedule> schedules = default(List<TflApiPresentationEntitiesSchedule>))
        {
            this.StationIntervals = stationIntervals;
            this.Schedules = schedules;
        }
        
        /// <summary>
        /// Gets or Sets StationIntervals
        /// </summary>
        [DataMember(Name="stationIntervals", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesStationInterval> StationIntervals { get; set; }

        /// <summary>
        /// Gets or Sets Schedules
        /// </summary>
        [DataMember(Name="schedules", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesSchedule> Schedules { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesTimetableRoute {\n");
            sb.Append("  StationIntervals: ").Append(StationIntervals).Append("\n");
            sb.Append("  Schedules: ").Append(Schedules).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesTimetableRoute);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesTimetableRoute instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesTimetableRoute to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesTimetableRoute input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.StationIntervals == input.StationIntervals ||
                    this.StationIntervals != null &&
                    this.StationIntervals.SequenceEqual(input.StationIntervals)
                ) && 
                (
                    this.Schedules == input.Schedules ||
                    this.Schedules != null &&
                    this.Schedules.SequenceEqual(input.Schedules)
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
                if (this.StationIntervals != null)
                    hashCode = hashCode * 59 + this.StationIntervals.GetHashCode();
                if (this.Schedules != null)
                    hashCode = hashCode * 59 + this.Schedules.GetHashCode();
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