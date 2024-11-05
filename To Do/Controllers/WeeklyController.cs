using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Do.Data;
using To_Do.Models.DTO;
using To_Do.Models.Entities;

namespace To_Do.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeeklyController : ControllerBase
	{
		private readonly ApplicationDBContext _dbContext;

		public WeeklyController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult GetWeekly()
		{
			return Ok(_dbContext.Weekly.ToList());
		}

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetWeeklyById(int id)
		{
			var weekly = _dbContext.Weekly.Find(id);

			if (weekly is null)
			{
				return NotFound();
			}

			return Ok(weekly);
		}

		[HttpPost]
		public IActionResult AddWeekly(WeeklyDTO addWeeklyDto)
		{
			var weeklyEntity = new Weekly()
			{
				Title = addWeeklyDto.Title,
				Description = addWeeklyDto.Description,
				IsCompleted = addWeeklyDto.IsCompleted,
				CreatedAt = addWeeklyDto.CreatedAt
			};

			_dbContext.Weekly.Add(weeklyEntity);
			_dbContext.SaveChanges();
			return Ok(weeklyEntity);
		}

		[HttpPut]
		[Route("{id:int}")]
		public IActionResult UpdateWeekly(int id, WeeklyUpdateDTO updateWeeklyDto)
		{
			var weekly = _dbContext.Weekly.Find(id);

			if (weekly is null)
			{
				return NotFound();
			}

			weekly.Title = updateWeeklyDto.Title;
			weekly.Description = updateWeeklyDto.Description;
			weekly.IsCompleted = updateWeeklyDto.IsCompleted;
			weekly.CreatedAt = updateWeeklyDto.CreatedAt;

			_dbContext.SaveChanges();
			return Ok(weekly);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteWeekly(int id)
		{
			var weekly = _dbContext.Weekly.Find(id);

			if (weekly is null)
			{
				return NotFound();
			}

			_dbContext.Weekly.Remove(weekly);
			_dbContext.SaveChanges();
			return Ok();
		}
	}
}
