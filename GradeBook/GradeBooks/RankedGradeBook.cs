﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires 5 students");
            }
            int threshold = (int)Math.Ceiling(Students.Count * 0.2); 
            var grades = Students.Select(s => s.AverageGrade).OrderByDescending(g => g).ToList();

            if (grades.IndexOf(averageGrade) < threshold)
                return 'A';
            else if (grades.IndexOf(averageGrade) < threshold * 2)
                return 'B';
            else if (grades.IndexOf(averageGrade) < threshold * 3)
                return 'C';
            else if (grades.IndexOf(averageGrade) < threshold * 4)
                return 'D';
            else
                return 'F';


        }
    }
   

}
