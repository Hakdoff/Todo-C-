using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Do.Data;
using To_Do.Models.DTO;
using To_Do.Models.Entities;

namespace To_Do.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ScheduleController : ControllerBase
	{

		private readonly ApplicationDBContext _dbContext;

		public ScheduleController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult GetSchedules()
		{
			return Ok(_dbContext.Schedules.ToList());
		}

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetSchedulesById(int id)
		{
			var schedule = _dbContext.Schedules.Find(id);

			if (schedule is null)
			{
				return NotFound();
			}

			return Ok(schedule);
		}

		[HttpPost]
		public IActionResult AddSchedule(ScheduleDTO addScheduleDto)
		{
			var sceduleEntity = new Schedule()
			{
				Title = addScheduleDto.Title,
				CreatedAt = addScheduleDto.CreatedAt,
			};

			_dbContext.Schedules.Add(sceduleEntity);
			_dbContext.SaveChanges();
			return Ok(sceduleEntity);
		}

		[HttpPut]
		[Route("{id:int}")]
		public IActionResult UpdateSchedule(int id, ScheduleUpdateDTO updateScheduleDto)
		{
			var schedule = _dbContext.Schedules.Find(id);

			if (schedule is null)
			{
				return NotFound();
			}

			schedule.Title = updateScheduleDto.Title;
			schedule.CreatedAt = updateScheduleDto.CreatedAt;

			_dbContext.SaveChanges();
			return Ok(schedule);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteSchedule(int id)
		{
			var schedule = _dbContext.Schedules.Find(id);

			if (schedule is null)
			{
				return NotFound();
			}

			_dbContext.Schedules.Remove(schedule);
			_dbContext.SaveChanges();
			return Ok();
		}
	}
}
