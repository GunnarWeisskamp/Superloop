using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;
using System.Threading.Tasks;

namespace DAOEntityFramework.EntityActions
{
	public class ToDoEdit : ConnectionFactory, IToDoEdit
	{
		public async void UpdateItem(ToDo item)
		{
			await Task.Run(() =>
			{
				var context = CreateContextForInMemory();
				context.ToDos.Update(item);
				context.SaveChanges();
			});
		}
	}
}
