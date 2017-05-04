using System;
namespace SAD_Project2017.Models
{
    //**repository pattern**
    // Define a generic interface for the repository
    public interface MemberRepository
    {
        System.Collections.Generic.IEnumerable<Member> GetAll();
        Member Get(int id);
        Member Add(Member item);
        Message Remove(int id);
        Boolean Update(Member item);
    }
}
