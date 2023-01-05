using GOLconsole.Source;
using Timer = System.Windows.Forms.Timer;

namespace GOLForm
{
    public partial class GameForm : Form
    {
        private Grid grid;
        private Timer timer;

        public GameForm()
        {
            InitializeComponent();

            // Set up the grid and timer
            grid = new Grid(40, 40);
            grid.Initialize();
            DrawGrid();
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update and draw the grid
            grid.Update();
            grid.NextState();
            DrawGrid();
        }

        private void DrawGrid()
        {
            // Clear the canvas
            Graphics g = canvasPanel.CreateGraphics();
            g.Clear(Color.White);

            // Draw the cells
            for (int i = 0; i < grid.Width; i++)
            {
                for (int j = 0; j < grid.Height; j++)
                {
                    var cell = grid.Cells[i, j];
                    var brush = cell.IsAlive ? Brushes.Black : Brushes.White;
                    g.FillRectangle(brush, i * 10, j * 10, 10, 10);
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}