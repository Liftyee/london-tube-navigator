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
    /// Bike point occupancy
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesBikePointOccupancy :  IEquatable<TflApiPresentationEntitiesBikePointOccupancy>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesBikePointOccupancy" /> class.
        /// </summary>
        /// <param name="id">Id of the bike point such as BikePoints_1.</param>
        /// <param name="name">Name / Common name of the bike point.</param>
        /// <param name="bikesCount">Total bike counts.</param>
        /// <param name="emptyDocks">Empty docks.</param>
        /// <param name="totalDocks">Total docks available.</param>
        /// <param name="standardBikesCount">Total standard bikes count.</param>
        /// <param name="eBikesCount">Total ebikes count.</param>
        public TflApiPresentationEntitiesBikePointOccupancy(string id = default(string), string name = default(string), int? bikesCount = default(int?), int? emptyDocks = default(int?), int? totalDocks = default(int?), int? standardBikesCount = default(int?), int? eBikesCount = default(int?))
        {
            this.Id = id;
            this.Name = name;
            this.BikesCount = bikesCount;
            this.EmptyDocks = emptyDocks;
            this.TotalDocks = totalDocks;
            this.StandardBikesCount = standardBikesCount;
            this.EBikesCount = eBikesCount;
        }
        
        /// <summary>
        /// Id of the bike point such as BikePoints_1
        /// </summary>
        /// <value>Id of the bike point such as BikePoints_1</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Name / Common name of the bike point
        /// </summary>
        /// <value>Name / Common name of the bike point</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Total bike counts
        /// </summary>
        /// <value>Total bike counts</value>
        [DataMember(Name="bikesCount", EmitDefaultValue=false)]
        public int? BikesCount { get; set; }

        /// <summary>
        /// Empty docks
        /// </summary>
        /// <value>Empty docks</value>
        [DataMember(Name="emptyDocks", EmitDefaultValue=false)]
        public int? EmptyDocks { get; set; }

        /// <summary>
        /// Total docks available
        /// </summary>
        /// <value>Total docks available</value>
        [DataMember(Name="totalDocks", EmitDefaultValue=false)]
        public int? TotalDocks { get; set; }

        /// <summary>
        /// Total standard bikes count
        /// </summary>
        /// <value>Total standard bikes count</value>
        [DataMember(Name="standardBikesCount", EmitDefaultValue=false)]
        public int? StandardBikesCount { get; set; }

        /// <summary>
        /// Total ebikes count
        /// </summary>
        /// <value>Total ebikes count</value>
        [DataMember(Name="eBikesCount", EmitDefaultValue=false)]
        public int? EBikesCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesBikePointOccupancy {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  BikesCount: ").Append(BikesCount).Append("\n");
            sb.Append("  EmptyDocks: ").Append(EmptyDocks).Append("\n");
            sb.Append("  TotalDocks: ").Append(TotalDocks).Append("\n");
            sb.Append("  StandardBikesCount: ").Append(StandardBikesCount).Append("\n");
            sb.Append("  EBikesCount: ").Append(EBikesCount).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesBikePointOccupancy);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesBikePointOccupancy instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesBikePointOccupancy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesBikePointOccupancy input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.BikesCount == input.BikesCount ||
                    (this.BikesCount != null &&
                    this.BikesCount.Equals(input.BikesCount))
                ) && 
                (
                    this.EmptyDocks == input.EmptyDocks ||
                    (this.EmptyDocks != null &&
                    this.EmptyDocks.Equals(input.EmptyDocks))
                ) && 
                (
                    this.TotalDocks == input.TotalDocks ||
                    (this.TotalDocks != null &&
                    this.TotalDocks.Equals(input.TotalDocks))
                ) && 
                (
                    this.StandardBikesCount == input.StandardBikesCount ||
                    (this.StandardBikesCount != null &&
                    this.StandardBikesCount.Equals(input.StandardBikesCount))
                ) && 
                (
                    this.EBikesCount == input.EBikesCount ||
                    (this.EBikesCount != null &&
                    this.EBikesCount.Equals(input.EBikesCount))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.BikesCount != null)
                    hashCode = hashCode * 59 + this.BikesCount.GetHashCode();
                if (this.EmptyDocks != null)
                    hashCode = hashCode * 59 + this.EmptyDocks.GetHashCode();
                if (this.TotalDocks != null)
                    hashCode = hashCode * 59 + this.TotalDocks.GetHashCode();
                if (this.StandardBikesCount != null)
                    hashCode = hashCode * 59 + this.StandardBikesCount.GetHashCode();
                if (this.EBikesCount != null)
                    hashCode = hashCode * 59 + this.EBikesCount.GetHashCode();
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
