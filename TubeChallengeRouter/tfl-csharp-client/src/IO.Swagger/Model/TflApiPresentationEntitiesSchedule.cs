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
    /// TflApiPresentationEntitiesSchedule
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesSchedule :  IEquatable<TflApiPresentationEntitiesSchedule>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesSchedule" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="knownJourneys">knownJourneys.</param>
        /// <param name="firstJourney">firstJourney.</param>
        /// <param name="lastJourney">lastJourney.</param>
        /// <param name="periods">periods.</param>
        public TflApiPresentationEntitiesSchedule(string name = default(string), List<TflApiPresentationEntitiesKnownJourney> knownJourneys = default(List<TflApiPresentationEntitiesKnownJourney>), TflApiPresentationEntitiesKnownJourney firstJourney = default(TflApiPresentationEntitiesKnownJourney), TflApiPresentationEntitiesKnownJourney lastJourney = default(TflApiPresentationEntitiesKnownJourney), List<TflApiPresentationEntitiesPeriod> periods = default(List<TflApiPresentationEntitiesPeriod>))
        {
            this.Name = name;
            this.KnownJourneys = knownJourneys;
            this.FirstJourney = firstJourney;
            this.LastJourney = lastJourney;
            this.Periods = periods;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets KnownJourneys
        /// </summary>
        [DataMember(Name="knownJourneys", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesKnownJourney> KnownJourneys { get; set; }

        /// <summary>
        /// Gets or Sets FirstJourney
        /// </summary>
        [DataMember(Name="firstJourney", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesKnownJourney FirstJourney { get; set; }

        /// <summary>
        /// Gets or Sets LastJourney
        /// </summary>
        [DataMember(Name="lastJourney", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesKnownJourney LastJourney { get; set; }

        /// <summary>
        /// Gets or Sets Periods
        /// </summary>
        [DataMember(Name="periods", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesPeriod> Periods { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesSchedule {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  KnownJourneys: ").Append(KnownJourneys).Append("\n");
            sb.Append("  FirstJourney: ").Append(FirstJourney).Append("\n");
            sb.Append("  LastJourney: ").Append(LastJourney).Append("\n");
            sb.Append("  Periods: ").Append(Periods).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesSchedule);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesSchedule instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesSchedule to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesSchedule input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.KnownJourneys == input.KnownJourneys ||
                    this.KnownJourneys != null &&
                    this.KnownJourneys.SequenceEqual(input.KnownJourneys)
                ) && 
                (
                    this.FirstJourney == input.FirstJourney ||
                    (this.FirstJourney != null &&
                    this.FirstJourney.Equals(input.FirstJourney))
                ) && 
                (
                    this.LastJourney == input.LastJourney ||
                    (this.LastJourney != null &&
                    this.LastJourney.Equals(input.LastJourney))
                ) && 
                (
                    this.Periods == input.Periods ||
                    this.Periods != null &&
                    this.Periods.SequenceEqual(input.Periods)
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.KnownJourneys != null)
                    hashCode = hashCode * 59 + this.KnownJourneys.GetHashCode();
                if (this.FirstJourney != null)
                    hashCode = hashCode * 59 + this.FirstJourney.GetHashCode();
                if (this.LastJourney != null)
                    hashCode = hashCode * 59 + this.LastJourney.GetHashCode();
                if (this.Periods != null)
                    hashCode = hashCode * 59 + this.Periods.GetHashCode();
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