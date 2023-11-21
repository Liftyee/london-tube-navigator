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
    /// TflApiPresentationEntitiesOrderedRoute
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesOrderedRoute :  IEquatable<TflApiPresentationEntitiesOrderedRoute>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesOrderedRoute" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="naptanIds">naptanIds.</param>
        /// <param name="serviceType">serviceType.</param>
        public TflApiPresentationEntitiesOrderedRoute(string name = default(string), List<string> naptanIds = default(List<string>), string serviceType = default(string))
        {
            this.Name = name;
            this.NaptanIds = naptanIds;
            this.ServiceType = serviceType;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets NaptanIds
        /// </summary>
        [DataMember(Name="naptanIds", EmitDefaultValue=false)]
        public List<string> NaptanIds { get; set; }

        /// <summary>
        /// Gets or Sets ServiceType
        /// </summary>
        [DataMember(Name="serviceType", EmitDefaultValue=false)]
        public string ServiceType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesOrderedRoute {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NaptanIds: ").Append(NaptanIds).Append("\n");
            sb.Append("  ServiceType: ").Append(ServiceType).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesOrderedRoute);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesOrderedRoute instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesOrderedRoute to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesOrderedRoute input)
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
                    this.NaptanIds == input.NaptanIds ||
                    this.NaptanIds != null &&
                    this.NaptanIds.SequenceEqual(input.NaptanIds)
                ) && 
                (
                    this.ServiceType == input.ServiceType ||
                    (this.ServiceType != null &&
                    this.ServiceType.Equals(input.ServiceType))
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
                if (this.NaptanIds != null)
                    hashCode = hashCode * 59 + this.NaptanIds.GetHashCode();
                if (this.ServiceType != null)
                    hashCode = hashCode * 59 + this.ServiceType.GetHashCode();
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
