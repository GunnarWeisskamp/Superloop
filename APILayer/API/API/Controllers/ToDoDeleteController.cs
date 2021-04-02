using API.ModelAPI;
using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoDeleteController : ControllerBase
    {
        public IResultAPI _resCls;
        public IToDoDelete _IToDel;

        public ToDoDeleteController(IToDoDelete IToDel, IResultAPI resCls)
        {
            _IToDel = IToDel;
            _resCls = resCls;
        }

        [HttpPost]
        [Route("DeleteToDoItem")]
        public async Task<IResultAPI> DeleteToDoItem(ToDo item)
        {
            try
            {
                await Task.Run(() =>
                {
                    _IToDel.DeleteItemFromToDoList(item);
                    _resCls.EndMessage = "Item Deleted";
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