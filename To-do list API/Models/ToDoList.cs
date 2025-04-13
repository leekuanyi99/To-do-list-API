using System.ComponentModel.DataAnnotations;

namespace To_do_list_API.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "To-do item content cannot be empty")]
        public string? Todoitem { get; set; }
    }
}
