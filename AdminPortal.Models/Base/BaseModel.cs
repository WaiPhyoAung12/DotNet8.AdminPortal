using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPortal.Models.Base
{
    public class BaseModel
    {
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public int CreatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UpdatedUserId { get; set; }
    }
}
