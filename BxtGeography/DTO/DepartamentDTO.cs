namespace BxtGeography.DTO
{
    public class DepartamentDTO
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string countryName{ get; set; }
        public int? countryId { get; set; }
        public ICollection<CityDTO> city {  get; set; } = new List<CityDTO>();
    }
}
