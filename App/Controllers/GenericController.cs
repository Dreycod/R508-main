using AutoMapper;
using App.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

/// <summary>
/// Generic CRUD controller with AutoMapper
/// </summary>
/// <typeparam name="TEntity">Domain entity</typeparam>
/// <typeparam name="TListDto">DTO used for list endpoints</typeparam>
/// <typeparam name="TDetailDto">DTO used for single item GET</typeparam>
[ApiController]
[Route("api/[controller]")] // override in the derived class if you want a fixed route
public abstract class GenericController<TEntity, TListDto, TDetailDto> : ControllerBase
    where TEntity : class
{
    protected readonly IMapper _mapper;
    protected readonly IDataRepository<TEntity> _repo;
    private readonly Func<TEntity, int> _getId; // how to read the PK (for CreatedAtAction)

    protected GenericController(IMapper mapper,
                                IDataRepository<TEntity> repo,
                                Func<TEntity, int> getId)
    {
        _mapper = mapper;
        _repo = repo;
        _getId = getId;
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<TDetailDto?>> Get(int id)
    {
        var res = await _repo.GetByIdAsync(id);
        if (res.Value is null) return NotFound();
        return Ok(_mapper.Map<TDetailDto>(res.Value));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public virtual async Task<ActionResult<IEnumerable<TListDto>>> GetAll()
    {
        var res = await _repo.GetAllAsync();
        var items = res.Value?.ToList() ?? [];
        if (items.Count == 0) return NoContent();
        return Ok(_mapper.Map<IEnumerable<TListDto>>(items));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<TEntity>> Create([FromBody] TEntity entity)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _repo.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = _getId(entity) }, entity);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<IActionResult> Update(int id, [FromBody] TEntity updated)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existing = await _repo.GetByIdAsync(id);
        if (existing.Value is null) return NotFound();

        await _repo.UpdateAsync(existing.Value, updated);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing.Value is null) return NotFound();

        await _repo.DeleteAsync(existing.Value);
        return NoContent();
    }
}
