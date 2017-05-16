using Xunit;
using Toz.Dotnet.Core.Interfaces;
using Toz.Dotnet.Tests.Helpers;
using Toz.Dotnet.Models;
using Toz.Dotnet.Models.EnumTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Toz.Dotnet.Tests.Tests
{
    public class PetsManagementTest
    {
        private readonly Pet _testingPet;
        private readonly IPetsManagementService _petsManagementService;

        public PetsManagementTest()
        { 
            _testingPet = new Pet
            {
                Id = Guid.NewGuid().ToString(),
                Name = "TestDog",
                Type = PetType.Dog,
                Sex = PetSex.Male,
                Photo = new byte[10],
                Description = "Dog that eats tigers",
                Address = "Found in the jungle",
                Created = DateTime.Now,
                LastModified = DateTime.Now
            };
            _petsManagementService = ServiceProvider.Instance.Resolve<IPetsManagementService>();
            _petsManagementService.RequestUri = RequestUriHelper.PetsUri;
        }

        [Fact]
        public void TestDependencyInjection()
        {
            Assert.NotNull(_petsManagementService);
        }

        [Fact]
        public void TestRequestedUriNotEmpty()
        {
            Assert.True(!string.IsNullOrEmpty(_petsManagementService.RequestUri));
        }

        [Fact]
        public void TestOfGettingAllPets()
        {
            Assert.NotNull(_petsManagementService.GetAllPets().Result);
        }
         
        [Fact]
        public void TestOfCreatingNewPet()
        {
            var result = _petsManagementService.CreatePet(_testingPet).Result;
            Assert.True(result);
        }
        
        [Fact]
        public void TestOfDeletingSpecifiedPet()
        {
            Assert.True(_petsManagementService.DeletePet(_testingPet).Result);
        }
        
        [Fact]
        public void TestOfGettingSpecifiedPet()
        {
            Assert.NotNull(_petsManagementService.GetPet(_testingPet.Id).Result);        
        }

        [Fact]
        public void TestOfUpdatingPet()
        {
            Assert.True(_petsManagementService.UpdatePet(_testingPet).Result);
        }

        [Fact]
        public void TestOfUpdatingPetWithNullValue()
        {
            var exception = Record.Exception(() => _petsManagementService.UpdatePet(null).Result);
            Assert.IsType(typeof(NullReferenceException), exception?.InnerException);
        }

        [Fact]
        public void TestOfDeletingPetThatIsNull()
        {
            var exception = Record.Exception(() => _petsManagementService.DeletePet(null).Result);
            Assert.IsType(typeof(NullReferenceException), exception?.InnerException);
        }

        [Fact]
        public void TestOfGettingAllPetsUsingWrongUrl()
        {
            _petsManagementService.RequestUri = RequestUriHelper.WrongUrl;
            Assert.Null(_petsManagementService.GetAllPets().Result);
            _petsManagementService.RequestUri = RequestUriHelper.PetsUri;
        }

        [Fact]
        public void TestPetValidationIfCorrectData()
        {
            // Arrange
            var context = new ValidationContext(_testingPet, null, null);
            var result = new List<ValidationResult>();

            // Act
            bool valid = Validator.TryValidateObject(_testingPet, context, result, true);

            Assert.True(valid);
        }

        [Theory]
        [InlineData("Type")]
        public void TestPetValidationIfRequiredPropertyIsNotInitialized(string property)
        {
            // Arrange
            Pet pet = ClonePet(_testingPet);

            if (property.Equals("Type"))
            {
                pet.Type = PetType.Unidentified;
            }
           
            var context = new ValidationContext(pet, null, null);
            var result = new List<ValidationResult>();

            // Act
            bool valid = Validator.TryValidateObject(pet, context, result, true);

            Assert.False(valid);
        }

        [Theory]
        [InlineData("Name")]
        [InlineData("Address")]
        [InlineData("Description")]
        public void TestPetValidationIfStringIsTooLong(string property)
        {
            // Arrange
            Pet pet = ClonePet(_testingPet);

            if (property.Equals("Name")) 
            { 
                pet.Name = new string('x', 40);
            }
            else if (property.Equals("Address"))
            {
                pet.Address = new string('x', 101);
            }
            else if (property.Equals("Description"))
            {
                pet.Description = new string('x', 310);
            }

            var context = new ValidationContext(pet, null, null);
            var result = new List<ValidationResult>();

            //Act
            bool valid = Validator.TryValidateObject(pet, context, result, true);

            Assert.False(valid);                      
        }

        [Fact]
        public void TestPetValidationIfPetTypeIsUndentified()
        {
            var pet = ClonePet(_testingPet);
            pet.Type = PetType.Unidentified;
            var validationContext = new ValidationContext(pet, null, null);
            var validationResult = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(pet, validationContext, validationResult, true));
        }

        [Fact]
        public void TestPetValidationIfPetSexIsUnknown()
        {
            var pet = ClonePet(_testingPet);
            pet.Sex = PetSex.Unknown;
            var validationContext = new ValidationContext(pet, null, null);
            var validationResult = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(pet, validationContext, validationResult, true));
        }

        [Fact]
        public void TestPetPhotoConvertingToByteArray()
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("Test"));
            var streamBytes = _petsManagementService.ConvertPhotoToByteArray(stream);
            Assert.NotNull(streamBytes);
            Assert.True(streamBytes.Length > 0);
        }

        private Pet ClonePet(Pet pet)
        {
            return new Pet
            {
                Id = pet.Id,
                Name = pet.Name,
                Type = pet.Type,
                Sex = pet.Sex,
                Photo = (byte[])pet.Photo.Clone(),
                Description = pet.Description,
                Address = pet.Address,
                Created = pet.Created,
                LastModified = pet.LastModified
            };
        }
    }
}
