using System;
namespace SAD_Project2017.Models
{
    public class Member :Message
    {
        //error or success
        public Boolean returnCode { get; set; }
        //message}
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String username { get; set; }
        public String address { get; set; }
    }
}
