namespace TodoApiTest;
using Microsoft.AspNetCore.Mvc.Testing;


[TestClass]
public class UnitTest1
{

    [TestMethod]
    public void TestMethod1()
    {
        bool result = false;
        Assert.IsFalse(result, "false better be false");
    }

    [TestMethod]
    public void DieShouldReturnIntInRange()
    {

    }
}
