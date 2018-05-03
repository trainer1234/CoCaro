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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPlayWithCom = new System.Windows.Forms.Button();
            this.btnCoThe = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnPlayWithPlayer
            // 
            this.btnPlayWithPlayer.BackColor = System.Drawing.Color.White;
            this.btnPlayWithPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPlayWithPlayer.Location = new System.Drawing.Point(495, 109);
            this.btnPlayWithPlayer.Name = "btnPlayWithPlayer";
            this.btnPlayWithPlayer.Size = new System.Drawing.Size(194, 59);
            this.btnPlayWithPlayer.TabIndex = 1;
            this.btnPlayWithPlayer.Text = "Chơi với người";
            this.btnPlayWithPlayer.UseVisualStyleBackColor = false;
            this.btnPlayWithPlayer.Click += new System.EventHandler(this.btnPlayWithPlayer_Click);
            // 
            // btnWatchRecord
            // 
            this.btnWatchRecord.BackColor = System.Drawing.Color.White;
            this.btnWatchRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnWatchRecord.Location = new System.Drawing.Point(495, 239);
            this.btnWatchRecord.Name = "btnWatchRecord";
            this.btnWatchRecord.Size = new System.Drawing.Size(194, 59);
            this.btnWatchRecord.TabIndex = 2;
            this.btnWatchRecord.Text = "Xem lại lịch sử";
            this.btnWatchRecord.UseVisualStyleBackColor = false;
            this.btnWatchRecord.Click += new System.EventHandler(this.btnWatchRecord_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExit.Location = new System.Drawing.Point(495, 304);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(194, 59);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPlayWithCom
            // 
            this.btnPlayWithCom.BackColor = System.Drawing.Color.White;
            this.btnPlayWithCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPlayWithCom.Location = new System.Drawing.Point(495, 44);
            this.btnPlayWithCom.Name = "btnPlayWithCom";
            this.btnPlayWithCom.Size = new System.Drawing.Size(194, 59);
            this.btnPlayWithCom.TabIndex = 0;
            this.btnPlayWithCom.Text = "Chơi với máy";
            this.btnPlayWithCom.UseVisualStyleBackColor = false;
            this.btnPlayWithCom.Click += new System.EventHandler(this.btnPlayWithCom_Click);
            // 
            // btnCoThe
            // 
            this.btnCoThe.BackColor = System.Drawing.Color.White;
            this.btnCoThe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCoThe.Location = new System.Drawing.Point(495, 174);
            this.btnCoThe.Name = "btnCoThe";
            this.btnCoThe.Size = new System.Drawing.Size(194, 59);
            this.btnCoThe.TabIndex = 4;
            this.btnCoThe.Text = "Cờ thế";
            this.btnCoThe.UseVisualStyleBackColor = false;
            this.btnCoThe.Click += new System.EventHandler(this.btnCoThe_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::CoCaro.Properties.Resources.caro_background;
            this.groupBox1.Location = new System.Drawing.Point(57, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 319);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(768, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCoThe);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWatchRecord);
            this.Controls.Add(this.btnPlayWithPlayer);
            this.Controls.Add(this.btnPlayWithCom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cờ Carô";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayWithCom;
        private System.Windows.Forms.Button btnPlayWithPlayer;
        private System.Windows.Forms.Button btnWatchRecord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCoThe;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

