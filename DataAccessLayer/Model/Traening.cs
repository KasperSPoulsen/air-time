﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Traening
    {
        public DateTime Dato {  get; set; }
        public int Id { get; set; }
        public virtual Hold Hold { get; set; }
        public virtual List<Fremmoederegistrering> Fremmoederegistreringer { get; set; } = new List<Fremmoederegistrering>();
        public Traening() { }

        public Traening(DateTime dato, Hold hold, List<Fremmoederegistrering> fremmoederegistrering)
        {
            Dato = dato;
            Hold = hold;
            Fremmoederegistreringer = fremmoederegistrering;
        }
    }
}
