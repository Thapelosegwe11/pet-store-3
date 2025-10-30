using Applications.PetStore.Swagger.Api;
using NUnit.Framework;

namespace PetStoreTests;

public class InventoryTests
{
    readonly StoreApi _storeApi = new StoreApi(TestHelper.BasePath);

    [Test]
    [QaVerification.Grading]
    public void GetInventoryShouldReturnInventory()
    {
        var inventory = _storeApi.GetInventory();

        Assert.That(inventory, Is.Not.Empty);
        Assert.That(inventory.ContainsKey("sold"), Is.True);
        Assert.That(inventory.ContainsKey("pending"), Is.True);
        Assert.That(inventory.ContainsKey("available"), Is.True);
    }
}
