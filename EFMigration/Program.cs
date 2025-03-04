using EFMigration.Data;
using System.Runtime.InteropServices;
namespace EFMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {
             using (var context = new AppDbContext())
            {
                var data = from s in context.Sections
                           join i in context.Instructors
                           on s.InstructorId equals i.Id
                           join sc in context.SectionSchedules
                           on s.Id equals sc.SectionId
                           join c in context.Schedules
                           on sc.ScheduleId equals c.Id
                           join cou in context.Courses
                           on s.CourseId equals cou.Id
                           select new
                           {
                               courseName = cou.CourseName,
                               SectionName = s.SectionName,
                               ScheduleTitle = c.Title,
                               InstructorName=i.FName+ " " + i.LName,
                               StartTime = sc.StartTime,
                               EndTime = sc.EndTime,
                               Sun = c.SUN,
                               Mon = c.MON,
                               Tue = c.TUE,
                               Wed = c.WED,
                               Thu = c.THU,
                               Fri = c.FRI,
                               Sat = c.SAT
                           };
                Console.WriteLine($"Course Name ");
                Console.Write($"Section Name ");
                Console.Write($"Schedule Title ");
                Console.Write($"Instructor Name ");
                Console.Write($"Start Time  ");
                Console.Write($"End Time  ");
                Console.Write($"Sun  ");
                Console.Write($"Mon  ");
                Console.Write($"Tue  ");
                Console.Write($"Wed  ");
                Console.Write($"Thu  ");
                Console.Write($"Fri  ");
                Console.WriteLine($"Sat  ");
                Console.WriteLine("-------------------------------------------------");
                foreach (var item in data)
                {
                    Console.WriteLine($"{item.courseName}");
                    Console.Write($"        {item.SectionName}");
                    Console.Write($"     {item.ScheduleTitle}");
                    Console.Write($"     {item.InstructorName}");
                    Console.Write($"     {item.StartTime}");
                    Console.Write($"     {item.EndTime}");
                    Console.Write($"    {item.Sun}");
                    Console.Write($" {item.Mon}");
                    Console.Write($" {item.Tue}");
                    Console.Write($" {item.Wed}");
                    Console.Write($" {item.Thu}");
                    Console.Write($" {item.Fri}");
                    Console.WriteLine($" {item.Sat}");
                    
                }
            }
        }
    }
}
