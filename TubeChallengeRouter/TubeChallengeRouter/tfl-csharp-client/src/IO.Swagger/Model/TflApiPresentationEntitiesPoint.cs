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
    /// Represents a point located at a latitude and longitude using the WGS84 co-ordinate system.
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesPoint :  IEquatable<TflApiPresentationEntitiesPoint>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesPoint" /> class.
        /// </summary>
        /// <param name="lat">WGS84 latitude of the location..</param>
        /// <param name="lon">WGS84 longitude of the location..</param>
        public TflApiPresentationEntitiesPoint(double? lat = default(double?), double? lon = default(double?))
        {
            this.Lat = lat;
            this.Lon = lon;
        }
        
        /// <summary>
        /// WGS84 latitude of the location.
        /// </summary>
        /// <value>WGS84 latitude of the location.</value>
        [DataMember(Name="lat", EmitDefaultValue=false)]
        public double? Lat { get; set; }

        /// <summary>
        /// WGS84 longitude of the location.
        /// </summary>
        /// <value>WGS84 longitude of the location.</value>
        [DataMember(Name="lon", EmitDefaultValue=false)]
        public double? Lon { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesPoint {\n");
            sb.Append("  Lat: ").Append(Lat).Append("\n");
            sb.Append("  Lon: ").Append(Lon).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesPoint);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesPoint instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesPoint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesPoint input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Lat == input.Lat ||
                    (this.Lat != null &&
                    this.Lat.Equals(input.Lat))
                ) && 
                (
                    this.Lon == input.Lon ||
                    (this.Lon != null &&
                    this.Lon.Equals(input.Lon))
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
                if (this.Lat != null)
                    hashCode = hashCode * 59 + this.Lat.GetHashCode();
                if (this.Lon != null)
                    hashCode = hashCode * 59 + this.Lon.GetHashCode();
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
