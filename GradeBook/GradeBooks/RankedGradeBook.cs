using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
                throw new InvalidOperationException();

            var a = Students.Count / 5;
            var countHigherGrades = Students.FindAll(x => x.AverageGrade > averageGrade).Count;

            switch(countHigherGrades)
            {
                case var b when b < a:
                    return 'A';
                case var b when b < 2 * a:
                    return 'B';
                case var b when b < 3 * a:
                    return 'C';
                case var b when b < 4 * a:
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}