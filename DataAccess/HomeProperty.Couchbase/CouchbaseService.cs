using Couchbase.Configuration.Client;
using System;
using System.Collections.Generic;

namespace HomeProperty.Couchbase {
    public class CouchbaseService {
        /// <summary>
        /// http://docs.couchbase.com/developer/dotnet-2.1/configuring-the-client.html
        /// Configures couchbase servers and bucket
        /// </summary>
        /// <param name="serverUris">The list of server uris</param>
        /// <param name="bucketName">The requested bucket name</param>
        /// <param name="password">The bucket password</param>
        /// <param name="useSsl">If need to enable SSL</param>
        /// <param name="defaultOperationLifeSpan">The default operation life span</param>
        /// <param name="bucketDefaultOperationLifeSpan">The defualt bucket operation life span</param>
        /// <param name="poolMaxSize">The pool max size</param>
        /// <param name="poolMinSize">The pool minimum size</param>
        /// <param name="poolSendTimeout">The pool send timeout</param>
        public ClientConfiguration GetClientConfiguration(List<Uri> serverUris,
            string bucketName, string password,
            bool useSsl = true,
            uint defaultOperationLifeSpan = 1000,
            uint bucketDefaultOperationLifeSpan = 2000,
            int poolMaxSize = 10, int poolMinSize = 5,
            int poolSendTimeout = 12000) {
            var config = new ClientConfiguration {
                Servers = serverUris,
                UseSsl = useSsl,
                DefaultOperationLifespan = defaultOperationLifeSpan,
                BucketConfigs = new Dictionary<string, BucketConfiguration>
                {
                   {bucketName, new BucketConfiguration {
                              BucketName = bucketName,
                              UseSsl = useSsl,
                              Password = password,
                              DefaultOperationLifespan = bucketDefaultOperationLifeSpan,
                              PoolConfiguration = new PoolConfiguration {
                                MaxSize = poolMaxSize,
                                MinSize = poolMinSize,
                                SendTimeout = poolSendTimeout
                              }
                         }
                    }
                }
            };
            return config;
        }
    }
}
