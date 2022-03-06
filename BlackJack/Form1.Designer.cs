namespace BlackJack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dealerDisplay = new System.Windows.Forms.RichTextBox();
            this.playerDisplay = new System.Windows.Forms.RichTextBox();
            this.eventDisplay = new System.Windows.Forms.RichTextBox();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnBet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.betInput = new System.Windows.Forms.TextBox();
            this.pointsDisplay = new System.Windows.Forms.Label();
            this.cashDisplay = new System.Windows.Forms.Label();
            this.dealerPoints = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dealerDisplay
            // 
            this.dealerDisplay.Location = new System.Drawing.Point(307, 80);
            this.dealerDisplay.Name = "dealerDisplay";
            this.dealerDisplay.ReadOnly = true;
            this.dealerDisplay.Size = new System.Drawing.Size(216, 83);
            this.dealerDisplay.TabIndex = 0;
            this.dealerDisplay.Text = "";
            // 
            // playerDisplay
            // 
            this.playerDisplay.Location = new System.Drawing.Point(307, 212);
            this.playerDisplay.Name = "playerDisplay";
            this.playerDisplay.ReadOnly = true;
            this.playerDisplay.Size = new System.Drawing.Size(216, 83);
            this.playerDisplay.TabIndex = 1;
            this.playerDisplay.Text = "";
            // 
            // eventDisplay
            // 
            this.eventDisplay.Location = new System.Drawing.Point(32, 76);
            this.eventDisplay.Name = "eventDisplay";
            this.eventDisplay.ReadOnly = true;
            this.eventDisplay.Size = new System.Drawing.Size(181, 302);
            this.eventDisplay.TabIndex = 2;
            this.eventDisplay.Text = "";
            // 
            // btnHit
            // 
            this.btnHit.BackColor = System.Drawing.Color.Silver;
            this.btnHit.Cursor = System.Windows.Forms.Cursors.No;
            this.btnHit.Enabled = false;
            this.btnHit.Location = new System.Drawing.Point(594, 76);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(99, 51);
            this.btnHit.TabIndex = 3;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = false;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // btnStand
            // 
            this.btnStand.BackColor = System.Drawing.Color.Silver;
            this.btnStand.Cursor = System.Windows.Forms.Cursors.No;
            this.btnStand.Enabled = false;
            this.btnStand.Location = new System.Drawing.Point(594, 143);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(99, 51);
            this.btnStand.TabIndex = 4;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = false;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // btnBet
            // 
            this.btnBet.BackColor = System.Drawing.Color.Silver;
            this.btnBet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBet.Location = new System.Drawing.Point(594, 212);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(99, 51);
            this.btnBet.TabIndex = 5;
            this.btnBet.Text = "Bet";
            this.btnBet.UseVisualStyleBackColor = false;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(586, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bet:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(586, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Points:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(586, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cash: ";
            // 
            // betInput
            // 
            this.betInput.Location = new System.Drawing.Point(655, 311);
            this.betInput.Name = "betInput";
            this.betInput.Size = new System.Drawing.Size(47, 23);
            this.betInput.TabIndex = 10;
            // 
            // pointsDisplay
            // 
            this.pointsDisplay.AutoSize = true;
            this.pointsDisplay.Location = new System.Drawing.Point(655, 338);
            this.pointsDisplay.Name = "pointsDisplay";
            this.pointsDisplay.Size = new System.Drawing.Size(65, 15);
            this.pointsDisplay.TabIndex = 11;
            this.pointsDisplay.Text = "labelPoints";
            // 
            // cashDisplay
            // 
            this.cashDisplay.AutoSize = true;
            this.cashDisplay.Location = new System.Drawing.Point(655, 363);
            this.cashDisplay.Name = "cashDisplay";
            this.cashDisplay.Size = new System.Drawing.Size(58, 15);
            this.cashDisplay.TabIndex = 12;
            this.cashDisplay.Text = "labelCash";
            // 
            // dealerPoints
            // 
            this.dealerPoints.AutoSize = true;
            this.dealerPoints.Location = new System.Drawing.Point(379, 51);
            this.dealerPoints.Name = "dealerPoints";
            this.dealerPoints.Size = new System.Drawing.Size(72, 15);
            this.dealerPoints.TabIndex = 13;
            this.dealerPoints.Text = "dealerPoints";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BlackJack.Properties.Resources.greenfelt;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dealerPoints);
            this.Controls.Add(this.cashDisplay);
            this.Controls.Add(this.pointsDisplay);
            this.Controls.Add(this.betInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBet);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.eventDisplay);
            this.Controls.Add(this.playerDisplay);
            this.Controls.Add(this.dealerDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox dealerDisplay;
        private RichTextBox playerDisplay;
        private RichTextBox eventDisplay;
        private Button btnHit;
        private Button btnStand;
        private Button btnBet;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox betInput;
        private Label pointsDisplay;
        private Label cashDisplay;
        private Label dealerPoints;
    }
}