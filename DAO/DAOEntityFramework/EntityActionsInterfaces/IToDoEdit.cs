using DAOEntityFramework.EntityModels;

namespace DAOEntityFramework.EntityActionsInterfaces
{
	public interface IToDoEdit
	{
		void UpdateItem(ToDo item);
	}
}
