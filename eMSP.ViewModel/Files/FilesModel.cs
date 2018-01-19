using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Files
{
    public class FilesModel
    {
        public FilesModel() { }
        public long id { get; set; }
        public long vacancyId { get; set; }

    }
    public class FilesCreateModel
    {
        public FilesCreateModel() { }
        public string filePath { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public System.DateTime createdTimestamp { get; set; }
        public string createdUserId { get; set; }
        public Nullable<System.DateTime> updatedTimestamp { get; set; }
        public string updatedUserId { get; set; }
    }
}
