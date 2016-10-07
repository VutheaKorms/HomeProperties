using Couchbase;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace HomeProperty.Couchbase {
    public class CouchbaseClientService : CouchbaseService, ICouchbaseClientService {
        private string bucketName;
        private string password;
        private List<Uri> serverUris;
        private ClientConfiguration clientConfig;
        private bool useSsl;

        //private uint defaultOperationLifeSpan;
        //private uint bucketDefaultOperationLifespan;
        //private int poolMinSize;
        //private int poolMaxSize;
        //private int poolSendTimeout;

        public CouchbaseClientService() {
            bucketName = ConfigurationManager.AppSettings.Get("bucketName");
            password = ConfigurationManager.AppSettings.Get("password");
            var serverUri1 = ConfigurationManager.AppSettings.Get("serverUri1");
            useSsl = bool.Parse(ConfigurationManager.AppSettings.Get("useSsl"));
            serverUris = new List<Uri>();
            serverUris.Add(new Uri(serverUri1));
            clientConfig = GetClientConfiguration(serverUris, bucketName, password, useSsl);
        }

        /// <summary>
        /// Updates or inserts the document asynchronously
        /// http://docs.couchbase.com/developer/dotnet-2.1/storing.html
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="content">The instance of entity filled with data</param>
        /// <returns>The document result with status</returns>
        public async Task<IDocumentResult<T>> UpsertDocAsync<T>(T content) {
            using (var cluster = new Cluster(clientConfig)) {
                IBucket bucket = null;
                try {
                    bucket = cluster.OpenBucket();
                    var doc = new Document<T> {
                        Id = new Guid().ToString(),
                        Content = content
                    };
                    return await bucket.UpsertAsync(doc);
                } finally {
                    if (bucket != null)
                        cluster.CloseBucket(bucket);
                }
            }
        }

        /// <summary>
        /// Gets document asynchronously
        /// </summary>
        /// <typeparam name="T">The type of object that document will be converted to</typeparam>
        /// <param name="docId">The document ID</param>
        /// <returns>The document result with status.</returns>
        public async Task<IDocumentResult<T>> GetDocAsync<T>(string docId) {
            using (var cluster = new Cluster(clientConfig)) {
                IBucket bucket = null;
                try {
                    bucket = cluster.OpenBucket();
                    return await bucket.GetDocumentAsync<T>(docId);
                } finally {
                    if (bucket != null)
                        cluster.CloseBucket(bucket);
                }
            }
        }

        /// <summary>
        /// Updates document
        /// </summary>
        /// <typeparam name="T">The type of document</typeparam>
        /// <param name="docId">The doucment ID</param>
        /// <param name="content">The content of document</param>
        /// <returns>The document result</returns>
        public async Task<IDocumentResult<T>> UpdateDocAsync<T>(string docId, T content) {
            using (var cluster = new Cluster(clientConfig)) {
                IBucket bucket = null;
                try {
                    bucket = cluster.OpenBucket();
                    var result = await bucket.GetDocumentAsync<T>(docId);
                    result.Document.Content = content;
                    return await bucket.ReplaceAsync<T>(result.Document);
                } finally {
                    if (bucket != null)
                        cluster.CloseBucket(bucket);
                }
            }
        }

        /// <summary>
        /// Removes document asynchronously
        /// </summary>
        /// <param name="docId">The document ID</param>
        /// <returns>The operation result</returns>
        public async Task<IOperationResult> RemoveDocAsync(string docId) {
            using (var cluster = new Cluster(clientConfig)) {
                IBucket bucket = null;
                try {
                    bucket = cluster.OpenBucket();
                    return await bucket.RemoveAsync(docId);
                } finally {
                    if (bucket != null)
                        cluster.CloseBucket(bucket);
                }
            }
        }

        Task<IDocumentResult<T>> ICouchbaseClientService.UpsertDocAsync<T>(T content) {
            throw new NotImplementedException();
        }

        Task<IDocumentResult<T>> ICouchbaseClientService.GetDocAsync<T>(string docId) {
            throw new NotImplementedException();
        }

        Task<IDocumentResult<T>> ICouchbaseClientService.UpdateDocAsync<T>(string docId, T content) {
            throw new NotImplementedException();
        }

        Task<IOperationResult> ICouchbaseClientService.RemoveDocAsync(string docId) {
            throw new NotImplementedException();
        }
    }
}
