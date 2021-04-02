using DAOEntityFramework.EntityModels;

namespace DAOEntityFramework.EntityActionsInterfaces
{
	public interface IToDoDelete
	{
		void DeleteItemFromToDoList(ToDo itemToAdd);
	}
}
