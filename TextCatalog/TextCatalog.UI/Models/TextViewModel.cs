namespace TextCatalog.UI.Models
{
    using System;

    public class TextViewModel
    {
        public int TextId { get; set; }
        public string TextTitle { get; set; }
        public string TextDescription { get; set; }
        public int UploaderId { get; set; }
        public string UploaderName { get; set; }
        public DateTime UploadDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string FileName { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
    }
}