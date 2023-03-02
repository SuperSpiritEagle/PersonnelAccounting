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
            string[] lastFirstNamePatronymic = new string[] { "Иванов Иван Иванович", "Петров Петр Петрович", "Карлов Крал Карлович" };
            string[] post = new string[] { "Актер", "Художник", "Музыкант" };

            while (isWork)
            {
                Console.WriteLine("Выберите пункт меню");
                Console.WriteLine($"{CommandAddDossier} Добавить досье");
                Console.WriteLine($"{CommandOutputAllDossiers} Вывести все досье");
                Console.WriteLine($"{CommandDeleteDossier} Удалить досье");
                Console.WriteLine($"{CommandSearchSurnames} Поиск по фамилии");
                Console.WriteLine($"{CommandExit} Выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddDossier(ref lastFirstNamePatronymic, ref post);
                        break;
                    case CommandOutputAllDossiers:
                        OutputAllDossiers(ref lastFirstNamePatronymic, ref post);
                        break;
                    case CommandDeleteDossier:
                        DeleteDossier(ref lastFirstNamePatronymic, ref post);
                        break;
                    case CommandSearchSurnames:
                        SearchSurnames(ref lastFirstNamePatronymic, ref post);
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                }
            }
        }
        private static void AddDossier(ref string[] lastFirstNamePatronymicArray, ref string[] postArray)
        {
            Console.WriteLine("Введите ФИО");
            string inputName = Console.ReadLine();

            Console.WriteLine("Должность");
            string inputPost = Console.ReadLine();

            EnlargeArray(ref lastFirstNamePatronymicArray, inputName);
            EnlargeArray(ref postArray, inputPost);
        }
        private static void OutputAllDossiers(ref string[] lastFirstNamePatronymicArray, ref string[] postArray)
        {
            for (int i = 0; i < lastFirstNamePatronymicArray.Length; i++)
            {
                Console.WriteLine($"{i + 1} {lastFirstNamePatronymicArray[i]} {postArray[i]}");
            }
        }
        private static void DeleteDossier(ref string[] lastFirstNamePatronymicArray, ref string[] postArray)
        {
            Console.WriteLine("Введите номер досье которое хотите удалить");
            int.TryParse(Console.ReadLine(), out int element);

            ReduceArray(ref lastFirstNamePatronymicArray, element - 1);
            ReduceArray(ref postArray, element - 1);
        }
        private static void SearchSurnames(ref string[] lastFirstNamePatronymicArray, ref string[] postArray)
        {
            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();
            string searchResult = string.Empty;

            for (int i = 0; i < lastFirstNamePatronymicArray.Length; i++)
            {
                string[] splitArray = lastFirstNamePatronymicArray[i].Split(' ');

                for (int j = 0; j < splitArray.Length; j++)
                {
                    if (splitArray[j] == surname)
                    {
                        searchResult = $"{i + 1} {lastFirstNamePatronymicArray[i]} {postArray[i]}";
                        break;
                    }
                }
            }

            Console.WriteLine(searchResult);
        }
        private static void EnlargeArray(ref string[] array, string newSize)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[array.Length] = newSize;
            array = tempArray;
        }
        private static void ReduceArray(ref string[] array, int element)
        {
            for (int i = element; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize(ref array, array.Length - 1);
        }
    }
}
