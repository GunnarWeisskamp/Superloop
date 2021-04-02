using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAOEntityFramework.EntityActions
{
	public class ToDoGet : ConnectionFactory, IToDoGet
    {
        public async Task<List<ToDo>> GetToDoList()
        {
            var context = CreateContextForInMemory();
            return await context.ToDos.ToListAsync();
        }

        public async Task<ToDo> GetToDoByID(int id)
        {
            var context = CreateContextForInMemory();
            return await context.ToDos.Where(x => x.Id == id).SingleAsync();
        }
    }
}

