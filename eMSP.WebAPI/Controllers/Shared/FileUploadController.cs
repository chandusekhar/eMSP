using eMSP.Data.DataServices.Shared;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Results;


namespace eMSP.WebAPI.Controllers.Shared
{
    [RoutePrefix("api/FileUpload")]
    public class FileUploadController : ApiController
    {
        [Route("uploadFiles")]
        [HttpPost]
        [ResponseType(typeof(List<FileModel>))]        
        public async Task<IHttpActionResult> UploadMultiple()
        {
            List<FileModel> list = new List<FileModel>();

            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            try
            {



                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                var baseUploadPath = @"~\App_Data\Uploads\";// + Request.QueryString["someParameter"];

                foreach (var file in provider.Contents)
                {
                    if (file.Headers.ContentLength > 0)
                    {
                        var fileName = file.Headers.ContentDisposition.FileName.Trim('\"');
                        var filePath = Path.Combine(HttpContext.Current.Server.MapPath(baseUploadPath), fileName);
                        var buffer = await file.ReadAsByteArrayAsync();
                        File.WriteAllBytes(filePath, buffer);

                        FileModel fi = CreateFileModel(fileName, filePath, "");
                        list.Add(fi);
                    }


                }


                return Ok(list);

            }
            catch (Exception ex)
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(response);
            }
        }

        public FileModel CreateFileModel(string fileName, string path, string UserID)
        {
            return new FileModel()
            {
                FileName = fileName,
                FilePath = path,
                FileTypeId = 2,
                isActive = true,
                isDeleted = false,
                createdTimestamp = DateTime.Now,
                createdUserID = UserID,
                FileVersionNumber = 1,
                updatedTimestamp = DateTime.Now,
                updatedUserID = UserID,
                ID = 0

            };
        }
    }
}