using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAOEntityFramework.EntityActionsInterfaces;
using DAOEntityFramework.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoGetController : ControllerBase
    {
        private readonly IToDoGet _IDoGet;

        public ToDoGetController(IToDoGet IDoGet)
        {
            _IDoGet = IDoGet;
        }

        [HttpGet]
        [Route("GetToDoList")]
        public async Task<IEnumerable<ToDo>> GetToDoList()
        {
            var items = await _IDoGet.GetToDoList();
            return items;
        }

        [HttpGet]
        [Route("GetToDoByID")]
        public async Task<ToDo> GetToDoByID(int id)
        {
            ToDo _ToDoCls = new ToDo();
            try
            {
                _ToDoCls = await _IDoGet.GetToDoByID(id);
            }
            catch (Exception ex)
            {
                _ToDoCls.Description = "Error has happened please contact customer support with the following error code: " + ex.Message; ;
            }
            return _ToDoCls;
        }
    }
}
