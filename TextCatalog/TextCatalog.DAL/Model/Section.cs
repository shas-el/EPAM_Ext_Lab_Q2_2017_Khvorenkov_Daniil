namespace TextCatalog.DAL.Model
{
    using System.Collections.Generic;

    public class Section
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int? ParentSectionId { get; set; }
    }
}
