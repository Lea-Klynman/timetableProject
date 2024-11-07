using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using timetableProject;
using timetableProject.Controllers;

namespace TestTimetableProject
{
    public class UnitTest1
    {
        [Fact]
        public void TestlengthIdPost()
        {
            string id = "215117";
            Teacher t1 = new Teacher();
            t1.Id = id;
            t1.TotalWeeklyHours = 4;
            var result = new TeacherController().Post(t1);
            Assert.IsNotType<BadRequestResult>(result);
        }
        public void TestValidPost()
        {
            string id = "215114777";
            Teacher t1 = new Teacher();
            t1.Id = id;
            t1.TotalWeeklyHours = 4;
            var result = new TeacherController().Post(t1);
            Assert.IsNotType<BadRequestResult>(result);
        }
        public void TestlengthIdPut()
        {
            string id = "215114777";
            Teacher t1 = new Teacher();
            t1.Id = id;
            t1.TotalWeeklyHours = 4;
            var result = new TeacherController().Put(1,t1);
            Assert.IsType<BadRequestResult>(result);
        }
        public void TestValidPut()
        {
            string id = "215114777";
            Teacher t1 = new Teacher();
            t1.Id = id;
            t1.TotalWeeklyHours = 4;
            var result = new TeacherController().Put(1,t1);
            Assert.IsNotType<BadRequestResult>(result);
        }

    }
}