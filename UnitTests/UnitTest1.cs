using InfoCollector;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        AssemblyResult _result;

        public void Setup()
        {
            string path = @"C:\Users\dauks\source\repos\Spp_Lab3_Assembly_Browser\TestLib\bin\Debug\TestLib.dll";

           // GetType().Assembly.Location

            AssemblyBrowser browser = new AssemblyBrowser();

            _result = browser.GetNamespaces(path);
        }

        [Test]
        public void NamespacesTest()
        {
            Setup();
            Assert.IsNotNull(_result.Namespaces);
            Assert.AreEqual(2, _result.Namespaces.Count);
            Assert.AreEqual(_result.Namespaces[0].Name, "namespace " + nameof(StructEnumDelegate));
            Assert.AreEqual(_result.Namespaces[1].Name, "namespace " + nameof(TestLib));
        }

        [Test]
        public void ClassTest()
        {
            Setup();
            Assert.IsNotNull(_result.Namespaces[0].Classes);
            Assert.IsNotNull(_result.Namespaces[1].Classes);
            Assert.AreEqual(3, _result.Namespaces[0].Classes.Count);
            Assert.AreEqual(4, _result.Namespaces[1].Classes.Count);
        }

        [Test]
        public void FieldsTest()
        {
            Setup();
            Assert.IsNotNull(_result.Namespaces[1].Classes[1].Elements[0].ClassificationElements);
            Assert.AreEqual(6, _result.Namespaces[1].Classes[1].Elements[0].ClassificationElements.Count);
        }

        [Test]
        public void PropertiesTest()
        {
            Setup();
            Assert.IsNotNull(_result.Namespaces[1].Classes[1].Elements[1].ClassificationElements);
            Assert.AreEqual(2, _result.Namespaces[1].Classes[1].Elements[1].ClassificationElements.Count);
        }

        [Test]
        public void MethodsTest()
        {
            Setup();
            Assert.IsNotNull(_result.Namespaces[0].Classes[1].Elements[2].ClassificationElements);
            Assert.AreEqual(3, _result.Namespaces[0].Classes[1].Elements[2].ClassificationElements.Count);
        }

        [Test]
        public void ConstructorTest()
        {
            Setup();
            Assert.IsNotNull(_result.Namespaces[1].Classes[1].Elements[3].ClassificationElements);
            Assert.AreEqual(1, _result.Namespaces[1].Classes[1].Elements[3].ClassificationElements.Count);
        }
    }
}
