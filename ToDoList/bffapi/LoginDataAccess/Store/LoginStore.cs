using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoginDataAccess.Model;

namespace LoginDataAccess.Store {
    public class LoginStore {
        private readonly LoginContext context;

        public LoginStore(LoginContext context) { // Login bilgilerini saklıyorum.
            this.context = context;

            if (!this.context.Logins.Any()) {
                this.context.Logins.AddRange(
                    new Login {Name = "Detay", Passwrd = "123"  },
                    new Login {Name = "Umut", Passwrd = "123"  },
                    new Login {Name = "Arda", Passwrd = "123"  },
                    new Login {Name = "Semih", Passwrd = "123"  }
                    
                );
                this.context.SaveChanges();
            }
        }

        public List<Login> Get() {
            return context.Logins.OrderBy(p => p.Name).ToList();
        }

        public IAsyncEnumerable<Login> GetAsync() {
            return context.Logins.OrderBy(p => p.Name).AsAsyncEnumerable();
        }

        public bool TryGet(int id, out Login litem) {
            litem = context.Logins.Find(id);

            return litem != null;
        }

        public async Task<int> AddAsync(Login litem) {
            context.Logins.Add(litem);
            var rowsAffected = await context.SaveChangesAsync();
            return rowsAffected;
        }
    }
}