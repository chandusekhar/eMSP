using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Comments
{
    public class CommentModel : BaseModel
    {
        public CommentModel() { }
        public long id { get; set; }
        public string comment { get; set; }
        public Nullable<bool> showToAll { get; set; }
        public IList<CommentUsersModel> commentUser { get; set; }
    }
}
