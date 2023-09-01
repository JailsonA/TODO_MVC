using Microsoft.EntityFrameworkCore;
using TODO_MVC.Models;

namespace TODO_MVC.Data
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
        {
        }

        public DbSet<TodoModel> Todos { get; set; }
    }
}
