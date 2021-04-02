using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ModelAPI;
using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoStatusController : ControllerBase
    {
        private readonly IToDoStatus _IDoStatus;
        public IResultAPI _resCls;

        public ToDoStatusController(IToDoStatus IDoStatus, IResultAPI resCls)
        {
            _resCls = resCls;
            _IDoStatus = IDoStatus;
        }

        [HttpGet]
        [Route("GetToDoStatusByID")]
        public async Task<List<ToDo>> GetToDoStatusByID(bool status)
        {
            var item = await _IDoStatus.GetToDoStatusPendingOrDone(status);
            return item;
        }

        [HttpPost]
        [Route("UpdateToDoStatus")]
        public async Task<IResultAPI> UpdateToDoStatus(ToDo item)
        {
            try
            {
                await Task.Run(() =>
                {
                    _IDoStatus.UpdateToDoStatus(item);
                    _resCls.EndMessage = "Item status updated";
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