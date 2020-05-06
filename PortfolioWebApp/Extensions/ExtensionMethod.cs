using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApp.Extensions
{
    public class ExtensionMethod
    {
        //Extension method for Post Edit method(6 photos).     
        public void PostEdit(Post post, PostEditViewModel model, IFormFile[] fileobj, IWebHostEnvironment _hosting)
        {
            string uniqueFileName = null;
            int i = 0;

            //Mapping Viewmodel to Model.
            post.Id = model.Id;
            post.Name = model.Name;
            post.Title = model.Title;
            post.IsActive = model.IsActive;
            post.CategoryId = model.CategoryId;
            post.UpdateDate = DateTime.Today;

            //Make equal to null. Because when we edit previous url didn't change.
            post.FirstImageUrl = null;
            post.SecondImageUrl = null;
            post.ThirdImageUrl = null;
            post.FourthImageUrl = null;
            post.FifthImageUrl = null;
            post.SixthImageUrl = null;

            //Mapping Pictures Filepath to ViewModel. Our vm gives us null imageUrl. That's why we mapping Post photoUrl to Vm photoUrl.          
            //Get Previous pictures url to empty Viewmodel picture url. Then with filepathes array make loop and delete old pictures from root folder. 
            //Get Pictures to array
            string[] filepathes = new string[6]
            {
                    model.FirstImageUrl = post.FirstImageUrl,
                    model.SecondImageUrl = post.SecondImageUrl,
                    model.ThirdImageUrl = post.ThirdImageUrl,
                    model.FourthImageUrl = post.FourthImageUrl,
                    model.FifthImageUrl = post.FifthImageUrl,
                    model.SixthImageUrl = post.SixthImageUrl
            };

            if (fileobj.Length > 0)
            {
                //Adding new pictures, when in edit action selected new pictures *files.jpg/png*.Adding new pictures with new random name.
                foreach (var img in fileobj)
                {
                    i++;

                    var uploadFolder = Path.Combine(_hosting.WebRootPath, "postImages");
                    uniqueFileName = Guid.NewGuid().ToString() + "-" + img.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        img.CopyTo(fileStream);
                    }
                    switch (i)
                    {
                        case 1:
                            post.FirstImageUrl = uniqueFileName;
                            break;
                        case 2:
                            post.SecondImageUrl = uniqueFileName;
                            break;
                        case 3:
                            post.ThirdImageUrl = uniqueFileName;
                            break;
                        case 4:
                            post.FourthImageUrl = uniqueFileName;
                            break;
                        case 5:
                            post.FifthImageUrl = uniqueFileName;
                            break;
                        case 6:
                            post.SixthImageUrl = uniqueFileName;
                            break;
                    }
                }

                //Deleting pictures from Root folder "postImages", ex pictures which we already don't use.;
                foreach (var picture in filepathes)
                {
                    if (picture == null)
                    {
                        break;
                    }
                    string filepath = Path.Combine(_hosting.WebRootPath, "postImages", picture);
                    System.IO.File.Delete(filepath);

                }
            }
        }

        //Extension method for Post Create method(6 photos).
        public void PostCreate(Post post, IFormFile[] fileobj, IWebHostEnvironment _hosting)
        {
            //Guid, random for fileName. For Selected Image.
            string uniqueFileName = null;
            int i = 0;

            foreach (var img in fileobj)
            {
                i++;

                var uploadFolder = Path.Combine(_hosting.WebRootPath, "postImages");
                uniqueFileName = Guid.NewGuid().ToString() + "-" + img.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
                switch (i)
                {
                    case 1:
                        post.FirstImageUrl = uniqueFileName;
                        break;
                    case 2:
                        post.SecondImageUrl = uniqueFileName;
                        break;
                    case 3:
                        post.ThirdImageUrl = uniqueFileName;
                        break;
                    case 4:
                        post.FourthImageUrl = uniqueFileName;
                        break;
                    case 5:
                        post.FifthImageUrl = uniqueFileName;
                        break;
                    case 6:
                        post.SixthImageUrl = uniqueFileName;
                        break;
                }
            }
        }

        //Extension method for About Create Method(1 photo).
        public string ProcessUploadFile(AboutOwnerViewModel model, IWebHostEnvironment _hosting)
        {
            string uniqueFileName = null;
            if (model.CompanyPhoto != null)
            {
                string uploadsFolder = Path.Combine(_hosting.WebRootPath, "companyImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CompanyPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CompanyPhoto.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
