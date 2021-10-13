using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
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
		private readonly IMapper _IMapper;

		public CommandsController(ICommanderRepo repo, IMapper mapper)
		{
			_repo = repo;
			_IMapper = mapper;
		}
		[HttpGet]
		public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
		{
			var commandItems = _repo.GetAllCommand();
			return Ok(_IMapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
		}

		//Get api/commands/{id}
		[HttpGet("id")]
		public ActionResult<CommandReadDTO> GetCommandById(int Id)
		{
			var commandItem = _repo.GetCommandById(Id);
			if(commandItem != null)
			{
				return Ok(_IMapper.Map<CommandReadDTO>(commandItem));
			}
			return NotFound("The id doesn't not exist");
		}

		//POST /api/command
		[HttpPost]
		public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
		{
			var commandCreated = _IMapper.Map<Command>(commandCreateDTO);
			_repo.CreateCommand(commandCreated);
			_repo.SaveChanges();

			var commandReadDTO = _IMapper.Map<CommandReadDTO>(commandCreated);

			//This return the created object with the location in the header
			return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.id }, commandReadDTO);
		}

		//PUT api/command/{id}
		[HttpPut("{id}", Name = "GetCommandById")]
		public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
		{
			var commandFromRepo = _repo.GetCommandById(id);
			if (commandFromRepo == null)
				return NotFound();

			_IMapper.Map(commandUpdateDTO, commandFromRepo);

			_repo.UpdateCommand(commandFromRepo);
			_repo.SaveChanges();

			return NoContent();
		}

		//[HttpPatch("{id")]
		//public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
		//{
		//	var commandFromRepo = _repo.GetCommandById(id);
		//	if (commandFromRepo == null)
		//	{
		//		return NotFound();
		//	}

		//	var commandToPatch = _IMapper.Map<CommandUpdateDTO>(commandFromRepo);

		//	patchDoc.ApplyTo(commandToPatch, ModelState);// check the modelstate of the doc passed

		//	if (!TryValidateModel(commandToPatch))
		//	{
		//		return ValidationProblem(ModelState);
		//	}

		//	//mapp the validated patch model(commad) to the command from repo
		//	_IMapper.Map(commandToPatch, commandFromRepo);

		//	_repo.UpdateCommand(commandFromRepo);
		//	_repo.SaveChanges();
		//	return NoContent();
		//}
	}
}
