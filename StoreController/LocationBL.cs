using System;
using StoreModel;
using System.Collections.Generic;
using StoreData;

namespace StoreController
{
    public class LocationBL : ILocationBL
    {

        private ILocationRepository _repo;

        public LocationBL(ILocationRepository repo){
            _repo = repo;
        }

        public List<Location> GetLocations(){
                return _repo.GetLocations();
        }
    }
}