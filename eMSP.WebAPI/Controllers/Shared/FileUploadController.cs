using eMSP.Data.DataServices.Shared;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.Shared;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;


namespace eMSP.WebAPI.Controllers.Shared
{
    [RoutePrefix("api/FileUpload")]
    public class FileUploadController : ApiController
    {
        [Route("getProfilePic")]
        [HttpGet]
        public async Task<HttpResponseMessage> getProfilePic(string path)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                String filePath = HttpContext.Current.Server.MapPath(path);
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                Image image = Image.FromStream(fileStream);
                MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, ImageFormat.Jpeg);
                result.Content = new ByteArrayContent(memoryStream.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return result;

            }
            catch (Exception ex)
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                throw new HttpResponseException(response);
            }
        }
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
                        var fileName = "";

                        if (file.Headers.ContentDisposition.FileName != null)
                        {
                            fileName = file.Headers.ContentDisposition.FileName.Trim('\"');
                        }
                        else
                        {
                            fileName = "Test.jpg";
                        }

                        var filePath = Path.Combine(HttpContext.Current.Server.MapPath(baseUploadPath), fileName);

                        var buffer = await file.ReadAsByteArrayAsync();

                        File.WriteAllBytes(filePath, buffer);

                        FileModel fi = CreateFileModel(fileName, baseUploadPath+fileName, User.Identity.GetUserId());

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