using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public double Balance { get; set; }
}

class Program 
{
 
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
       
        while (true)
        {
            Console.WriteLine("1 - Yeni öğrenci ekle");
            Console.WriteLine("2 - Öğrenci bakiyesini görüntüle");
            Console.WriteLine("3 - Öğrenci bakiyesini güncelle");
            Console.WriteLine("4 - Çıkış");
            Console.Write("Seçenek: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent(students);
                    break;
                case 2:
                    ShowStudentBalances(students);
                    break;
                case 3:
                    UpdateStudentBalance(students);
                    break;
                case 4:
                    Console.WriteLine("Programdan çıkılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçenek. Tekrar deneyin.");
                    break;
            }
        }
    }

    static void AddStudent(List<Student> students)
    {
        Console.Write("Öğrenci adı: ");
        string name = Console.ReadLine();

        if (students.Any(student => student.Name == name))
        {
            Console.WriteLine("Bu isimde bir öğrenci zaten var. Farklı bir isim girin.");
            return;
        }

        Console.Write("Bakiye: ");
        double balance = double.Parse(Console.ReadLine());
        if (balance < 0)
        {
            Console.WriteLine("Bakiye negatif olamaz.");
        }
        else 
        { 
        students.Add(new Student {Name=name, Balance = balance });
        Console.WriteLine("Öğrenci başarıyla eklendi.");
        }
    }

    static void ShowStudentBalances(List<Student> students)
    {
        Console.WriteLine("Öğrenci Listesi:");
        foreach (var student in students)
        {
            Console.WriteLine($"Adı: {student.Name}, Bakiye: {student.Balance}");
        }
    }

    static void UpdateStudentBalance(List<Student> students)
    {
        double NewBalance = 0;
        Console.Write("Bakiyesini güncellemek istediğiniz öğrencinin adını girin: ");
        string name = Console.ReadLine();
        Student studentToUpdate = students.Find(s => s.Name == name);

        if (studentToUpdate != null)
        {
            Console.WriteLine("1- Para Ekle ");
            Console.WriteLine("2- Para Çıkar");
            Console.Write("Yapılacak işlemi seçiniz: ");
            int choice2 = int.Parse(Console.ReadLine());

            Console.WriteLine("İşlem miktarını giriniz: ");
            double amount = double.Parse(Console.ReadLine());
            if (choice2==1)
            {
                NewBalance = studentToUpdate.Balance + amount;
                studentToUpdate.Balance=NewBalance;
                Console.WriteLine($"Güncel bakiyeniz:, {NewBalance}");

            }
            if (choice2==2)
            {
                NewBalance = studentToUpdate.Balance - amount;
                studentToUpdate.Balance = NewBalance;
                Console.WriteLine($"Güncel bakiyeniz:, {NewBalance}");
                
            } 
        }
        else
        {
            Console.WriteLine("Öğrenci bulunamadı.");
        }
    }
}
