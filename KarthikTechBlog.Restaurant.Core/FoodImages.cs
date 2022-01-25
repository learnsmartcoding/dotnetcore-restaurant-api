namespace KarthikTechBlog.Restaurant.Core
{
    public class FoodImages
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Mime { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public int? FoodMenusId { get; set; }
        public virtual FoodMenus FoodMenus { get; set; }
    }
}
 