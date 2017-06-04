using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace WebRole1.api
{
    public class MetaWeblog : BlogEngine.MetaWeblogService
    {
        public override BlogEngine.XmlRpcContracts.BlogInfo[] getUsersBlogs(string appKey, string username, string password)
        {
            return new BlogEngine.XmlRpcContracts.BlogInfo[] {
                 new BlogEngine.XmlRpcContracts.BlogInfo() {
                      blogid = "1",
                      blogName = "AzureBlog",
                      url = "http://www.microsoft.com/windowsazure"}
                };
        }

        protected override Uri UploadMediaObject(string fileExtension, string contentType, byte[] data)
        {
            CloudStorageAccount account = new CloudStorageAccount(
                new StorageCredentialsAccountAndKey("YourAzureStorageAccount", "YouNameIt"),
                new Uri("http://YourAzureStorageAccount.blob.core.windows.net/"), null, null);


            string containerName = "workshop";

            var client = account.CreateCloudBlobClient();

            var container = client.GetContainerReference(containerName);

            if (container.CreateIfNotExist()) {
                var permissions = container.GetPermissions();

                permissions.PublicAccess = BlobContainerPublicAccessType.Container;

                container.SetPermissions(permissions);
            }
            
            Guid blobGuid = Guid.NewGuid();

            string blobName = string.Concat(blobGuid.ToString(), fileExtension);

            var blob = container.GetBlobReference(blobName);

            blob.Properties.ContentType = contentType;

            blob.UploadByteArray(data);

            return blob.Uri;
        }
    }
}