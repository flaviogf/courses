using System;
using School.Domain.Students;

namespace School.Domain.Recommendations
{
    public class Recommendation
    {
        public Recommendation(Student recommended, Student recommender)
        {
            Recommended = recommended;
            Recommender = recommender;
            Date = DateTime.UtcNow;
        }

        public Student Recommended { get; }

        public Student Recommender { get; }

        public DateTime Date { get; }
    }
}
