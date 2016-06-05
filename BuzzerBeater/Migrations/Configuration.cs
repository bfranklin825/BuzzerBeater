namespace BuzzerBeater.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BuzzerBeater.DAL.BuzzerBeaterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BuzzerBeater.DAL.BuzzerBeaterContext context)
        {

            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            //add or update default school
            var schools = new List<School>
            {
                new School{SchoolName="Practice Tests"}
            };
            schools.ForEach(s => context.Schools.AddOrUpdate(n => n.SchoolName, s));
            context.SaveChanges();

            //add or update default teacher
            var teachers = new List<Teacher>
            {
                new Teacher{ PersonId=Guid.NewGuid(), FirstName="Buzzer", LastName="Beater", MySchool = schools.Single(s => s.SchoolName == "Practice Tests")}
            };
            teachers.ForEach(t => context.Teachers.AddOrUpdate(n => n.FirstName, t));
            context.SaveChanges();

            //add the practice student
            var students = new List<Student>
            {
                new Student{ PersonId=Guid.NewGuid(), FirstName = "Practice", LastName ="Tests", UserName="practice", Password="test123"}
            };
            students.ForEach(s => context.Students.AddOrUpdate(n => n.UserName, s));
            context.SaveChanges();

            //var practiceClass = new Class { ClassName = "Practice Class", Students = new List<Student>() };

            //clear the defult tests
            context.Tests.RemoveRange(context.Tests.Where(t => t.DefaultTest == true));

            //add default tests
            var tests = new List<Test>
            {
                new Test{TestName="Addition", Duration=5, DefaultTest=true, Active=true, Owner= context.Teachers.Single(t => t.FirstName == "Buzzer" && t.LastName == "Beater")},
                new Test{TestName="Subtraction", Duration=5, DefaultTest=true, Active=true, Owner= context.Teachers.Single(t => t.FirstName == "Buzzer" && t.LastName == "Beater")},
                new Test{TestName="Multiplication", Duration=5, DefaultTest=true, Active=true, Owner= context.Teachers.Single(t => t.FirstName == "Buzzer" && t.LastName == "Beater")},
                new Test{TestName="Division", Duration=5, DefaultTest=true, Active=true, Owner= context.Teachers.Single(t => t.FirstName == "Buzzer" && t.LastName == "Beater")}
            };
            tests.ForEach(t => context.Tests.AddOrUpdate(n => n.TestName));
            context.SaveChanges();

            //clear the default questions from the database            
            context.Questions.RemoveRange(context.Questions.Where(q => q.Test.DefaultTest == true));

            var questions = new List<Question>
            {
                //addition
                new Question{LeftOperand=3, RightOperand=2, Operator="+", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=3, Operator="+", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=2, Operator="+", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=6, RightOperand=1, Operator="+", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=7, RightOperand=7, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=2, RightOperand=7, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=8, RightOperand=6, Operator="+", CorrectAnswer=14, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=4, RightOperand=2, Operator="+", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=2, Operator="+", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=2, RightOperand=0, Operator="+", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Addition")}, //10

                new Question{LeftOperand=7, RightOperand=7, Operator="+", CorrectAnswer=14, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=5, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=2, RightOperand=2, Operator="+", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=6, RightOperand=5, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=1, Operator="+", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=9, RightOperand=2, Operator="+", CorrectAnswer=11, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=3, RightOperand=1, Operator="+", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=7, RightOperand=2, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=0, Operator="+", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=4, RightOperand=9, Operator="+", CorrectAnswer=13, Test=tests.Single(i => i.TestName == "Addition")}, //20

                new Question{LeftOperand=4, RightOperand=8, Operator="+", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=8, RightOperand=9, Operator="+", CorrectAnswer=17, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=7, Operator="+", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=9, RightOperand=4, Operator="+", CorrectAnswer=13, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=1, Operator="+", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=8, RightOperand=0, Operator="+", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=6, RightOperand=9, Operator="+", CorrectAnswer=15, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=9, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=2, RightOperand=4, Operator="+", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=4, RightOperand=6, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")}, //30

                new Question{LeftOperand=9, RightOperand=0, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=3, Operator="+", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=8, RightOperand=2, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=3, RightOperand=0, Operator="+", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=2, RightOperand=6, Operator="+", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=3, RightOperand=6, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=6, Operator="+", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=7, RightOperand=6, Operator="+", CorrectAnswer=13, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=2, Operator="+", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=8, Operator="+", CorrectAnswer=13, Test=tests.Single(i => i.TestName == "Addition")}, //40

                new Question{LeftOperand=2, RightOperand=1, Operator="+", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=3, RightOperand=3, Operator="+", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=9, RightOperand=7, Operator="+", CorrectAnswer=16, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=4, RightOperand=1, Operator="+", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=5, Operator="+", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=4, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=0, Operator="+", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=0, Operator="+", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=6, RightOperand=4, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=3, RightOperand=9, Operator="+", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Addition")}, //50

                new Question{LeftOperand=2, RightOperand=5, Operator="+", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=1, Operator="+", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=7, RightOperand=3, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=7, RightOperand=0, Operator="+", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=4, RightOperand=4, Operator="+", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=6, RightOperand=0, Operator="+", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=2, RightOperand=9, Operator="+", CorrectAnswer=11, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=7, RightOperand=9, Operator="+", CorrectAnswer=16, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=6, RightOperand=8, Operator="+", CorrectAnswer=14, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=4, Operator="+", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Addition")}, //60
                
                new Question{LeftOperand=8, RightOperand=4, Operator="+", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=3, RightOperand=8, Operator="+", CorrectAnswer=11, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=6, RightOperand=3, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=8, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=9, RightOperand=3, Operator="+", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=4, RightOperand=7, Operator="+", CorrectAnswer=11, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=3, RightOperand=5, Operator="+", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=9, RightOperand=9, Operator="+", CorrectAnswer=18, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=6, Operator="+", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=9, RightOperand=6, Operator="+", CorrectAnswer=15, Test=tests.Single(i => i.TestName == "Addition")}, //70

                new Question{LeftOperand=6, RightOperand=6, Operator="+", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=6, Operator="+", CorrectAnswer=11, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=8, RightOperand=7, Operator="+", CorrectAnswer=15, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=4, RightOperand=0, Operator="+", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=2, RightOperand=3, Operator="+", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=9, RightOperand=8, Operator="+", CorrectAnswer=17, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=8, RightOperand=3, Operator="+", CorrectAnswer=11, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=9, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=8, RightOperand=5, Operator="+", CorrectAnswer=13, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=7, Operator="+", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Addition")}, //80

                new Question{LeftOperand=7, RightOperand=1, Operator="+", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=5, Operator="+", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=7, RightOperand=5, Operator="+", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=7, RightOperand=8, Operator="+", CorrectAnswer=15, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=8, RightOperand=1, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=4, Operator="+", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=6, RightOperand=2, Operator="+", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=2, RightOperand=8, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=7, RightOperand=4, Operator="+", CorrectAnswer=11, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=9, RightOperand=1, Operator="+", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Addition")}, //90

                new Question{LeftOperand=3, RightOperand=4, Operator="+", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=9, Operator="+", CorrectAnswer=14, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=4, RightOperand=5, Operator="+", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=0, RightOperand=8, Operator="+", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=9, RightOperand=5, Operator="+", CorrectAnswer=14, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=5, RightOperand=3, Operator="+", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=4, RightOperand=3, Operator="+", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=8, RightOperand=8, Operator="+", CorrectAnswer=16, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=1, RightOperand=7, Operator="+", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Addition")},
                new Question{LeftOperand=6, RightOperand=7, Operator="+", CorrectAnswer=13, Test=tests.Single(i => i.TestName == "Addition")}, //100
                //subtraction
                new Question{LeftOperand=8, RightOperand=1, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=4, RightOperand=2, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=16, RightOperand=7, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=7, RightOperand=1, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=9, RightOperand=3, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=13, RightOperand=4, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=10, RightOperand=2, Operator="-", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=5, RightOperand=4, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=7, RightOperand=7, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=2, RightOperand=2, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")}, //10

                new Question{LeftOperand=9, RightOperand=8, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=5, RightOperand=5, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=10, RightOperand=7, Operator="-", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=13, RightOperand=8, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=6, RightOperand=4, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=1, RightOperand=0, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=9, RightOperand=0, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=14, RightOperand=9, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=11, RightOperand=6, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=9, RightOperand=1, Operator="-", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Subtraction")}, //20

                new Question{LeftOperand=12, RightOperand=9, Operator="-", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=8, RightOperand=0, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=0, RightOperand=0, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=13, RightOperand=6, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=7, RightOperand=6, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=12, RightOperand=4, Operator="-", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=8, RightOperand=5, Operator="-", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=4, RightOperand=1, Operator="-", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=11, RightOperand=9, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=6, RightOperand=1, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")}, //30

                new Question{LeftOperand=5, RightOperand=0, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=14, RightOperand=6, Operator="-", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=8, RightOperand=8, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=10, RightOperand=3, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=3, RightOperand=0, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=12, RightOperand=7, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=7, RightOperand=0, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=10, RightOperand=1, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=2, RightOperand=1, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=9, RightOperand=7, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")}, //40

                new Question{LeftOperand=11, RightOperand=7, Operator="-", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=6, RightOperand=0, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=9, RightOperand=4, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=4, RightOperand=0, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=10, RightOperand=6, Operator="-", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=5, RightOperand=3, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=15, RightOperand=8, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=4, RightOperand=4, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=10, RightOperand=9, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=8, RightOperand=4, Operator="-", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Subtraction")}, //50

                new Question{LeftOperand=7, RightOperand=5, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=2, RightOperand=0, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=12, RightOperand=3, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=6, RightOperand=3, Operator="-", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=9, RightOperand=2, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=11, RightOperand=5, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=8, RightOperand=3, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=14, RightOperand=5, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=7, RightOperand=3, Operator="-", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=12, RightOperand=6, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")}, //60

                new Question{LeftOperand=10, RightOperand=8, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=6, RightOperand=6, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=14, RightOperand=8, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=11, RightOperand=2, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=3, RightOperand=2, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=13, RightOperand=5, Operator="-", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=9, RightOperand=6, Operator="-", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=1, RightOperand=1, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=16, RightOperand=9, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=11, RightOperand=3, Operator="-", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Subtraction")}, //70

                new Question{LeftOperand=4, RightOperand=3, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=13, RightOperand=7, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=7, RightOperand=2, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=15, RightOperand=6, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=10, RightOperand=5, Operator="-", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=18, RightOperand=9, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=6, RightOperand=2, Operator="-", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=17, RightOperand=8, Operator="-", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=11, RightOperand=8, Operator="-", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=5, RightOperand=1, Operator="-", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Subtraction")}, //80

                new Question{LeftOperand=16, RightOperand=8, Operator="-", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=8, RightOperand=2, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=10, RightOperand=4, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=15, RightOperand=9, Operator="-", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=5, RightOperand=2, Operator="-", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=8, RightOperand=6, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=13, RightOperand=9, Operator="-", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=9, RightOperand=9, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=14, RightOperand=7, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=12, RightOperand=8, Operator="-", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Subtraction")}, //90

                new Question{LeftOperand=3, RightOperand=1, Operator="-", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=15, RightOperand=7, Operator="-", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=9, RightOperand=5, Operator="-", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=6, RightOperand=5, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=17, RightOperand=9, Operator="-", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=7, RightOperand=4, Operator="-", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=11, RightOperand=4, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=3, RightOperand=3, Operator="-", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=12, RightOperand=5, Operator="-", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Subtraction")},
                new Question{LeftOperand=8, RightOperand=7, Operator="-", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Subtraction")}, //100
                //multiplication
                new Question{LeftOperand=6, RightOperand=1, Operator="x", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=2, RightOperand=5, Operator="x", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=0, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=4, Operator="x", CorrectAnswer=16, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=2, Operator="x", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=5, Operator="x", CorrectAnswer=45, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=2, RightOperand=8, Operator="x", CorrectAnswer=16, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=8, Operator="x", CorrectAnswer=40, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=4, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=7, Operator="x", CorrectAnswer=63, Test=tests.Single(i => i.TestName == "Multiplication")}, //10

                new Question{LeftOperand=1, RightOperand=5, Operator="x", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=4, Operator="x", CorrectAnswer=28, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=2, Operator="x", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=8, Operator="x", CorrectAnswer=72, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=3, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=1, Operator="x", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=3, Operator="x", CorrectAnswer=27, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=2, RightOperand=6, Operator="x", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=8, Operator="x", CorrectAnswer=32, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=0, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")}, //20

                new Question{LeftOperand=5, RightOperand=2, Operator="x", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=3, Operator="x", CorrectAnswer=18, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=7, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=2, Operator="x", CorrectAnswer=18, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=7, Operator="x", CorrectAnswer=28, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=2, RightOperand=3, Operator="x", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=9, Operator="x", CorrectAnswer=54, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=5, Operator="x", CorrectAnswer=15, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=1, Operator="x", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=4, Operator="x", CorrectAnswer=24, Test=tests.Single(i => i.TestName == "Multiplication")}, //30

                new Question{LeftOperand=7, RightOperand=7, Operator="x", CorrectAnswer=49, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=2, RightOperand=9, Operator="x", CorrectAnswer=18, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=5, Operator="x", CorrectAnswer=30, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=8, Operator="x", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=4, Operator="x", CorrectAnswer=36, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=6, Operator="x", CorrectAnswer=18, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=9, Operator="x", CorrectAnswer=63, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=6, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=8, Operator="x", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=2, Operator="x", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Multiplication")}, //40

                new Question{LeftOperand=4, RightOperand=9, Operator="x", CorrectAnswer=36, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=1, Operator="x", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=0, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=8, Operator="x", CorrectAnswer=24, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=5, Operator="x", CorrectAnswer=35, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=2, RightOperand=4, Operator="x", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=9, Operator="x", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=3, Operator="x", CorrectAnswer=15, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=0, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=4, Operator="x", CorrectAnswer=16, Test=tests.Single(i => i.TestName == "Multiplication")}, //50

                new Question{LeftOperand=4, RightOperand=3, Operator="x", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=8, Operator="x", CorrectAnswer=56, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=2, RightOperand=1, Operator="x", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=4, Operator="x", CorrectAnswer=20, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=6, Operator="x", CorrectAnswer=36, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=0, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=3, Operator="x", CorrectAnswer=21, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=0, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=6, Operator="x", CorrectAnswer=48, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=3, Operator="x", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Multiplication")}, //60

                new Question{LeftOperand=2, RightOperand=7, Operator="x", CorrectAnswer=14, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=0, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=9, Operator="x", CorrectAnswer=81, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=7, Operator="x", CorrectAnswer=42, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=3, Operator="x", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=5, Operator="x", CorrectAnswer=20, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=8, Operator="x", CorrectAnswer=24, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=1, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=3, Operator="x", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=2, Operator="x", CorrectAnswer=14, Test=tests.Single(i => i.TestName == "Multiplication")}, //70

                new Question{LeftOperand=3, RightOperand=9, Operator="x", CorrectAnswer=27, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=8, Operator="x", CorrectAnswer=32, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=2, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=8, Operator="x", CorrectAnswer=40, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=6, Operator="x", CorrectAnswer=42, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=6, Operator="x", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=5, Operator="x", CorrectAnswer=25, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=2, RightOperand=2, Operator="x", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=8, Operator="x", CorrectAnswer=48, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=1, Operator="x", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Multiplication")}, //80

                new Question{LeftOperand=2, RightOperand=8, Operator="x", CorrectAnswer=16, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=7, Operator="x", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=8, Operator="x", CorrectAnswer=72, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=6, Operator="x", CorrectAnswer=24, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=8, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=3, Operator="x", CorrectAnswer=21, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=0, RightOperand=9, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=6, Operator="x", CorrectAnswer=30, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=2, Operator="x", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=4, RightOperand=0, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")}, //90

                new Question{LeftOperand=0, RightOperand=1, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=9, RightOperand=1, Operator="x", CorrectAnswer=56, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=3, RightOperand=1, Operator="x", CorrectAnswer=12, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=7, RightOperand=1, Operator="x", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=2, RightOperand=1, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=1, Operator="x", CorrectAnswer=35, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=6, RightOperand=1, Operator="x", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=1, RightOperand=1, Operator="x", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=1, Operator="x", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Multiplication")},
                new Question{LeftOperand=5, RightOperand=1, Operator="x", CorrectAnswer=45, Test=tests.Single(i => i.TestName == "Multiplication")}, //100

                //divison
                new Question{LeftOperand=18, RightOperand=9, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=16, RightOperand=8, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=7, RightOperand=7, Operator="÷", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=60, RightOperand=6, Operator="÷", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=20, RightOperand=5, Operator="÷", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=16, RightOperand=4, Operator="÷", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=5, RightOperand=5, Operator="÷", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=18, RightOperand=6, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=28, RightOperand=7, Operator="÷", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=100, RightOperand=10, Operator="÷", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Division")}, //10

                new Question{LeftOperand=12, RightOperand=3, Operator="÷", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=54, RightOperand=9, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=48, RightOperand=8, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=35, RightOperand=7, Operator="÷", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=12, RightOperand=6, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=30, RightOperand=5, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=28, RightOperand=4, Operator="÷", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=10, RightOperand=5, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=36, RightOperand=6, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=21, RightOperand=7, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")}, //20

                new Question{LeftOperand=8, RightOperand=4, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=3, RightOperand=3, Operator="÷", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=72, RightOperand=9, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=72, RightOperand=8, Operator="÷", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=14, RightOperand=7, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=54, RightOperand=6, Operator="÷", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=45, RightOperand=5, Operator="÷", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=20, RightOperand=4, Operator="÷", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=50, RightOperand=5, Operator="÷", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=48, RightOperand=6, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")}, //30

                new Question{LeftOperand=6, RightOperand=2, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=12, RightOperand=4, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=9, RightOperand=3, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=27, RightOperand=9, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=64, RightOperand=8, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=63, RightOperand=7, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=30, RightOperand=6, Operator="÷", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=15, RightOperand=5, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=36, RightOperand=4, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=40, RightOperand=5, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")}, //40

                new Question{LeftOperand=3, RightOperand=1, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=4, RightOperand=2, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=40, RightOperand=4, Operator="÷", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=30, RightOperand=3, Operator="÷", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=81, RightOperand=9, Operator="÷", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=32, RightOperand=8, Operator="÷", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=70, RightOperand=7, Operator="÷", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=48, RightOperand=6, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=35, RightOperand=5, Operator="÷", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=24, RightOperand=4, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")}, //50

                new Question{LeftOperand=27, RightOperand=3, Operator="÷", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=4, RightOperand=2, Operator="÷", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=2, RightOperand=2, Operator="÷", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=32, RightOperand=4, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=15, RightOperand=3, Operator="÷", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=36, RightOperand=9, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=0, RightOperand=8, Operator="÷", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=42, RightOperand=7, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=24, RightOperand=6, Operator="÷", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=10, RightOperand=5, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")}, //60

                new Question{LeftOperand=8, RightOperand=8, Operator="÷", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=18, RightOperand=3, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=7, RightOperand=1, Operator="÷", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=8, RightOperand=2, Operator="÷", CorrectAnswer=4, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=12, RightOperand=4, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=27, RightOperand=3, Operator="÷", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=18, RightOperand=9, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=40, RightOperand=8, Operator="÷", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=56, RightOperand=7, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=42, RightOperand=6, Operator="÷", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Division")}, //70

                new Question{LeftOperand=18, RightOperand=2, Operator="÷", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=56, RightOperand=8, Operator="÷", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=30, RightOperand=3, Operator="÷", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=5, RightOperand=1, Operator="÷", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=10, RightOperand=2, Operator="÷", CorrectAnswer=5, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=36, RightOperand=4, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=18, RightOperand=3, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=9, RightOperand=9, Operator="÷", CorrectAnswer=1, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=80, RightOperand=8, Operator="÷", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=49, RightOperand=7, Operator="÷", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Division")}, //80

                new Question{LeftOperand=60, RightOperand=10, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=20, RightOperand=2, Operator="÷", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=72, RightOperand=8, Operator="÷", CorrectAnswer=9, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=21, RightOperand=3, Operator="÷", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=6, RightOperand=1, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=16, RightOperand=2, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=24, RightOperand=4, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=21, RightOperand=3, Operator="÷", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=18, RightOperand=9, Operator="÷", CorrectAnswer=2, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=24, RightOperand=8, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")}, //90

                new Question{LeftOperand=80, RightOperand=10, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=30, RightOperand=10, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=0, RightOperand=2, Operator="÷", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=48, RightOperand=8, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=0, RightOperand=3, Operator="÷", CorrectAnswer=0, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=8, RightOperand=1, Operator="÷", CorrectAnswer=8, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=12, RightOperand=2, Operator="÷", CorrectAnswer=7, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=28, RightOperand=4, Operator="÷", CorrectAnswer=6, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=9, RightOperand=3, Operator="÷", CorrectAnswer=3, Test=tests.Single(i => i.TestName == "Division")},
                new Question{LeftOperand=90, RightOperand=9, Operator="÷", CorrectAnswer=10, Test=tests.Single(i => i.TestName == "Division")}, //100

            };
            questions.ForEach(q => context.Questions.AddOrUpdate(q));
            context.SaveChanges();
        }
    }
}
