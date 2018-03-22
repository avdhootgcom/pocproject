using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public string MimeType { get; set; }
        public long Length { get; set; }
        public byte[] Content { get; set; }
    }
}