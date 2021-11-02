using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgorithms.Programs.Matrices
{
    public class SparseMatrix
    {
        //SparseMatrix ms = new SparseMatrix(8, 9, 3);
        //ms.Add(new Element { row = 0, column = 0, value = 1 });
        //ms.Add(new Element { row = 1, column = 2, value = 7 });
        //ms.Add(new Element { row = 4, column = 4, value = 2 });
        //ms.Add(new Element { row = 4, column = 5, value = 2 });
        //ms.Display();

        private readonly int Rows;
        private readonly int Columns;
        /// <summary>
        /// Non zero elements
        /// </summary>
        private int ElementsCount;
        private List<Element> Elements;
        public SparseMatrix(int rows, int cols, int elementCount)
        {
            Rows = rows;
            Columns = cols;
            ElementsCount = elementCount;
            Elements = new List<Element>();
        }
        public void Add(Element element)
        {
            if(Elements.Count <= ElementsCount)
            {
                Elements.Add(element);
            }
        }

        public void Display()
        {
            int k = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if(k < ElementsCount && i == Elements[k].row && j == Elements[k].column)
                    {
                        Console.Write(Elements[k++].value + " ");
                    }
                    else
                    {
                        Console.Write(0 + " ");
                    }
                }
                Console.WriteLine(" ");
            }
        }
    }

    public class Element
    {
       public int row;
       public int column;
       public int value;
    }
}
