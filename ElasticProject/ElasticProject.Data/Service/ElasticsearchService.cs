using ElasticProject.Data.Domain;
using ElasticProject.Data.Service.Contracts;
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


        public async Task<List<Cities>> Search(string indexName)
        {
            var data = await _client.SearchAsync<Cities>(i => i
                .Index(indexName)
                .Query(q => q
                        .Wildcard(w => w
                            .Field(f=>f.City)
                            .Value("t*o"))
                        //.Terms(t => t
                        //    .Terms(new List<string>(){"tok"}))
                        //.Regexp(rgx=>rgx
                        //    .Field(f=>f.City)
                        //    .Value("t.*o")
                        //    .Flags("INTERSECTION|COMPLEMENT|EMPTY"))
                        //.TermRange(tr => tr
                        //    .Field(f => f.City)
                        //    .GreaterThan("tokyo")
                        //)
                    //.DateRange(dr => dr
                    //    .Field(f => f.CreatedDate)
                    //    .GreaterThan(DateTime.Now.AddDays(-3))
                    //    .LessThan(DateTime.Now.AddDays(10)))
                    )
            //.Prefix(pre => pre
            //    .Field(f => f.City)
            //    .Value("tok")))
            //.Ids(ids => ids
            //    .Values(1, 45, 6)))
            );


            //var data = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Query(q => q
            //         .FuzzyNumeric(fn => fn
            //             .Field(f => f.Id)
            //             .Fuzziness(100)
            //             .Value(10)
            //             .MaxExpansions(100)
            //             .Transpositions(false))));

            //var data = await _client.SearchAsync<Cities>(i => i
            //    .Index(indexName)
            //    .Query(q => q
            //        .FuzzyDate(fd => fd
            //                .Field(f => f.CreatedDate)
            //                .Fuzziness(TimeSpan.FromDays(2))
            //                .MaxExpansions(1)
            //                .Transpositions()
            //        )));

            //var data = await _client.SearchAsync<CityDto>(i => i
            //    .Index(indexName)
            //    .Query(query => query
            //        .MultiMatch(mm => mm
            //            .Fields(fields => fields
            //                .Field(f => f.City)
            //                .Field(f => f.Id))
            //            .Query("tok"))
            //.Query(query =>query
            //    .MatchPhrasePrefix(mp => mp
            //        .Query("to"))
            //.Query(query => query
            //        .Fuzzy(fz => fz
            //            .Field(f => f.City)
            //            .Value("tok"))
            //.MatchPhrase(mp => mp
            //    .Field(field => field.City)
            //    .Query("tokyo"))
            //));

            //var data = await _client.SearchAsync<CityDto>(i => i
            //    .Index(indexName)
            //    .Query(query => query
            //        .CommonTerms(ct => ct
            //            .Field(field => field.City)
            //            .Analyzer("standard")
            //            .Boost(1.1)
            //            .CutoffFrequency(0.001)
            //            .HighFrequencyOperator(Operator.And)
            //            .LowFrequencyOperator(Operator.Or)
            //            .MinimumShouldMatch(1)
            //            .Name("named_query")
            //            .Query("query"))
            //    ));

            // var data = await _client.SearchAsync<CityDto>(i => i
            //         .Index(indexName)
            //         .Source(src => src
            //             .ExcludeAll()
            //             .Includes(inc => inc
            //                 .Fields(f => f.City)))
            //     // .IncludeAll()
            //     // .Excludes(ex => ex
            //     //     .Fields(fields => fields
            //     //         .Population)))
            // );

            // var data = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Sort(sort => sort
            //         .Descending(f => f.CreatedDate)
            //     )
            //     .SearchAfter(
            //         "CreatedDate"
            //     ));


            // var data = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .ScriptFields(sf => sf
            //         .ScriptField("test 123", sc => sc
            //             .Source("doc['Population']")
            //             .Params(p => p
            //                 .Add("custom factor", "Hiya")))));

            // var data = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Profile()
            //     .Query(query => query
            //         .MatchAll()));

            //     var data = await _client.SearchAsync<Cities>(i => i
            //         .Index(indexName)
            //         .PostFilter(f => f.MatchAll()));

            // var data = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .MinScore(0.5)
            //     .Query(query => query
            //         .Term(term => term.City, "Tokyo")));

            // var data = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Query(query => query
            //         .HasChild<CityDto>(child => child
            //             .Query(childQuery => childQuery
            //                 .MatchAll())
            //             .InnerHits(ih => ih
            //                 .Version()))));

            // var data = await _client.SearchAsync<Cities>(i => i
            //     .Index(indexName)
            //     .Highlight(highlight => highlight
            //         .Fields(fields => fields
            //             .Field(field => field.Population)))
            //     );

            //var data = await _client.SearchAsync<Cities>(i => i
            //    .Index(indexName)
            //    .From(10)
            //    .Size(200));

            // eror
            // 
            //var data = await _client.SearchAsync<CityDto>(i => i
            //    .Index(indexName)
            //    .Query(query => ProjectFilter)
            //    .Query(query => query
            //        .Match(match => match.Field(field => field.Id > 0)))
            //    .StoredFields(fields => fields
            //        .Field(field => field.Id)
            //        .Field(field => field.City)
            //        .Field(field => field.Population))
            //    );


            return data.Documents.ToList();
        }

        //public async Task<List<T>> Search<T>(string indexName)
        //{
        //    var data = await _client.SearchAsync<T>(i => i
        //        .Index(indexName)
        //        //.Query(query => query
        //        //    .Match(match => match.Field(field => field.Id > 0)))
        //        .StoredFields(fields => fields
        //            .Field(field => field.Id)
        //            .Field(field => field.City)
        //            .Field(field => field.Population))
        //        );


        //    return data.Documents.ToList();
        //}

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