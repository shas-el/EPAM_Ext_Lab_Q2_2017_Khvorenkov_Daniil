namespace TextCatalog.DAL.Model
{
    using System.Collections.Generic;

    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public int CategoryId { get; set; }
    }
}
