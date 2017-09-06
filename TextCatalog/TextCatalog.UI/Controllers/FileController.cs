using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextCatalog.DAL;
using TextCatalog.DAL.Model;
using AutoMapper;
using TextCatalog.UI.Models;

namespace TextCatalog.UI.Controllers
{
    public class FileController : Controller
    {
        private TextCatalogDAL repo;

        public FileController()
        {
            repo = new TextCatalogDAL();
        }

        [HttpGet]
        public ActionResult FilePage(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Text, TextViewModel>()
                 .ForMember("Likes", opt => opt.MapFrom(t => t.Likes()))
                 .ForMember("Dislikes", opt => opt.MapFrom(t => t.Dislikes()))
                 .ForMember("UploaderName", opt => opt.MapFrom(t => t.Uploader().UserName))
                 .ForMember("SectionName", opt => opt.MapFrom(t => t.Section().SectionName)));

            var textModel = Mapper.Map<Text, TextViewModel>(repo.GetTextById(id));

            return View(textModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Rate(int textId, string userName, bool positive, string returnUrl)
        {
            Rating rating = new Rating()
            {
                TextId = textId,
                UserId = repo.GetUserDetailsName(new User { UserName = userName }).UserId,
                Positive = positive,
                RatingDate = DateTime.Now
            };

            if (!repo.CheckRating(rating))
            {
                repo.CreateRating(rating);
            }

            return Redirect(returnUrl);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Upload()
        {
            UploadViewModel model = new UploadViewModel()
            {
                AvailableSections = repo.GetSectionAndDescendants(repo.GetRootSection())
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upload(TextViewModel model)
        {
            Text text = new Text
            {
                TextTitle = model.TextTitle,
                TextDescription = model.TextDescription,
                UploaderId = repo.GetUserDetailsName(new User { UserName = User.Identity.Name }).UserId,
                UploadDate = DateTime.Now,
                SectionId = model.SectionId
            };

            repo.CreateText(text);

            return RedirectToAction("Index", "User");
        }
    }
}