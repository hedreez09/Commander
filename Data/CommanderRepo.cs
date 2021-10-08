using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
	public class CommanderRepo : ICommanderRepo
	{
		private readonly CommanderContext _context;

		public CommanderRepo(CommanderContext context)
		{
			_context = context;
		}
		public IEnumerable<Command> GetAllCommand()
		{
			return _context.Commands.ToList();
		}

		public Command GetCommandById(int Id)
		{
			return _context.Commands.FirstOrDefault(x => x.id == Id);
		}
	}
}
