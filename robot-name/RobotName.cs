using System;
using System.Linq;
using System.Collections.Generic;

public class Robot
{
    private static HashSet<string> Names = new HashSet<string>();

    public string Name { get; set; }

    public Robot() => Reset();

    public void Reset(){
        
        var random = new Random();
        var name = new string("AA000".Select((c, index) => c += index < 2 ? (char)random.Next(0,26) : (char)random.Next(0,9)).ToArray());

        if(Names.Contains(name))
            Reset();
        else {
            Names.Add(name);
            this.Name = name;
        }
    }
}