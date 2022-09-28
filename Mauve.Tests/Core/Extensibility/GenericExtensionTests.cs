using System;

using Mauve.Extensibility;
using Mauve.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Extensibility
{
    [TestClass]
    public class GenericExtensionTests
    {
        [TestMethod]
        [DataRow(32, SerializationMethod.None)]
        [DataRow(32, SerializationMethod.Binary)]
        [DataRow(32, SerializationMethod.Xml)]
        [DataRow(32, SerializationMethod.Json)]
        [DataRow(32, SerializationMethod.Yaml)]
        public void SerializeAndDeserialize(int input, SerializationMethod serializationMethod)
        {
            string serializedInput = input.Serialize(serializationMethod);
            int deserializedValue = serializedInput.Deserialize<int>(serializationMethod);
            Assert.AreEqual(input, deserializedValue);
        }
    }
}
