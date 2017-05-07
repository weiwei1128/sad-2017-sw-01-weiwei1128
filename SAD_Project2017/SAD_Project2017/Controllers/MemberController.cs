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
            return repository.GetAllMember();
        }

        public Message Get(int id)
        {
            Member item = repository.Get(id);
            if (item.id.Equals(404) && item.returnCode.Equals(false))
                return new Message { id = 1, message = item.message };

            return item;
        }


        public Message Post(Member item)
        {
            String response = "Unknown error";
            if (item != null)
                switch (repository.Add(item))
                {
                    //0: succeed 1: failed(not input data) 2: failed(other reason)
                    case 0:
                        response = "Add succeed, member id is " + item.id;
                        break;
                    case 1:
                        response = "Failed, please input all the information.";
                        break;
                    case 2:
                        response = "Failed";
                        break;
                }
            else response = "Add succeed, member id is " + item.id;

            return new Message { id = 1, message = response }; ;
        }

        public Message Put(int id, Member item)
        {

            String message;
            if (item == null)
                message = "Failed!!!";
            else
            {
                item.id = id;
                switch (repository.Update(item))
                {
                    //0: succeed 1: failed(not input data) 2: failed(other reason)
                    case 0:
                        message = "Updated";
                        break;
                    case 1:
                        message = "Failed, please input all the information.";
                        break;
                    case 2:
                        message = "Failed";
                        break;
                    case 3:
                        message = "Failed, can not find original data.";
                        break;
                    default:
                        message = "Unknown error.";
                        break;
                }
            }

            return new Message { id = 1, message = message };
        }

        public Message Delete(int id)
        {
            Member item = repository.Get(id);
            if (item.id.Equals(404) && item.returnCode.Equals(false))
                return new Message { id = 1, message = item.message };
            return repository.Remove(id);
        }
    }
}
