using Azure.Storage.Blobs.Specialized;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Functions.Helpers
{
    public class BlobStorage
    {
        public static async Task WriteMessage(AppendBlobClient appendBlobClient, string message)
        {
            using var stream = new MemoryStream();

            var writer = new StreamWriter(stream);
            await writer.WriteAsync(message);
            await writer.FlushAsync();
            stream.Position = 0;
            await appendBlobClient.AppendBlockAsync(stream);
        }

        public static async Task<string> ReadFileContent(BlobBaseClient blockBlobClient)
        {
            using var stream = new MemoryStream();
            await blockBlobClient.DownloadToAsync(stream);
            stream.Position = 0;
            using StreamReader reader = new(stream, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }
    }
}
