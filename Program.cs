using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

class ContactDeduplicator
{
    static void Main()
    {
        List<string> contacts = new List<string>();
        Console.WriteLine("Enter at least 15 contact names");

        while (contacts.Count < 15)
        {
            Console.Write($"Name {contacts.Count + 1}: ");
            string input = Console.ReadLine().Trim();

            if (!string.IsNullOrWhiteSpace(input))
            {
                contacts.Add(input);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        var distinctSortedContacts = contacts
            .Distinct(StringComparer.OrdinalIgnoreCase) 
            .Select(name => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower())) 
            .OrderBy(name => name) 
            .ToList();

        Console.WriteLine("\n Sorted Contact List:");
        foreach (var name in distinctSortedContacts)
        {
            Console.WriteLine(name);
        }
    }
}
