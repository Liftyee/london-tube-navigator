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
    /// TflApiPresentationEntitiesFaresFareBounds
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesFaresFareBounds :  IEquatable<TflApiPresentationEntitiesFaresFareBounds>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesFaresFareBounds" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="from">from.</param>
        /// <param name="to">to.</param>
        /// <param name="via">via.</param>
        /// <param name="routeCode">routeCode.</param>
        /// <param name="description">description.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="_operator">_operator.</param>
        /// <param name="displayOrder">displayOrder.</param>
        /// <param name="isPopularFare">isPopularFare.</param>
        /// <param name="isPopularTravelCard">isPopularTravelCard.</param>
        /// <param name="isTour">isTour.</param>
        /// <param name="messages">messages.</param>
        public TflApiPresentationEntitiesFaresFareBounds(int? id = default(int?), string from = default(string), string to = default(string), string via = default(string), string routeCode = default(string), string description = default(string), string displayName = default(string), string _operator = default(string), int? displayOrder = default(int?), bool? isPopularFare = default(bool?), bool? isPopularTravelCard = default(bool?), bool? isTour = default(bool?), List<TflApiPresentationEntitiesMessage> messages = default(List<TflApiPresentationEntitiesMessage>))
        {
            this.Id = id;
            this.From = from;
            this.To = to;
            this.Via = via;
            this.RouteCode = routeCode;
            this.Description = description;
            this.DisplayName = displayName;
            this.Operator = _operator;
            this.DisplayOrder = displayOrder;
            this.IsPopularFare = isPopularFare;
            this.IsPopularTravelCard = isPopularTravelCard;
            this.IsTour = isTour;
            this.Messages = messages;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets From
        /// </summary>
        [DataMember(Name="from", EmitDefaultValue=false)]
        public string From { get; set; }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [DataMember(Name="to", EmitDefaultValue=false)]
        public string To { get; set; }

        /// <summary>
        /// Gets or Sets Via
        /// </summary>
        [DataMember(Name="via", EmitDefaultValue=false)]
        public string Via { get; set; }

        /// <summary>
        /// Gets or Sets RouteCode
        /// </summary>
        [DataMember(Name="routeCode", EmitDefaultValue=false)]
        public string RouteCode { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name="displayName", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets Operator
        /// </summary>
        [DataMember(Name="operator", EmitDefaultValue=false)]
        public string Operator { get; set; }

        /// <summary>
        /// Gets or Sets DisplayOrder
        /// </summary>
        [DataMember(Name="displayOrder", EmitDefaultValue=false)]
        public int? DisplayOrder { get; set; }

        /// <summary>
        /// Gets or Sets IsPopularFare
        /// </summary>
        [DataMember(Name="isPopularFare", EmitDefaultValue=false)]
        public bool? IsPopularFare { get; set; }

        /// <summary>
        /// Gets or Sets IsPopularTravelCard
        /// </summary>
        [DataMember(Name="isPopularTravelCard", EmitDefaultValue=false)]
        public bool? IsPopularTravelCard { get; set; }

        /// <summary>
        /// Gets or Sets IsTour
        /// </summary>
        [DataMember(Name="isTour", EmitDefaultValue=false)]
        public bool? IsTour { get; set; }

        /// <summary>
        /// Gets or Sets Messages
        /// </summary>
        [DataMember(Name="messages", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesMessage> Messages { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesFaresFareBounds {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Via: ").Append(Via).Append("\n");
            sb.Append("  RouteCode: ").Append(RouteCode).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Operator: ").Append(Operator).Append("\n");
            sb.Append("  DisplayOrder: ").Append(DisplayOrder).Append("\n");
            sb.Append("  IsPopularFare: ").Append(IsPopularFare).Append("\n");
            sb.Append("  IsPopularTravelCard: ").Append(IsPopularTravelCard).Append("\n");
            sb.Append("  IsTour: ").Append(IsTour).Append("\n");
            sb.Append("  Messages: ").Append(Messages).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesFaresFareBounds);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesFaresFareBounds instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesFaresFareBounds to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesFaresFareBounds input)
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
                    this.From == input.From ||
                    (this.From != null &&
                    this.From.Equals(input.From))
                ) && 
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
                ) && 
                (
                    this.Via == input.Via ||
                    (this.Via != null &&
                    this.Via.Equals(input.Via))
                ) && 
                (
                    this.RouteCode == input.RouteCode ||
                    (this.RouteCode != null &&
                    this.RouteCode.Equals(input.RouteCode))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.Operator == input.Operator ||
                    (this.Operator != null &&
                    this.Operator.Equals(input.Operator))
                ) && 
                (
                    this.DisplayOrder == input.DisplayOrder ||
                    (this.DisplayOrder != null &&
                    this.DisplayOrder.Equals(input.DisplayOrder))
                ) && 
                (
                    this.IsPopularFare == input.IsPopularFare ||
                    (this.IsPopularFare != null &&
                    this.IsPopularFare.Equals(input.IsPopularFare))
                ) && 
                (
                    this.IsPopularTravelCard == input.IsPopularTravelCard ||
                    (this.IsPopularTravelCard != null &&
                    this.IsPopularTravelCard.Equals(input.IsPopularTravelCard))
                ) && 
                (
                    this.IsTour == input.IsTour ||
                    (this.IsTour != null &&
                    this.IsTour.Equals(input.IsTour))
                ) && 
                (
                    this.Messages == input.Messages ||
                    this.Messages != null &&
                    this.Messages.SequenceEqual(input.Messages)
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
                if (this.From != null)
                    hashCode = hashCode * 59 + this.From.GetHashCode();
                if (this.To != null)
                    hashCode = hashCode * 59 + this.To.GetHashCode();
                if (this.Via != null)
                    hashCode = hashCode * 59 + this.Via.GetHashCode();
                if (this.RouteCode != null)
                    hashCode = hashCode * 59 + this.RouteCode.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.Operator != null)
                    hashCode = hashCode * 59 + this.Operator.GetHashCode();
                if (this.DisplayOrder != null)
                    hashCode = hashCode * 59 + this.DisplayOrder.GetHashCode();
                if (this.IsPopularFare != null)
                    hashCode = hashCode * 59 + this.IsPopularFare.GetHashCode();
                if (this.IsPopularTravelCard != null)
                    hashCode = hashCode * 59 + this.IsPopularTravelCard.GetHashCode();
                if (this.IsTour != null)
                    hashCode = hashCode * 59 + this.IsTour.GetHashCode();
                if (this.Messages != null)
                    hashCode = hashCode * 59 + this.Messages.GetHashCode();
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
