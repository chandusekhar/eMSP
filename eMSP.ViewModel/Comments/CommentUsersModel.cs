using eMSP.ViewModel.Shared;
using eMSP.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Comments
{
    public class CommentUsersModel : BaseModel
    {
        public CommentUsersModel() { }
        public long id { get; set; }
        public long commentId { get; set; }
        public string userId { get; set; }
        //public string userName { get; set; }
        //public string userProfile { get; set; }
        public Nullable<bool> isRead { get; set; }
        public Nullable<System.DateTime> readBy { get; set; }
        public UserCreateModel user { get; set; }
    }
}
