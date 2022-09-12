using System;

//Daniel Svensson .NET22

namespace ChessBoard
{
    class ProgramExtra
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode; // forceing unicode to show the squares, and setting a standard in the output
            string ChessNumber = ""; // handles storing the user's input of how meny squares
            int ConvertedChessNumber = 0;
            int OnGoingThings = 0; // using int as a navigator in the 'switch case' for simplicity, 0 is default

            string WhiteSquare = "◻︎"; // ◻︎  \u25A1 
            string BlackSquare = "◼︎"; // ◼︎  \u25A0
            string CustomWhite = "";
            string CustomBlack = "";
            string[,] Board;
            bool SelectedCustom = false;
            bool SelectedPeice = false;
            string PieceSelection = "";
            ConsoleKey OptionKey; // for getting the selected option if they want to have custom squares or not


            switch (OnGoingThings)
            {
                default:
                    //normal greeting to user, and the first prompt to start the process
                    Console.WriteLine("Hello and Welcome to the Chessboard generator, \nplease follow the instructions carefully \n");
                    Console.WriteLine("Please enter a Number for the chessboard grid");
                    Console.WriteLine("Be Warned, boards above 26 squares is not supported for piece placement in this program");
                    ChessNumber = Console.ReadLine();

                    while (int.TryParse(ChessNumber, out ConvertedChessNumber) is false)
                    // checks to see if the entered value is a integer or not, and if not then asks the user again until it is one, Infinite loop potential if they dont follow instructions   
                    {
                        Console.WriteLine("That was not a number,\t Please try again..");
                        ChessNumber = Console.ReadLine();
                    }
                    do
                    {
                        Console.WriteLine("Do you want to set your squares to a custom shape? [Y/N]\n"); // setting up a dialog if the user wants custom squares or not.
                        OptionKey = Console.ReadKey(false).Key;
                        if (OptionKey != ConsoleKey.Enter)
                        {
                            Console.WriteLine();

                        }

                    } while (OptionKey != ConsoleKey.Y && OptionKey != ConsoleKey.N); //keeps looping untill acceptable response from user, Yes or No.

                    Board = new string[ConvertedChessNumber, ConvertedChessNumber];

                    if (OptionKey == ConsoleKey.Y) // checks to see if the user said yes to a question
                    {
                        SelectedCustom = true;
                    }

                    if (ConvertedChessNumber < 27) // makes certain that the user can't go into Board row letters saing 'AA' and so on, only 'A->Z'
                    {
                        do
                        {
                            Console.WriteLine("Do you want to place a piece on the board? [Y/N]\n"); // setting up a dialog if the user wants to place a piece or not.
                            OptionKey = Console.ReadKey(false).Key;
                            if (OptionKey != ConsoleKey.Enter)
                            {
                                Console.WriteLine();

                            }

                        } while (OptionKey != ConsoleKey.Y && OptionKey != ConsoleKey.N); //keeps looping untill acceptable response from user, Yes or No.
                        if (OptionKey == ConsoleKey.Y)
                        {
                            SelectedPeice = true;
                        }
                    }

                    if (OptionKey == ConsoleKey.Y && SelectedCustom == true && SelectedPeice == true) // if Yes, it asks for what symbols for each and captures the chosen one,
                    {
                        Console.WriteLine("What Character for white?\n");
                        CustomWhite = Console.ReadLine();
                        Console.WriteLine("What Character for Black?\n");
                        CustomBlack = Console.ReadLine();
                        Console.WriteLine("And where do you want to place the piece?\n");
                        PieceSelection = Console.ReadLine().ToUpper();
                        goto case 1; //  then moves to make the squares
                    }
                    else if (OptionKey == ConsoleKey.Y && SelectedCustom == false && SelectedPeice == true)
                    {
                        Console.WriteLine("Where do you want to place the piece?\n");
                        PieceSelection = Console.ReadLine();
                        goto case 2; //  then moves to make the squares
                    }

                    else
                    {
                        goto case 2; // if no on both, then use the default from the code
                    }

                case 1: // custom creation on the symbols inputed by the user
                    Board = CreateSquares(ConvertedChessNumber, CustomWhite, CustomBlack, SelectedPeice, PieceSelection);
                    break;

                case 2: // default creation as user didn't want custom tiles
                    Board = CreateSquares(ConvertedChessNumber, WhiteSquare, BlackSquare, SelectedPeice, PieceSelection);
                    break;

            }

            for (int i = 0; i < ConvertedChessNumber; i++) // prints the entire board from the array
            {
                for (int j = 0; j < ConvertedChessNumber; j++)
                {
                    Console.Write(Board[i, j]);
                }
                Console.WriteLine();
            }

        }

        // small method to create the squares that is needed in the right positions 
        static string[,] CreateSquares(int numberOfSquares, string squareWhite, string squareBlack, bool pieceSelected ,string piecePlacement)  
            //pulling in the diffrent variables needed to construct the board.
        {
            string[,] BoardsArray = new string[numberOfSquares,numberOfSquares];
            string[] LettersArray = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int RowIndex = 0;
            int ColumnIndex = 0;
            
            for (int i = 0; i < numberOfSquares ; i++) // doing double 'for' loop to populate the board with the right color at the right place
            {// first loop handles columns of the squares
                
                for (int j = 0; j < numberOfSquares; j++) //handles the rows of squares == user's input of how meny squares is printed
                {
                    
                    if ((i + j) % 2 == 0)  // checks to see if the number is even or odd, and asigns differing squares depending on it
                    {
                        BoardsArray[i,j] = squareWhite;
                    }
                    else
                    {
                        BoardsArray[i,j] = squareBlack;
                    }

                }
                
            }
            if (pieceSelected == true)
            {
                if (piecePlacement.Length == 2) { // checks if it's something like "E7"
                    RowIndex = Array.IndexOf(LettersArray, piecePlacement.Substring(0, 1).ToUpper()); // get's the position of the letter in the letters array and captures the index of it

                    ColumnIndex = Convert.ToInt32(piecePlacement.Substring(1, 1)); //get's the numbers entered by the user
                    BoardsArray.SetValue("♜   ", ColumnIndex -1, RowIndex); // Column needs to be shortened by 1 due to For loop increment is 1 higher for it and replaces the square with symbol
                }
                if (piecePlacement.Length == 3) // checks if it's something like "E20"
                {
                    RowIndex = Array.IndexOf(LettersArray, piecePlacement.Substring(0, 1).ToUpper());

                    ColumnIndex = Convert.ToInt32(piecePlacement.Substring(1, 2)) -1;
                    BoardsArray.SetValue("♜   ", ColumnIndex - 1, RowIndex); //"\u2654" using a chesspiece
                    //ended up using three (3) whitespaces to fix the printing error, as it shifts the entire print to the side due to non uniform printing to console
                }
            }
            return BoardsArray;
        }
    }
}
