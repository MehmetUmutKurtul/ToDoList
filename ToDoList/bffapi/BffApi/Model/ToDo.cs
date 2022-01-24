namespace BffApi.Model {
    public class ToDo {
        public int ToDoId { get; set; }

        public string Date { get; set; }

        public string Desc { get; set; }
        
        public int IsComplete { get; set; }
        
        public int LoginId { get; set; }
    }
}