using System;

namespace ReferanceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //stack
            int sayi1 = 10;
            int sayi2 = 20;

            sayi1 = sayi2;
            sayi2 = 100;

            /*
            sayi1 ne olur?
            sayı1 20 olur.Bunun sebebi value type(değer tip) olmasıdır.Stack'te yer alır. (int, double, float, bool vs.)
            stackteki değişkenler o değişkene verilen değerleri tutar.
            Değer tiplerde atama bir başka değer ataması ise önceki değer yerine yeni değer geçer. Anlık değer ile ilgilenir ve yukarıdan aşağıya ilerlediği için
            bu örnekte sayı 2 ye yapılan değişiklik sayı1 = sayı2 satırında değişiklik olmaz.
            */
            
            Console.WriteLine("Sayı 1: "+sayi1);
            
            //Heap
            int[] sayilar1 = new int[] { 1, 2, 3 };
            int[] sayilar2 = new int[] { 10, 20, 30 };

            sayilar1 = sayilar2;

            sayilar2[0] = 1000;
            
            /*
            sayilar1[0] değeri ne olur
            Heap'te durumlar stacke göre farklıdır. heap'te değerin kendisi değil, o değerin tutulduğu bellek adresi kayıtlıdır.
            yukarıdaki işlmede sayilar1 = sayilar2 atamasında sayılar1'in tuttuğu adres değişir. Bu durumda sayilar2[0]=1000 ataması sayilar2'nin adresindeki verileri
            değiştieceğinden otomatik olarak sayilar2'deki veriler de değişir. Sonuç olarak aşağıdaki çıktının cevabı 1000 olur.
            heap grubuna array,class interface vs. dahildir.
            //Veri eşitlemesi değil adres eşitlemesi yapılıyor.
            */
            Console.WriteLine("Sayılar1[0] değeri: " + sayilar1[0]);
            
            //Class Heap örneği
            Person person1 = new Person();
            Person person2 = new Person();

            person1.FirstName = "Engin";
            person2 = person1;
            person1.FirstName = "Derin";
            Console.WriteLine(person2.FirstName);


            Customer customer = new Customer();
            customer.FirstName = "Cem";
            customer.CreditCardNumber = "1234567890";
            Employee employee = new Employee();
            employee.FirstName = "Mehmet";

            //customer kalıtım olarak parent'ı person olduğu için teknik olarak customer da bir person'dur. custumer'ın person'dan sadece Credit Card Number 'ı vardır.
            //customerlar child olduğu id, firtname ve lastname özellikleini görür ama parent child'ın özelliklerini göremez.
            Person person3 = customer;

            Console.WriteLine(person3.FirstName);

            //boxing -- person3 'ü customer gibi gör 
            Console.WriteLine(((Customer)person3).CreditCardNumber);

            //Person istese bile employee da bir person olduğu için customer ve employee de gönderilebilir.
            PersonManager personManager = new PersonManager();
            personManager.Add(employee);

        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Customer:Person
    {
        public string CreditCardNumber { get; set; }
    }

    class Employee:Person
    {
        public int EmployeeNumber { get; set; }
    }

    class PersonManager
    {
        public void Add(Person person)
        {
            //parametre olarak customer veya employee göndermemenin sebebi sadece o türler için çalışabilecek olmasıdır. En tepede kim varsa onu yazmak mantıkldıır.
            Console.WriteLine(person.FirstName);
        }
    }
}
