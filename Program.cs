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
        public int Turn(){
            return this.turn;
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
            if(startPos[0] == endPos[0]){
                if(startPos[1] > endPos[1]){
                    for(int j = startPos[1] - 1; j <= startPos[1] + 1 || j <colors.GetLength(1); j++ ){
                        if(colors[startPos[0],j] == 0){return new int[]{startPos[0],j};}
                        else {
                            if( startPos[0]-1 > 0)
                                for(int i = startPos[0] - 1; i <= startPos[1] + 1 || i <colors.GetLength(0); i++ ){
                                    if(colors[i,j] == 0){return new int[]{i,j};}
                                }
                            else{
                                for(int i = startPos[0] + 1; i <= startPos[1] - 1 || i <colors.GetLength(0); i-- ){    
                                    if(colors[i,j] == 0){return new int[]{i,j};}
                                }
                            }
                        }
                    }
                }
                else{
                    for(int j = startPos[1] + 1; j <= startPos[1] - 1 || j >= 0; j-- ){
                        if(colors[startPos[0],j] == 0){return new int[]{startPos[0],j};}
                        else {
                            if( startPos[0]-1 > 0)
                                for(int i = startPos[0] - 1; i <= startPos[1] + 1 || i <colors.GetLength(0); i++ ){
                                    if(colors[startPos[0],j] == 0){return new int[]{i,j};}
                                }
                            else{
                                for(int i = startPos[0] + 1; i <= startPos[1] - 1 || i <colors.GetLength(0); i-- ){    
                                    if(colors[startPos[0],j] == 0){return new int[]{i,j};}
                                }
                            }
                        }
                    }
                }
            } 
            else if(startPos[1] == endPos[1]){
                if(startPos[0] > endPos[0]){
                    for(int i = startPos[0] - 1; i <= startPos[0] + 1 || i <colors.GetLength(0); i++ ){
                        if(colors[i,startPos[1]] == 0){return new int[]{i,startPos[1]};}
                        else {
                            if( startPos[0]-1 > 0)
                                for(int j = startPos[1] - 1; j <= startPos[1] + 1 || j <colors.GetLength(1); j++ ){
                                    if(colors[i,j] == 0){return new int[]{i,j};}
                                }
                            else{
                                for(int j = startPos[1] + 1; j <= startPos[1] - 1 || j <colors.GetLength(1); j-- ){    
                                    if(colors[i,j] == 0){return new int[]{i,j};}
                                }
                            }
                        }
                    }
                }
                else{
                    for(int i = startPos[0] + 1; i <= startPos[0] - 1 || i >= 0; i-- ){
                        if(colors[i,startPos[1]] == 0){return new int[]{i,startPos[1]};}
                    }
                }
            }
            if(startPos[0] > endPos[0]){
                if(startPos[1] > endPos[1]){
                    for(int j = startPos[1] - 1; j <= startPos[1] + 1 || j <colors.GetLength(1); j++ ){
                        if(colors[startPos[0],j] == 0){return new int[]{startPos[0],j};}
                    }
                }
                else{
                    for(int j = startPos[1] + 1; j <= startPos[1] - 1 || j >= 0; j-- ){
                        if(colors[startPos[0],j] == 0){return new int[]{startPos[0],j};}
                    }
                }
            }
            if(startPos[0] < endPos[0]){
                if(startPos[1] > endPos[1]){
                    for(int j = startPos[1] - 1; j <= startPos[1] + 1 || j <colors.GetLength(1); j++ ){
                        if(colors[startPos[0],j] == 0){return new int[]{startPos[0],j};}
                    }
                }
                else{
                    for(int j = startPos[1] + 1; j <= startPos[1] - 1 || j >= 0; j-- ){
                        if(colors[startPos[0],j] == 0){return new int[]{startPos[0],j};}
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
        public bool IsLine(){
            for(int i = 0; i< colors.GetLength(0); i++){
                for(int j = 0; j < colors.GetLength(1); j++)
                if(HorizontalLine(i,j,colors[i,j]) == 5){ return true;}
                else if( VerticalLine(i,j,colors[i,j]) == 5){ return true;}
                else if(DiagonalLine(i,j,colors[i,j]) == 5) {return true;}
            }
            return false;
        }
        public int DiagonalLine(int iIndex,int jIndex, int color){
            int counter = 1;
            for(int i = iIndex +1; i < iIndex + 5 || i < colors.GetLength(0); i++){
                for(int j = jIndex + 1; j < jIndex +5 || j < colors.GetLength(1); j++){
                    if(colors[i,j] == color){counter++;}else{counter = 1; break;}
                }
            }
            for(int i = iIndex +1; i < iIndex + 5 || i < colors.GetLength(0) || counter < 5; i++){
                for(int j = jIndex -1 ; j < jIndex - 5 || j > 0; j--){
                    if(colors[i,j] == color){counter++;}else{counter = 1; break;}
                }
            }
            return counter;
        }
        public int VerticalLine(int iIndex,int jIndex,int color){
            int counter = 1;
            int i = iIndex +1 ;
            while( i < iIndex + 5 || i < colors.GetLength(0)){if(colors[i,jIndex] == color){counter++; i++;}else{counter = 0; break;}}            
            return counter;
        }
        public int HorizontalLine(int iIndex,int jIndex,int color){
            int counter = 1;
            int i = jIndex +1 ;
            while( i < jIndex + 5 || i < colors.GetLength(1)){if(colors[iIndex,i] == color){counter++; i++;}else{counter = 0; break;}}            
            return counter;
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
            int points = 0;
            do{
                board.NewTurn();
                board.ShowBoardContent();
                board.Move(SelectElem(),SelectElem());
            //   if(board.IsLine()){points ++;}
            }while(board.Turn() < 4);
            Console.WriteLine("You score is {0}", points);
            board.ShowBoardContent();
        }
    }
}
