namespace TextCatalog.UI.Controllers
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TextCatalog.DAL;
    using TextCatalog.DAL.Model;
    using TextCatalog.UI.Models;


    public class HomeController : Controller
    {
        private TextCatalogDAL repo;

        public HomeController()
        {
            repo = new TextCatalogDAL();
        }

        [HttpGet]
        public ActionResult Index()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Text, TextIntroViewModel>()
                .ForMember("Likes", opt => opt.MapFrom(t => t.Likes()))
                .ForMember("Dislikes", opt => opt.MapFrom(t => t.Dislikes())));

            var textsModel = Mapper.Map<List<Text>, List<TextIntroViewModel>>(repo.GetTopTexts());

            return View(textsModel);
        }

        [HttpGet]
        public ActionResult AdvancedSearch()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Tag, TagViewModel>()
                .ForMember("CategoryName", opt => opt.MapFrom(t => t.TagCategory().CategoryName)));

            SearchQueryViewModel model = new SearchQueryViewModel
            {
                AvailableSections = repo.GetSectionAndDescendants(repo.GetRootSection()),
                AvailableTags = Mapper.Map<List<Tag>, List<TagViewModel>>(repo.GetTags())
            };
            model.AvailableTags.Add(new TagViewModel { TagId = -1, TagName = "All", CategoryName = "All" });

            return View(model);
        }

        [HttpPost]
        public ActionResult SearchResults(SearchQueryViewModel searchQuery)
        {
            TextQueryParams searchParams = new TextQueryParams()
            {
                Title = searchQuery.Title,
                Description = searchQuery.Description,
                SectionId = searchQuery.SectionId,
                BeginDate = searchQuery.BeginDate,
                EndDate = searchQuery.EndDate
            };

            if (searchQuery.UploaderName == null)
            {
                searchParams.UploaderId = null;
            }
            else
            {
                searchParams.UploaderId = 
                    repo.GetUserDetailsName(new User { UserName = searchQuery.UploaderName }).UserId;
            }

            var texts = repo.GetTexts(searchParams);

            if (searchQuery.TagIds.Count != 0 && !searchQuery.TagIds.Contains(-1))
            {
                texts = texts.Where(txt => searchQuery.TagIds
                    .All(t => (txt.Tags().Select(x => x.TagId).ToList().Contains(t))))
                    .ToList();
            }

            Mapper.Initialize(cfg => cfg.CreateMap<Text, TextIntroViewModel>()
                .ForMember("Likes", opt => opt.MapFrom(t => t.Likes()))
                .ForMember("Dislikes", opt => opt.MapFrom(t => t.Dislikes())));

            var resultsModel = Mapper.Map<List<Text>, List<TextIntroViewModel>>(texts);

            return View(resultsModel);
        }
    }
}