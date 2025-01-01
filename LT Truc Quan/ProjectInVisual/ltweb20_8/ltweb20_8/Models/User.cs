using System.ComponentModel.DataAnnotations;

namespace ltweb20_8.Models
{
    public class User
    {


        public long Id { get; set; }
        [System.ComponentModel.DisplayName("ho  ten")]
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }



    }
}
