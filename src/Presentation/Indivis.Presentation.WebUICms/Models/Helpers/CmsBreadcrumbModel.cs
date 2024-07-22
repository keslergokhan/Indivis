namespace Indivis.Presentation.WebUICms.Models.Helpers
{
	public class CmsBreadcrumbModel
	{
        public CmsBreadcrumbModel()
        {
            
        }

        public CmsBreadcrumbModel(string title,string link)
        {
            this.Link = link;
            this.Title = title; 
        }
        public string Title { get; set; }
        public string Link { get; set; }
        public string BaseKey { get; set; }
    }
}
