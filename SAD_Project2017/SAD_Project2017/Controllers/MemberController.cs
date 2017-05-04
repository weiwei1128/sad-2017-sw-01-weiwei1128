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
            return  item;
        }

        public HttpResponseMessage Post(Member item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Member>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public Message Put(int id, Member item)
        {
            item.id = id;
            String message;
            if (repository.Update(item))
                message = "Updated";
            else message = "Update failed";
            
            return new Message { id = 1, message = message };
        }

        public Message Delete(int id)
        {
            Member item = repository.Get(id);
            if(item.id.Equals(404)&&item.returnCode.Equals(false))
                return new Message { id = 1, message = item.message };
            return repository.Remove(id);
        }
    }
}
