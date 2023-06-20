using System;
using System.Collections.Generic;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string name, string phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}

class ContactManagerApp
{
    static List<Contact> contactList = new List<Contact>();

    static void Main()
    {
        Console.WriteLine("Welcome to Contact Manager App!");

        bool continueManaging = true;

        while (continueManaging)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add a new contact");
            Console.WriteLine("2. View all contacts");
            Console.WriteLine("3. Search for a contact");
            Console.WriteLine("4. Delete a contact");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ViewContacts();
                    break;
                case "3":
                    SearchContact();
                    break;
                case "4":
                    DeleteContact();
                    break;
                case "5":
                    continueManaging = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("\nThank you for using the Contact Manager App!");
    }

    static void AddContact()
    {
        Console.Write("\nEnter the name of the contact: ");
        string name = Console.ReadLine();

        Console.Write("Enter the phone number of the contact: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter the email address of the contact: ");
        string email = Console.ReadLine();

        Contact contact = new Contact(name, phoneNumber, email);
        contactList.Add(contact);

        Console.WriteLine("\nContact added successfully.");
    }

    static void ViewContacts()
    {
        if (contactList.Count > 0)
        {
            Console.WriteLine("\nContact List:");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("\nThe contact list is empty.");
        }
    }

    static void SearchContact()
    {
        Console.Write("\nEnter the name of the contact you want to search for: ");
        string name = Console.ReadLine();

        bool contactFound = false;

        foreach (Contact contact in contactList)
        {
            if (contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nContact Details:");
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");

                contactFound = true;
                break;
            }
        }

        if (!contactFound)
        {
            Console.WriteLine("\nContact not found.");
        }
    }

    static void DeleteContact()
    {
        Console.Write("\nEnter the name of the contact you want to delete: ");
        string name = Console.ReadLine();

        bool contactFound = false;

        for (int i = 0; i < contactList.Count; i++)
        {
            if (contactList[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                contactList.RemoveAt(i);
                Console.WriteLine("\nContact deleted successfully.");
                contactFound = true;
                break;
            }
        }

        if (!contactFound)
        {
            Console.WriteLine("\nContact not found.");
        }
    }
}
