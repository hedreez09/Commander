using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data 
{
    public interface ICommanderRepo
    {
        bool SaveChanges();

       IEnumerable<Command> GetAllCommand();
       Command GetCommandById(int Id);
        void CreateCommand(Command obj);
    }
}