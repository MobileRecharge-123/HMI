using System.ComponentModel.DataAnnotations;

namespace MobileRechargeWebsite.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(10, MinimumLength = 10)]
        public string Mobile { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        // Optional: services like DoNotDisturb etc.
        public bool DoNotDisturb { get; set; }
        public bool CallerTune { get; set; }
        public string MobileNumber { get; set; }
        public string FullName { get; set; }
       


    }
}
