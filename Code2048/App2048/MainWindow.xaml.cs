using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App2048
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] control = new int[4, 4];
        private TextBox[,] blocks;
        private const int length = 4;
        ITileMovement movement;
        ITileStyle tileStyle;

        public MainWindow()
        {
            
            InitializeComponent();
            Start_Game();
        }

       private void Save_Best_Score()
        {
            using (StreamWriter writetext = new StreamWriter(@"score\bestscore.txt"))
            {
                writetext.WriteLine(tb_best.Text);
            }
        }

        private void Load_Best_Score()
        {
            using (StreamReader readtext = new StreamReader(@"score\bestscore.txt"))
            {
                tb_best.Text = readtext.ReadLine().Trim();
            }
        }

        private void Start_Game()
        {
            tileStyle = new TileStyle();
            blocks = new TextBox[length, length]
                {
                    {tb_00, tb_01, tb_02, tb_03},
                    {tb_10, tb_11, tb_12, tb_13},
                    {tb_20, tb_21, tb_22, tb_23},
                    {tb_30, tb_31, tb_32, tb_33}

                };
            
            movement = new TileMovement(control, blocks);
            movement.NewTile();
            movement.NewTile();
            tileStyle.Style(blocks);
            Load_Best_Score();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                case Key.W:
                    movement.Move_Up();
                    tb_score.Text = movement.AddingScore.ToString();
                    break;

                case Key.Down:
                case Key.S:
                    movement.Move_Down();
                    tb_score.Text = movement.AddingScore.ToString();
                    break;

                case Key.Left:
                case Key.A:
                    movement.Move_Left();
                    tb_score.Text = movement.AddingScore.ToString();
                    break;

                case Key.Right:
                case Key.D:
                    movement.Move_Right();
                    tb_score.Text = movement.AddingScore.ToString();
                    break;

                default:
                    break;
            }

            //Drawing tiles
            tileStyle.Style(blocks);
            if (Convert.ToInt32(tb_score.Text) > Convert.ToInt32(tb_best.Text))
            {
                tb_best.Text = tb_score.Text;
            }


        }

        private void btn_new_game_Click(object sender, RoutedEventArgs e)
        {
            Save_Best_Score();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    blocks[i, j].Text = "";
                    control[i, j] = 0;
                }
            }
            tb_score.Text = "0";
            Start_Game();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Save_Best_Score();
        }

    }
}
