namespace CoCaro.View.PlayWithCom
{
    partial class PlayWithComViewForm
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
            this.components = new System.ComponentModel.Container();
            this.timerTurn = new System.Windows.Forms.Timer(this.components);
            this.timerGameDuration = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerTurn
            // 
            this.timerTurn.Interval = 1000;
            // 
            // timerGameDuration
            // 
            this.timerGameDuration.Interval = 1000;
            // 
            // PlayWithComViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 961);
            this.Name = "PlayWithComViewForm";
            this.Text = "PlayWithComViewForm";
            this.Load += new System.EventHandler(this.PlayWithComViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerTurn;
        private System.Windows.Forms.Timer timerGameDuration;
    }
}