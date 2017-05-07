using System;
namespace SAD_Project2017.Models
{
    //**repository pattern**
    // Define a generic interface for the repository
    public interface MemberRepository
    {
        System.Collections.Generic.IEnumerable<Member> GetAllMember();
        Member Get(int id);
        int Add(Member item);
        Message Remove(int id);
        int Update(Member item);
    }
}
