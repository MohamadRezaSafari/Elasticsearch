using ElasticProject.Data.Domain;
using ElasticProject.Data.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticProject.Data.Infrastructure.Mapping;
using Microsoft.Extensions.Configuration;
using Nest;

namespace ElasticProject.Data.Service
{
    public class ElasticsearchService : IElasticsearchService
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticClient _client;

        public ElasticsearchService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = CreateInstance();
        }

        private ElasticClient CreateInstance()
        {
            string host = _configuration.GetSection("ElasticsearchServer:Host").Value;
            string port = _configuration.GetSection("ElasticsearchServer:Port").Value;
            string username = _configuration.GetSection("ElasticsearchServer:Username").Value;
            string password = _configuration.GetSection("ElasticsearchServer:Password").Value;

            var settings = new ConnectionSettings(new Uri(host + ":" + port));
            if (username is not null && password is not null)
                settings.BasicAuthentication(username, password);

            return new ElasticClient(settings);
        }

        public async Task CheckIndex(string indexName)
        {
            var indexExists = await _client.Indices.ExistsAsync(indexName);
            if (indexExists.Exists)
                return;

            var response = await _client.Indices.CreateAsync(indexName,
                i => i.Index(indexName)
                    .CitiesMapping()
                    .Settings(setting =>
                        setting
                            .NumberOfShards(3)
                            .NumberOfReplicas(1)
                    )
            );

            return;
        }

        public async Task DeleteByIdDocument(string indexName, Cities city)
        {
            var response = await _client.CreateAsync(city, i => i.Index(indexName));

            if (response.ApiCall?.HttpStatusCode is 409)
                await _client.DeleteAsync(DocumentPath<Cities>.Id(city.Id)
                    .Index(indexName));
        }

        public async Task DeleteIndex(string indexName)
        {
            await _client.Indices.DeleteAsync(indexName);
        }

        public async Task<Cities> GetDocument(string indexName, string id)
        {
            var response = await _client.GetAsync<Cities>(id, i => i.Index(indexName));
            return response.Source;
        }

        public async Task<List<Cities>> GetDocuments(string indexName)
        {
            var response = await _client.SearchAsync<Cities>(i => i
                .From(0)
                .Take(10)
                .Index(indexName)
                .Query(query => query
                    .Bool(@bool => @bool
                        .Should(should => should
                            .Wildcard(wildCard => wildCard
                                .Field("city")
                                .Value("r*ze"))))));

            // var response = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Query(query => query
            //         .Fuzzy(fz => fz.Field("city")
            //             .Value("anka")
            //             .Fuzziness(Fuzziness.EditDistance(4)))));

            // var response = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Query(query => query
            //         .Fuzzy(fz => fz.Field("city")
            //             .Value("rie")
            //             .Transpositions(true))));

            // var response = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Query(query => query
            //         .MatchPhrasePrefix(match => match.Field(field => field.City)
            //             .Query("iz")
            //             .MaxExpansions(10))));

            // var response = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Query(query => query
            //         .MultiMatch(match => match
            //             .Fields(fields => fields
            //                 .Field(field => field.City)
            //                 .Field(field => field.Region))
            //             .Type(TextQueryType.PhrasePrefix)
            //             .Query("iz")
            //             .MaxExpansions(10))));

            // var response = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Size(10000)
            //     .Query(query => query.Term(term => term.City, "rize")));

            // var response = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Size(10000)
            //     .Query(query => query
            //         .Match(match => match
            //             .Field("city")
            //             .Query("ankara"))));

            // var response = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Query(query => query
            //         .QueryString(qString => qString
            //             .AnalyzeWildcard()
            //             .Query("*" + "iz" + "*")
            //             .Fields(fields => fields
            //                 .Field(field => field.City)))));

            return response.Documents.ToList();
        }

        public async Task InsertBulkDocuments(string indexName, List<Cities> cities)
        {
            await _client.IndexManyAsync(cities, index: indexName);
        }

        public async Task InsertDocument(string indexName, Cities city)
        {
            var response = await _client.CreateAsync(city, i => i.Index(indexName));

            if (response.ApiCall?.HttpStatusCode == 409)
                await _client.UpdateAsync<Cities>(city.Id,
                    i => i.Index(indexName).Doc(city));
        }
    }
}