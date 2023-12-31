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
    ///  Class for testing SearchApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class SearchApiTests
    {
        private SearchApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new SearchApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of SearchApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' SearchApi
            //Assert.IsInstanceOfType(typeof(SearchApi), instance, "instance is a SearchApi");
        }

        
        /// <summary>
        /// Test SearchBusSchedules
        /// </summary>
        [Test]
        public void SearchBusSchedulesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string query = null;
            //var response = instance.SearchBusSchedules(query);
            //Assert.IsInstanceOf<TflApiPresentationEntitiesSearchResponse> (response, "response is TflApiPresentationEntitiesSearchResponse");
        }
        
        /// <summary>
        /// Test SearchGet
        /// </summary>
        [Test]
        public void SearchGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string query = null;
            //var response = instance.SearchGet(query);
            //Assert.IsInstanceOf<TflApiPresentationEntitiesSearchResponse> (response, "response is TflApiPresentationEntitiesSearchResponse");
        }
        
        /// <summary>
        /// Test SearchMetaCategories
        /// </summary>
        [Test]
        public void SearchMetaCategoriesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.SearchMetaCategories();
            //Assert.IsInstanceOf<List<string>> (response, "response is List<string>");
        }
        
        /// <summary>
        /// Test SearchMetaSearchProviders
        /// </summary>
        [Test]
        public void SearchMetaSearchProvidersTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.SearchMetaSearchProviders();
            //Assert.IsInstanceOf<List<string>> (response, "response is List<string>");
        }
        
        /// <summary>
        /// Test SearchMetaSorts
        /// </summary>
        [Test]
        public void SearchMetaSortsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.SearchMetaSorts();
            //Assert.IsInstanceOf<List<string>> (response, "response is List<string>");
        }
        
    }

}
