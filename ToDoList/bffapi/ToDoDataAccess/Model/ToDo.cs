using System.ComponentModel.DataAnnotations;

namespace ToDoDataAccess.Model {
    public class ToDo {
        public int Id { get; set; }

        [Required] 
        public string Date { get; set; }

        [Required] 
        public string Desc { get; set; }
        
        [Required] 
        public int IsComplete { get; set; }
        
        [Required] 
        public int LoginId { get; set; }
    }
}