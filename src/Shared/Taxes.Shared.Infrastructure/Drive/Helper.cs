using Taxes.Shared.Infrastructure.Drive.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Drive
{
    internal class Helper
    {
        private static readonly string[] _supportedExtensions 
            = { ".jpg", ".png", ".bmp", ".doc", ".docx", ".pdf" };
        private const int MIN_FOLDER_LENGTH = 2;

        public static string FileCommit(string ext, string fileWithoutBase, string filePath, string fileName)
        {
            if (string.IsNullOrEmpty(fileName) && fileName != "string")
            {
                throw new StaffCodeRequiredException();
            }

            var photofolder = Path.GetDirectoryName($"{filePath}");
            if (!Directory.Exists(photofolder))
            {
                Directory.CreateDirectory(photofolder);
            }

            MemoryStream ms = new(Convert.FromBase64String(fileWithoutBase));
            using FileStream fs = new($"{filePath}{fileName}{ext}", FileMode.Create, FileAccess.Write);

            ms.WriteTo(fs);
            fs.Close();
            ms.Close();

            return $"{fileName}{ext}";
        }
        
        public static string ToBase64(string fullpath)
        {
            byte[] imageBytes = File.ReadAllBytes(fullpath);
            string base64String = Convert.ToBase64String(imageBytes);
            string strpath = Path.GetExtension(fullpath);
            String fileExtension = Path.GetExtension(fullpath);

            string toBase64 = "";

            if (fileExtension == ".pdf")

            {
                toBase64 = string.Format("data:application/pdf;base64,{0}", base64String);
            }
            else if (fileExtension == ".png")
            {
                toBase64 = string.Format("data:image/png;base64,{0}", base64String);
            }

            else if (fileExtension == ".jpg" || fileExtension == ".jpeg")
            {
                toBase64 = string.Format("data:image/jpeg;base64,{0}", base64String);
            }
            return toBase64;
        }
        public static bool HasBase64File(string fileInBase64)
        {
            return !String.IsNullOrEmpty(fileInBase64) && fileInBase64 != "string" &&
                              fileInBase64 != string.Empty && !string.IsNullOrWhiteSpace(fileInBase64);
        }

        public static bool IsValidBase64String(string fileInBase64)
        {
            var base64 = fileInBase64[..30];

            if (base64.Contains("data:image/jpeg;base64,"))
            {
                return true;
            }
            if (base64.Contains("data:image/png;base64,"))
            {
                return true;
            }
            if (base64.Contains("data:image/bmp;base64,"))
            {
                return true;
            }
            if (base64.Contains("data:application/msword;base64,"))
            {
                return true;
            }
            if (base64.Contains("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,"))
            {
                return true;
            }
            if (base64.Contains("data:application/pdf;base64,"))
            {
                return true;
            }
            return false;
        }

        public static string GetFileExtensionFromBase64(string fileInBase64)
        {
            var base64 = fileInBase64[..50];

            if (base64.Contains("data:image/jpeg;base64,"))
            {
                return ".jpg";
            }
            else if (base64.Contains("data:image/png;base64,"))
            {
                return ".png";
            }
            else if (base64.Contains("data:image/bmp;base64,"))
            {
                return ".bmp";
            }
            else if (base64.Contains("data:application/msword;base64,"))
            {
                return ".doc";
            }
            else if (base64.Contains("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,"))
            {
                return ".docx";
            }
            else if (base64.Contains("data:application/pdf;base64,"))
            {
                return ".pdf";
            }
            else
            {
                throw new UnsupportedExtensionException();
            }
        }

        public static string PrepareFile(string fileInBase64)
        {
            if (fileInBase64.Contains("data:image/jpeg;base64,"))
            {
                return fileInBase64.Replace("data:image/jpeg;base64,", "");
            }
            else if (fileInBase64.Contains("data:image/png;base64,"))
            {
                return fileInBase64.Replace("data:image/png;base64,", "");
            }
            else if (fileInBase64.Contains("data:image/bmp;base64"))
            {
                return fileInBase64.Replace("data:image/bmp;base64", "");
            }
            else if (fileInBase64.Contains("data:application/msword;base64,"))
            {
                return fileInBase64.Replace("data:application/msword;base64,", "");
            }
            else if (fileInBase64.Contains("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,"))
            {
                return fileInBase64.Replace("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,", "");
            }
            else if (fileInBase64.Contains("data:application/pdf;base64,"))
            {
                return fileInBase64.Replace("data:application/pdf;base64,", "");
            }
            else
            {
                throw new UnsupportedExtensionException();
            }
        }

        public static string GetFilePath(string[] folder)
        {
            if (folder.Length < MIN_FOLDER_LENGTH)
            {
                throw new InvalidFolderStructureException();
            }
            var path = string.Join(",", folder).Replace(",", "//");
            return $"{path}//";
        }

        // 
        public static bool IsImageFile(string img)
            => _supportedExtensions.Contains(Path.GetExtension(img));

        public static bool FileExist(string fullpath)
            => File.Exists(fullpath);
    }
}
