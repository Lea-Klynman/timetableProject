using System.Text.Json;
using timetableProject.DTO;
using timetableProject.Interface;

namespace timetableProject.DATA
{
    public class TeacherDataContex : ITeacherData
    {
        public List<Teacher> LoadData()
        {
            try
            {
                string path= Path.Combine(AppContext.BaseDirectory, "Data", "teacher.json");
                string jsonString = File.ReadAllText(path);
                var AllTeacher = JsonSerializer.Deserialize<List<Teacher>>(jsonString);

                if (AllTeacher == null) { return null; }

                return AllTeacher;
            }
            catch
            {

                return null;
            }
        }

        public bool SaveData(List<Teacher> data)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "teacher.json");



                string jsonString = JsonSerializer.Serialize<List<Teacher>>(data);

                File.WriteAllText(path, jsonString);
                return true;
            }
            catch { return false; }
        }
    }
}
