using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ThirtyOne.Args;
using ThirtyOne.Exceptions;
using ThirtyOne.Models;
using ThirtyOne.Utility;
using ThirtyOne.Validators;
using ThirtyOne.ViewHandlers;

namespace ThirtyOne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Author: Jacob Yousif
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// A private field for the default username.
        /// </summary>
        private readonly string defUsername = "Anonymous";
        /// <summary>
        /// A private field for the paths of the images.
        /// </summary>
        private readonly string[] paths = ImageSources.GetSources();
        /// <summary>
        /// A private field for the check boxes.
        /// </summary>
        private readonly CheckBox[] boxes = new CheckBox[6];
        /// <summary>
        /// A private field for the images.
        /// </summary>
        private readonly Image[] images = new Image[6];
        /// <summary>
        /// A private field for the username of the player.
        /// </summary>
        private string username;
        /// <summary>
        /// A private field for the game.
        /// </summary>
        private readonly Game game = new Game();
        /// <summary>
        /// A private field for the view score manager.
        /// </summary>
        private readonly ViewScoreManager vScoreManager = new ViewScoreManager();

        /// <summary>
        /// A public constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            username = defUsername;
            Populate();
            Init();
            EnableBoxes(false);
            HandleScores(null, false);
        }

        /// <summary> 
        /// It sets the values to the initial values.
        /// </summary>
        private void Init()
        {
            result_label.Content = "Next is Roll No:" + game.GetNextRollNumber().ToString() + " and Round No: " + (game.GetCurrentRound() + 1).ToString();
            result_window.Items.Clear();
            result_window.IsEnabled = true;
            throw_btn.IsEnabled = true;
            throw_btn.Visibility = Visibility.Visible;
            for (int index = 0; index < paths.Length; ++index)
            {
                images[index].Source = new BitmapImage(new Uri(paths[index], UriKind.Relative));
            }
        }

        /// <summary>
        /// It enables the check boxes.
        /// </summary>
        /// <param name="isEnable">Whether to enable the boxes.</param>
        private void EnableBoxes(bool isEnable)
        {
            for (int index = 0; index < boxes.Length; ++index)
            {
                boxes[index].IsEnabled = isEnable;
                boxes[index].IsChecked = false;
            }
        }

        /// <summary>
        /// It populates the checkboses and the images.
        /// </summary>
        private void Populate()
        {
            boxes[0] = cBox1;
            boxes[1] = cBox2;
            boxes[2] = cBox3;
            boxes[3] = cBox4;
            boxes[4] = cBox5;
            boxes[5] = cBox6;
            images[0] = iBox1;
            images[1] = iBox2;
            images[2] = iBox3;
            images[3] = iBox4;
            images[4] = iBox5;
            images[5] = iBox6;
        }

        /// <summary>
        /// It updates/populates the scores in the file and in the list view.
        /// </summary>
        /// <param name="score">The score of the game.</param>
        /// <param name="isUpdate">Whether it is update.</param>
        private void HandleScores(ScoreArgs score, bool isUpdate)
        {
            try
            {
                if (isUpdate && score != null)
                {
                    vScoreManager.UpdateScores(score, score_window);
                }
                else
                {
                    vScoreManager.PopulateScores(score_window);
                }
            }
            catch (BaseException ex)
            {
                MessageBox.Show(ex.GetMessage(), "Error");
            }
        }

        /// <summary>
        /// It listens to the throw button.
        /// It sets the values accordingly.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event.</param>
        private void OnThrowClick(object sender, RoutedEventArgs e)
        {
            HandleImages(game.Play(GetValueOFCheckBoxes()));
            if (game.IsFirstRoll())
            {
                EnableBoxes(true);
            }
            if (game.IsRoundOver())
            {
                result_window.Items.Insert(game.GetCurrentRound() - 1, game.GetScore());
                game.SetRound();
                EnableBoxes(false);
            }
            result_label.Content = "Next is Roll No:" + game.GetNextRollNumber().ToString() + " and Round No: " + (game.GetCurrentRound() + 1).ToString();
            if (game.IsGameOver())
            {
                throw_btn.IsEnabled = false;
                throw_btn.Visibility = Visibility.Hidden;
                result_label.Content = "Total score: " + game.GetTotal();
                HandleScores(new ScoreArgs(username, game.GetTotal()), true);
            }
        }

        private void HandleImages(int[] values)
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].Source = new BitmapImage(new Uri(paths[values[i] - 1], UriKind.Relative));
            }
        }

        /// <summary>
        /// It returns the value of the checkboxes
        /// </summary>
        /// <returns>bool[]</returns>
        private bool[] GetValueOFCheckBoxes()

        {
            bool[] areBoxesChecked = new bool[6];
            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].IsChecked.Equals(true))
                {
                    areBoxesChecked[i] = true;
                }
                else
                {
                    areBoxesChecked[i] = false;
                }
            }
            return areBoxesChecked;
        }

        /// <summary>
        /// It listens to the new game button.
        /// It sets the game to new.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event.</param>
        private void OnPlayGame(object sender, RoutedEventArgs e)
        {
            game.Init();
            Init();
            EnableBoxes(false);
        }

        /// <summary>
        /// It listens to the set username button.
        /// It validates and sets the username.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event.</param>
        private void SetUsernameClick(object sender, RoutedEventArgs e)
        {
            InputValidator inputValidator = new InputValidator();
            if (!inputValidator.IsValidString(playername.Text))
            {
                MessageBox.Show("The Username Seems To Be Empty Or Invalid!", "Error");
            }
            else if (!inputValidator.IsValidName(playername.Text))
            {
                MessageBox.Show("The username should contain only letters!", "Error");
            }
            else
            {
                username = playername.Text.ToUpper();
                playername.Text = "";
                username_label.Content = "Hello " + username;
            }
        }

        /// <summary>
        /// It showes the guide.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event.</param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GuideWindow guideWindow = new GuideWindow();
            guideWindow.Show();
        }
    }
}
