using System;

using RAP.Controller;

namespace RAP
{
    class Program
    {
        public delegate void ByID(int id);

        static void Main(string[] args)
        {
            Action doSomething;
            ByID doByID;
            ResearcherController rc = new ResearcherController();

            doSomething = rc.TestBasicListResearchers;
            doSomething();


            //doByID = rc.TestResearcherListByID;
            //doByID(123460);

        }
    }
}
