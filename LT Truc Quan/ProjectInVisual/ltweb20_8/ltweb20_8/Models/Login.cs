using System.ComponentModel.DataAnnotations;

namespace ltweb20_8.Models
{
    public class Login
    {
        public string userName { get; set; }
        [DataType(DataType.Password)]

        public string password { get; set; }    
    }
}

