namespace ElasticProject.Data.Domain
{
    public class Cities
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int Population { get; set; }
        public DateTime CreatedDate { get; set; }
    }


    public class CityDto
    {
        public long Id { get; set; }
        public string City { get; set; }
        public int Population { get; set; }
    }
}
