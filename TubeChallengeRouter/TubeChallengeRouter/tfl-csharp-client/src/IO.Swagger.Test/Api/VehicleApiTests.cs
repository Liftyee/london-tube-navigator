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
    ///  Class for testing VehicleApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class VehicleApiTests
    {
        private VehicleApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new VehicleApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of VehicleApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' VehicleApi
            //Assert.IsInstanceOfType(typeof(VehicleApi), instance, "instance is a VehicleApi");
        }

        
        /// <summary>
        /// Test VehicleGet
        /// </summary>
        [Test]
        public void VehicleGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> ids = null;
            //var response = instance.VehicleGet(ids);
            //Assert.IsInstanceOf<List<TflApiPresentationEntitiesPrediction>> (response, "response is List<TflApiPresentationEntitiesPrediction>");
        }
        
    }

}
