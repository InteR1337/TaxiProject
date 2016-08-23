using DataAccess;
using DataAccessInterfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiHosting.Controllers
{
    [EnableCors("*", headers: "*", methods: "*")]
    public class TaxisController : ApiController
    {
        private IRepository<Taxi> _taxiRepo;
        
        public TaxisController(IRepository<Taxi> repo)
        {
            this._taxiRepo = repo;
        }

        // GET api/taxis
        public IEnumerable<Taxi> Get()
        {
            return _taxiRepo.GetEntities();
        }

        // GET api/taxis/5 
        public Taxi Get(int id)
        {
            return _taxiRepo.GetEntity(id);
        }

        // POST api/taxis
        public void Post([FromBody]Taxi value)
        {
            _taxiRepo.CreateEntity(value);
        }

        // PUT api/taxis/5 
        public void Put(int id, [FromBody]Taxi value)
        {
            _taxiRepo.UpdatEntity(id, value);
        }

        // DELETE api/taxis/5 
        public void Delete(int id)
        {
            _taxiRepo.DeleteEntity(id);
        }
    }
}
