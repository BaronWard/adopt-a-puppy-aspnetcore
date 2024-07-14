using adopt_a_puppy_aspnetcore.Models;
using adopt_a_puppy_aspnetcore.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace adopt_a_puppy_aspnetcore.Controllers
{
    [Route("api/puppies")]
    [ApiController]
    public class PuppiesController : ControllerBase
    {
        private readonly IPuppyRepository _puppyRepository;

        public PuppiesController(IPuppyRepository puppyRepository)
        {
            _puppyRepository = puppyRepository;
        }

        [HttpPost(Name = "AddPuppy")]
        public Task<Puppy> AddPuppy(Puppy puppy)
        {
            return Task.FromResult(puppy);
        }

        [HttpGet(Name = "GetAllPuppies")]
        public IEnumerable<Puppy> GetAll()
        {
            var puppies = _puppyRepository.GetAllPuppies();
            return puppies;
        }

        [HttpGet("{id}")]
        public Task<Puppy> GetPuppyDetails(int id)
        {
            var puppy = _puppyRepository.GetPuppy(id);
            return Task.FromResult(puppy);
        }

        [HttpPut(Name = "UpdatePuppyDetails")]
        public Task<bool> UpdatePuppy(int puppyId)
        {
            return Task.FromResult(true);
        }

        [HttpDelete(Name = "RemovePuppy")]
        public Task<bool> DeletePuppy(int puppyId)
        {
            return Task.FromResult(true);
        }

        [HttpGet("filterOptions")]
        public IEnumerable<Puppy> FilterPuppies([FromQuery]string? breed, int? age, string? size, string? gender)
        {
            var filteredPuppies = _puppyRepository.FilterPuppies(breed, age, size, gender); 
            return filteredPuppies;
        }
    }
}
