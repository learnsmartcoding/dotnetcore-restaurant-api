using KarthikTechBlog.Restaurant.CrossCutting.Validation;

namespace KarthikTechBlog.Restaurant.API.ViewModel.Get
{
    public class CategoryViewModel: AbstractValidatableObject
    {
        public short Id { get; set; }   
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
