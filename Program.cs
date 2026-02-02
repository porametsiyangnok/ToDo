using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        List<string> todos = new List<string>();

        while (true)
        {
            ShowMenu();
           int choice = ReadInt("Deine Wahl: ");


            switch (choice)
            {
                case 1:
                    AddTodo(todos);
                    break;
                case 2:
                    ShowTodos(todos);
                    break;
                case 3:
                    DeleteTodo(todos);
                    break;
                case 4: 
                    ClearTodos(todos);
                    break;
                case 0:
                    Console.WriteLine("Tschüss!");
                    return;
                default:
                    Console.WriteLine("Ungültige Auswahl.");
                    break;
            }

            Pause();
        }
    }

    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("==== TODO APP ====");
        Console.WriteLine("1 - Aufgabe hinzufügen");
        Console.WriteLine("2 - Aufgaben anzeigen");
        Console.WriteLine("3 - Aufgabe löschen");
        Console.WriteLine("4 - Alle Aufgabe löschen");
        Console.WriteLine("0 - Beenden");
        Console.WriteLine();
    }

    static void AddTodo(List<string> todos)
    {
        Console.Write("Neue Aufgabe: ");
        string task = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("Aufgabe darf nicht leer sein.");
            return;
        }

        todos.Add(task.Trim());
        Console.WriteLine("Aufgabe hinzugefügt.");
    }

    static void ShowTodos(List<string> todos)
    {
        Console.WriteLine("=== Aufgaben ===");

        if (todos.Count == 0)
        {
            Console.WriteLine("Keine Aufgaben vorhanden.");
            return;
        }

        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todos[i]}");
        }
    }

    static void DeleteTodo(List<string> todos)
    {
        if (todos.Count == 0)
        {
            Console.WriteLine("Keine Aufgaben zum Löschen.");
            return;
        }

        ShowTodos(todos);
        Console.WriteLine();
        int number = ReadInt("Welche Nummer löschen? ");

       

        int index = number - 1;

        if (index < 0 || index >= todos.Count)
        {
            Console.WriteLine("Diese Nummer existiert nicht.");
            return;
        }

        string removed = todos[index];
        todos.RemoveAt(index);

        Console.WriteLine($"Gelöscht: {removed}");
    }

    static void ClearTodos(List<string> todos)
    {
        if(todos.Count == 0)
        {
            Console.WriteLine("Keine Aufgaben vorhanden.");
            return;
        }

        Console.Write("Wirklich alle Aufgaben löschen? (j/n)");
        string answer = Console.ReadLine();

        if (answer != null && answer.Trim().ToLower() == "j")
        {
            todos.Clear();
            Console.WriteLine("Alle Aufgaben wurden gelöscht.");
        }
        else
        {
            Console.WriteLine("Abgebrochen");
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.Write("Drücke Enter zum Fortfahren...");
        Console.ReadLine();
    }
    static int ReadInt(string massage)
    {
        while (true)
        {
            Console.Write(massage);
            String input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            return value;

            Console.WriteLine("Bitte eine gültige Zahl eingeben.");
        }
    }
    
}
