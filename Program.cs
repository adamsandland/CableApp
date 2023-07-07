using System;
using System.IO;

public class Program{
    static void Main(){
        Console.Clear();
        FileManager manager = new FileManager();
        manager.LoadSave("save.sav");
        manager.ReadFileList();
        foreach (var line in manager.GetFile())
        {
            Console.WriteLine(line);
        }
        
    }
}