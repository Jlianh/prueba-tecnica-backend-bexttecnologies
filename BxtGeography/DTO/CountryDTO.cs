namespace BxtGeography.DTO
{
    public class CountryDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string flag { get; set; }
        public ICollection<DepartamentDTO> departaments { get; set; } = new List<DepartamentDTO>();

    }
}
