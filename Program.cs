using System.Linq.Expressions;
using System.IO.Enumeration;
using System.IO;
using System.Security.AccessControl;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TOPCODER
{
    class Program
    {
       public static void NewTurn(int[,] grid){
            var random = new Random();
            int color, row, column;
            int i = 4;
            while( i> 0){
            color = random.Next(1,5);
            row = random.Next(grid.GetLength(0));
            column = random.Next(grid.GetLength(1));
            
                if(grid[row,column] == 0){
                    grid[row,column] = color;
                    i--;
                }
            }
            
        }
        public static void BoardShower(int[,] grid){
            for(int i = 0; i < grid.GetLength(0); i++){
                for(int j = 0; j < grid.GetLength(1); j++)
                    Console.Write(grid[i,j] +" ");
                Console.Write("\n");     
            }
        }
        public static void MoveElem(int posX, int posY, int newX,int newY, int[,] grid){
            grid[newX,newY] = grid[posX,posY];
            grid[posX,posY] = 0;
        }
        

        public static void Main(){
            int[,] grid = new int[6,6];
            
            NewTurn(grid);
            BoardShower(grid);
            Console.Write("Wich row have your number?\nrow:");
            int posX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Wich column have your number?\ncolumn:");
            int posY = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Wich row have is your number destiny?\n row:");
            int newX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Wich column is your number destiny?\ncolumn:");
            int newY = Convert.ToInt32(Console.ReadLine());
            MoveElem(posX,posY,newX,newY,grid);
            BoardShower(grid);    
            
        }
    }
}
