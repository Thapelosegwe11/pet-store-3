using System;
using System.Collections.Generic;
using Applications.PetStore.Swagger.Api;
using Applications.PetStore.Swagger.Model;
using NUnit.Framework;

namespace PetStoreTests;

public class OrderTests
{
    [Test]
    [QaVerification.Grading]
    public void AddOrder()
    {
        // Arrange - create a pet to order
        var petApi = new PetApi(TestHelper.BasePath);
        var storeApi = new StoreApi(TestHelper.BasePath);

        var petName = "TestBird" + new Random().Next(1, 10000);
        var newPet = new Pet(
            name: petName,
            photoUrls: new List<string> { "http://example.com/photo1.jpg" }
        );
        newPet.Status = Pet.StatusEnum.Available;
        petApi.AddPet(newPet);

        var results = petApi.FindPetsByStatus(new List<string> { "available" });
        var createdPet = results.Find(p => p.Name == petName);

        // Act - place an order
        var order = new Order();
        order.PetId = createdPet!.Id;
        order.Quantity = 1;
        order.Status = Order.StatusEnum.Placed;
        var result = storeApi.PlaceOrder(order);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.PetId, Is.EqualTo(createdPet.Id));
        Assert.That(result.Quantity, Is.EqualTo(1));
        Assert.That(result.Status, Is.EqualTo(Order.StatusEnum.Placed));
    }
}