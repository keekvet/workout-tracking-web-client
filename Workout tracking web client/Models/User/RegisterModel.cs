using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_tracking_web_client.Models.User
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
