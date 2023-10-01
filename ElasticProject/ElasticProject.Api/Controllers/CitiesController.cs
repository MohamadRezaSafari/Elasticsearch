using ElasticProject.Data.Domain;
using ElasticProject.Data.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
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

            return Ok();
        }
    }
}