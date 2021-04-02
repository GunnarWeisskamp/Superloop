using DAOEntityFramework.EntityModels;

namespace DAOEntityFramework.EntityActionsInterfaces
{
	public interface IToDoAdd
	{
		public void AddItemToDoList(ToDo itemToAdd);
	}
}
