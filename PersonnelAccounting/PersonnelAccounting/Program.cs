using System;

namespace PersonnelAccounting
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandOutputAllDossiers = "2";
            const string CommandDeleteDossier = "3";
            const string CommandSearchSurnames = "4";
            const string CommandExit = "5";

            bool isWork = true;

            string userInput;
            string[] fullNames = new string[] { "Иванов Иван Иванович", "Петров Петр Петрович", "Карлов Карл Карлович" };
            string[] positions = new string[] { "Актер", "Художник", "Музыкант" };

            while (isWork)
            {
                Console.WriteLine("Выберите пункт меню");
                Console.WriteLine($"{CommandAddDossier} Добавить досье");
                Console.WriteLine($"{CommandOutputAllDossiers} Вывести все досье");
                Console.WriteLine($"{CommandDeleteDossier} Удалить досье");
                Console.WriteLine($"{CommandSearchSurnames} Поиск по фамилии");
                Console.WriteLine($"{CommandExit} Выход");

                userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddDossier(ref fullNames, ref positions);
                        break;

                    case CommandOutputAllDossiers:
                        OutputAllDossiers(fullNames, positions);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(ref fullNames, ref positions);
                        break;

                    case CommandSearchSurnames:
                        SearchSurnames(fullNames, positions);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }

                Console.WriteLine("\n");
            }
        }

        private static void AddDossier(ref string[] fullNamesArray, ref string[] positionsArray)
        {
            Console.WriteLine("Введите ФИО");
            string inputName = Console.ReadLine();

            Console.WriteLine("Должность");
            string inputPost = Console.ReadLine();

            fullNamesArray = EnlargeArray(fullNamesArray, inputName);
            positionsArray = EnlargeArray(positionsArray, inputPost);
        }

        private static void OutputAllDossiers(string[] fullNamesArray, string[] positionsArray)
        {
            for (int i = 0; i < fullNamesArray.Length; i++)
            {
                int number = 1;
                int dossierNumber = i + number;    

                Console.WriteLine($"{dossierNumber} {fullNamesArray[i]} {positionsArray[i]}");  
            }
        }

        private static void DeleteDossier(ref string[] fullNamesArray, ref string[] positionsArray)
        {
            Console.WriteLine("Введите номер досье которое хотите удалить");
            int.TryParse(Console.ReadLine(), out int element);

            if (element <= 0 || element > fullNamesArray.Length)
            {
                Console.WriteLine("Данные не верны");
            }
            else
            {
                fullNamesArray = ReduceArray(fullNamesArray, element - 1);
                positionsArray = ReduceArray(positionsArray, element - 1);
            }
        }

        private static void SearchSurnames(string[] fullNamesArray, string[] positionsArray)
        {
            char whitespace = ' ';

            bool isSurnameFound = false;

            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();

            for (int i = 0; i < fullNamesArray.Length; i++)
            {
                string[] splitArray = fullNamesArray[i].Split(whitespace);

                for (int j = 0; j < splitArray.Length; j++)
                {
                    if (splitArray[0].ToLower() == surname.ToLower())
                    {
                        int number = 1;
                        int dossierNumber = i + number;

                        Console.WriteLine($"[{dossierNumber}] Full name: [{fullNamesArray[i]}] Post: [{positionsArray[i]}]");

                        isSurnameFound = true;
                        break;
                    }
                }

            }

            if (isSurnameFound == false)
            {
                Console.WriteLine("Фамилия не найдена");
            }
        }

        private static string[] EnlargeArray(string[] array, string newSize)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[array.Length] = newSize;
            array = tempArray;

            return array;
        }

        private static string[] ReduceArray(string[] array, int element)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < element; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = element; i < array.Length - 1; i++)
            {
                tempArray[i] = array[i + 1];
            }

            array = tempArray;
            return array;
        }
    }
}
