using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
class Program
{
    static List<Tool> tools = new List<Tool>();
    static string filePath = "tools.json";
    static int nextId = 1;
    static void Main()
    {
        LoadTools();
        while (true)
        {
            Console.WriteLine("\n1. Dodaj urządzenie");
            Console.WriteLine("2. Aktualizuj urządzenie");
            Console.WriteLine("3. Usuń urządzenie");
            Console.WriteLine("4. Zapisz narzędzia");
            Console.WriteLine("5. Wyświetl pojedyncze narzędzie");
            Console.WriteLine("6. Wyświetl wszystkie narzędzia");
            Console.WriteLine("7. Wyjdź");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();
            if (choice == "1") AddTool();
            else if (choice == "2") UpdateTool();
            else if (choice == "3") RemoveTool();
            else if (choice == "4") SaveTools();
            else if (choice == "5") ShowSingleTool();
            else if (choice == "6") ShowAllTools();
            else if (choice == "7") break;
            else Console.WriteLine("Nieprawidłowa opcja!");
        }
    }
    static void AddTool()
    {
        Console.Write("Nazwa: ");
        string name = Console.ReadLine();
        Console.Write("Ilość: ");
        int quantity = int.Parse(Console.ReadLine());
        Console.Write("Cena: ");
        decimal price = decimal.Parse(Console.ReadLine());
        tools.Add(new Tool { Id = nextId++, Name = name, Quantity = quantity, Price = price });
        Console.WriteLine("Urządzenie dodane!");
    }
    static void UpdateTool()
    {
        Console.Write("Podaj ID urządzenia do aktualizacji: ");
        int id = int.Parse(Console.ReadLine());
        var tool = tools.Find(t => t.Id == id);
        if (tool == null)
        {
            Console.WriteLine("Nie znaleziono urządzenia!");
            return;
        }
        Console.Write("Nowa ilość: ");
        tool.Quantity = int.Parse(Console.ReadLine());
        Console.Write("Nowa cena: ");
        tool.Price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Urządzenie zaktualizowane!");
    }
    static void RemoveTool()
    {
        Console.Write("Podaj ID urządzenia do usunięcia: ");
        int id = int.Parse(Console.ReadLine());
        tools.RemoveAll(t => t.Id == id);
        Console.WriteLine("Urządzenie usunięte!");
    }
    static void SaveTools()
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(tools));
        Console.WriteLine("Narzędzia zapisane!");
    }
    static void ShowSingleTool()
    {
        Console.Write("Podaj ID urządzenia: ");
        int id = int.Parse(Console.ReadLine());
        var tool = tools.Find(t => t.Id == id);
        if (tool != null)
            Console.WriteLine($"Id: {tool.Id}, Nazwa: {tool.Name}, Ilość: {tool.Quantity}, Cena: {tool.Price}");
        else
            Console.WriteLine("Nie znaleziono urządzenia!");
    }
    static void ShowAllTools()
    {
        foreach (var tool in tools)
            Console.WriteLine($"Id: {tool.Id}, Nazwa: {tool.Name}, Ilość: {tool.Quantity}, Cena: {tool.Price}");
    }
    static void LoadTools()
    {
        if (File.Exists(filePath))
            tools = JsonSerializer.Deserialize<List<Tool>>(File.ReadAllText(filePath)) ?? new List<Tool>();
    }
}
class Tool
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
/****************************
nazwa funkcji: <AddTool>
informacje: <Funkcja pobiera dane od użytkownika i dodaje narzędzie do listy narzędzi>
autor:   <Mateusz Chwiałkowski 4D>
****************************/