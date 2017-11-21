using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Comments
{
    public class CommentModel
    {
        public CommentModel() { }
        public long id { get; set; }
    }

    public class CommentCreateModel : CommentModel
    {
        public CommentCreateModel() { }
        public string comment { get; set; }
        public Nullable<bool> showToAll { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public System.DateTime createdTimestamp { get; set; }
        public string createdUserId { get; set; }
        public Nullable<System.DateTime> updatedTimestamp { get; set; }
        public string updatedUserId { get; set; }
    }
}
