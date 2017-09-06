namespace TextCatalog.DAL
{
    using System;

    public class TextQueryParams
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? SectionId { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UploaderId { get; set; }
    }
}
