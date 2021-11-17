using System;
using System.Collections.Generic;
using System.Text;

namespace Phone_Book_App_v2
{
    public class Tools
    {
        public void Loading(string load, string finish, int repeat, int time)
        {

            Console.WriteLine();

            for (int i = 0; i < repeat; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(load + "");
                System.Threading.Thread.Sleep(time);


                Console.Write(".");
                System.Threading.Thread.Sleep(time);


                Console.Write(".");
                System.Threading.Thread.Sleep(time);


                Console.Write(".");
                System.Threading.Thread.Sleep(time);


                Console.SetCursorPosition(load.Length, Console.CursorTop);
                Console.Write("   ");
                Console.SetCursorPosition(load.Length, Console.CursorTop);
            }

            for (int i = 0; i < load.Length; i++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(0, Console.CursorTop);

            Console.WriteLine(finish);
            System.Threading.Thread.Sleep(time * 2);

            Console.SetCursorPosition(0, Console.CursorTop);

            for (int i = 0; i < finish.Length; i++)
            {
                Console.Write(" ");
            }

        }

        public string TakeAPhoneNumber(string text)
        {

            string number;

        tryagain:
            Console.Write(text);
            number = Console.ReadLine().Trim();

            int x;

            if (number.Length != 12)
            {
                Console.WriteLine("invalid input, please try again");
                goto tryagain;
            }
           
            if (!int.TryParse(number.Substring(0, 3), out x))
            {
                Console.WriteLine("invalid input, please try again");
                goto tryagain;
            }

            if (!int.TryParse(number.Substring(4, 3), out x))
            {
                Console.WriteLine("invalid input, please try again");
                goto tryagain;
            }

            if (!int.TryParse(number.Substring(8, 4), out x))
            {
                Console.WriteLine("invalid input, please try again");
                goto tryagain;
            }

            if (number.Substring(3, 1) != " " && number.Substring(7, 1) != " ")
            {
                Console.WriteLine("invalid input, please try again");
                goto tryagain;
            }

            return number;
        }
        
        public string takeString(string text)
        {
            string data;

        tryagain:
            Console.Write(text);

            data = Console.ReadLine().Trim();

            if (data == "")                
            {
                Console.WriteLine("you didn't enter data. please try again.");
                goto tryagain;
            }

            if (data.IndexOf("  ") != -1)
            {
                Console.WriteLine("you used too many spaces. please try again.");
                goto tryagain;
            }

            if (checkSpecialCharacter(data))
            {
                Console.WriteLine("you used special character. please try again.");
                goto tryagain;
            }

            string[] datas = data.Split(" ");
            for (int i = 0; i < datas.Length; i++)
            {
                if (datas[i].Length == 1)
                {
                    Console.WriteLine("names must be at least two letters, please try again");
                    goto tryagain;
                }

                datas[i] = capitalizeFirstLetter(datas[i]);
            }

            data = string.Join(" ", datas);


            return data;

        }

        public string capitalizeFirstLetter(string text)
        {

            text = text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
            return text;
        }

        public bool checkSpecialCharacter(string data)
        {
            string number = "1234567890!^+-*/?*.,#%&:;()={}[]-_\"<>'\\~@|";

            for (int i = 0; i < number.Length; i++)
            {
                if (data.Contains(number[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public GENDER takeGender()
        {
            Console.WriteLine("for male (m) ");
            Console.WriteLine("for female (f) ");

        tryagain:
            Console.Write("please enter the gender: ");

            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "m":
                    return GENDER.MALE;
                case "f":
                    return GENDER.FEMALE;
                default:
                    Console.WriteLine("invalid input,please try again");
                    goto tryagain;
            }
        }

        public void deneme()
        {
            Console.WriteLine();
        }

    }

}

