using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstraction;
using sda_onsite_2_csharp_backend_teamwork.src.Controller;
using sda_onsite_2_csharp_backend_teamwork.src.DTO;
using sda_onsite_2_csharp_backend_teamwork.src.Entity;
namespace sdaonsite_2_csharp_backend_teamwork.src.Controller;
public class CategoryController : BaseController
{
    private ICategoryService _CategoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _CategoryService = categoryService;
    }
    [HttpGet()]
    public ActionResult<IEnumerable<CategoryReadDto>> FindAll()
    {
        return Ok(_CategoryService.FindAll());
    }
    [HttpGet("{categoryId}")]
    public ActionResult<CategoryReadDto?> FindOne(Guid categoryId)
    {
        return Ok(_CategoryService.FindOne(categoryId));
    }
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<CategoryReadDto> CreateOne([FromBody] Category category)
    {
        if (category is not null)
        {
            var createdUser = _CategoryService.CreateOne(category);
            return CreatedAtAction(nameof(CreateOne), createdUser);
        }
        return BadRequest();
    }
    [HttpPatch("{categoryId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<CategoryReadDto> UpdateOne(Guid categoryId, [FromBody] Category category)
    {

        CategoryReadDto? updatedCategory = _CategoryService.UpdateOne(categoryId, category);
        if (updatedCategory is not null)
        {
            return CreatedAtAction(nameof(UpdateOne), updatedCategory);
        }
        else return BadRequest();
    }

    [HttpDelete("{categoryId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOne(Guid categoryId)
    {
        bool isDeleted = _CategoryService.DeleteOne(categoryId);
        if (!isDeleted)

        {
            return NotFound();
        }
        return NoContent();

    }

}