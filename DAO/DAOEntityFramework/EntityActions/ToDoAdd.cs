using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;

namespace DAOEntityFramework.EntityActions
{
    public class ToDoAdd : ConnectionFactory, IToDoAdd
    {
        public void AddItemToDoList(ToDo itemToAdd)
        {
            var context = CreateContextForInMemory();
            context.ToDos.AddAsync(itemToAdd);
            context.SaveChangesAsync();
        }
    }
}
