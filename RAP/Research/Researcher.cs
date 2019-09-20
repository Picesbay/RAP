﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
   
    public class Researcher
    {
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public Position position;

        private Position curr_position;
        private Position first_position;

        public List<Position> positions = new List<Position>();
        public List<Publication> publications = new List<Publication>();

        public Position GetCurrentJob() {
            curr_position = (from p in positions
                           where p.End == default(DateTime)
                           select p).Single();
            return curr_position;
        }
        public string CurrentJobTitle()
        {
            return curr_position.Title();
        }
        public DateTime CurrentJobStart()
        {
            return curr_position.Start;
        }
        public Position GetEarliestJob()
        {
            first_position = (from p in positions
                              orderby p.Start
                              select p).First();
            return first_position; 
        }
        public DateTime EarliestStart()
        {
            return first_position.Start;
        }
        public float Tenure()
        {
            float days = (DateTime.Today - first_position.Start).Days;
            return days/(365.0f);
        }
        public int PublicationsCount()
        {
            return publications.Count;
        }
                
    }
}