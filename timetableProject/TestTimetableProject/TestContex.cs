using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using timetableProject.DTO;
using timetableProject.Interface;

namespace TestTimetableProject
{
    class TestContex : ITeacherData
    {
        string json = @"
{
    'TeacherId': 3,
    'FirstName': 'שרה',
    'LastName': 'מזרחי',
    'Id': '215114778',
    'Subjects': [
        {
            'TeacherClassSubjectId': 5,
            'TeacherId': 3,
            'ClassId': 105,
            'SubjectId': 5,
            'HoursPerWeek': 7
        }
    ],
    'Availabilities': [
        {
            'AvailabilityId': 5,
            'DayOfWeek': 'שני',
            'Unavailablehours': '12:00-13:00',
            'IsWholeDayOff': false,
            'isMust': true
        },
        {
            'AvailabilityId': 6,
            'DayOfWeek': 'שישי',
            'Unavailablehours': '09:00-10:00',
            'IsWholeDayOff': false,
            'isMust': false
        }
    ],
    'TotalWeeklyHours': 7
}";
        public List<Teacher> LoadData()
        {
            List<Teacher>data = new List<Teacher>();
            Teacher teacher = JsonConvert.DeserializeObject<Teacher>(json);
            Teacher teacher2 = JsonConvert.DeserializeObject<Teacher>(json);
            data.Add(teacher);
            data.Add(teacher2);
            return data;
        }

        public bool SaveData(List<Teacher> data)
        {
            return true;
        }
    }
}
