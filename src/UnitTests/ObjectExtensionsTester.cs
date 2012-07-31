using System;
using System.Linq;
using Core.Extensions;
using NUnit.Framework;
using Should;

namespace UnitTests
{
    [TestFixture]
    public class ObjectExtensionsTester
    {
        [Test]
        public void Should_return_parameter_list_if_property_is_not_null()
        {
            var parameterList = GetTestObject().ToParameterList();
            parameterList.Count(x => x.Key == "TestBool").ShouldEqual(1);
            parameterList.Count(x => x.Key == "TestDate").ShouldEqual(1);
            parameterList.Count(x => x.Key == "TestInt").ShouldEqual(1);
            parameterList.Count(x => x.Key == "TestIntArray").ShouldEqual(5);
            parameterList.Count(x => x.Key == "TestString").ShouldEqual(1);
            parameterList.Count(x => x.Key == "TestStringArray").ShouldEqual(2);
            parameterList.Count(x => x.Key == "TestDateArray").ShouldEqual(3);
        }

        private TestObject GetTestObject()
        {
            return new TestObject
            {
                TestBool = false,
                TestDate = DateTime.Today,
                TestInt = 5,
                TestIntArray = new[] {1, 2, 3, 4, 5},
                TestString = "",
                TestStringArray = new[] {"test", "string"},
                TestDateArray = new[] {DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today.AddDays(2),}
            };
        }
    }

    internal class TestObject
    {
        public DateTime? TestDate { get; set; }
        public DateTime[] TestDateArray { get; set; }
        public string TestString { get; set; }
        public int? TestInt { get; set; }
        public bool? TestBool { get; set; }
        public int[] TestIntArray { get; set; }
        public string[] TestStringArray { get; set; }
    }
}