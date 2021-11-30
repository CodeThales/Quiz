using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musical_Quiz.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Points { get; set; }

        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public string updatedById { get; set; }
        public IdentityUser updatedBy { get; set; }
        public string createdById { get; set; }
        public IdentityUser createdBy { get; set; }
    }
}
