using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracking.Data.Enums;

namespace WorkoutTracking.Application.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public UserAccess Access { get; set; }
    }
}
