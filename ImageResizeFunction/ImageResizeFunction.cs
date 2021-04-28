using System;
using System.IO;
using ImageResizeFunction.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ImageResizeFunction
{
    [StorageAccount("BlobConnectionString")]
    public class ImageResizeFunction
    {
        private readonly IImageResizer imageResizer;

        public ImageResizeFunction(IImageResizer imageResizer) 
            => this.imageResizer = imageResizer;

        [FunctionName("ImageResizeFunction")]
        public void Run(
            [BlobTrigger("normal-size/{name}")] Stream inputBlob,
            [Blob("reduced-size/{name}", FileAccess.Write)] Stream outputBlob,
            string name,
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {inputBlob.Length} Bytes");

            try
            {
                this.imageResizer.Resize(inputBlob, outputBlob);

                log.LogInformation("Reduced image saved to blob storage");
            }
            catch (Exception e)
            {
                log.LogError("Resize fails", e);
            }
        }
    }
}
