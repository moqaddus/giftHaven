using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;


namespace WebWebWeb
{
    public abstract class Audit
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }


        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
    }
}