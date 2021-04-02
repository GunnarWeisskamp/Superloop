using DAOEntityFramework.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAOEntityFramework.EntityActionsInterfaces
{
	public interface IToDoGet
	{
		Task<List<ToDo>> GetToDoList();
		Task<ToDo> GetToDoByID(int id);
	}
}
