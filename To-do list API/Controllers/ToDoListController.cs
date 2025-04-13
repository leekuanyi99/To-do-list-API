using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using To_do_list_API.Models;
using To_do_list_API.Data;

namespace To_do_list_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ApiContext _context;

        public ToDoListController(ApiContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(ToDoList toDoItem)
        {
            if (toDoItem.Id == 0)
            {
                _context.ToDoList.Add(toDoItem);
            }
            else
            {
                var iteminDb = _context.ToDoList.Find(toDoItem.Id);

                if (iteminDb == null)
                {
                    return new JsonResult(NotFound());
                }

                iteminDb.Todoitem = toDoItem.Todoitem;

            }

            _context.SaveChanges();

            return new JsonResult(Ok(toDoItem));

        }


        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.ToDoList.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.ToDoList.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.ToDoList.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        // Get All
        [HttpGet()]
        public JsonResult GetAll()
        {
            
            var result = _context.ToDoList.ToList();

            return new JsonResult(Ok(result));
        }

    }
}
