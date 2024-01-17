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
    /// TflApiPresentationEntitiesGeoCodeSearchMatch
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesGeoCodeSearchMatch :  IEquatable<TflApiPresentationEntitiesGeoCodeSearchMatch>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesGeoCodeSearchMatch" /> class.
        /// </summary>
        /// <param name="types">The type of the place e.g. \&quot;street_address\&quot;.</param>
        /// <param name="address">A string describing the formatted address of the place. Adds additional context to the place&#39;s Name..</param>
        /// <param name="id">id.</param>
        /// <param name="url">url.</param>
        /// <param name="name">name.</param>
        /// <param name="lat">lat.</param>
        /// <param name="lon">lon.</param>
        public TflApiPresentationEntitiesGeoCodeSearchMatch(List<string> types = default(List<string>), string address = default(string), string id = default(string), string url = default(string), string name = default(string), double? lat = default(double?), double? lon = default(double?))
        {
            this.Types = types;
            this.Address = address;
            this.Id = id;
            this.Url = url;
            this.Name = name;
            this.Lat = lat;
            this.Lon = lon;
        }
        
        /// <summary>
        /// The type of the place e.g. \&quot;street_address\&quot;
        /// </summary>
        /// <value>The type of the place e.g. \&quot;street_address\&quot;</value>
        [DataMember(Name="types", EmitDefaultValue=false)]
        public List<string> Types { get; set; }

        /// <summary>
        /// A string describing the formatted address of the place. Adds additional context to the place&#39;s Name.
        /// </summary>
        /// <value>A string describing the formatted address of the place. Adds additional context to the place&#39;s Name.</value>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Lat
        /// </summary>
        [DataMember(Name="lat", EmitDefaultValue=false)]
        public double? Lat { get; set; }

        /// <summary>
        /// Gets or Sets Lon
        /// </summary>
        [DataMember(Name="lon", EmitDefaultValue=false)]
        public double? Lon { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesGeoCodeSearchMatch {\n");
            sb.Append("  Types: ").Append(Types).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesGeoCodeSearchMatch);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesGeoCodeSearchMatch instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesGeoCodeSearchMatch to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesGeoCodeSearchMatch input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Types == input.Types ||
                    this.Types != null &&
                    this.Types.SequenceEqual(input.Types)
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
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
                if (this.Types != null)
                    hashCode = hashCode * 59 + this.Types.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
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