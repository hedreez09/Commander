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

		public void CreateCommand(Command obj)
		{
			if (obj == null)
				throw new ArgumentNullException(nameof(obj));
			_context.Commands.Add(obj);
		}

		public IEnumerable<Command> GetAllCommand()
		{
			return _context.Commands.ToList();
		}

		public Command GetCommandById(int Id)
		{
			return _context.Commands.FirstOrDefault(x => x.id == Id);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}

		public void UpdateCommand(Command obj)
		{
			//Good to have 
		}
	}
}
