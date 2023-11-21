using EntityFramework___L5.Entities;
using EntityFramework___L5;

class Program
{
    public static void Main()
    {
        using (var context = new SchoolContext())
        {
            context.Database.EnsureCreated();

            var grd1 = new Grade() { GradeName = "1st Grade" };
            var std1 = new Student() { FirstName = "Yash", LastName = "Malhotra", Grade = grd1 };

            context.Students.Add(std1);

            context.SaveChanges();

            foreach (var s in context.Students)
            {
                Console.WriteLine($"First Name: {s.FirstName}, Last Name: {s.LastName}");
            }
        }
    }
}