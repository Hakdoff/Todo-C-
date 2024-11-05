using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Do.Data;
using To_Do.Models.DTO;
using To_Do.Models.Entities;

namespace To_Do.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NoteController : ControllerBase
	{
		private readonly ApplicationDBContext _dbContext;

		public NoteController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult GetNotes()
		{
			return Ok(_dbContext.Notes.ToList());
		}

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetNotesById(int id)
		{
			var note = _dbContext.Notes.Find(id);

			if (note is null)
			{
				return NotFound();
			}

			return Ok(note);
		}

		[HttpPost]
		public IActionResult AddNote(NoteDTO addNoteDto)
		{
			var noteEntity = new Note()
			{
				Description = addNoteDto.Description,
				CreatedAt = addNoteDto.CreatedAt
			};

			_dbContext.Notes.Add(noteEntity);
			_dbContext.SaveChanges();
			return Ok(noteEntity);
		}

		[HttpPut]
		[Route("{id:int}")]
		public IActionResult UpdateNote(int id, NoteUpdateDTO updateNoteDto)
		{
			var note = _dbContext.Notes.Find(id);

			if (note is null)
			{
				return NotFound();
			}

			note.Description = updateNoteDto.Description;
			note.CreatedAt = updateNoteDto.CreatedAt;

			_dbContext.SaveChanges();
			return Ok(note);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteNote(int id)
		{
			var note = _dbContext.Notes.Find(id);

			if (note is null)
			{
				return NotFound();
			}

			_dbContext.Notes.Remove(note);
			_dbContext.SaveChanges();
			return Ok();
		}
	}
}
