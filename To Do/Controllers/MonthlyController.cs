using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_Do.Data;
using To_Do.Models.DTO;
using To_Do.Models.Entities;

namespace To_Do.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MonthlyController : ControllerBase
	{
		private readonly ApplicationDBContext _dbContext;

		public MonthlyController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult GetMonthly()
		{
			return Ok(_dbContext.Monthly.ToList());
		}

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetMonthlyById(int id)
		{
			var monthly = _dbContext.Monthly.Find(id);

			if (monthly is null)
			{
				return NotFound();
			}

			return Ok(monthly);
		}

		[HttpPost]
		public IActionResult AddMonthly(MonthlyDTO addMonthlyDto)
		{
			var monthlyEntity = new Monthly()
			{
				Title = addMonthlyDto.Title,
				Description = addMonthlyDto.Description,
				IsCompleted = addMonthlyDto.IsCompleted,
			};

			_dbContext.Monthly.Add(monthlyEntity);
			_dbContext.SaveChanges();
			return Ok(monthlyEntity);
		}

		[HttpPut]
		[Route("{id:int}")]
		public IActionResult UpdateMonthly(int id, MonthlyUpdateDTO updateMonthlyDto)
		{
			var monthly = _dbContext.Monthly.Find(id);

			if (monthly is null)
			{
				return NotFound();
			}

			monthly.Title = updateMonthlyDto.Title;
			monthly.Description = updateMonthlyDto.Description;
			monthly.IsCompleted = updateMonthlyDto.IsCompleted;

			_dbContext.SaveChanges();
			return Ok(monthly);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteMonthly(int id)
		{
			var monthly = _dbContext.Monthly.Find(id);

			if (monthly is null)
			{
				return NotFound();
			}

			_dbContext.Monthly.Remove(monthly);
			_dbContext.SaveChanges();
			return Ok();
		}
	}
}
