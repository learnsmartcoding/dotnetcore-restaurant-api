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
    public class CuisineController : ControllerBase
    {
        public CuisineController(ILogger<CuisineController> logger,
            ICuisineServices cuisineServices,
             IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            Logger = logger;
            CuisineServices = cuisineServices;
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
        }

        public ILogger<CuisineController> Logger { get; }
        public ICuisineServices CuisineServices { get; }        
        public IMapper Mapper { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        [HttpGet("{id}", Name = ControllerRoute.GetCuisine)]
        [ProducesResponseType(typeof(CuisineViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCuisineAsync([FromRoute] int id)
        {
            HttpContextAccessor.HttpContext.Caller<CuisineController>();
            Logger.LogInformation($"Executing {nameof(GetCuisineAsync)}");

            var cuisine = await CuisineServices.GetCuisineAsync(id);

            if (cuisine == null)
                return NotFound();

            var cuisineModel = Mapper.Map<CuisineViewModel>(cuisine);

            return Ok(cuisineModel);
        }

        [HttpGet("All", Name = ControllerRoute.GetAllCuisine)]
        [ProducesResponseType(typeof(List<CuisineViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCuisineAsync()
        {
            HttpContextAccessor.HttpContext.Caller<CuisineController>();
            Logger.LogInformation($"Executing {nameof(GetAllCuisineAsync)}");

            var cuisines = await CuisineServices.GetCuisineAsync();

            var cuisineModels = Mapper.Map<List<CuisineViewModel>>(cuisines);

            return Ok(cuisineModels);

        }


        [HttpPost("", Name = ControllerRoute.PostCuisine)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostCuisineAsync([FromBody] CreateCuisine createCuisine)
        {
            HttpContextAccessor.HttpContext.Caller<CuisineController>();
            Logger.LogInformation($"Executing {nameof(PostCuisineAsync)}");

            var entity = Mapper.Map<Cuisine>(createCuisine);

            var isSuccess  = await CuisineServices.CreateCuisineAsync(entity);

            return new CreatedAtRouteResult(ControllerRoute.GetCuisine,
                   new { id = entity.Id });
        }


        [HttpPut("", Name = ControllerRoute.PutCuisine)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]        
        public async Task<IActionResult> PutCuisineAsync([FromBody] UpdateCuisine  updateCuisine)
        {
            HttpContextAccessor.HttpContext.Caller<CuisineController>();
            Logger.LogInformation($"Executing {nameof(PutCuisineAsync)}");

            var entity = Mapper.Map<Cuisine>(updateCuisine);

            //await CuisineServices.UpdateCuisineAsync(entity);

            return Ok();
        }


        [HttpDelete("{id}", Name = ControllerRoute.DeleteCuisine)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCuisineAsync([FromRoute] int id)
        {
            HttpContextAccessor.HttpContext.Caller<CuisineController>();
            Logger.LogInformation($"Executing {nameof(DeleteCuisineAsync)}");

            var category = await CuisineServices.GetCuisineAsync(id);

            if (category == null)
                return NotFound();
            
            //await CuisineServices.DeleteCuisineAsync(id);

            return Ok();
        }

    }
}
