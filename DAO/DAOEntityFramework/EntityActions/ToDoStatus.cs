using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAOEntityFramework.EntityActions
{
	public class ToDoStatus : ConnectionFactory, IToDoStatus
	{
		public async Task<List<ToDo>> GetToDoStatusPendingOrDone(Boolean status)
		{
			var context = CreateContextForInMemory();
			return await context.ToDos.Where(x => x.Status == status).ToListAsync();
		}

		public async void UpdateToDoStatus(ToDo item)
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
