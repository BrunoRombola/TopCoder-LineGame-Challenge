import java.util.*;

public class Main {
    
    static int turns = -1;
    
    public static int gridCharger(int[][] grid){   
        Random r =new Random();
        
        int color = r.nextInt(4)+1;
        int row = r.nextInt(grid.length);
        int column = r.nextInt(grid[row].length);
        
        if(grid[row][column] == 0)
        {
            grid[row][column] = color;
            return 1;
        }
        return 0;
    }
    public static void showBoard (int[][] grid){
        for(int i = 0; i < grid.length; i++){
            for(int j = 0; j < grid[i].length; j++)
                System.out.print(grid[i][j] + " ");
            System.out.print("\n");
        }
    }
    public static void newTurn(int[][] grid){
        int i = 4;
        while(i > 0)
            i -= gridCharger(grid);
        turns++;
    }
    
    public static void main(String[] args) throws Exception 
    {
        int[][] board = new int[6][6];
        int points = 0;
        
        newTurn(board);            
        showBoard(board);
        System.out.print(turns);
    }
}
