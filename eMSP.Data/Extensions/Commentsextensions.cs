using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using eMSP.ViewModel.Comments;

namespace eMSP.Data.Extensions
{
    public static class Commentsextensions
    {
        public static tblComment ConvertTotblComment(this CommentModel data)
        {
            return new tblComment()
            {
                ID = Convert.ToInt64(data.id),
                Comment = data.comment,
                ShowToAll = data.showToAll,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static CommentModel ConvertToComment(this tblComment data)
        {
            return new CommentModel()
            {
                id = data.ID,
                comment = data.Comment,
                showToAll = data.ShowToAll,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp,
                commentUser = data.tblCommentUsers?.Select(x => x.ConvertToCommentUsers()).ToList()
            };
        }

        public static tblCommentUser ConvertTotblCommentUser(this CommentUsersModel data)
        {
            return new tblCommentUser()
            {
                ID = Convert.ToInt64(data.id),
                CommentID = data.commentId,
                UserID = data.userId,
                IsRead = data.isRead ?? false,
                ReadBy = data.readBy,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static CommentUsersModel ConvertToCommentUsers(this tblCommentUser data)
        {
            return new CommentUsersModel()
            {
                id = data.ID,
                commentId = data.CommentID,
                userId = data.UserID,
                user = data.tblUserProfile?.ConvertToUser(),
                isRead = data.IsRead,
                readBy = data.ReadBy,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }
    }
}
