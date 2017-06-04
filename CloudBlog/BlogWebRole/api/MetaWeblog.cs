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
            CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;

            string containerName = "workshop";

            // Client erstellen
            var client = account.CreateCloudBlobClient();

            // Referenz auf Container
            var container = client.GetContainerReference(containerName);

            // Container erstellen?
            if (container.CreateIfNotExist())
            {
                var permissions = container.GetPermissions();

                // Public setzen
                permissions.PublicAccess = BlobContainerPublicAccessType.Container;

                container.SetPermissions(permissions);
            }

            // blob name erstellen
            Guid blobGuid = Guid.NewGuid();

            string blobName = string.Concat(blobGuid.ToString(), fileExtension);

            // blob referenzieren
            var blob = container.GetBlobReference(blobName);

            // content type setzen
            blob.Properties.ContentType = contentType;

            // hochladen
            blob.UploadByteArray(data);

            return blob.Uri;
        }
    }
}