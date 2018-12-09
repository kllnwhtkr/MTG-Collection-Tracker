﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_Collection_Tracker
{
    public static class TaskCollectionExtensions
    {
        public static IEnumerable<BackgroundTask> FindCompleted(this IEnumerable<BackgroundTask> tasks)
        {
            return tasks.Where(x => x.RunState == RunState.Completed);
        }

        public static IEnumerable<BackgroundTask> FindInitialized(this IEnumerable<BackgroundTask> tasks)
        {
            return tasks.Where(x => x.RunState == RunState.Initialized);
        }
    }
}