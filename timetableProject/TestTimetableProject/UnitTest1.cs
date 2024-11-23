using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using timetableProject.Controllers;
using timetableProject.DTO;
using timetableProject.Services;

namespace TestTimetableProject
{
    public class UnitTest1
    {
        [Fact]
        public void TestlengthIdPost()
        {
            string id = "215114778";
            Teacher t1 = new Teacher();
            t1.Id = id;
            t1.TotalWeeklyHours = 4;
            var controller= new TeacherController(new TeacherService(new TestContex()));
            var result = controller.Post(t1);
            Assert.IsType<bool>(result.Value);
        }
        [Fact]
        public void TestValidPost()
        {
            string id = "215114778";
            Teacher t1 = new Teacher();
            t1.Id = id;
            t1.TotalWeeklyHours = 4;
            var controller = new TeacherController(new TeacherService(new TestContex()));
            var result = controller.Post(t1);
            Assert.IsType<bool>(result.Value);
        }
        [Fact]
        public void TestlengthIdPut()
        {
            string id = "215114778";
            Teacher t1 = new Teacher();
            t1.Id = id;
            t1.TeacherId = 3;
            t1.TotalWeeklyHours = 4;
            var controller = new TeacherController(new TeacherService(new TestContex()));
            var result = controller.Put(3,t1);
            Assert.IsType<bool>(result.Value);
        }
        [Fact]
        public void TestValidPut()
        {
            string id = "215114778";
            Teacher t1 = new Teacher();
            t1.Id = id;
            t1.TotalWeeklyHours = 4;
            var controller = new TeacherController(new TeacherService(new TestContex()));
            var result = controller.Put(3,t1);
            Assert.IsType<bool>(result.Value);
        }

    }
}