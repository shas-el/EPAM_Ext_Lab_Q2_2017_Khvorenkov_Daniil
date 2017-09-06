namespace TextCatalog.UI.Models
{
    using System;
    using System.Collections.Generic;
    using TextCatalog.DAL.Model;

    public class SearchQueryViewModel
    {
        public SearchQueryViewModel()
        {
            TagIds = new List<int>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }
        public List<Section> AvailableSections { get; set; }
        public List<int> TagIds { get; set; }
        public List<TagViewModel> AvailableTags { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UploaderName { get; set; }
    }
}