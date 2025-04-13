using Microsoft.EntityFrameworkCore;
using To_do_list_API.Models;

namespace To_do_list_API.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<ToDoList> ToDoList {  get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) 
            :base(options)
        { 
        }
    }
}
