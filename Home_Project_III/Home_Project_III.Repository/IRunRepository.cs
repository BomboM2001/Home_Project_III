﻿using Home_Project_III.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Repository
{
    public interface IRunRepository
    {
        public void Create(string json);
        public IQueryable<RunInformation> ReadAll();
        public RunInformation Read(int runID);
        public void Delete(int runId);
        public void Update(string json, int runId);
    }
}
