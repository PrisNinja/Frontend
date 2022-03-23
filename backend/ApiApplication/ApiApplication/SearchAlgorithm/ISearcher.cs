﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteringsalgoritme.SearchAlgorithm
{
    public interface ISearcher
    {
        public StoreSearch FindStore(List<string> productNames, double xCoordinate, double yCoordinate, int range);
    }
}
