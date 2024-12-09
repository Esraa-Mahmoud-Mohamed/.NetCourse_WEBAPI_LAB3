namespace WEBAPI_LAB3.DTOs.CatalogDTOs
{
    public class DisplayCatalog
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> productname { get; set; } = new List<string>();

    }
}
