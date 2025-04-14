using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Repositories.Entity
{
    public class Token
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string ValidToken { get; set; }
    }
}
