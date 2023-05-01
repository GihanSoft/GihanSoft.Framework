using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Sample.AspCore.Common.Data;

namespace Sample.AspCore.Features.Notes;

[ApiController]
[Route("/API/v1/[controller]")]
public class NotesController : ControllerBase
{
    private readonly AppDbContext appDbContext;

    public NotesController(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    [HttpGet]
    public async ValueTask<IActionResult> Query()
    {
        var notes = await appDbContext.Notes.ToListAsync();
        return Ok(notes);
    }
}
