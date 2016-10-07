using Couchbase;
using System.Threading.Tasks;

namespace HomeProperty.Couchbase {
    public interface ICouchbaseClientService {
        Task<IDocumentResult<T>> UpsertDocAsync<T>(T content);
        Task<IDocumentResult<T>> GetDocAsync<T>(string docId);
        Task<IDocumentResult<T>> UpdateDocAsync<T>(string docId, T content);
        Task<IOperationResult> RemoveDocAsync(string docId);
    }
}
