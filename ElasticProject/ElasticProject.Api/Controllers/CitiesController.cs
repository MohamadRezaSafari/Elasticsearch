using CsvHelper;
using ElasticProject.Data.Domain;
using ElasticProject.Data.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ElasticProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly IElasticsearchService _elasticsearchService;
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(IElasticsearchService elasticsearchService,
            ILogger<CitiesController> logger)
        {
            _elasticsearchService = elasticsearchService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _elasticsearchService.Search("cities");

            //List<CityDto> records;

            //using (var reader = new StreamReader(@"D:\Develop\Elasticsearch\ElasticProject\worldcities.csv"))
            //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //{
            //    records = csv.GetRecords<CityDto>().ToList();
            //}

            //var cities = new List<Cities>();

            //for (int i = 0; i < records.Count; i++)
            //{
            //    var aa = records[i];

            //    cities.Add(new Cities()
            //    {
            //        Id = i,
            //        City = (records[i]).city,
            //        Population = SetPopulation((records[i]).population),
            //        CreatedDate = DateTime.UtcNow,

            //    });
            //}

            //_elasticsearchService.InsertBulkDocuments("cities", cities);

            //_elasticsearchService.DeleteByIdDocument("cities", new Cities() { Id= 1 });
            //var cities = new List<Cities>()
            //{
            //    new Cities
            //    {
            //        Id = 1,
            //        City = "tabriz 1",
            //        Region = "Azerbaijan-Shargi 1",
            //        Population = 1,
            //        CreatedDate = DateTime.Now
            //    },
            //    new Cities
            //    {
            //        Id = 2,
            //        City = "tabriz 2",
            //        Region = "Azerbaijan-Shargi 2",
            //        Population = 2,
            //        CreatedDate = DateTime.Now
            //    },
            //    new Cities
            //    {
            //        Id = 3,
            //        City = "tabriz 3",
            //        Region = "Azerbaijan-Shargi 3",
            //        Population = 3,
            //        CreatedDate = DateTime.Now
            //    },
            //    new Cities
            //    {
            //        Id = 4,
            //        City = "tabriz 4",
            //        Region = "Azerbaijan-Shargi 4",
            //        Population = 4,
            //        CreatedDate = DateTime.Now
            //    }
            //};

            //_elasticsearchService.InsertBulkDocuments("cities", cities);

            return Ok(result);
        }

        private int SetPopulation(string population)
        {
            Int32.TryParse(population, out int result);

            return result;
        }
    }
}