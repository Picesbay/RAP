﻿using System;

using RAP.Controller;

namespace RAP
{
    class Program
    {

        static void Main(string[] args)
        {
            ResearcherController rc = new ResearcherController();
            Action doSomething;
            //doSomething = rc.LoadResearchers;
            doSomething = rc.TestRunTimeLoadResearchers;
            //doSomething = rc.TestRunTimeLoadResearchers;
            doSomething();
        }
    }
}
