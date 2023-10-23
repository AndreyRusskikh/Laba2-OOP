using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace Божуха_Лаб2_1_Руських_ПЗ_22_2
{
    public class ListNode<T>
    {
        public T Data { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class NodeWork<T>
    {
        private ListNode<T> head;
        private int count;

        internal int Count
        {
            get { return count; }
            private set { count = value; }
        }

        public NodeWork()
        {
            head = null;
            Count = 0;
        }

        public void Add(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data);
            var current = head;
            if (head == null)
            {
                head = newNode;
                newNode.Next = null;
                Count++;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Next = null;
                Count++;
            }
        }

        // Функція додавання елементу в початок списку
        public void AddToFront(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data);
            newNode.Next = head;
            head = newNode;
            Count++;
        }

        // Функція вставлення елементу після n-го елементу списку
        public void InsertAfterNthNode(int n, T data)
        {
            if (n < 0 || n >= Count)
            {
                Console.WriteLine("Невозможно добавить на такую позицию - выход за пределы списка");
                return;
            }

            ListNode<T> newNode = new ListNode<T>(data);
            if (n == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                ListNode<T> current = head;
                for (int i = 0; i < n; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            Count++;
        }

        // Функція пересування елемента на n позицій
        public void MoveNodeByNPositions(T value, int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("Невозможно переместить на нулевое или отрицательное количество позиций.");
                return;
            }
            if (n > Count)
            {
                Console.WriteLine("Недостаточно элементов для перемещения");
                return;
            }

            ListNode<T> current = head;
            ListNode<T> prev = null;
            int count = 0;

            while (current != null && count < n)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, value))
                {
                    // Нашли узел
                    ListNode<T> next = current.Next;
                    if (prev != null)
                    {
                        prev.Next = next;
                    }
                    else
                    {
                        // Если элемент находится в голове, обновляем head
                        head = next;
                    }
                    current.Next = null;

                    // Вставляем узел после n позиций
                    ListNode<T> afterN = head;
                    for (int i = 0; i < n; i++)
                    {
                        if (afterN == null)
                        {
                            break;
                        }
                        afterN = afterN.Next;
                    }

                    if (afterN != null)
                    {
                        current.Next = afterN.Next;
                        afterN.Next = current;
                    }

                    return;
                }

                prev = current;
                current = current.Next;
                count++;
            }

            Console.WriteLine("Узел с таким значением не найден или недостаточно элементов для перемещения.");
        }



        // Функція видалення n-го елементу зі списку
        public void RemoveNthNode(int n)
        {
            if (n < 0 || n >= Count)
            {
                Console.WriteLine("Невозможно удалить такой элемент - выход за пределы списка");
                return;

            }

            if (n == 0)
            {
                head = head.Next;
            }
            else
            {
                ListNode<T> current = head;
                ListNode<T> prev = null;
                for (int i = 0; i < n; i++)
                {
                    prev = current;
                    current = current.Next;
                }
                prev.Next = current.Next;
            }
            Count--;
        }

        // Функція видалення кожного n-го елементу зі списку
        public void RemoveEveryNthNode(int n)
        {
            if (n >= Count)
            {
                Console.WriteLine("Число выходит за пределы списка - элементы не будут затронуты");
                return;
            }
            if (n == 1)
            {
                Clear(); // Если n = 1, просто очистите весь список
            }
            else
            {
                ListNode<T> current = head;
                ListNode<T> prev = null;
                int index = 1; // Инициализируем индекс как 1 (первый элемент)

                while (current != null)
                {
                    if (index % n == 0) // Проверка, является ли текущий элемент n-м элементом
                    {
                        if (prev == null)
                        {
                            head = current.Next;
                        }
                        else
                        {
                            prev.Next = current.Next;
                        }
                        Count--;
                    }
                    prev = current;
                    current = current.Next;
                    index++;
                }
            }
        }


        // Функція впорядкування елементів в списку за зростанням (спаданням)

        public void Sort(int choice)
        {
            if (Count < 2)
            {
                return; // Сортировка не требуется
            }

            bool swapped;
            if (choice == 1)
            {
                do
                {
                    swapped = false;
                    ListNode<T> current = head;
                    ListNode<T> previous = null;
                    while (current != null && current.Next != null)
                    {
                        if (Comparer<T>.Default.Compare(current.Data, current.Next.Data) > 0)
                        {
                            // Меняем местами значения
                            T temp = current.Data;
                            current.Data = current.Next.Data;
                            current.Next.Data = temp;

                            swapped = true;
                        }
                        previous = current;
                        current = current.Next;
                    }
                } while (swapped);
            }
            else 
            {
                do
                {
                    swapped = false;
                    ListNode<T> current = head;
                    ListNode<T> previous = null;
                    while (current != null && current.Next != null)
                    {
                        if (Comparer<T>.Default.Compare(current.Data, current.Next.Data) < 0)
                        {
                            // Меняем местами значения
                            T temp = current.Data;
                            current.Data = current.Next.Data;
                            current.Next.Data = temp;

                            swapped = true;
                        }
                        previous = current;
                        current = current.Next;
                    }
                } while (swapped);
            }
        }

        
        // Функція створення копії списку
        public NodeWork<T> Copy()
        {
            NodeWork<T> copy = new NodeWork<T>();
            ListNode<T> current = head;
            while (current != null)
            {
                copy.Add(current.Data); // Добавить элемент в конец нового списка
                current = current.Next;
            }
            return copy;
        }


        public void Clear()
        {
            head = null;
            Count = 0;
        }

        // Функція склеювання двох списків
        public static NodeWork<T> Concatenate(NodeWork<T> list1, NodeWork<T> list2)
        {
            NodeWork<T> result = new NodeWork<T>();
            ListNode<T> current = list1.head;
            while (current != null)
            {
                result.AddToFront(current.Data);
                current = current.Next;
            }
            current = list2.head;
            while (current != null)
            {
                result.AddToFront(current.Data);
                current = current.Next;
            }
            return result;
        }

        // Функція створення списку, який містить спільні елементи двох списків
        public static NodeWork<T> GetCommonElements(NodeWork<T> list1, NodeWork<T> list2)
        {
            NodeWork<T> result = new NodeWork<T>();

            ListNode<T> current1 = list1.head;

            while (current1 != null)
            {
                ListNode<T> current2 = list2.head;
                while (current2 != null)
                {
                    if (EqualityComparer<T>.Default.Equals(current1.Data, current2.Data))
                    {
                        result.AddToFront(current1.Data);
                        break;  // Общий элемент найден, переходим к следующему элементу из list1
                    }
                    current2 = current2.Next;
                }

                current1 = current1.Next;
            }

            return result;
        }

        
        // Функція для виведення списку
        public void Display()
        {
            ListNode<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

}