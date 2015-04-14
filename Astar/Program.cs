using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astar
{
    class Program
    {
       
        public int Get_Cost()
        {
            return 0;
        }
        static void Main(string[] args)
        {
            int[] h = new int[40];
            int[] path = new int[40];
            int[,] Graph = new int[40, 20];
            int node,i,j;
            int edge, Weight, node1, edge1, hn, node2, Weight1, Goal, Start;
            for (i = 0; i < 40; i++)
                for (j = 0; j < 20; j++)
                    Graph[i,j] = 0;
            for (i = 0; i < 40; i++)
                h[i] = 0;
            Console.WriteLine("Total Nodes : ");
            var v = Console.ReadLine();
           
            int.TryParse(v, out node);

            
            Console.WriteLine("Total edges : ");
            v = Console.ReadLine();
           
            int.TryParse(v, out edge);
            Console.WriteLine("Node1 Node2 Weight : ");
            for (i = 0; i < edge; i++) 
            {
               
                v = Console.ReadLine();
                int.TryParse(v, out node1);
                v = Console.ReadLine();
                int.TryParse(v, out edge1);
                v = Console.ReadLine();
                int.TryParse(v, out Weight);
                
                Graph[node1, edge1] = Weight;
                Console.WriteLine(node1 + " " + edge1 + " " + Weight);
            }
            Console.WriteLine("Total Huristic Nodes : ");
            v = Console.ReadLine();
            
            int.TryParse(v, out hn);
            for (i = 0; i < hn;i++ ){
                //h[i]=
                v = Console.ReadLine();
                int.TryParse(v, out node2);
                v = Console.ReadLine();
                int.TryParse(v, out Weight1);
                h[node2] = Weight1;
            }
            Console.WriteLine("Total Start Node : ");
            v = Console.ReadLine();

            int.TryParse(v, out Start);

            Console.WriteLine("Total Goal Node : ");
            v = Console.ReadLine();

            int.TryParse(v, out Goal);
             Queue<int> visit = new Queue<int>();
             visit.Enqueue(Start);
             path[Start] = 0;
             while (visit.Count > 0) 
             {
                 int search = visit.Dequeue();
                
                 for (j = 0; j <= node; j++) 
                 {
                     if (Graph[search, j] != 0) 
                     {
                         path[j] = path[search] + Graph[search, j];
                         Console.WriteLine(path[j]);
                         visit.Enqueue(j);
                     }
                 }
             }
             visit.Clear();
             visit.Enqueue(Start);
             int min , minnode=Start;

             while (visit.Count > 0)
             {
                visit.Dequeue();
                 int tempmini = 0;
                 min = 250000;
                 if (minnode == Goal)
                 {
                     Console.WriteLine("Found");
                     break;
                 }
                 for (j = 0; j <= node; j++)
                 {
                     if (Graph[minnode, j] != 0)
                     {
                         int sum=path[minnode] + h[j];
                         if (min >= sum) 
                         {
                             min = path[minnode] + h[j];
                             tempmini = j;   
                         }
                         visit.Enqueue(minnode);
                     }

                 }
                 minnode = tempmini;
             }

            if(visit.Count==0)
                Console.WriteLine("Not Found");

                Console.ReadKey(true);
        }
    }
}
