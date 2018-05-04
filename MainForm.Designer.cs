namespace CoCaro
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlayWithPlayer = new System.Windows.Forms.Button();
            this.btnWatchRecord = new System.Windows.Forms.Button();
            this.btnPlayWithCom = new System.Windows.Forms.Button();
            this.btnCoThe = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCoTheManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlayWithPlayer
            // 
            this.btnPlayWithPlayer.BackColor = System.Drawing.Color.White;
            this.btnPlayWithPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPlayWithPlayer.Location = new System.Drawing.Point(585, 134);
            this.btnPlayWithPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlayWithPlayer.Name = "btnPlayWithPlayer";
            this.btnPlayWithPlayer.Size = new System.Drawing.Size(259, 73);
            this.btnPlayWithPlayer.TabIndex = 1;
            this.btnPlayWithPlayer.Text = "Chơi với người";
            this.btnPlayWithPlayer.UseVisualStyleBackColor = false;
            this.btnPlayWithPlayer.Click += new System.EventHandler(this.btnPlayWithPlayer_Click);
            // 
            // btnWatchRecord
            // 
            this.btnWatchRecord.BackColor = System.Drawing.Color.White;
            this.btnWatchRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnWatchRecord.Location = new System.Drawing.Point(585, 376);
            this.btnWatchRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWatchRecord.Name = "btnWatchRecord";
            this.btnWatchRecord.Size = new System.Drawing.Size(259, 73);
            this.btnWatchRecord.TabIndex = 2;
            this.btnWatchRecord.Text = "Xem lại lịch sử";
            this.btnWatchRecord.UseVisualStyleBackColor = false;
            this.btnWatchRecord.Click += new System.EventHandler(this.btnWatchRecord_Click);
            // 
            // btnPlayWithCom
            // 
            this.btnPlayWithCom.BackColor = System.Drawing.Color.White;
            this.btnPlayWithCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPlayWithCom.Location = new System.Drawing.Point(585, 54);
            this.btnPlayWithCom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlayWithCom.Name = "btnPlayWithCom";
            this.btnPlayWithCom.Size = new System.Drawing.Size(259, 73);
            this.btnPlayWithCom.TabIndex = 0;
            this.btnPlayWithCom.Text = "Chơi với máy";
            this.btnPlayWithCom.UseVisualStyleBackColor = false;
            this.btnPlayWithCom.Click += new System.EventHandler(this.btnPlayWithCom_Click);
            // 
            // btnCoThe
            // 
            this.btnCoThe.BackColor = System.Drawing.Color.White;
            this.btnCoThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCoThe.Location = new System.Drawing.Point(585, 214);
            this.btnCoThe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCoThe.Name = "btnCoThe";
            this.btnCoThe.Size = new System.Drawing.Size(259, 73);
            this.btnCoThe.TabIndex = 4;
            this.btnCoThe.Text = "Cờ thế";
            this.btnCoThe.UseVisualStyleBackColor = false;
            this.btnCoThe.Click += new System.EventHandler(this.btnCoThe_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::CoCaro.Properties.Resources.caro_background;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Location = new System.Drawing.Point(127, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(391, 393);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnCoTheManager
            // 
            this.btnCoTheManager.BackColor = System.Drawing.Color.White;
            this.btnCoTheManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCoTheManager.Location = new System.Drawing.Point(585, 295);
            this.btnCoTheManager.Margin = new System.Windows.Forms.Padding(4);
            this.btnCoTheManager.Name = "btnCoTheManager";
            this.btnCoTheManager.Size = new System.Drawing.Size(259, 73);
            this.btnCoTheManager.TabIndex = 6;
            this.btnCoTheManager.Text = "Chỉnh sửa cờ thế";
            this.btnCoTheManager.UseVisualStyleBackColor = false;
            this.btnCoTheManager.Click += new System.EventHandler(this.btnCoTheManager_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(963, 508);
            this.Controls.Add(this.btnCoTheManager);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCoThe);
            this.Controls.Add(this.btnWatchRecord);
            this.Controls.Add(this.btnPlayWithPlayer);
            this.Controls.Add(this.btnPlayWithCom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cờ Carô";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayWithCom;
        private System.Windows.Forms.Button btnPlayWithPlayer;
        private System.Windows.Forms.Button btnWatchRecord;
        private System.Windows.Forms.Button btnCoThe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCoTheManager;
    }
}

