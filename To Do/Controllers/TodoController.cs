using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do.Data;
using To_Do.Models.DTO;
using To_Do.Models.Entities;

namespace To_Do.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private readonly ApplicationDBContext _dbContext;

		public TodoController(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult GetProducts()
		{
			return Ok(_dbContext.Todos.ToList());
		}

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetProductById(int id)
		{
			var todo = _dbContext.Todos.Find(id);

			if (todo is null)
			{
				return NotFound();
			}

			return Ok(todo);
		}

		[HttpPost]
		public IActionResult AddProducts(TodoDTO addTodoDto)
		{
			var todoEntity = new Todo()
			{
				Title = addTodoDto.Title,
				Description = addTodoDto.Description,
				Deadline = addTodoDto.Deadline,
				IsCompleted = addTodoDto.IsCompleted,
			};

			_dbContext.Todos.Add(todoEntity);
			_dbContext.SaveChanges();
			return Ok(todoEntity);
		}

		[HttpPut]
		[Route("{id:int}")]
		public IActionResult UpdateTodo(int id, TodoDTOUpdate updateTodoDto)
		{
			var todo = _dbContext.Todos.Find(id);

			if (todo is null)
			{
				return NotFound();
			}

			todo.Title = updateTodoDto.Title;
			todo.Description = updateTodoDto.Description;
			todo.IsCompleted = updateTodoDto.IsCompleted;
			todo.Deadline = updateTodoDto.Deadline;

			_dbContext.SaveChanges();
			return Ok(todo);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteProduct(int id)
		{
			var todo = _dbContext.Todos.Find(id);

			if (todo is null)
			{
				return NotFound();
			}

			_dbContext.Todos.Remove(todo);
			_dbContext.SaveChanges();
			return Ok();
		}
	}
}
