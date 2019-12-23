namespace DependencyInversionDatabaseAfter
{
    public class Courses
    {
        private readonly Data database;

        public Courses(Data database)
        {
            this.database = database;
        }

        public void PrintAll()
        {
            var courses = this.database.CourseNames();

            // print courses
        }

        public void PrintIds()
        {
            var courses = this.database.CourseIds();

            // print courses
        }

        public void PrintById(int id)
        {
            var courses = this.database.GetCourseById(id);

            // print courses
        }

        public void Search(string substring)
        {
            var courses = this.database.Search(substring);

            // print courses
        }
    }
}
