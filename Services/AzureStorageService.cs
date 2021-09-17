using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using wargamer_showcase.Data;

namespace wargamer_showcase.Services
{
	public class AzureStorageService
	{
		private readonly IOptions<AzureStorageConfig> _options;
		public AzureStorageService(IOptions<AzureStorageConfig> options)
		{
			_options = options;
		}

		public async Task<Uri> UploadFileToStorage(Stream stream, string container, string fileName)
		{
			Uri blobUri = new Uri("https://" +
								  _options.Value.AccountName +
								  ".blob.core.windows.net/" +
								  container + "/" + fileName);

			StorageSharedKeyCredential storageCredentials =
				new StorageSharedKeyCredential(_options.Value.AccountName, _options.Value.AccountKey);

			// Create the blob client.
			BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

			// Upload the file
			await blobClient.UploadAsync(stream, true);

			return blobUri;
		}
	}
}
