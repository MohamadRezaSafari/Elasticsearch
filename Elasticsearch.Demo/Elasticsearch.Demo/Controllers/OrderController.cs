using Elasticsearch.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elasticsearch.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OrderController> _logger;
        private readonly ElasticContext context;
        private readonly IElasticClient elasticClient;

        public OrderController(ILogger<OrderController> logger, ElasticContext context, IElasticClient elasticClient)
        {
            _logger = logger;
            this.context = context;
            this.elasticClient = elasticClient;
        }


        [HttpGet("GetColorById/{id}")]
        public async Task<Color> GetColorById(long id)
        {
            var response = await elasticClient.GetAsync<Color>(new DocumentPath<Color>(new Id(id)), i => i.Index("colors"));

            return response?.Source;
        }


        [HttpGet("GetColor/{colorName}")]
        public async Task<Color> GetColor(string colorName)
        {
            var response = await elasticClient.SearchAsync<Color>
                (i =>
                    i.Index("colors")
                    .Query(
                        q => q.Term(t => t.ColorName, colorName)
                        ||
                        q.Match(m => m.Field(f => f.ColorName).Query(colorName))
                    )
                );

            return response?.Documents?.FirstOrDefault();
        }


        //[HttpGet]
        //[Route("GetAllOrders")]
        //public async Task<List<Order>> GetAllOrders()
        //{
        //    return await context.Orders.ToListAsync();
        //}
    }
}
