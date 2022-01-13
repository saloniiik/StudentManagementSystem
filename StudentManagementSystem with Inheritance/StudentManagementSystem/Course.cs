using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem
{
    public abstract class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDuration { get; set; }
        public float CourseFees { get; set; }
        public float FeesToBePaid { get; set; }
        public string type { get; set; }
        public int availibility { get; set; }
        public Level Degreelevel { get; set; }
        public DiplomaType diplomaType { get; set; }
        public bool IsPlacementAvailable{ get; set; }
        public string optedPlacment { get; set; }
        public bool choice;

        public Course()
        {

        }
        public Course(string CourseId, string CourseName, string CourseDuration, float CourseFees, int availibility)
        {
            this.CourseId = CourseId;
            this.CourseName = CourseName;
            this.CourseDuration = CourseDuration;
            this.CourseFees = CourseFees;
            this.availibility = availibility;
        }
        public abstract float CalculateFees(bool choice);

    }

    public enum DiplomaType { Academic, Professional }
    class Diploma : Course
    {
        public Diploma(string CourseId, string CourseName, string CourseDuration, float CourseFees, int availibility, string type, DiplomaType DiplomaTypee) : base(CourseId, CourseName, CourseDuration, CourseFees, availibility)
        {
            this.type = type;
            this.diplomaType = DiplomaTypee;
        }

        public override float CalculateFees(bool choice)
        {
            if (diplomaType.Equals(DiplomaType.Academic))
                return FeesToBePaid = CourseFees + ((CourseFees * 10) / 100);
            else
                return FeesToBePaid = CourseFees + ((CourseFees * 20) / 100);
        }
        
    }

    public enum Level { Bachelors, Masters}
    
    class Degree : Course
    {
        
        public Degree(string CourseId, string CourseName, string CourseDuration, float CourseFees, int availibility, string type, Level Degreelevel, string optedPlacment) : base(CourseId, CourseName, CourseDuration, CourseFees, availibility)
        {
            this.type = type;
            this.Degreelevel = Degreelevel;
            this.optedPlacment = optedPlacment;
            this.IsPlacementAvailable = optedPlacment.ToUpper().Equals("YES") ? true : false;
        }
        public override float CalculateFees(bool IsPlacementAvailable)
        {
            if (Degreelevel.Equals(Level.Bachelors))
            {
                if (IsPlacementAvailable)
                    return FeesToBePaid = CourseFees + ((CourseFees * 10) / 100);
                else
                    return FeesToBePaid = CourseFees + ((CourseFees * 5) / 100);
            }
            if (Degreelevel.Equals(Level.Masters))
            {
                if (IsPlacementAvailable)
                    return FeesToBePaid = CourseFees + ((CourseFees * 20) / 100);
                else
                    return FeesToBePaid = CourseFees + ((CourseFees * 10) / 100);
            }
            return FeesToBePaid;
        }

    }
}
