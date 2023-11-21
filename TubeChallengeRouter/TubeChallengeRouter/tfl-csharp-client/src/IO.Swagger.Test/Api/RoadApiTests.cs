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
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing RoadApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class RoadApiTests
    {
        private RoadApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new RoadApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of RoadApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' RoadApi
            //Assert.IsInstanceOfType(typeof(RoadApi), instance, "instance is a RoadApi");
        }

        
        /// <summary>
        /// Test RoadDisruptedStreets
        /// </summary>
        [Test]
        public void RoadDisruptedStreetsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //DateTime? startDate = null;
            //DateTime? endDate = null;
            //var response = instance.RoadDisruptedStreets(startDate, endDate);
            //Assert.IsInstanceOf<SystemObject> (response, "response is SystemObject");
        }
        
        /// <summary>
        /// Test RoadDisruption
        /// </summary>
        [Test]
        public void RoadDisruptionTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> ids = null;
            //bool? stripContent = null;
            //List<string> severities = null;
            //List<string> categories = null;
            //bool? closures = null;
            //var response = instance.RoadDisruption(ids, stripContent, severities, categories, closures);
            //Assert.IsInstanceOf<List<TflApiPresentationEntitiesRoadDisruption>> (response, "response is List<TflApiPresentationEntitiesRoadDisruption>");
        }
        
        /// <summary>
        /// Test RoadDisruptionById
        /// </summary>
        [Test]
        public void RoadDisruptionByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> disruptionIds = null;
            //bool? stripContent = null;
            //var response = instance.RoadDisruptionById(disruptionIds, stripContent);
            //Assert.IsInstanceOf<TflApiPresentationEntitiesRoadDisruption> (response, "response is TflApiPresentationEntitiesRoadDisruption");
        }
        
        /// <summary>
        /// Test RoadGet
        /// </summary>
        [Test]
        public void RoadGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.RoadGet();
            //Assert.IsInstanceOf<List<TflApiPresentationEntitiesRoadCorridor>> (response, "response is List<TflApiPresentationEntitiesRoadCorridor>");
        }
        
        /// <summary>
        /// Test RoadGet_0
        /// </summary>
        [Test]
        public void RoadGet_0Test()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> ids = null;
            //var response = instance.RoadGet_0(ids);
            //Assert.IsInstanceOf<List<TflApiPresentationEntitiesRoadCorridor>> (response, "response is List<TflApiPresentationEntitiesRoadCorridor>");
        }
        
        /// <summary>
        /// Test RoadMetaCategories
        /// </summary>
        [Test]
        public void RoadMetaCategoriesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.RoadMetaCategories();
            //Assert.IsInstanceOf<List<string>> (response, "response is List<string>");
        }
        
        /// <summary>
        /// Test RoadMetaSeverities
        /// </summary>
        [Test]
        public void RoadMetaSeveritiesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.RoadMetaSeverities();
            //Assert.IsInstanceOf<List<TflApiPresentationEntitiesStatusSeverity>> (response, "response is List<TflApiPresentationEntitiesStatusSeverity>");
        }
        
        /// <summary>
        /// Test RoadStatus
        /// </summary>
        [Test]
        public void RoadStatusTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> ids = null;
            //DateTime? dateRangeNullableStartDate = null;
            //DateTime? dateRangeNullableEndDate = null;
            //var response = instance.RoadStatus(ids, dateRangeNullableStartDate, dateRangeNullableEndDate);
            //Assert.IsInstanceOf<List<TflApiPresentationEntitiesRoadCorridor>> (response, "response is List<TflApiPresentationEntitiesRoadCorridor>");
        }
        
    }

}
