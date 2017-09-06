namespace TextCatalog.UI.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TextCatalog.DAL.Model;

    public class UploadViewModel
    {
        [Required]
        public string TextTitle { get; set; }
        [Required]
        public string TextDescription { get; set; }
        public int SectionId { get; set; }
        public List<Section> AvailableSections { get; set; }
    }
}