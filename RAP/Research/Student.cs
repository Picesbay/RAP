﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public class Student : Researcher
    {
        public string Degree { get; set; }
        public int SupervisorID { get; set; }


        public string SupervisorsName(List<Researcher> researchers)
        {
            var supervisor = (from r in researchers
                              where r.ID == SupervisorID
                              select r).SingleOrDefault();
            return supervisor.GivenName + " " + supervisor.FamilyName;
        }
    }
}
