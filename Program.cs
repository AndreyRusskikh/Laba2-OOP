using Божуха_Лаб2_1_Руських_ПЗ_22_2;
namespace Laba2_Alg
{
    class Program
    {
        static void Main()
        {
            NodeWork<int> listNode = new NodeWork<int>();
            NodeWork<int> nodeWork2 = new NodeWork<int>();

            listNode.Add(5);
            listNode.Add(2);
            listNode.Add(8);
            listNode.Add(9);
            listNode.Add(6);
            listNode.Add(1);

            Init_Menu.Menu(listNode, nodeWork2);

        }
    }
}