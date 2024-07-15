# adopt-a-puppy-aspnetcore

Below is the unit test code used for the controllers (using Moq, Microsoft.AspNetCore.Mvc.Testing, and Microsoft.AspNetCore.Mvc.NewtonsoftJson packages on a xUnit Testing Project)
<------------------------------------ Start of Test Code -------------------------------------------->
using adopt_a_puppy_aspnetcore.Controllers;
using adopt_a_puppy_aspnetcore.Models;
using adopt_a_puppy_aspnetcore.Repositories.Interfaces;
using Moq;

namespace AdoptAPuppy.Tests
{
    public class PuppiesControllerTests
    {
        private readonly Mock<IPuppyRepository> _mockRepo;
        private readonly PuppiesController _controller;

        public PuppiesControllerTests()
        {
            _mockRepo = new Mock<IPuppyRepository>();
            _controller = new PuppiesController(_mockRepo.Object);
        }

        [Fact]
        public void GetAll_RetrieveAllPuppies()
        {
            var puppies = new List<Puppy> {
                new Puppy { Id = 1, Age= 1, Name="Charlie" },
                new Puppy { Id = 2, Age = 3, Name="Jane"}
            };

            _mockRepo.Setup(repo => repo.GetAllPuppies()).Returns(puppies);

            var result = _controller.GetAll();

            Assert.Equal(puppies, result);
        }

        [Fact]
        public void GetPuppyDetails_ReturnsPuppy()
        {
            var puppy = new Puppy { Id = 1, Name = "Buddy" };
            _mockRepo.Setup(repo => repo.GetPuppy(1)).Returns(puppy);

            var result = _controller.GetPuppyDetails(1).Result;

            Assert.Equal(puppy, result);
        }

        [Fact]
        public void FilterPuppies_ReturnsFilteredPuppies()
        {
            var puppies = new List<Puppy> {
                new Puppy { Id = 1, Name = "Buddy", Breed = "Labrador", Age = 2, Size = "Medium", Gender = "Male" },
                new Puppy { Id = 2, Name = "Bella", Breed = "Beagle", Age = 1, Size = "Small", Gender = "Female" }
            };
            _mockRepo.Setup(repo => repo.FilterPuppies("Labrador", null, null, null)).Returns(new List<Puppy> { puppies[0] });

            var result = _controller.FilterPuppies("Labrador", null, null, null);

            Assert.Single(result);
            Assert.Equal("Buddy", result.First().Name);
        }
    }
}
<------------------------------------ End of Test Code -------------------------------------------->
