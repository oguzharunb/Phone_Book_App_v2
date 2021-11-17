using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Phone_Book_App_v2
{
    /*
     PROJE-1 : Console Telefon Rehberi Uygulaması


Yeni bir console uygulaması açarak telefon rehberi uygulaması yazınız. Uygulamada olması gereken özellikler aşağıdaki gibidir.

Telefon Numarası Kaydet
Telefon Numarası Sil
Telefon Numarası Güncelle
Rehber Listeleme (A-Z, Z-A seçimli)
Rehberde Arama

Açıklama:

Başlangıç olarak 5 kişinin numarasını varsayılan olarak ekleyiniz.

Uygulama ilk başladığında kullanıcıya yapmak istediği işlem seçtirilir.

  Lütfen yapmak istediğiniz işlemi seçiniz :) 
  *******************************************
  (1) Yeni Numara Kaydetmek
  (2) Varolan Numarayı Silmek
  (3) Varolan Numarayı Güncelleme
  (4) Rehberi Listelemek
  (5) Rehberde Arama Yapmak﻿

(1) Yeni Numara Kaydetmek

 Lütfen isim giriniz             : 
 Lütfen soyisim giriniz          :
 Lütfen telefon numarası giriniz :
(2) Var olan Numarayı Silmek

İsim ve soy isime göre arama yapılması yeterlidir.

  Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:

Kullanıcıdan alınan girdi doğrultusunda rehberde bir kişi bulunamazsa:

  Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.
  * Silmeyi sonlandırmak için : (1)
  * Yeniden denemek için      : (2)

Rehberde uygun veri bulunursa:

  {} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)
Not: Rehber uygun kriterlere uygun birden fazla kişi bulunursa ilk bulunan silinmeli.

(3) Varolan Numarayı Güncelleme

 Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:

Kullanıcıdan alınan girdi doğrultusunda rehberde bir kişi bulunamazsa:

 Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.
 * Güncellemeyi sonlandırmak için    : (1)
 * Yeniden denemek için              : (2)

Rehberde uygun veri bulunursa güncelleme işlemi gerçekleştirilir.

Not: Rehber uygun kriterlere uygun birden fazla kişi bulunursa ilk bulunan silinmeli.

(4) Rehberi Listelemek

Tüm rehber aşağıdaki formatta console'a listelenir.

  Telefon Rehberi
  **********************************************
  isim: {}
  Soyisim: {}
  Telefon Numarası: {}
  - 
  isim: {}
  Soyisim: {}
  Telefon Numarası: {}
  .
  .

(5) Rehberde Arama Yapmak


 Arama yapmak istediğiniz tipi seçiniz.
 **********************************************
 
 İsim veya soyisime göre arama yapmak için: (1)
 Telefon numarasına göre arama yapmak için: (2)


Arama sonucuna göre bulunan veriler aşağıdaki formatta gösterilmeli.



 Arama Sonuçlarınız:
 **********************************************
 isim: {}
 Soyisim: {}
 Telefon Numarası: {}
 - 
 isim: {}
 Soyisim: {}
 Telefon Numarası: {}
 .
 .


** Her bir feature ayrı class/method kullanarak yapılmalıdır. Mümkün olduğunca sorumlulukları parçalanmalı ve kod okunabilir olmalıdır.
     */

    public class App
    {

        Tools tools = new Tools();
        List<Person> Persons = new List<Person>();


        public void Application()
        {
            EnterFakePerson();
            Menu();
        }

        public void Menu()
        {

            while (true)
            {
                Persons = Persons.OrderBy(item => item.fullName).ToList();

                Console.WriteLine("to Register a Person(r)");
                Console.WriteLine("to Delete a Person(d)");
                Console.WriteLine("to Update a Person (u)");
                Console.WriteLine("to See Full List A-Z(a)");
                Console.WriteLine("to See Full List Z-A(z)");
                Console.WriteLine("to See Filtered List (f)");
                Console.WriteLine("to Exit(x)");
                Console.WriteLine();
                
                tryagain:
                Console.Write("what is your choose?: ");
                string choose = Console.ReadLine();
                switch (choose)
                {

                    case "r":
                        RegisterPerson();
                        Console.Clear();
                        break;
                    case "d":
                        DeletePerson();
                        Console.Clear();
                        break;
                    case "a":
                        ShowListA_Z(Persons);
                        goto tryagain;
                    case "z":
                        ShowListZ_A(Persons);
                        goto tryagain;
                    case "u":
                        UpDatePersons();
                        break;
                    case "f":
                        FilteredList();
                        break;
                    case "x":
                        tools.Loading("exiting", "exited", 2, 300);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("invalid input, please try again");
                        goto tryagain;
                }

            }
        
        }

        static void SeeMain()
        {
            Console.WriteLine("to Register a Person(r)");
            Console.WriteLine("to Delete a Person(d)");
            Console.WriteLine("to Update a Person (u)");
            Console.WriteLine("to See Full List A-Z(a)");
            Console.WriteLine("to See Full List Z-A(z)");
            Console.WriteLine("to See Filtered List (f)");
            Console.WriteLine("to Exit(x)");
            Console.WriteLine();
        }

        public void RegisterPerson()
        {

            string firstname = tools.takeString("Please Enter First Name: ");
            string lastname = tools.takeString("Please Enter Last Name: ");
            string phonenumber = tools.TakeAPhoneNumber("Plese Enter Phone Number(this format: XXX XXX XXXX):");
            GENDER gender = tools.takeGender();

            tools.Loading("loading", "successfully loaded", 2, 300);

            Persons.Add(new Person(firstname, lastname, phonenumber, gender));

        }

        public void DeletePerson()
        {

            if (Persons.Count == 0)
            {
                Console.WriteLine("no person to be delete");
            }

            string wanted;

            List<Person> list = new List<Person>();
            while (true)
            {
                Console.Write("Please enter the name or surname of the person you want to delete: ");
                wanted = Console.ReadLine().ToLower();
                list = Persons.Where(b => b.fullName.ToLower().IndexOf(wanted) > -1).ToList();

                if (list.Count == 0)
                {
                    Console.WriteLine("There is no such a person, please try again.");
                    continue;
                }

                list = list.OrderBy(b => b.fullName).ToList();
                ShowList(list);
                break;
            }

            if (list.Count == 1)
            {

                Console.Write($"There is only one person named \"{wanted}\", would you like to delete it?(y)(n) :");
                string choose = Console.ReadLine().ToLower();

                if (choose == "y")
                {
                    Persons.Remove(list[0]);
                    tools.Loading("deleting", "successfully deleted", 2, 300);
                    Console.Clear();
                    return;
                }
                // :
                Console.WriteLine("no one has been deleted from the list");
                tools.Loading("exiting", "successfully exited", 2, 300);

                Console.Clear();
                return;

            }


            while (true)
            {

                Console.Write("Please enter the order number of the person you want to delete: ");
                try
                {

                    int choose = int.Parse(Console.ReadLine());

                    Person tbdperson = list[choose - 1];

                    Console.WriteLine($"Are you sure you want to delete the {tbdperson.fullName} contact? (y, n): ");
                   
                    if (Console.ReadLine().ToLower().Trim() == "y")
                    {
                        tools.Loading("deleting", "successfully deleted", 2, 300);

                        Persons.Remove(tbdperson);
                        return;
                    }

                    tools.Loading("exiting","successfully exited",2,300);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("invalid input. please try again.");
                    continue;
                }
            }

        }

        public void UpDatePersons()
        {
            //liste
            //lütfen güncellemek istediğiniz kişinin sıra numarasını giriniz:
            //geçersiz numara 
            //güncellemeden çık(x)
            //try again (t)
            // {fullname} kişisini güncellemek istediğinize emin misiniz (y,n)
            //ismi güncelle (y,n) {fullname} => console.readline();
            //telefon güncelle güncelle (y,n) {fullname} => console.readline();
            //cinsiyet güncelle (y,n) {fullname} => console.readline();
            //new LastName
            //new phoneNumber
            //new gender
            //Kişi başarıyla güncellendi
            //

            ShowListA_Z(Persons);
            
        tryagainorder:
            Console.WriteLine();
            Console.Write("please enter the order number of the person you want to update: ");

            string ordertxt = Console.ReadLine().Trim();
            int order;
            uint x;
            if (!uint.TryParse(ordertxt,out x))
            {
                Console.WriteLine("invalid input, please try again.");
                goto tryagainorder;
            }

            if (x > int.MaxValue || x == 0)
            {
                Console.WriteLine("invalid input, please try again.");
                goto tryagainorder;
            }

            if (uint.Parse(ordertxt) > Persons.Count)
            {
                Console.WriteLine("there is no one with this order number in the list");
                goto tryagainorder;
            }

            order = int.Parse(ordertxt) - 1;

            Console.Write($"Are you sure you want to update {Persons[order].fullName} (y, n): ");
            string choice = Console.ReadLine().Trim().ToLower();

            if (choice != "y")
            {
                tools.Loading("exiting","successfully exited",2,300);
                Console.Clear();
                return;
            }




            Console.Write("do you want to update first name (y, n): ");
            string namechoice = Console.ReadLine().Trim().ToLower();

            int counter = 0;

            if (namechoice == "y")
            {
                Persons[order].firstName = tools.takeString($"{Persons[order].firstName} => ");
                counter++;
            }

            
            Console.Write("do you want to update last name (y, n): ");
            string lastnamechoice = Console.ReadLine().Trim().ToLower();

            if (lastnamechoice == "y")
            {
                Persons[order].lastName = tools.takeString($"{Persons[order].lastName} => ");
                counter++;
            }

            if (counter != 0)
            {
                Persons[order].fullName = Persons[order].firstName + " " + Persons[order].lastName;
            }
            
            Console.Write("do you want to update phone number (y, n): ");
            string phonenumberchoice = Console.ReadLine().Trim().ToLower();

            if (phonenumberchoice == "y")
            {
                Persons[order].phoneNumber = tools.TakeAPhoneNumber($"{Persons[order].phoneNumber} => ");
                counter++;
            }
            
            
            Console.Write("do you want to update gender (y, n): ");
            string genderchoice = Console.ReadLine().Trim().ToLower();

            if (genderchoice == "y")
            {
                Persons[order].gender = tools.takeGender();
                counter++;
            }

            if (counter != 0)
            {
                tools.Loading("updating", "the person has been succesfully updated", 2, 300);
                Console.Clear();
                return;
            }

            Console.WriteLine("couldn't update the person");

        }

        public void ShowList(List<Person> theList)
        {

            Console.WriteLine();

            if (theList.Count == 0)
            {
                Console.WriteLine("There is no person this list");
                Console.WriteLine();
                return;
            }


            Console.WriteLine("order   " + "Fullname".PadRight(25) + "Phone Number".PadRight(15) + "Gender");
            Console.WriteLine("------------------------------------------------------------------");

            foreach (Person item in theList)
            {
                Console.WriteLine((theList.IndexOf(item) + 1).ToString().PadRight(8) + item.fullName.PadRight(25) + item.phoneNumber.PadRight(15) + item.gender);
            }
            Console.WriteLine();

        }

        public void ShowListA_Z(List<Person> list)
        {
            ShowList(list.OrderBy(item => item.fullName).ToList());
        }

        public void FilteredList()
        {
            //gender
            //namimg
            //a-z z-a

            List<Person> list = Persons;

            string desiredname;
            GENDER desiredgender;

            tryagain:
                Console.Write("enter name or sirname to be list: ");
                desiredname = Console.ReadLine().ToLower().Trim();

                if (tools.checkSpecialCharacter(desiredname) == true)
                {
                    Console.WriteLine("invalid input, please try again.");
                goto tryagain;
                }

            do
            {
                Console.WriteLine("male (m)");
                Console.WriteLine("female (f)");
                Console.WriteLine("doesn't matter (d)");
                Console.Write("input: ");
                string Strdesiredgender = Console.ReadLine().ToLower();

                switch (Strdesiredgender)
                {
                    case "m":
                        desiredgender = GENDER.MALE;
                        break;
                    case "f":
                        desiredgender = GENDER.FEMALE;
                        break;
                    case "d":
                        desiredgender = GENDER.Null;
                        break;
                    default:
                        Console.WriteLine("invalid input, please try again.");
                        continue;
                }

                break;

            } while (true);


            list = list.Where(item => item.fullName.ToLower().Contains(desiredname) == true).ToList();
           
            if (desiredgender != GENDER.Null)
            {
                list.Where(item => item.gender == desiredgender).ToList();
            }

            do
            {
                Console.WriteLine("Show List A-Z (a)");
                Console.WriteLine("Show List Z-A (z)");
                string a_z_z_a = Console.ReadLine().ToLower();

                switch (a_z_z_a)
                {
                    case "a":
                        tools.Loading("loading list","list loaded ",2,300);
                        ShowListA_Z(list);
                        break;
                    case "z":
                        ShowListZ_A(list);
                        break;
                    default:
                        Console.WriteLine("invalid input, please try again.");
                        continue;
                }
                break;

            } while (true);


        }

        public void ShowListZ_A(List<Person> list)
        {
            ShowList(list.OrderByDescending(item => item.fullName).ToList());
        }

        public void SearchOnDirectory()
        {

        }

        public void EnterFakePerson()
        {
            Persons.Add(new Person("Mustafa", "Ceceli", "123 456 7890", GENDER.MALE));
            Persons.Add(new Person("Acun", "Ilıcalı", "118 808 3434", GENDER.MALE));
            Persons.Add(new Person("Neşet", "Ertaş", "987 654 1223", GENDER.MALE));
        }


    }
}
