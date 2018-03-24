using eMSP.Data.Extensions;
using eMSP.DataModel;
using eMSP.ViewModel.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Comments
{
    class CommentsManager
    {
        #region Initialization

        private bool IsDisposed = false;

        public CommentsManager()
        {
        }

        #endregion

        #region Get

        public async Task<CommentModel> GetComment(long Id)
        {
            try
            {
                CommentModel model = null;
                tblComment data = await Task.Run(() => ManageComments.GetComment(Id));
                model = data.ConvertToComment();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Insert

        public async Task<CommentModel> InsertComment(CommentModel data)
        {
            try
            {
                tblComment res = await Task.Run(() => ManageComments.InsertComment(data.ConvertTotblComment()));
                return res.ConvertToComment();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        #endregion

        #region Update

        public async Task<CommentModel> UpdateComment(CommentModel model)
        {
            try
            {
                tblComment data = await Task.Run(() => ManageComments.UpdateComment(model.ConvertTotblComment()));
                return data.ConvertToComment();

            }
            catch (Exception)
            {
                throw;
            }
        }
        
        #endregion

        #region Delete

        public async Task DeleteVacancy(long Id)
        {
            try
            {
                await Task.Run(() => ManageComments.DeleteComment(Id));
            }
            catch (Exception)
            {
                throw;
            }
        }        

        #endregion

        #region Dispose

        protected virtual void Dispose(bool dispose)
        {
            if (!IsDisposed)
            {
                if (dispose)
                {
                    this.Dispose();
                }
                IsDisposed = true;
            }
        }

        ~CommentsManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
