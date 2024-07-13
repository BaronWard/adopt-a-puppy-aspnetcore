using adopt_a_puppy_aspnetcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace adopt_a_puppy_aspnetcore.Controllers
{
    [Route("api/puppies")]
    [ApiController]
    public class PuppiesController : ControllerBase
    {
        [HttpPost(Name = "AddPuppy")]
        public Task<Puppy> AddPuppy(Puppy puppy)
        {
            return Task.FromResult(puppy);
        }

        [HttpGet(Name = "GetAllPuppies")]
        public IEnumerable<Puppy> GetAll()
        {
            var puppies = new List<Puppy>();
            return puppies;
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

        [HttpPost(Name = "FilterPuppies")]
        public IEnumerable<Puppy> FilterPuppies()
        {
            var filteredPuppies = new List<Puppy>();
            return filteredPuppies;
        }
    }
}
