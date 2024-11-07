using timetableProject.Controllers;

namespace timetableProject.Services
{
    public class AvailabilityService
    {
        public List<Availability> GetList() { 
            if(MangerDataContex._dataContex._Availabilities==null)
                MangerDataContex._dataContex._Availabilities=new List<Availability>();
            return MangerDataContex._dataContex._Availabilities; }
        public Availability GetAvailabilityId(int id) {
            if (MangerDataContex._dataContex._Availabilities == null)
                MangerDataContex._dataContex._Availabilities = new List<Availability>();
            Availability av = MangerDataContex._dataContex._Availabilities.FirstOrDefault(a => a.AvailabilityId == id);
        return av ;
        }
        public bool Update(int id, Availability avail)
        {
            if (MangerDataContex._dataContex._Availabilities == null)
                MangerDataContex._dataContex._Availabilities = new List<Availability>();
            Availability av = MangerDataContex._dataContex._Availabilities.FirstOrDefault(a => a.AvailabilityId == id);
            if (av == null) return false;
            av.AvailabilityId = id;
            av.isMust=avail.isMust;
            av.Unavailablehours = avail.Unavailablehours;
            av.IsWholeDayOff = avail.IsWholeDayOff;
            av.DayOfWeek = avail.DayOfWeek;
            return true;
        }
        public bool RemoveItem(int id)
        {
            if (MangerDataContex._dataContex._Availabilities == null)
                MangerDataContex._dataContex._Availabilities = new List<Availability>();
            Availability av = MangerDataContex._dataContex._Availabilities.FirstOrDefault(a=> a.AvailabilityId == id);
            if( av == null)
            {
                return false;
            }
            MangerDataContex._dataContex._Availabilities.Remove(av);
            return true;
        }
        public bool AddItem(Availability av)
        {
            if (MangerDataContex._dataContex._Availabilities == null)
                MangerDataContex._dataContex._Availabilities = new List<Availability>();
            if (av == null) return false;
            av.AvailabilityId = MangerDataContex._dataContex._Availabilities.Max(t => t.AvailabilityId) + 1;
            MangerDataContex._dataContex._Availabilities.Add(av);
            return true;
        }
    }
}
