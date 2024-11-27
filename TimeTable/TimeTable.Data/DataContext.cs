using System.Drawing;
using System.Text.Json;
using TimeTable.Core.Entity;
namespace TimeTable.Data
{
    public class DataContext
    {
        public List<AvailabilityEntity> _Availabilities { get; set; }
        public List<ClassEntity> _Classes { get; set; }
        public List<SubjectEntity> _Subjects { get; set; }
        public List<TeacherEntity> _Teachers { get; set; }

        public DataContext()
        {
            try
            {
                //lowd_teacher
                string path = Path.Combine(AppContext.BaseDirectory, "JsonData", "teacher.json");
                string jsonString = File.ReadAllText(path);
                _Teachers = JsonSerializer.Deserialize<List<TeacherEntity>>(jsonString);
                 //lowd_class
                path = Path.Combine(AppContext.BaseDirectory, "JsonData", "class.json");
                 jsonString = File.ReadAllText(path);
                _Classes = JsonSerializer.Deserialize<List<ClassEntity>>(jsonString);
                //lowd_subject
                path = Path.Combine(AppContext.BaseDirectory, "JsonData", "subject.json");
                jsonString = File.ReadAllText(path);
                _Subjects = JsonSerializer.Deserialize<List<SubjectEntity>>(jsonString);
                //lowd_availability
                path = Path.Combine(AppContext.BaseDirectory, "JsonData", "availiability.json");
                jsonString = File.ReadAllText(path);
                _Availabilities = JsonSerializer.Deserialize<List<AvailabilityEntity>>(jsonString);

            }
            catch
            {

                
            }
        }
        public void SaveChange()
        {
            //save teacher
            string path = Path.Combine(AppContext.BaseDirectory, "JsonData", "teacher.json");
            string jsonString = JsonSerializer.Serialize<List<TeacherEntity>>(_Teachers);
            File.WriteAllText(path, jsonString);
            //save class
             path = Path.Combine(AppContext.BaseDirectory, "JsonData", "class.json");
             jsonString = JsonSerializer.Serialize<List<ClassEntity>>(_Classes);
            File.WriteAllText(path, jsonString);
            //save subject
            path = Path.Combine(AppContext.BaseDirectory, "JsonData", "subject.json");
            jsonString = JsonSerializer.Serialize<List<SubjectEntity>>(_Subjects);
            File.WriteAllText(path, jsonString);
            //save availability
            path = Path.Combine(AppContext.BaseDirectory, "JsonData", "availability.json");
            jsonString = JsonSerializer.Serialize<List<AvailabilityEntity>>(_Availabilities);
            File.WriteAllText(path, jsonString);

        }
    }
}
