namespace TextCatalog.UI.Models
{
    public class TagViewModel
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string CategoryName { get; set; }
        public string TagPresentation
        {
            get
            {
                return CategoryName + " : " + TagName;
            }
        }
    }
}