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
            this.SuspendLayout();
            // 
            // btnPlayWithPlayer
            // 
            this.btnPlayWithPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPlayWithPlayer.Location = new System.Drawing.Point(219, 213);
            this.btnPlayWithPlayer.Name = "btnPlayWithPlayer";
            this.btnPlayWithPlayer.Size = new System.Drawing.Size(194, 59);
            this.btnPlayWithPlayer.TabIndex = 1;
            this.btnPlayWithPlayer.Text = "Chơi với người";
            this.btnPlayWithPlayer.UseVisualStyleBackColor = true;
            this.btnPlayWithPlayer.Click += new System.EventHandler(this.btnPlayWithPlayer_Click);
            // 
            // btnWatchRecord
            // 
            this.btnWatchRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnWatchRecord.Location = new System.Drawing.Point(219, 288);
            this.btnWatchRecord.Name = "btnWatchRecord";
            this.btnWatchRecord.Size = new System.Drawing.Size(194, 59);
            this.btnWatchRecord.TabIndex = 2;
            this.btnWatchRecord.Text = "Xem lại lịch sử";
            this.btnWatchRecord.UseVisualStyleBackColor = true;
            this.btnWatchRecord.Click += new System.EventHandler(this.btnWatchRecord_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExit.Location = new System.Drawing.Point(219, 363);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(194, 59);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPlayWithCom
            // 
            this.btnPlayWithCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPlayWithCom.Location = new System.Drawing.Point(219, 145);
            this.btnPlayWithCom.Name = "btnPlayWithCom";
            this.btnPlayWithCom.Size = new System.Drawing.Size(194, 59);
            this.btnPlayWithCom.TabIndex = 0;
            this.btnPlayWithCom.Text = "Chơi với máy";
            this.btnPlayWithCom.UseVisualStyleBackColor = true;
            this.btnPlayWithCom.Click += new System.EventHandler(this.btnPlayWithCom_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 484);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWatchRecord);
            this.Controls.Add(this.btnPlayWithPlayer);
            this.Controls.Add(this.btnPlayWithCom);
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
    }
}

