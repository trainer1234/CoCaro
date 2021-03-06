﻿using CoCaro.Model;
using CoCaro.Presenter;
using CoCaro.View;
using CoCaro.View.ChessBoardEditForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CoCaro.View.MainForm
{
    public partial class CoTheManagerFormView : Form, ICoTheManagerFormView
    {
        private List<CoTheGameLevel> gameLevels;
        public CoTheManagerPresenter Presenter { private get; set; }
        public CoTheManagerFormView()
        {
            InitializeComponent();
            Presenter = new CoTheManagerPresenter(this, Program.DataSource);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Presenter.LoadLevels();
        }

        public void ShowLevels(List<CoTheGameLevel> gameLevels)
        {
            this.gameLevels = gameLevels;            

            int buttonSize = 50;
            int paddingTop = 100;
            int paddingLeft = 100;
            int levelsInRow = 5;

            this.Width = 2 * paddingLeft + levelsInRow * (2 * buttonSize);
            this.Height = 2 * paddingTop + ((gameLevels.Count + 1) / levelsInRow + 1) * (2 * buttonSize);

            Label title = new Label();
            title.Width = 100;
            title.Height = 40;
            title.Location = new Point(this.Width / 2 - title.Width / 2, paddingTop / 3);
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Text = "Cờ thế";

            Controls.Add(title);

            Button btnRefresh = new Button();
            btnRefresh.Width = 100;
            btnRefresh.Height = 40;
            btnRefresh.Location = new Point(this.Width - paddingLeft - 20, title.Location.Y - 20);
            btnRefresh.Font = new Font("Arial", 14, FontStyle.Regular);
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;

            Controls.Add(btnRefresh);

            for (int i = 0; i <= gameLevels.Count; i++)
            {
                if(i == gameLevels.Count)
                {
                    Button btnNewLevel = new Button();
                    btnNewLevel.Name = "btnLevel_New";
                    btnNewLevel.Width = buttonSize;
                    btnNewLevel.Height = buttonSize;
                    btnNewLevel.Location = new Point(paddingLeft + 2 * buttonSize * (i % levelsInRow),
                        paddingTop + 2 * buttonSize * (i / levelsInRow));
                    btnNewLevel.Font = new Font("Arial", 22, FontStyle.Bold);
                    btnNewLevel.ForeColor = Color.Green;
                    btnNewLevel.Text = "+";
                    btnNewLevel.Click += btnNewLevel_Click;

                    Controls.Add(btnNewLevel);

                    break;
                }
                Button btnLevel = new Button();
                btnLevel.Name = "btnLevel_" + gameLevels[i].Id.ToString();
                btnLevel.Width = buttonSize;
                btnLevel.Height = buttonSize;
                btnLevel.Location = new Point(paddingLeft + 2 * buttonSize * (i % levelsInRow),
                    paddingTop + 2 * buttonSize * (i / levelsInRow));
                btnLevel.Font = new Font("Arial", 16, FontStyle.Bold);
                btnLevel.Text = (gameLevels[i].Id).ToString();
                btnLevel.Click += btnLevel_Click;

                Controls.Add(btnLevel);
            }                        
        }

        private void btnLevel_Click(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;
            int index = int.Parse(selectedButton.Name.Split('_')[1]);

            CoTheGameLevel coTheGame = null;
            foreach(var game in gameLevels)
            {
                if(game.Id == index)
                {
                    coTheGame = game;
                    break;
                }
            }
            if(coTheGame != null)
            {
                ChessBoardEditFormView form = new ChessBoardEditFormView(coTheGame);
                form.Show();
            }            
        }

        private void btnNewLevel_Click(object sender, EventArgs e)
        {            
            ChessBoardEditFormView form = new ChessBoardEditFormView();
            form.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            Presenter.LoadLevels();
        }
    }
}
