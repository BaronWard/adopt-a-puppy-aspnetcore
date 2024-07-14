using adopt_a_puppy_aspnetcore.Models;

namespace adopt_a_puppy_aspnetcore.Repositories.Interfaces
{
    public interface IPuppyRepository
    {
        public List<Puppy> GetAllPuppies();
        public Puppy GetPuppy(int id);
        public Task AddPuppy(Puppy puppy);
        public Task UpdatePuppyDetails(Puppy puppy);
        public Task DeletePuppyDetails(string id);
        public List<Puppy> FilterPuppies(string? breed, int? age, string? size, string? gender);
    }
}
