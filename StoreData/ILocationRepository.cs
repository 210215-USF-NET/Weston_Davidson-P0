using StoreModel;
using System.Collections.Generic;
using System;


namespace StoreData
{
    public interface ILocationRepository
    {
        List<Location> GetLocations();

    }
}