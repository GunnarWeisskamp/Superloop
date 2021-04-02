using API.ModelAPI;
using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ToDoAddController : ControllerBase
    {
        private readonly IToDoAdd _IToDo;
        public IResultAPI _resCls;

        public ToDoAddController(IToDoAdd IToDo, IResultAPI resCls)
        {
            _IToDo = IToDo;
            _resCls = resCls;
        }

        [HttpPost]
        [Route("AddToDoList")]
        public async Task<IResultAPI> AddToDoList(ToDo item)
        {
            try
            {
                await Task.Run(() =>
                {
                    //status must be pending upon creation
                    item.Status = false;
                    _IToDo.AddItemToDoList(item);
                    _resCls.EndMessage = "Item Inserted";
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