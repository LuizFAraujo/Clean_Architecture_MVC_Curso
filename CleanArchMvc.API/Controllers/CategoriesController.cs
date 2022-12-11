using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null)
            {
                return NotFound("Categorias não encontradas.");
            }
            return Ok(categories);
        }


        //[HttpGet("{id}")]
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int? id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada.");
            }
            return Ok(category);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO category)
        {
            if (category == null)
                return BadRequest("Invalid Data.");

            await _categoryService.Add(category);
            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category); // retorna 201
        }


        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO category)
        {
            if (id != category.Id)
                return BadRequest("Invalid Data.");
            if (category == null)
                return BadRequest("Invalid Data.");

            await _categoryService.Update(category);
            return Ok(category);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound("Category not found");

            await _categoryService.Remove(id);
            return Ok(category);
        }

    }
}
