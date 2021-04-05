using System;
using System.Collections;
using System.Collections.Generic;

namespace TOPCODER
{
    class Board
    {
        private int rows, columns, turn;
        private int[,] colors;
        public Board (int rows, int columns){
            this.rows = rows;
            this.columns = columns;
            this.turn = 0;
            this.colors = new int[rows,columns];
        }  
        public void ShowBoardContent(){
            for(int i = 0; i < colors.GetLength(0); i++){
                for(int j = 0 ; j < colors.GetLength(1); j++){
                    Console.Write("{0} ", colors[i,j]);
                }
                Console.WriteLine();
            }
        }
        public void Move(int[] startPos,int[] endPos){
            int[] aux = new int[2];
            while(startPos[0] != endPos[0] || startPos[1]!= endPos[1]){
                aux = NextPos(startPos,endPos);
                Console.WriteLine("aux = ({0},{1})",aux[0]+1,aux[1]+1);
                MoveOne(startPos,aux);
                startPos[0] = aux[0];
                startPos[1] = aux[1];
                ShowBoardContent();
                Console.WriteLine();
                Console.ReadLine();
            }  
        }
        public int[] NextPos(int[] startPos, int[] endPos){
            Console.WriteLine("Ingresó a NextPos");
            if(startPos[1] == endPos[1]){
                if(startPos[0] > endPos[0]){
                        for(int j = startPos[0]-1; j < startPos[0]+1; j++){
                            Console.WriteLine("Ingresó a NextPos 1 if 1 if" );
                            if(colors[j,startPos[1]] == 0){
                                return new int[]{startPos[0],j};    
                            }
                        }
                    }
                else{ 
                   for(int j = startPos[0]+1; j > startPos[0]-1; j--){
                        Console.WriteLine("Ingresó a NextPos 1 if 2 if" );
                        if(colors[j,startPos[1]] == 0){
                            return new int[]{startPos[0],j};    
                        }
                    }
                }
            }
            else if(startPos[0] == endPos[0]){
                if(startPos[1] > endPos[1]){
                        for(int j = startPos[1]-1; j < startPos[1]+1; j++){
                            Console.WriteLine("Ingresó a NextPos 2 if 1 if" );
                            if(colors[startPos[0],j] == 0){
                                return new int[]{startPos[0],j};    
                            }
                        }
                    }
                else{ 
                   for(int j = startPos[1]+1; j > startPos[1]-1; j--){
                        Console.WriteLine("Ingresó a NextPos 2 if 2 if" );
                        if(colors[startPos[0],j] == 0){
                            return new int[]{startPos[0],j};    
                        }
                    }
                }
            }
            else if(startPos[0] < endPos[0]){
                for(int i = startPos[0]+1; i < startPos[0]-1; i--){
                    if(startPos[1] > endPos[1]){
                        for(int j = startPos[1]-1; j < startPos[1]+1; j++){
                            Console.WriteLine("Ingresó a NextPos 3 if 1 if" );
                             if(colors[i,j] == 0){
                                return new int[]{i,j};
                            }
                        }
                    }
                    else{ 
                    for(int j = startPos[1]+1; j > startPos[1]-1; j--){
                            Console.WriteLine("Ingresó a NextPos 3 if 2 if" );
                            if(colors[i,j] == 0){
                                return new int[]{i,j};    
                            }
                        }
                    }
                }
            }
            else  if(startPos[0] > endPos[0]){
                for(int i = startPos[0]-1; i < startPos[0]+1; i++){
                    if(startPos[1] > endPos[1]){
                        for(int j = startPos[1]-1; j < startPos[1]+1; j++){
                            Console.WriteLine("Ingresó a NextPos 4 if 1 if" );
                             if(colors[i,j] == 0){
                                return new int[]{i,j};
                            }
                        }
                    }
                    else{ 
                       for(int j = startPos[1]+1; j > startPos[1]-1; j--){
                            Console.WriteLine("Ingresó a NextPos 4 if 2 if" );
                            if(colors[i,j] == 0){
                                return new int[]{i,j};    
                            }
                        }
                    }
                }
            }
            return startPos;
        }
        public void MoveOne(int[] startPos,int[] endPos){
            
            colors[endPos[0],endPos[1]] = colors[startPos[0],startPos[1]];
            colors[startPos[0],startPos[1]] = 0;
        }
        public void NewTurn(){
            Random r = new Random();
            int posX;
            int posY;
            int color, i = 0;
            while(i<5){
                color = r.Next(3)+1;
                posX = r.Next(colors.GetLength(0));
                posY = r.Next(colors.GetLength(1));
                if(colors[posX,posY] == 0){
                    colors[posX,posY] = color;
                    i++;
                }
            }
            this.turn++;

        }
    }
    class Program
    {
        public static int[] SelectElem(){
            Console.Write("Select the row: ");
            int posX = Convert.ToInt32(Console.ReadLine())-1;
            Console.Write("Select the column: ");
            int posY = Convert.ToInt32(Console.ReadLine())-1;
            return new int[]{posX,posY};
        }
        public static void Main(){
            Board board = new Board(6,6);
            board.NewTurn();
            board.ShowBoardContent();
            board.Move(SelectElem(),SelectElem());
            Console.WriteLine("Final");
            board.ShowBoardContent();
        }
    }
}
