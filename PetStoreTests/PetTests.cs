using System;
using System.Collections.Generic;
using System.Net;
using Applications.PetStore.Swagger.Api;
using Applications.PetStore.Swagger.Client;
using Applications.PetStore.Swagger.Model;
using NUnit.Framework;

namespace PetStoreTests;

public class PetTests : TestHelper
{

    [Test]
    [QaVerification.Grading]
    public void GetPetThatExists()
    {
        // Arrange
        var petApi = new PetApi(BasePath);

        // Act
        var pet = petApi.GetPetById(1);

        // Assert
        Assert.That(pet, Is.Not.Null);
        Assert.That(pet.Id, Is.EqualTo(1));
        Assert.That(pet.Name, Is.Not.Null);
    }

    [Test]
    [QaVerification.Grading]
    public void GetPetThatDoesNotExist()
    {
        // Arrange
        var petApi = new PetApi(BasePath);

        // Act & Assert
        var ex = Assert.Throws<ApiException>(() => petApi.GetPetById(99));
        Assert.That(ex!.ErrorCode, Is.EqualTo(404));
    }

    [Test]
    [QaVerification.Grading]
    public void AddPet()
    {
        // Arrange
        var petApi = new PetApi(BasePath);
        var petName = "TestCat" + new Random().Next(1, 10000);
        var newPet = new Pet(
        name: petName,
        photoUrls: new List<string> { "http://example.com/photo1.jpg" }
    );
        newPet.Status = Pet.StatusEnum.Available;

        // Act - add the pet then find it by name
        petApi.AddPet(newPet);
        var results = petApi.FindPetsByStatus(new List<string> { "available" });
        var result = results.Find(p => p.Name == petName);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Name, Is.EqualTo(petName));
    }

    [Test]
    [QaVerification.Grading]
    public void RemovePet()
    {
         // Arrange - create a pet first
        var petApi = new PetApi(BasePath);
        var petName = "TestDog" + new Random().Next(1, 10000);
        var newPet = new Pet(
            name: petName,
            photoUrls: new List<string> { "http://example.com/photo1.jpg" }
    );
        newPet.Status = Pet.StatusEnum.Available;

        // Act - add the pet
        petApi.AddPet(newPet);
        var results = petApi.FindPetsByStatus(new List<string> { "available" });
        var createdPet = results.Find(p => p.Name == petName);

        // Act - remove the pet
        Assert.That(createdPet, Is.Not.Null);
        petApi.DeletePet(createdPet!.Id);

        // Assert - pet no longer exists
        var ex = Assert.Throws<ApiException>(() => petApi.GetPetById(createdPet!.Id));
        Assert.That(ex!.ErrorCode, Is.EqualTo(404));
    }
}
