using adopt_a_puppy_aspnetcore.Models;
using adopt_a_puppy_aspnetcore.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace adopt_a_puppy_aspnetcore.Repositories
{
    public class PuppyRepository : IPuppyRepository
    {
        private readonly List<Puppy> _puppies;
        public PuppyRepository() {
            //Get Data from JSON to simulate DbConnection
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Puppies.json" );
            var jsonData = File.ReadAllText(jsonFilePath);
            _puppies = JsonConvert.DeserializeObject<List<Puppy>>(jsonData) ?? [];
        }

        public List<Puppy> GetAllPuppies() {
            return _puppies;
        }

        public Puppy GetPuppy(int id)
        {
            return _puppies.FirstOrDefault(puppy => puppy.Id == id);
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
        public List<Puppy> FilterPuppies(string? breed, int? age, string? size, string? gender)
        {
            var query = _puppies.AsQueryable();
            if (!string.IsNullOrWhiteSpace(breed))
            {
                query = query.Where(puppy => puppy.Breed.ToLower() == breed.Trim().ToLower());
            }

            if (age.HasValue)
            {
                if (int.IsPositive((int)age))
                {
                    query = query.Where(puppy => puppy.Age == age);
                }
            }

            if (!string.IsNullOrEmpty(size))
            {
                query = query.Where(puppy => puppy.Size == size);
            }

            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(puppy => puppy.Gender == gender);
            }

            return query.ToList();
        }
    }
}
