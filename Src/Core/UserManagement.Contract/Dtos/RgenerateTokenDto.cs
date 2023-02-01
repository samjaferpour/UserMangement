using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Contract.Dtos
{
    public class RgenerateTokenDto
    {
        public string refreshToken { get; set; } = string.Empty;
    }
}
