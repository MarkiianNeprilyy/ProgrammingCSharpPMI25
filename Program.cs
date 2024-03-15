// Непрілий Маркіян ПМІ-25
// Модуль 15.03
// Варіант 3
using System;
class Matrix
{
    private int[][] data;
    public Matrix(int rows, int columns)    
    {
        data = new int[rows][];        
        for (int i = 0; i < rows; i++)
        {            
            data[i] = new int[columns];
        }    
    }
    public int this[int row, int column]
    {        
        get { return data[row][column]; }
        set { data[row][column] = value; }    
    }
    
    public void FillMatrixRandom(int rows, int columns, int min, int max)
    {        Random random = new Random();
        for (int i = 0; i < rows; i++) 
            {
            for (int j = 0; j < columns; j++)            
            {
                data[i][j] = random.Next(min, max + 1);            
            }
        }    
    }
    public void PrintMatrix()
    {        
        for (int i = 0; i < data.Length; i++)
        {            
            for (int j = 0; j < data[i].Length; j++)
            {                
                Console.Write(data[i][j] + " ");
            }            
            Console.WriteLine();
        }    
    }
}
class Program{
    static void Main(string[] args)    
    {
        Matrix matrix = new Matrix(3, 3);        
        matrix.FillMatrixRandom(3, 3, 1, 10);
        Console.WriteLine("Generated Matrix:");        
        matrix.PrintMatrix();

        int row = 1;        
        int column = 2;
        Console.WriteLine($"Value at ({row}, {column}): {matrix[row, column]}");    
    }
}