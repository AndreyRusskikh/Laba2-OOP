namespace Божуха_Лаб2_2_Руських_ПЗ_22_2
{
    class NodeStudent<T>
    {
        public T Student { get; set; }
        public NodeStudent<T> Next { get; set; }
        public NodeStudent(T student)
        {
            Student = student;
            Next = null;
        }

    }

    class NodeTicket<M>
    {
        public M Ticket { get; set; }
        public NodeTicket<M> Next { get; set; }
        public NodeTicket(M ticket)
        {
            Ticket = ticket;
            Next = null;
        }

    }
    class ListNodeStudentWork<T>
    {
        internal NodeStudent<T> headStud;
        public void Add(params T[] Data)
        {
            foreach (var item in Data)
            {
                var newNode = new NodeStudent<T>(item);

                if (headStud == null)
                {
                    headStud = newNode;
                    headStud.Next = headStud; // Создаем замкнутую структуру
                }
                else
                {
                    var current = headStud;
                    while (current.Next != headStud)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
                    newNode.Next = headStud; // Связываем новый узел с первым
                }

            }
        }
        public void Remove(T Data)
        {


            if (headStud == null) { return; }

            else
            {
                var current = headStud;
                NodeStudent<T>? previous = current;

                while (current.Next == headStud)
                {
                    if (current.Student.Equals(Data))
                    {
                        previous.Next = current.Next;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }

            }
        }

    }
    class ListNodeTicketWork<M>
    {
        internal NodeTicket<M> headTick;
        public void Add(params M[] Data)
        {
            foreach (var item in Data)
            {
                var newNode = new NodeTicket<M>(item);

                if (headTick == null)
                {
                    headTick = newNode;
                    headTick.Next = headTick; // Создаем замкнутую структуру
                }
                else
                {
                    var current = headTick;
                    while (current.Next != headTick)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
                    newNode.Next = headTick; // Связываем новый узел с первым
                }

            }
        }
        public void Remove(M Data)
        {


            if (headTick == null) { return; }

            else
            {
                var current = headTick;
                NodeTicket<M>? previous = current;

                while (current.Next == headTick)
                {
                    if (current.Ticket.Equals(Data))
                    {
                        previous.Next = current.Next;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }

            }
        }
    }


}
