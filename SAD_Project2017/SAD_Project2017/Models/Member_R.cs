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
            Add(new Member { firstname = "John", message = "", lastname = "Wu", username = "sunshine00", address = "downtown" });
            Add(new Member { firstname = "David", message = "", lastname = "Becker", username = "thunder12", address = "city center,ghost Rd." });
            Add(new Member { firstname = "Mary", message = "", lastname = "Xiang", username = "wholepackage", address = "uy street no. 5" });
            Add(new Member { firstname = "Mary", message = "", lastname = "Delod", username = "superhero94", address = "polly district" });
            Add(new Member { firstname = "Cherry", message="",lastname = "Parker", username = "cherryP", address = "hahn road, room 18" });

        }

        public Member Add(Member item)
        {
            if (item == null)
                throw new ArgumentNullException();
            item.id = next_id++;
            Members.Add(item);
            return item;
        }

        public Member Get(int id)
        {
            Member item = Members.Find(p => p.id == id);
            if (item == null)
                throw new ArgumentNullException();
            return item;
        }

        public IEnumerable<Member> GetAll()
        {
            return Members;
        }

        public void Remove(int id)
        {
            Members.RemoveAll(p => p.id == id);
        }

        public bool Update(Member item)
        {
            //Remove and add
            if (item == null)
                throw new ArgumentNullException();
            int index = Members.FindIndex(p => p.id == item.id);
            if (index == -1)
                return false;
            Members.RemoveAt(index);
            Members.Add(item);
            return true;
        }
    }
}
