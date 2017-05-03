using System;
using System.Collections.Generic;
using System.Web.Http;
using SAD_Project2017.Models;
using System.Net;
using System.Net.Http;

namespace SAD_Project2017.Controllers
{
    public class MemberController : ApiController
    {
        static readonly MemberRepository repository = new Member_R();

        public IEnumerable<Member> GetAllMember()
        {
            return repository.GetAll();
        }

        public Member Get(int id)
        {
            Member item = repository.Get(id);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return item;
        }

        public HttpResponseMessage Post(Member item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Member>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void Put(int id, Member item)
        {
            item.id = id;
            if (!repository.Update(item))
                throw new HttpResponseException(HttpStatusCode.NotFound);

        }

        public void Delete(int id)
        {
            Member item = repository.Get(id);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            repository.Remove(id);
        }
    }
}
