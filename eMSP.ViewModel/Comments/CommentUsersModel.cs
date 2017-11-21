using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Comments
{
    public class CommentUsersModel
    {
        public CommentUsersModel() { }
        public long id { get; set; }
        public long commentId { get; set; }
        public string userId { get; set; }
    }

    public class CommentUsersCreateModel: CommentUsersModel
    {
        public CommentUsersCreateModel() { }
        public Nullable<bool> isRead { get; set; }
        public Nullable<System.DateTime> readBy { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public System.DateTime createdTimestamp { get; set; }
        public string createdUserId { get; set; }
        public Nullable<System.DateTime> updatedTimestamp { get; set; }
        public string updatedUserId { get; set; }
    }
}
