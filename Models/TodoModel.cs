using System.ComponentModel.DataAnnotations;

namespace TODO_MVC.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200,ErrorMessage = "Max 200 letter")]
        [MinLength(2, ErrorMessage = "Min 2 Letter")]
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime Date { get; set; }
    }
}
