using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoCaro.DAL.Models;
using CoCaro.Model;
using CoCaro.Presenter.CoThe;
using CoCaro.View.PlayWithCom;

namespace CoCaro.View.CoThe
{
    public partial class CoTheViewForm : Form, ICoTheView
    {
        private List<CoTheGameLevel> gameLevels;
        public CoTheViewForm()
        {
            InitializeComponent();
            this.Presenter = new CoThePresenter(this, Program.DataSource);
        }

        public CoThePresenter Presenter { private get; set; }

        public void ShowLevels(List<CoTheGameLevel> gameLevels)
        {
            this.gameLevels = gameLevels;            

            int buttonSize = 50;
            int paddingTop = 100;
            int paddingLeft = 100;
            int levelsInRow = 5;            

            this.Width = 2 * paddingLeft + levelsInRow * (2 * buttonSize);
            this.Height = 3 * paddingTop + gameLevels.Count / levelsInRow * (2 * buttonSize);

            if (gameLevels == null || gameLevels.Count < 1)
            {
                Label noGameCreated = new Label();
                noGameCreated.Width = this.Width;
                noGameCreated.Height = 40;
                noGameCreated.Location = new Point(0, this.Height / 2 - 
                    noGameCreated.Height);
                noGameCreated.Font = new Font("Arial", 16, FontStyle.Bold);
                noGameCreated.TextAlign = ContentAlignment.MiddleCenter;
                noGameCreated.ForeColor = Color.Blue;
                noGameCreated.Text = "Chưa có level cờ thế nào được tạo!";

                Controls.Add(noGameCreated);
            }

            Label title = new Label();
            title.Width = 100;
            title.Height = 40;
            title.Location = new Point(this.Width / 2 - title.Width / 2, paddingTop / 3);
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Text = "Cờ thế";

            Controls.Add(title);

            for(int i=0;i<gameLevels.Count; i++)
            {
                Button btnLevel = new Button();
                btnLevel.Name = "btnLevel_" + i.ToString();
                btnLevel.Width = buttonSize;
                btnLevel.Height = buttonSize;
                btnLevel.Location = new Point(paddingLeft + 2 * buttonSize * (i % levelsInRow),
                    paddingTop + 2 * buttonSize * (i / levelsInRow));
                btnLevel.Font = new Font("Arial", 16, FontStyle.Bold);
                btnLevel.Text = (i + 1).ToString();
                btnLevel.Click += btnLevel_Click;

                Controls.Add(btnLevel);
            }            
        }

        private void CoTheViewForm_Load(object sender, EventArgs e)
        {
            this.Presenter.LoadLevels();
        }

        private void btnLevel_Click(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;
            int index = int.Parse(selectedButton.Name.Split('_')[1]);

            PlayWithComViewForm form = new PlayWithComViewForm(this.gameLevels[index]);
            form.Show();
        }
    }
}
