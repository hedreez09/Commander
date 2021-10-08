using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
	public class MockCommanderRepo : ICommanderRepo
	{
		public IEnumerable<Command> GetAllCommand()
		{
			var commands = new List<Command>
			{
				new Command { id = 0, HowTo = "Boil Fish", Line = "Boiled water", Platform = "Kettle  & Pot" },
				new Command { id = 1, HowTo = "Boil Fish", Line = "Boiled water", Platform = "Kettle  & Pot" },
				new Command { id = 2, HowTo = "Boil Fish", Line = "Boiled water", Platform = "Kettle  & Pot" }
			};
			return commands;
		}

		public Command GetCommandById(int Id)
		{
			return new Command { id = 0, HowTo = "Boil Fish", Line = "Boiled water", Platform = "Kettle  & Pot" };
		}
	}

	
}