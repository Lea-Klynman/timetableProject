using timetableProject.DTO;

namespace timetableProject.Interface
{
    public interface ITeacherData
    {
        public List<Teacher> LoadData();
        public bool SaveData(List<Teacher> data);


    }
}
