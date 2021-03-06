﻿namespace PCBStore.Web.Infrastructure.Extensions
{
   using System.IO;
   using System.Threading.Tasks;
   using Microsoft.AspNetCore.Http;

   public static class FormFileExtensions
    {
        public static async Task<byte[]> ToByteArrayAsync(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Position = 0;
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
