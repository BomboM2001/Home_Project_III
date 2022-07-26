﻿using Home_Project_III.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Logic
{
    public interface IRunLogic
    {
        public void Create(string json);
        public IQueryable<RunInformation> ReadAll();
        public RunInformation Read(int runID);
        public void Update(string json, int runID);
        public void Delete(int runID);

        public IEnumerable<string> GetTimeOfPremiumCompetitors();
        public IEnumerable<int> GetRunIDOfPremiumUsers();
        public IEnumerable<int> GetRunIDOfLongDistanceJuniorRunners();
        public IEnumerable<string> GetLocationOfChonkers();
        public IEnumerable<string> GetLocationOfJuniorPremiumUsers();
    }
}
