﻿using System;
using System.Collections.Generic;
using System.Linq;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class ThingRepository : GenericRepository<Thing>, IThingRepository
    {

        public ThingRepository(TwnContext mc) : base(mc)
        {

        }
    }
}   