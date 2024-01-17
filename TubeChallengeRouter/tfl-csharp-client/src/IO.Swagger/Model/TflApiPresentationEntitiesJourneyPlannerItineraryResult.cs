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
    /// A DTO representing a list of possible journeys.
    /// </summary>
    [DataContract]
    public partial class TflApiPresentationEntitiesJourneyPlannerItineraryResult :  IEquatable<TflApiPresentationEntitiesJourneyPlannerItineraryResult>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TflApiPresentationEntitiesJourneyPlannerItineraryResult" /> class.
        /// </summary>
        /// <param name="journeys">journeys.</param>
        /// <param name="lines">lines.</param>
        /// <param name="cycleHireDockingStationData">cycleHireDockingStationData.</param>
        /// <param name="stopMessages">stopMessages.</param>
        /// <param name="recommendedMaxAgeMinutes">recommendedMaxAgeMinutes.</param>
        /// <param name="searchCriteria">searchCriteria.</param>
        /// <param name="journeyVector">journeyVector.</param>
        public TflApiPresentationEntitiesJourneyPlannerItineraryResult(List<TflApiPresentationEntitiesJourneyPlannerJourney> journeys = default(List<TflApiPresentationEntitiesJourneyPlannerJourney>), List<TflApiPresentationEntitiesLine> lines = default(List<TflApiPresentationEntitiesLine>), TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData cycleHireDockingStationData = default(TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData), List<string> stopMessages = default(List<string>), int? recommendedMaxAgeMinutes = default(int?), TflApiPresentationEntitiesJourneyPlannerSearchCriteria searchCriteria = default(TflApiPresentationEntitiesJourneyPlannerSearchCriteria), TflApiPresentationEntitiesJourneyPlannerJourneyVector journeyVector = default(TflApiPresentationEntitiesJourneyPlannerJourneyVector))
        {
            this.Journeys = journeys;
            this.Lines = lines;
            this.CycleHireDockingStationData = cycleHireDockingStationData;
            this.StopMessages = stopMessages;
            this.RecommendedMaxAgeMinutes = recommendedMaxAgeMinutes;
            this.SearchCriteria = searchCriteria;
            this.JourneyVector = journeyVector;
        }
        
        /// <summary>
        /// Gets or Sets Journeys
        /// </summary>
        [DataMember(Name="journeys", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesJourneyPlannerJourney> Journeys { get; set; }

        /// <summary>
        /// Gets or Sets Lines
        /// </summary>
        [DataMember(Name="lines", EmitDefaultValue=false)]
        public List<TflApiPresentationEntitiesLine> Lines { get; set; }

        /// <summary>
        /// Gets or Sets CycleHireDockingStationData
        /// </summary>
        [DataMember(Name="cycleHireDockingStationData", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesJourneyPlannerJourneyPlannerCycleHireDockingStationData CycleHireDockingStationData { get; set; }

        /// <summary>
        /// Gets or Sets StopMessages
        /// </summary>
        [DataMember(Name="stopMessages", EmitDefaultValue=false)]
        public List<string> StopMessages { get; set; }

        /// <summary>
        /// Gets or Sets RecommendedMaxAgeMinutes
        /// </summary>
        [DataMember(Name="recommendedMaxAgeMinutes", EmitDefaultValue=false)]
        public int? RecommendedMaxAgeMinutes { get; set; }

        /// <summary>
        /// Gets or Sets SearchCriteria
        /// </summary>
        [DataMember(Name="searchCriteria", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesJourneyPlannerSearchCriteria SearchCriteria { get; set; }

        /// <summary>
        /// Gets or Sets JourneyVector
        /// </summary>
        [DataMember(Name="journeyVector", EmitDefaultValue=false)]
        public TflApiPresentationEntitiesJourneyPlannerJourneyVector JourneyVector { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TflApiPresentationEntitiesJourneyPlannerItineraryResult {\n");
            sb.Append("  Journeys: ").Append(Journeys).Append("\n");
            sb.Append("  Lines: ").Append(Lines).Append("\n");
            sb.Append("  CycleHireDockingStationData: ").Append(CycleHireDockingStationData).Append("\n");
            sb.Append("  StopMessages: ").Append(StopMessages).Append("\n");
            sb.Append("  RecommendedMaxAgeMinutes: ").Append(RecommendedMaxAgeMinutes).Append("\n");
            sb.Append("  SearchCriteria: ").Append(SearchCriteria).Append("\n");
            sb.Append("  JourneyVector: ").Append(JourneyVector).Append("\n");
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
            return this.Equals(input as TflApiPresentationEntitiesJourneyPlannerItineraryResult);
        }

        /// <summary>
        /// Returns true if TflApiPresentationEntitiesJourneyPlannerItineraryResult instances are equal
        /// </summary>
        /// <param name="input">Instance of TflApiPresentationEntitiesJourneyPlannerItineraryResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TflApiPresentationEntitiesJourneyPlannerItineraryResult input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Journeys == input.Journeys ||
                    this.Journeys != null &&
                    this.Journeys.SequenceEqual(input.Journeys)
                ) && 
                (
                    this.Lines == input.Lines ||
                    this.Lines != null &&
                    this.Lines.SequenceEqual(input.Lines)
                ) && 
                (
                    this.CycleHireDockingStationData == input.CycleHireDockingStationData ||
                    (this.CycleHireDockingStationData != null &&
                    this.CycleHireDockingStationData.Equals(input.CycleHireDockingStationData))
                ) && 
                (
                    this.StopMessages == input.StopMessages ||
                    this.StopMessages != null &&
                    this.StopMessages.SequenceEqual(input.StopMessages)
                ) && 
                (
                    this.RecommendedMaxAgeMinutes == input.RecommendedMaxAgeMinutes ||
                    (this.RecommendedMaxAgeMinutes != null &&
                    this.RecommendedMaxAgeMinutes.Equals(input.RecommendedMaxAgeMinutes))
                ) && 
                (
                    this.SearchCriteria == input.SearchCriteria ||
                    (this.SearchCriteria != null &&
                    this.SearchCriteria.Equals(input.SearchCriteria))
                ) && 
                (
                    this.JourneyVector == input.JourneyVector ||
                    (this.JourneyVector != null &&
                    this.JourneyVector.Equals(input.JourneyVector))
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
                if (this.Journeys != null)
                    hashCode = hashCode * 59 + this.Journeys.GetHashCode();
                if (this.Lines != null)
                    hashCode = hashCode * 59 + this.Lines.GetHashCode();
                if (this.CycleHireDockingStationData != null)
                    hashCode = hashCode * 59 + this.CycleHireDockingStationData.GetHashCode();
                if (this.StopMessages != null)
                    hashCode = hashCode * 59 + this.StopMessages.GetHashCode();
                if (this.RecommendedMaxAgeMinutes != null)
                    hashCode = hashCode * 59 + this.RecommendedMaxAgeMinutes.GetHashCode();
                if (this.SearchCriteria != null)
                    hashCode = hashCode * 59 + this.SearchCriteria.GetHashCode();
                if (this.JourneyVector != null)
                    hashCode = hashCode * 59 + this.JourneyVector.GetHashCode();
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