using System;
namespace SAD_Project2017.Models
{
    public class Member
    {
        public int id { get; set; }
        //error or success
        public Boolean returnCode { get; set; }
        //message
        public String message { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String username { get; set; }
        public String address { get; set; }
    }
}
