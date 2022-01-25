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
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodMenuController : ControllerBase
    {
        public FoodMenuController(ILogger<FoodMenuController> logger,
            IFoodMenusServices foodMenusServices,
             IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            Logger = logger;
            FoodMenusServices = foodMenusServices;            
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
        }

        public ILogger<FoodMenuController> Logger { get; }
        public IFoodMenusServices FoodMenusServices { get; }             
        public IMapper Mapper { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        [HttpGet("{id}", Name = ControllerRoute.GetFoodMenu)]
        [ProducesResponseType(typeof(FoodMenuViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFoodMenuASync([FromRoute] int id)
        {
            HttpContextAccessor.HttpContext.Caller<FoodMenuController>();
            Logger.LogInformation($"Executing {nameof(GetFoodMenuASync)}");

            var foodMenu = await FoodMenusServices.GetFoodMenuAsync(id);

            if (foodMenu == null)
                return NotFound();

            var foodMenuModel = Mapper.Map<FoodMenuViewModel>(foodMenu);

            return Ok(foodMenuModel);
        }

        [HttpGet("cuisine/{cuisineId}/allFoodMenus", Name = ControllerRoute.GetAllFoodMenuByCuisineId)]
        [ProducesResponseType(typeof(List<FoodMenuViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFoodMenuByCuisineIdAsync([FromRoute] int cuisineId)
        {
            HttpContextAccessor.HttpContext.Caller<FoodMenuController>();
            Logger.LogInformation($"Executing {nameof(GetAllFoodMenuByCuisineIdAsync)}");

            var foodMenus = await FoodMenusServices.GetFoodMenusByCuisineIdAsync(cuisineId);

            var foodMenusModel = Mapper.Map<List<FoodMenuViewModel>>(foodMenus);

            #region Temp for UI
            foodMenusModel.ForEach(f =>
            {
                var foodMenu = FoodMenusServices.GetFoodMenuAndImagesAsync(f.Id).Result;
                var foodMenuImages = Mapper.Map<List<FoodMenuImagesViewModel>>(foodMenu.FoodImages);
                f.FoodImage = foodMenuImages.FirstOrDefault();
            });
            #endregion

            return Ok(foodMenusModel);

        }


        [HttpPost("", Name = ControllerRoute.PostFoodMenu)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostFoodMenuAsync([FromBody] CreateFoodMenu  createFoodMenu)
        {
            HttpContextAccessor.HttpContext.Caller<FoodMenuController>();
            Logger.LogInformation($"Executing {nameof(PostFoodMenuAsync)}");

            var entity = Mapper.Map<FoodMenus>(createFoodMenu);

            var isSuccess = await FoodMenusServices.CreateFoodMenuAsync(entity);

            return new CreatedAtRouteResult(ControllerRoute.GetFoodMenu,
                   new { id = entity.Id });
        }


        [HttpPut("", Name = ControllerRoute.PutFoodMenu)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutFoodMenuAsync([FromBody] UpdateFoodMenu  updateFoodMenu)
        {
            HttpContextAccessor.HttpContext.Caller<FoodMenuController>();
            Logger.LogInformation($"Executing {nameof(PutFoodMenuAsync)}");

            var entity = Mapper.Map<FoodMenus>(updateFoodMenu);

            //await FoodMenusServices.UpdateFoodMenuAsync(entity);

            return Ok();
        }


        [HttpDelete("{id}", Name = ControllerRoute.DeleteFoodMenu)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteFoodMenuAsync([FromRoute] int id)
        {
            HttpContextAccessor.HttpContext.Caller<FoodMenuController>();
            Logger.LogInformation($"Executing {nameof(DeleteFoodMenuAsync)}");

            var foodmenu = await FoodMenusServices.GetFoodMenuAsync(id);

            if (foodmenu == null)
                return NotFound();

           // await FoodMenusServices.DeleteFoodMenuAsync(id);

            return Ok();
        }

        [HttpPost("upload/{id}", Name = ControllerRoute.UploadFoodMenuImage)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFoodMenuImageAsync(IFormFile file, [FromRoute] int id)
        {
            if (!IsValidFile(file))
            {                
                return BadRequest(new { message="Invalid file extension"});
            }

            byte[] fileBytes = null;
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                 fileBytes = stream.ToArray();
            }

            await FoodMenusServices.CreateFoodMenuImageAsync(fileBytes, id, file.FileName, file.ContentType);

            return Ok();
        }


        [HttpGet("{id}/foodMenuImages", Name = ControllerRoute.GetFoodMenuImages)]
        [ProducesResponseType(typeof(List<FoodMenuImagesViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFoodMenuImagesAsync([FromRoute] int id)
        {
            HttpContextAccessor.HttpContext.Caller<FoodMenuController>();
            Logger.LogInformation($"Executing {nameof(GetFoodMenuImagesAsync)}");

            var foodMenu = await FoodMenusServices.GetFoodMenuAndImagesAsync(id);

            if (foodMenu == null)
                return NotFound();

            var foodMenuModel = Mapper.Map<List<FoodMenuImagesViewModel>>(foodMenu.FoodImages);

            return Ok(foodMenuModel);
        }


        private bool IsValidFile(IFormFile file)
        {
            List<string> validFormats = new List<string>() { ".jpg", ".png",".svg" };
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            return validFormats.Contains(extension);
        }

    }
}
