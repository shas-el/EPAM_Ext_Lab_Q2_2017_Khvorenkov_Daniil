namespace TextCatalog.DAL.Model
{
    using System;
    using System.Collections.Generic;

    public class Text
    {
        public int TextId { get; set; }
        public string TextTitle { get; set; }
        public string TextDescription { get; set; }
        public int UploaderId { get; set; }
        public DateTime UploadDate { get; set; }
        public string FileName { get; set; }
        public int SectionId { get; set; }
    }
}
