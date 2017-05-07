using System;
using System.Collections.Generic;
namespace SAD_Project2017.Models
{
    public class Member_R : MemberRepository
    {
        private List<Member> Members = new List<Member>();
        private int next_id = 1;

        public Member_R()
        {
            //default data
            Add(new Member { firstname = "John", returnCode = true ,lastname = "Wu", username = "sunshine00", address = "downtown" });
            Add(new Member { firstname = "David", returnCode = true, lastname = "Becker", username = "thunder12", address = "city center,ghost Rd." });
            Add(new Member { firstname = "Mary", returnCode = true, lastname = "Xiang", username = "wholepackage", address = "uy street no. 5" });
            Add(new Member { firstname = "Mary", returnCode = true, lastname = "Delod", username = "superhero94", address = "polly district" });
            Add(new Member { firstname = "Cherry", returnCode =true,lastname = "Parker", username = "cherryP", address = "hahn road, room 18" });

        }


        public int Add(Member item)
        {
            if (item == null)
                return 2;
            if (item.firstname == null || item.firstname == ""
                || item.lastname.Equals(null) || item.lastname == ""
                || item.username.Equals(null) || item.username == ""
                || item.address.Equals(null) || item.address == "")
                return 1;
            item.id = next_id++;
            if (item.returnCode != true)
                item.returnCode = true;
            Members.Add(item);
            return 0;
        }

        public Member Get(int id)
        {
            Member item = Members.Find(p => p.id == id);
            if (item == null)
                return new Member { id = 404, returnCode = false, message = "not existed" };
            return item;
        }

        public IEnumerable<Member> GetAllMember()
        {
            return Members;
        }

        public Message Remove(int id)
        {
            //delete all the item whose id fits
            Members.RemoveAll(p => p.id == id);
            return new Message { id = 1, message = "removed" };
        }

        public int Update(Member item)
        {
            //0: succeed 1: failed(not input data) 2: failed(other reason)
            //Remove and add
            if (item == null)
                return 2;
            int index = Members.FindIndex(p => p.id == item.id);
            if (index == -1)
                return 2;
            if (item.firstname==null ||item.firstname == ""
                || item.lastname.Equals(null)|| item.lastname == ""
                || item.username.Equals(null)|| item.username == ""
                ||item.address.Equals(null)|| item.address == "")
                return 1;
            Members.RemoveAt(index);
            item.message = "Updated";
            Members.Add(item);
            return 0;
        }
    }
}
