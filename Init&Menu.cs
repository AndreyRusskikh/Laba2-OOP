using Божуха_Лаб2_1_Руських_ПЗ_22_2;
using Божуха_Лаб2_2_Руських_ПЗ_22_2;

namespace Laba2_Alg
{
    internal class Init_Menu
    {
        public static int ReadInt(string message, Func<int, bool> validator)
        {
            int result;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out result) || !validator(result));
            return result;
        }
        public static void InitDefault_String_Int(ListNodeStudentWork<string> listNodeStudentWork, ListNodeTicketWork<int> listNodeTicketWork)
        {
            string student = "Frank Goya";
            string student2 = "Oliver Stoun";
            string student3 = "Francheska Findebair";
            string student4 = "Alehandro Sumery";
            string student5 = "Vinietta Nostrakini";
            string student6 = "Li Min Ho";
            string student7 = "Phineas de Ostalianno";
            string student8 = "Damian Moro";
            string student9 = "Anna de Travil";
            string student10 = "Kenny Jaks";
            string student11 = "Astoria Lomental";
            string student12 = "Adrian Kastolvano";

            int ticket = 1;
            int ticket2 = 2;
            int ticket3 = 3;
            int ticket4 = 4;
            int ticket5 = 5;
            int ticket6 = 6;
            int ticket7 = 7;
            int ticket8 = 8;
            int ticket9 = 9;
            int ticket10 = 10;
            int ticket11 = 11;
            int ticket12 = 12;

            listNodeStudentWork.Add(student, student2, student3, student4, student5, student6, student7, student8, student9, student10, student11, student12);
            listNodeTicketWork.Add(ticket, ticket2, ticket3, ticket4, ticket5, ticket6, ticket7, ticket8, ticket9, ticket10, ticket11, ticket12);
        }

        public static void ShowStandart()
        {
            NodeWork<int> list = new NodeWork<int>();

            list.Add(18);
            list.Add(5);
            list.Add(45);

            Console.WriteLine("\nOriginal list:");
            list.Display();

            list.AddToFront(4);
            list.AddToFront(2);
            Console.WriteLine("\nAdd to front");
            list.Display();

            list.InsertAfterNthNode(2, 100);
            Console.WriteLine("\nInsert after n-element");
            list.Display();

            list.MoveNodeByNPositions(4, 2);
            Console.WriteLine("\nMove element");
            list.Display();

            list.RemoveNthNode(1);
            Console.WriteLine("\nRemove n-element");
            list.Display();

            list.RemoveEveryNthNode(2);
            Console.WriteLine("\nList with every 2nd node removed:");
            list.Display();

            list.Sort(1);
            Console.WriteLine("\nSorted list (возрастание):");
            list.Display();

            list.Sort(2);
            Console.WriteLine("\nSorted list (убывание):");
            list.Display();

            NodeWork<int> copy = list.Copy();
            Console.WriteLine("\nCopy of the list:");
            copy.Display();

            NodeWork<int> list2 = new NodeWork<int>();
            list2.AddToFront(2);
            list2.AddToFront(5);
            list2.AddToFront(1);
            list2.AddToFront(8);
            Console.WriteLine("\nOriginal list:");
            list.Display();
            Console.WriteLine("\nSecond list:");
            list2.Display();

            NodeWork<int> concatenated = NodeWork<int>.Concatenate(list, list2);
            Console.WriteLine("\nConcatenated list:");
            concatenated.Display();

            NodeWork<int> commonElements = NodeWork<int>.GetCommonElements(list, list2);
            Console.WriteLine("\nCommon elements between the two lists:");
            commonElements.Display();


        }

        public static void ShowOnChoice(int choice, NodeWork<int> list)
        {


            if (choice == 2)
            {
                choice = ReadInt("Добавить в начало число:", x => x < 0 || x >= 0);

                list.AddToFront(choice);


            }
            else if (choice == 3)
            {
                choice = ReadInt("Добавить число:", x => x < 0 || x >= 0);
                int choice2 = ReadInt("На место:", x => x >= 0);
                list.InsertAfterNthNode(choice2, choice);

            }
            else if (choice == 4)
            {
                choice = ReadInt("Подвинить элемент со значением:", x => x < 0 || x >= 0);
                int choice2 = ReadInt("На:", x => x >= 0);
                list.MoveNodeByNPositions(choice, choice2);

            }
            else if (choice == 5)
            {
                choice = ReadInt("Удалить элемент с номером:", x => x >= 0);
                list.RemoveNthNode(choice);

            }
            else if (choice == 6)
            {
                choice = ReadInt("Удалить каждый элемент с номером кратным:", x => x >= 0);
                list.RemoveEveryNthNode(choice);

            }
            else if (choice == 7)
            {
                Console.WriteLine("\nОригинальный список:");
                list.Display();
                list.Sort(1);
                Console.WriteLine("\nОтсортированный список (возрастание):");
                list.Display();

            }
            else if (choice == 8)
            {
                Console.WriteLine("\nОригинальный список:");
                list.Display();
                list.Sort(2);
                Console.WriteLine("\nОтсортированный список (убывание):");
                list.Display();

            }
            else if (choice == 9)
            {
                NodeWork<int> copy = list.Copy();
                Console.WriteLine("\nСписок - копия");
                copy.Display();

            }
            else
            {
                list.Display();
            }
        }

        public static void ShowOnChoice2(int choice, NodeWork<int> list, NodeWork<int> list2)
        {

            if (list.Count == 0)
            {
                Console.WriteLine("В списке нет элементов. Добавьте элементы в первый список. Введите количество элементов:");
                int countEl = ReadInt("", x => x >= 0);
                int inside = 0;
                Console.WriteLine("Введите элементы:");
                for (int i = 0; i < countEl; i++)
                {
                    inside = Convert.ToInt32(Console.ReadLine());
                    list.Add(inside);
                }
            }
            if (list2.Count == 0)
            {
                Console.WriteLine("Добавьте элементы во второй список. Введите количество элементов:");
                int countEl = ReadInt("", x => x >= 0);
                int inside = 0;
                Console.WriteLine("Введите элементы:");
                for (int i = 0; i < countEl; i++)
                {
                    inside = Convert.ToInt32(Console.ReadLine());
                    list2.Add(inside);
                }
            }

            Console.WriteLine("\nOriginal list:");
            list.Display();
            Console.WriteLine("\nSecond list:");
            list2.Display();
            if (choice == 10)
            {
                NodeWork<int> concatenated = NodeWork<int>.Concatenate(list, list2);
                Console.WriteLine("\nConcatenated list:");
                concatenated.Display();
            }
            else
            {
                NodeWork<int> commonElements = NodeWork<int>.GetCommonElements(list, list2);
                Console.WriteLine("\nCommon elements between the two lists:");
                commonElements.Display();
            }

        }
        public static void PrintResult()
        {
            ListNodeStudentWork<string> stud = new ListNodeStudentWork<string>();
            ListNodeTicketWork<int> tick = new ListNodeTicketWork<int>();
            InitDefault_String_Int(stud, tick);

            int N = ReadInt("\nВведите число перерасчета N: ", x => x > 0);

            int K = ReadInt("Введите число перерасчета K: ", x => x > 0);


            var headStud = stud.headStud;
            var headTick = tick.headTick;
            var previousStud = headStud;
            var previousTick = headTick;

            while (headStud.Next != headStud)
            {
                for (var i = 0; i < N - 1; i++)
                {
                    previousStud = headStud;
                    headStud = headStud.Next;
                }

                for (int j = 0; j < K - 1; j++)
                {
                    previousTick = headTick;
                    headTick = headTick.Next;
                }
                Console.WriteLine($"Студент {headStud.Student} получил билет номер {headTick.Ticket}");
                previousStud.Next = headStud.Next;
                previousTick.Next = headTick.Next;

                headStud = previousStud.Next;
                headTick = previousTick.Next;

            }
            if (N != 1)
            {
                Console.WriteLine($"Студент {headStud.Student} получил билет номер {headTick.Ticket}");
            }
        }

        public static void PrintResult(ListNodeStudentWork<string> stud, ListNodeTicketWork<int> tick)
        {

            int N = ReadInt("Введите число перерасчета N: ", x => x > 0);

            int K = ReadInt("Введите число перерасчета K: ", x => x > 0);

            var headStud = stud.headStud;
            var headTick = tick.headTick;
            var previousStud = headStud;
            var previousTick = headTick;
            while (headStud.Next != headStud)
            {
                for (var i = 0; i < N - 1; i++)
                {
                    previousStud = headStud;
                    headStud = headStud.Next;
                }

                for (int j = 0; j < K - 1; j++)
                {
                    previousTick = headTick;
                    headTick = headTick.Next;
                }
                Console.WriteLine($"Студент {headStud.Student} получил билет номер {headTick.Ticket}");
                previousStud.Next = headStud.Next;
                previousTick.Next = headTick.Next;

            }
        }

        public static void Menu(NodeWork<int> list, NodeWork<int> list2)
        {
            int choice;

            while (true)
            {

                Console.WriteLine("1 - Показ стандартных функций работы со связным списком");
                Console.WriteLine("2 - Добавить в начало");
                Console.WriteLine("3 - Добавить после n-элемента");
                Console.WriteLine("4 - Подвинуть элемент на n - позиций");
                Console.WriteLine("5 - Удалить n - элемент");
                Console.WriteLine("6 - Удалить каждый n - элемент");
                Console.WriteLine("7 - Сортировать по возрастанию");
                Console.WriteLine("8 - Сортировать по убыванию");
                Console.WriteLine("9 - Копировать список");
                Console.WriteLine("10 - Склеивание двух списков");
                Console.WriteLine("11 - Общие элементы у двух списков");
                Console.WriteLine("12 - Вывести список");
                Console.WriteLine("13 - Очистить список");
                Console.WriteLine("14 - Вывод списка выпавших студентам билетов\n");


                choice = ReadInt("Выберите необходимое действие: ", x => x > 0 && x <= 14);
                switch (choice)
                {

                    case 1:
                        ShowStandart();
                        break;
                    case 2:
                        ShowOnChoice(2, list);
                        break;
                    case 3:
                        ShowOnChoice(3, list);
                        break;
                    case 4:
                        ShowOnChoice(4, list);
                        break;
                    case 5:
                        ShowOnChoice(5, list);
                        break;
                    case 6:
                        ShowOnChoice(6, list);
                        break;
                    case 7:
                        ShowOnChoice(7, list);
                        break;
                    case 8:
                        ShowOnChoice(8, list);
                        break;
                    case 9:
                        ShowOnChoice(9, list);
                        break;
                    case 10:
                        ShowOnChoice2(10, list, list2);
                        break;
                    case 11:
                        ShowOnChoice2(11, list, list2);
                        break;
                    case 12:
                        ShowOnChoice(12, list);
                        break;
                    case 13:
                        list.Clear();
                        list2.Clear();
                        break;
                    case 14:
                        PrintResult();
                        break;

                }


                Console.WriteLine("\nПродолжить работу?");
                Console.WriteLine("1 - Продолжить");
                Console.WriteLine("2 - Продолжить и очистить консоль");
                Console.WriteLine("3 - Завершение работы");
                choice = ReadInt("Выберите необходимое действие: ", x => x > 0 && x < 4);

                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        Console.Clear();
                        break;
                    case 3:
                        list.Clear();
                        list2.Clear();
                        return;
                }

            }

        }

    }
}
