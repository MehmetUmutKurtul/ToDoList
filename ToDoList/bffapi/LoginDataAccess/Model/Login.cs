using System.ComponentModel.DataAnnotations;

namespace LoginDataAccess.Model {
    public class Login {
        public int Id { get; set; }

        [Required] //Dış dünyaya gönderim
        public string Name { get; set; }

        [Required] 
        public string Passwrd { get; set; }
    }
}