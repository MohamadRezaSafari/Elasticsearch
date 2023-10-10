using ElasticProject.Data.Domain;

namespace ElasticProject.Data.Service.Contracts
{
    public interface IElasticsearchService
    {
        Task<List<Cities>> Search(string indexName);
        //Task<List<T>> Search<T>(string indexName) where T : class;
        Task CheckIndex(string indexName);
        Task InsertDocument(string indexName, Cities city);
        Task DeleteIndex(string indexName);
        Task DeleteByIdDocument(string indexName, Cities city);
        Task InsertBulkDocuments(string indexName, List<Cities> cities);
        Task<Cities> GetDocument(string indexName, string id);
        Task<List<Cities>> GetDocuments(string indexName);
    }
}
