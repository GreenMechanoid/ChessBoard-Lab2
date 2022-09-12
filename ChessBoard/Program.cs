using System;


//Daniel Svensson .NET22

// ("\u25A0"); // Black square
// ("\u25A1"); // White square

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode; // forceing unicode to show the squares as i've chosen to represent them in Unicode
            string ChessNumber = ""; // handles storing the user's input of how meny squares
            int ConvertedChessNumber = 0;
            int OnGoingThings = 0; // using int as a navigator in the Switch case for simplicity, 0 is default

            string WhiteSquare = "\u25A1";
            string BlackSquare = "\u25A0";
            string CustomWhite = "";
            string CustomBlack = "";

            ConsoleKey actionKey; // for getting the selected option if they want to have custom squares or not


            switch (OnGoingThings)
            {
                default:
                    //normal greeting to user, and the first prompt to start the process
                    Console.WriteLine("Hello and Welcome to the Chessboard generator, \nplease follow the instructions carefully \n");
                    Console.WriteLine("Please enter a Number for the chessboard grid");
                    ChessNumber = Console.ReadLine();

                    while (int.TryParse(ChessNumber, out ConvertedChessNumber) is false)
                    // checks to see if the entered value is a integer or not, and if not then asks the user again until it is one, Infinite loop potential if they dont follow instructions   
                    {
                        Console.WriteLine("That was not a number,\t Please try again..");
                        ChessNumber = Console.ReadLine();

                    }
                    
                    do
                    {
                        Console.WriteLine("Do you want to set your squares to a custom shape? [Y/N]"); // setting up a dialog if the user wants custom squares or not.
                        actionKey = Console.ReadKey(false).Key;
                        if (actionKey != ConsoleKey.Enter)
                        {
                            Console.WriteLine();

                        }

                    } while (actionKey != ConsoleKey.Y && actionKey != ConsoleKey.N); //keeps looping untill acceptable response from user, Yes or No.
                    
                    if (actionKey == ConsoleKey.Y) // if Yes, it asks for what symbols for each and captures the chosen one,
                    {
                        Console.WriteLine("What Character for white?");
                        CustomWhite = Console.ReadLine();
                        Console.WriteLine("What Character for Black?");
                        CustomBlack = Console.ReadLine();
                        goto case 1; //  then moves to make the squares
                    }
                    else
                    {
                    goto case 2; // if no, then use the default from the code
                    }

                case 1: // custom creation on the symbols inputed by the user
                    CreateSquares(ConvertedChessNumber, CustomWhite, CustomBlack);
                    break;
                case 2: // default creation as user did'nt want custom tiles
                    CreateSquares(ConvertedChessNumber, WhiteSquare, BlackSquare);
                    break;
            }

        }

        // small function to create the squares that is needed in the right positions
        static void CreateSquares(int numberOfSquares, string squareWhite, string squareBlack)  
            //pulling in the diffrent variables needed to construct the board.
        {

            for (int i = 0; i < numberOfSquares ; i++) // doing dubbel for loop to populat the board with the right color
            {
                
                for (int j = 0; j < numberOfSquares; j++) //handles the vertical squares == user's input of how meny squares is printed
                {
                    if ((i + j) % 2 == 0)
                    {
                        Console.Write(squareWhite);
                    }
                    else
                    {
                        Console.Write(squareBlack);
                    }

                }

                Console.WriteLine(); // generates a new line to handle horizontal squares after the first pass of the square is done,
                                     // in reality it becomes a square of squares, I;E a chessboard
            }
        }
    }
}
