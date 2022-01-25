using AutoMapper;
using KarthikTechBlog.Restaurant.API.ViewModel.Create;
using KarthikTechBlog.Restaurant.API.ViewModel.Get;
using KarthikTechBlog.Restaurant.API.ViewModel.Update;
using KarthikTechBlog.Restaurant.Core;
using KarthikTechBlog.Restaurant.CrossCutting.Extensions;
using KarthikTechBlog.Restaurant.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController(ILogger<CategoryController> logger, 
            ICategoryService categoryService,
             IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            Logger = logger;
            CategoryService = categoryService;
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
        }

        public ILogger<CategoryController> Logger { get; }
        public ICategoryService CategoryService { get; }
        public IMapper Mapper { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        [HttpGet("{id}", Name = ControllerRoute.GetCategory)]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoryAsync([FromRoute] short id)
        {
            HttpContextAccessor.HttpContext.Caller<CategoryController>();
            Logger.LogInformation($"Executing {nameof(GetCategoryAsync)}");

            var category = await CategoryService.GetCategoryAsync(id);

            if (category == null)
                return NotFound();

            var categoryModel = Mapper.Map<CategoryViewModel>(category);

            return Ok(categoryModel);
        }

        [HttpGet("All", Name = ControllerRoute.GetAllCategory)]
        [ProducesResponseType(typeof(List<CategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            HttpContextAccessor.HttpContext.Caller<CategoryController>();
            Logger.LogInformation($"Executing {nameof(GetCategoryAsync)}");

            var categories = await CategoryService.GetCategoriesAsync();

            var categoriesModel = Mapper.Map<List<CategoryViewModel>>(categories);

            return Ok(categoriesModel);

        }


        [HttpPost("", Name = ControllerRoute.PostCategory)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCategoryAsync([FromBody] CreateCategory createCategory)
        {
            HttpContextAccessor.HttpContext.Caller<CategoryController>();
            Logger.LogInformation($"Executing {nameof(PostCategoryAsync)}");

            var entity = Mapper.Map<Category>(createCategory);

            var isSuccess  = await CategoryService.CreateCategoryAsync(entity);

            return new CreatedAtRouteResult(ControllerRoute.GetCategory,
                   new { id = entity.Id });
        }


        [HttpPut("", Name = ControllerRoute.PutCategory)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]        
        public async Task<IActionResult> PutCategoryAsync([FromBody] UpdateCategory  updateCategory)
        {
            HttpContextAccessor.HttpContext.Caller<CategoryController>();
            Logger.LogInformation($"Executing {nameof(PutCategoryAsync)}");

            //var entity = Mapper.Map<Category>(updateCategory);

            //await CategoryService.UpdateCategoryAsync(entity);

            return Ok();
        }


        //[HttpDelete("{id}", Name = ControllerRoute.DeleteCategory)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> DeleteCategoryAsync([FromRoute] short id)
        //{
        //    HttpContextAccessor.HttpContext.Caller<CategoryController>();
        //    Logger.LogInformation($"Executing {nameof(DeleteCategoryAsync)}");

        //    var category = await CategoryService.GetCategoryAsync(id);

        //    if (category == null)
        //        return NotFound();
            
        //    await CategoryService.DeleteCategoryAsync(id);

        //    return Ok();
        //}

    }
}

/*

byte[] bytes = System.IO.File.ReadAllBytes(@"C:\SampleReport.pdf");
string file = Convert.ToBase64String(bytes);
*/