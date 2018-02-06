using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Comments
{
    public class CommentUsersCreateModel : BaseModel
    {
        public CommentUsersCreateModel() { }
        public long id { get; set; }
        public long commentId { get; set; }
        public string userId { get; set; }
        public Nullable<bool> isRead { get; set; }
        public Nullable<System.DateTime> readBy { get; set; }
    }
}
