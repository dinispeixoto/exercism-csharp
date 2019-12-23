using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private IDictionary<int, ICollection<string>> students = new SortedDictionary<int, ICollection<string>>();

    public void Add(string student, int grade){
        students.TryGetValue(grade, out var gradeStudents);
        (gradeStudents ??= new SortedSet<string>()).Add(student);
        students[grade] = gradeStudents;
    }

    public IEnumerable<string> Roster() => students.Keys.SelectMany(Grade);

    public IEnumerable<string> Grade(int grade) => students.TryGetValue(grade, out var gradeStudents) ? gradeStudents : Enumerable.Empty<string>();
}
