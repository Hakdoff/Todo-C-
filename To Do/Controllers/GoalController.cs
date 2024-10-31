using Microsoft.AspNetCore.Mvc;
using To_Do.Data;
using To_Do.Models.DTO;
using To_Do.Models.Entities;

namespace To_Do.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GoalController : ControllerBase
	{
		private readonly ApplicationDBContext _dbContext;

		public GoalController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult GetGoals()
		{
			return Ok(_dbContext.Goals.ToList());
		}

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetGoalsById(int id)
		{
			var goal = _dbContext.Goals.Find(id);

			if (goal is null)
			{
				return NotFound();
			}

			return Ok(goal);
		}

		[HttpPost]
		public IActionResult AddGoals(GoalDTO addTodoDto)
		{
			var goalEntity = new Goal()
			{
				Title = addTodoDto.Title,
				IsCompleted = addTodoDto.IsCompleted,
				CreatedAt = addTodoDto.CreatedAt
			};

			_dbContext.Goals.Add(goalEntity);
			_dbContext.SaveChanges();
			return Ok(goalEntity);
		}

		[HttpPut]
		[Route("{id:int}")]
		public IActionResult UpdateGoals(int id, GoalUpdateDTO updateGoalDto)
		{
			var goal = _dbContext.Goals.Find(id);

			if (goal is null)
			{
				return NotFound();
			}

			goal.Title = updateGoalDto.Title;
			goal.IsCompleted = updateGoalDto.IsCompleted;
			goal.CreatedAt = updateGoalDto.createdAt;

			_dbContext.SaveChanges();
			return Ok(goal);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteGoal(int id)
		{
			var goal = _dbContext.Goals.Find(id);

			if (goal is null)
			{
				return NotFound();
			}

			_dbContext.Goals.Remove(goal);
			_dbContext.SaveChanges();
			return Ok();
		}
	}
}
