using timetableProject.Controllers;

namespace timetableProject.Services
{
    public class AvailabilityService
    {
        public List<Availability> Availabilities { get; set; }=new List<Availability>();
        public List<Availability> GetList() { return Availabilities; }
        public Availability GetAvailabilityId(int id) {
            Availability av = Availabilities.FirstOrDefault(a => a.AvailabilityId == id);
        return av ;
        }
        public bool Update(int id, Availability avail)
        {
            Availability av = Availabilities.FirstOrDefault(a => a.AvailabilityId == id);
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
            Availability av = Availabilities.FirstOrDefault(a=> a.AvailabilityId == id);
            if( av == null)
            {
                return false;
            }
            Availabilities.Remove(av);
            return true;
        }
        public bool AddItem(Availability av)
        {
            if (av == null) return false;
            Availabilities.Add(av);
            return true;
        }
    }
}
