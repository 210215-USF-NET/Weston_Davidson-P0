using System;
using System.Collections.Generic;
using StoreModel;
using StoreData;

namespace StoreController
{
    public interface ILocationBL
    {
        List<Location> GetLocations();

    }
}