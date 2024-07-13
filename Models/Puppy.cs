namespace adopt_a_puppy_aspnetcore.Models
{
    public class Puppy
    {
        public int Id { get; set; }
        public string Name { get; set; } = "No Name";
        public int Age { get; set; }
        public string Gender { get; set; } = "Undetermined";
        public bool IsVaccinated { get; set; }
        public bool IsNeutered { get; set; }
        public string Size { get; set; } = "Undetermined";
        public string Breed { get; set; } = "Undetermined";
        public List<string> Traits { get; set; } = new List<string>();
        public string PhotoUrl { get; set; } = "";
    }
}
