using adopt_a_puppy_aspnetcore.Models;
using adopt_a_puppy_aspnetcore.Repositories.Interfaces;

namespace adopt_a_puppy_aspnetcore.Repositories
{
    public class PuppyRepository : IPuppyRepository
    {
        public PuppyRepository() { }

        public List<Puppy> GetAllPuppies() {
            var puppies = new List<Puppy>();
            return puppies;
        }
        public Task AddPuppy(Puppy puppy)
        {
            return Task.CompletedTask;
        }
        public Task UpdatePuppyDetails(Puppy puppy)
        {
            return Task.CompletedTask;
        }
        public Task DeletePuppyDetails(string id)
        {
            return Task.CompletedTask;
        }
        public List<Puppy> FilterPuppies()
        {
            return new List<Puppy>();
        }
    }
}
