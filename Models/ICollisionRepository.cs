using System;
using System.Linq;
using ProjectDriveSafeV2.Models;

namespace ProjectDriveSafeV2.Models
{
    public interface ICollisionRepository
    {
        IQueryable<Crash> Crashes { get; }

        public Crash GetCrash(int crashid);
        public void SaveCollision(Crash c);
        public void EditCollision(Crash c);
        public void CreateCollision(Crash c);
        public void DeleteCollision(Crash c);
    }
}
