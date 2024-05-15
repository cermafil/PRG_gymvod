using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public class Class
        {
            public string Name { get; set; }
            public string Subject { get; set; }
        }

        public class Teacher
        {
            public string Name { get; set; }
            public List<string> Subjects { get; set; }
        }

        public class Schedule
        {
            public Dictionary<string, string> TimeSlots { get; set; } // Key: Time Slot (e.g., Mon Period 1), Value: Assigned Class (or empty string)
        }

        public class SchoolScheduler
        {
            public static Schedule GenerateSchedule(List<Class> classes, List<Teacher> teachers)
            {
                var schedule = new Schedule { TimeSlots = new Dictionary<string, string>() };
                // Define available time slots (replace with your actual time slots)
                string[] timeSlots = { "Mon Period 1", "Mon Period 2", "Tue Period 1", "Tue Period 2" };
                foreach (var slot in timeSlots)
                {
                    schedule.TimeSlots.Add(slot, "");
                }

                foreach (var classItem in classes)
                {
                    foreach (var teacher in teachers)
                    {
                        if (teacher.Subjects.Contains(classItem.Subject))
                        {
                            // Find an available time slot for the class
                            foreach (var slot in schedule.TimeSlots.Keys.ToList())
                            {
                                if (schedule.TimeSlots[slot] == "")
                                {
                                    schedule.TimeSlots[slot] = classItem.Name;
                                    break;
                                }
                            }
                            break; // Move to the next class after finding a teacher
                        }
                    }
                }

                return schedule;
            }
        }

        public static void Main(string[] args)
        {
            // Sample data (replace with your actual classes and teachers)
            var classes = new List<Class>()
    {
        new Class { Name = "Math 101", Subject = "Math" },
        new Class { Name = "English Literature", Subject = "English" }
    };

            var teachers = new List<Teacher>()
    {
        new Teacher { Name = "Mr. Smith", Subjects = new List<string>() { "Math" } },
        new Teacher { Name = "Ms. Johnson", Subjects = new List<string>() { "English" } }
    };

            var generatedSchedule = SchoolScheduler.GenerateSchedule(classes, teachers);

            Console.WriteLine("School Schedule:");
            foreach (var slot in generatedSchedule.TimeSlots)
            {
                Console.WriteLine($"{slot.Key}: {slot.Value}");
                Console.ReadKey();
            }
        }

    }
}
