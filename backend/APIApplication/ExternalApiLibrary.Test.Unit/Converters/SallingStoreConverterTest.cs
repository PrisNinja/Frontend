using ExternalApiLibrary.ExternalAPIComponent.Converters.Interfaces;
using ExternalApiLibrary.ExternalAPIComponent.Converters.Salling;
using NUnit.Framework;

namespace ExternalApiLibrary.Test.Unit.Converters;

[TestFixture]
public class SallingStoreConverterTest
{
    private IConverter _uut;

    [SetUp]
    public void Setup()
    {
        _uut = new SallingStoreConverter();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}