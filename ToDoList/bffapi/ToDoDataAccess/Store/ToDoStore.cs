using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoDataAccess.Model;

namespace ToDoDataAccess.Store {
    public class ToDoStore {
        private readonly ToDoContext context;

        public ToDoStore(ToDoContext context) { //Todo barındırıyoruz.Her eklenen Todo memoryde tutuluyor.
            this.context = context;

            if (!this.context.ToDos.Any()) {     
                this.context.SaveChanges();
            }
        }

        public List<ToDo> Get() {
            return context.ToDos.OrderBy(p => p.Desc).ToList(); // p degişken açıkalamayı return ediyoruz sıralı bir şekilde
        }
        
        

        public IAsyncEnumerable<ToDo> GetAsync() { //Zaman uyumsuz olarak numaralandırılabilen bir fonk döndürür.
            return context.ToDos.OrderBy(p => p.Desc).AsAsyncEnumerable();
        }

        public bool TryGet(int id, out ToDo litem) { //liteme id basıyoruz l itemi donderiyoruz
            litem = context.ToDos.Find(id);

            return litem != null;
        }

        public async Task<int> AddAsync(ToDo litem) {    //liteme değer ekliyoruz 
            context.ToDos.Add(litem);
            var rowsAffected = await context.SaveChangesAsync();
            return rowsAffected; 
        }
    }
}