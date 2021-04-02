using DAOEntityFramework.EntityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAOEntityFramework.EntityActionsInterfaces
{
	public interface IToDoStatus
	{
		Task<List<ToDo>> GetToDoStatusPendingOrDone(Boolean status);
		void UpdateToDoStatus(ToDo item);
	}
}
