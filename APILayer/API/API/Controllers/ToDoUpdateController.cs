using System;
using System.Threading.Tasks;
using API.ModelAPI;
using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoUpdateController : ControllerBase
    {
        private readonly IToDoEdit _IDoEdit;
        public IResultAPI _resCls;

        public ToDoUpdateController(IToDoEdit IDoEdit, IResultAPI resCls)
        {
            _IDoEdit = IDoEdit;
            _resCls = resCls;
        }

        [HttpPost]
        [Route("UpdateToDoItem")]
        public async Task<IResultAPI> UpdateToDoItem(ToDo item)
        {
            try
            {
                await Task.Run(() =>
                {
                    _IDoEdit.UpdateItem(item);
                    _resCls.EndMessage = "Item Updated";
                    _resCls.IsError = false;
                });            
            }
            catch (Exception ex)
            {
                _resCls.EndMessage = "Error has happened please contact customer support with the following error code: " + ex.Message; ;
                _resCls.IsError = true;
            }
            return _resCls;
        }
    }
}