﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class Bil
    {
        public int Id { get; set; }
        public KontaktPerson KontaktPerson { get; set; }
        public List<Springer> Springere { get; set; } = new List<Springer>();

        public Bil() { }

        public Bil(KontaktPerson kontaktPerson)
        {
            
            KontaktPerson = kontaktPerson;
        }
    }
}
