using System.Collections.Generic;
using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BffApi.Model;
using LoginDataAccess.Store;
using ToDoDataAccess.Store;

namespace BffApi.Controllers {
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class LoginToDoController : ControllerBase {
        private readonly IMapper mapper;
        private readonly LoginStore lstore;
        private readonly ToDoStore tdstore;
        public LoginToDoController(LoginStore lstore,ToDoStore tdstore, IMapper mapper) {//kullanacagım bilgileri taşıyan adres yolları
            this.lstore = lstore;
            this.tdstore = tdstore;
            this.mapper = mapper;
        }
 
        [Route("api/logins")]  //gelen bilgileri görebilmek için mapper kullanıldı en uc noktaya gitmek için yolu gösterme
        public List<Login> LGet() {
            return mapper.Map<List<Login>>(lstore.Get());
        }
        [Route("api/todos")] 
        public List<ToDo> TGet() {
            return mapper.Map<List<ToDo>>(tdstore.Get());
        }
        [HttpPost]
        [Route("api/todos/{addrec}")] 
        public void TSet(ToDoDataAccess.Model.ToDo addrec) {
          var effect=tdstore.AddAsync(addrec);
        }
        [Route("api/logins/{id}")]//[HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Login> GetById(int id) {
            if (!lstore.TryGet(id, out var login)) {
                return NotFound();
            }

            return mapper.Map<Login>(login);
        }
        

      
    
    }
}