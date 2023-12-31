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
    /// TflApiPresentationEntitiesJourneyPlannerFareTap
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesJourneyPlannerFareTap :  IEquatable<TflApiPresentationEntitiesJourneyPlannerFareTap>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesJourneyPlannerFareTap" /> class.
        /// </summary>
        /// <param name="atcoCode">atcoCode.</param>
        /// <param name="tapDetails">tapDetails.</param>
        public TflApiPresentationEntitiesJourneyPlannerFareTap(string atcoCode = default(string), TflApiPresentationEntitiesJourneyPlannerFareTapDetails tapDetails = default(TflApiPresentationEntitiesJourneyPlannerFareTapDetails))
        {
            this.AtcoCode = atcoCode;
            this.TapDetails = tapDetails;
        }
        
        /// <summary>
        /// Gets or Sets AtcoCode
        /// </summary>
        [DataMember(Name="atcoCode", EmitDefaultValue=false)]
        public string AtcoCode { get; set; }

        /// <summary>
        /// Gets or Sets TapDetails
        /// </summary>
        [DataMember(Name="tapDetails", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesJourneyPlannerFareTapDetails TapDetails { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesJourneyPlannerFareTap {\n");
            sb.Append("  AtcoCode: ").Append(AtcoCode).Append("\n");
            sb.Append("  TapDetails: ").Append(TapDetails).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesJourneyPlannerFareTap);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesJourneyPlannerFareTap instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesJourneyPlannerFareTap to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesJourneyPlannerFareTap input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AtcoCode == input.AtcoCode ||
                    (this.AtcoCode != null &&
                    this.AtcoCode.Equals(input.AtcoCode))
                ) && 
                (
                    this.TapDetails == input.TapDetails ||
                    (this.TapDetails != null &&
                    this.TapDetails.Equals(input.TapDetails))
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
                if (this.AtcoCode != null)
                    hashCode = hashCode * 59 + this.AtcoCode.GetHashCode();
                if (this.TapDetails != null)
                    hashCode = hashCode * 59 + this.TapDetails.GetHashCode();
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
