namespace task_10
{
    public partial class Form1 : Form
    {
        private char[,] board;
        private char currentPlayer;
        private bool gameEnded;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            board = new char[3, 3];
            currentPlayer = 'X';
            gameEnded = false;
            ClearBoard();
        }
        private void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                    Controls["button" + (i * 3 + j + 1)].Text = "";
                }
            }
        }
        private bool CheckWin()
        {

            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return true;
                }
            }
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }
            return false;
        }
        private bool CheckDraw()
        {
            foreach (char cell in board)
            {
                if (cell == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (gameEnded)
            {
                return;
            }
            Button button = (Button)sender;
            int index = int.Parse(button.Name.Substring(6)) - 1;
            int row = index / 3;
            int col = index % 3;
            if (board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                button.Text = currentPlayer.ToString();
                if (CheckWin())
                {
                    label1.Text = currentPlayer + " winned!!11!1";
                    gameEnded = true;
                }
                else if (CheckDraw())
                {
                    label1.Text = "it's a draw";
                    gameEnded = true;
                }

                else
                {
                    if (currentPlayer == 'X')
                        currentPlayer = 'O';
                    else if (currentPlayer == 'O')
                    {
                        currentPlayer = 'X';
                    }
                }
            }
        }
        private void button10_Click()
        {
            InitializeGame();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClearBoard();
            InitializeGame();
            label1.Text = "Who's winning?";
        }
    }
}