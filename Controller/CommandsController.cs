using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controller
{
	[Route("api/commands")]
	[ApiController]
	public class CommandsController : ControllerBase
	{
		private readonly ICommanderRepo _repo;

		public CommandsController(ICommanderRepo repo)
		{
			_repo = repo;
		}
		[HttpGet]
		public ActionResult<IEnumerable<Command>> GetAllCommands()
		{
			var commandItems = _repo.GetAllCommand();
			return Ok(commandItems);
		}

		//Get api/commands/{id}
		[HttpGet("{id}")]
		public ActionResult<Command> GetCommandById(int Id)
		{
			var commandItem = _repo.GetCommandById(Id);
			return Ok(commandItem);
		}
	}
}
