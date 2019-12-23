using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<int, ICollection<string>> students = new Dictionary<int, ICollection<string>>();

    public void Add(string student, int grade){
        students.TryGetValue(grade, out var gradeStudents);
        (gradeStudents ??= new List<string>()).Add(student);
        students[grade] = gradeStudents;
    }

    public IEnumerable<string> Roster() => students.Keys.OrderBy(key => key).SelectMany(Grade);

    public IEnumerable<string> Grade(int grade) => students.TryGetValue(grade, out var gradeStudents) ? 
        gradeStudents.OrderBy(student => student) : Enumerable.Empty<string>();
}
