using Services.ServiceInterfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace Services.Services
{
    public class FileManager : IFileManager
    {
        private readonly string _filesStorageFolder;

        public FileManager(string fileStorageFolder)
        {
            _filesStorageFolder = fileStorageFolder;
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public async Task AddPicture(HttpPostedFileBase file, Guid pictureId)
        {
            const int BufferSize = 65536;
            using (FileStream fs = System.IO.File.Create(String.Concat(_filesStorageFolder, Convert.ToString(pictureId))))
            {
                using (Stream reader = file.InputStream)
                {
                    byte[] buffer = new byte[BufferSize];
                    int read = -1, pos = 0;
                    do
                    {
                        int len = (file.ContentLength < pos + BufferSize ?
                            file.ContentLength - pos :
                            BufferSize);
                        read = reader.Read(buffer, 0, len);
                        fs.Write(buffer, 0, len);
                        pos += read;
                    } while (read > 0);
                }
            }
        }

        public async Task<byte[]> GetPicture(Guid id)
        {
            var file = System.IO.File.ReadAllBytes((string.Concat(_filesStorageFolder, Convert.ToString(id))));
            return file;
        }
    }
}

