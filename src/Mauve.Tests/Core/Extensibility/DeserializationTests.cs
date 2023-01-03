using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mauve.Extensibility;
using Mauve.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Extensibility
{
    [TestClass]
    public class DeserializationTests
    {

        #region Sub-Types

        [Serializable]
        public struct TestModel
        {

            #region Fields

            private int _id;
            private string _name;

            #endregion

            #region Properties

            public int Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }

            #endregion

        }

        #endregion

        #region Constants

        private const string RawData = @"Mauve.Tests.Core.Extensibility.DeserializationTests+TestModel";
        private const string BinaryData = "Ā\0\uff00\uffffǿ\0\0\0ఀ\u0002\0䵂畡敶吮獥獴‬敖獲潩㵮⸱⸰⸰ⰰ䌠汵畴敲渽略牴污‬畐汢捩敋呹歯湥渽汵լ\u0001\0䴽畡敶吮獥獴䌮牯\u2e65硅整獮扩汩瑩\u2e79敄敳楲污穩瑡潩呮獥獴含獥䵴摯汥\u0002\0弃摩弅慮敭ĀȈ\0Ā\0؀\u0003\0各獥୴";
        private const string XmlData = @"<TestModel xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Id>1</Id>
  <Name>Test</Name>
</TestModel>";
        private const string JsonData = @"{""Id"":1,""Name"":""Test""}";
        private const string YamlData = @"id: 1
name: Test";

        #endregion

        #region Public Methods

        [TestMethod]
        [DataRow(RawData, SerializationMethod.None)]
        [DataRow(BinaryData, SerializationMethod.Binary)]
        [DataRow(XmlData, SerializationMethod.Xml)]
        [DataRow(JsonData, SerializationMethod.Json)]
        [DataRow(YamlData, SerializationMethod.Yaml)]
        public void DeserializationTest(string input, SerializationMethod serializationMethod)
        {
            try
            {
                var expectedResult = new TestModel
                {
                    Id = 1,
                    Name = "Test"
                };
                TestModel deserializedData = input.Deserialize<TestModel>(serializationMethod);
                Assert.AreEqual(expectedResult, deserializedData);
            } catch (Exception e)
            {
                // SerializationMethod.None will always fail in the case of complex data.
                if (serializationMethod != SerializationMethod.None)
                    Assert.Fail(e.Message);
            }
        }

        #endregion

    }
}
