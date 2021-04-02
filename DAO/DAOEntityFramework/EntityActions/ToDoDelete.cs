using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;

namespace DAOEntityFramework.EntityActions
{
    public class ToDoDelete : ConnectionFactory, IToDoDelete
    {
        public void DeleteItemFromToDoList(ToDo itemToAdd)
        {
            var context = CreateContextForInMemory();
            context.ToDos.Remove(itemToAdd);
            context.SaveChangesAsync();
        }
    }
}
