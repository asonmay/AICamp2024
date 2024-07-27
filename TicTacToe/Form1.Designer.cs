namespace TicTacToe
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
            components = new System.ComponentModel.Container();
            buttonA = new Button();
            buttonH = new Button();
            buttonE = new Button();
            buttonG = new Button();
            buttonD = new Button();
            buttonC = new Button();
            buttonB = new Button();
            buttonI = new Button();
            buttonF = new Button();
            panel1 = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            ResetButton = new Button();
            GameOverLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonA
            // 
            buttonA.BackColor = Color.White;
            buttonA.FlatStyle = FlatStyle.Flat;
            buttonA.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            buttonA.Location = new Point(-2, -2);
            buttonA.Name = "buttonA";
            buttonA.Size = new Size(75, 75);
            buttonA.TabIndex = 0;
            buttonA.UseVisualStyleBackColor = false;
            buttonA.Click += buttonA_Click;
            // 
            // buttonH
            // 
            buttonH.BackColor = Color.White;
            buttonH.FlatStyle = FlatStyle.Flat;
            buttonH.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            buttonH.Location = new Point(81, 163);
            buttonH.Name = "buttonH";
            buttonH.Size = new Size(75, 75);
            buttonH.TabIndex = 1;
            buttonH.UseVisualStyleBackColor = false;
            buttonH.Click += buttonH_Click;
            // 
            // buttonE
            // 
            buttonE.BackColor = Color.White;
            buttonE.FlatStyle = FlatStyle.Flat;
            buttonE.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            buttonE.Location = new Point(81, 81);
            buttonE.Name = "buttonE";
            buttonE.Size = new Size(75, 75);
            buttonE.TabIndex = 2;
            buttonE.UseVisualStyleBackColor = false;
            buttonE.Click += buttonE_Click;
            // 
            // buttonG
            // 
            buttonG.BackColor = Color.White;
            buttonG.FlatStyle = FlatStyle.Flat;
            buttonG.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            buttonG.Location = new Point(-2, 163);
            buttonG.Name = "buttonG";
            buttonG.Size = new Size(75, 75);
            buttonG.TabIndex = 3;
            buttonG.UseVisualStyleBackColor = false;
            buttonG.Click += button4_Click;
            // 
            // buttonD
            // 
            buttonD.BackColor = Color.White;
            buttonD.FlatStyle = FlatStyle.Flat;
            buttonD.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            buttonD.Location = new Point(-2, 81);
            buttonD.Name = "buttonD";
            buttonD.Size = new Size(75, 75);
            buttonD.TabIndex = 4;
            buttonD.UseVisualStyleBackColor = false;
            buttonD.Click += buttonD_Click;
            // 
            // buttonC
            // 
            buttonC.BackColor = Color.White;
            buttonC.FlatStyle = FlatStyle.Flat;
            buttonC.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            buttonC.Location = new Point(163, -2);
            buttonC.Name = "buttonC";
            buttonC.Size = new Size(75, 75);
            buttonC.TabIndex = 5;
            buttonC.UseVisualStyleBackColor = false;
            buttonC.Click += buttonC_Click;
            // 
            // buttonB
            // 
            buttonB.BackColor = Color.White;
            buttonB.FlatStyle = FlatStyle.Flat;
            buttonB.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            buttonB.Location = new Point(81, -2);
            buttonB.Name = "buttonB";
            buttonB.Size = new Size(75, 75);
            buttonB.TabIndex = 6;
            buttonB.UseVisualStyleBackColor = false;
            buttonB.Click += buttonB_Click;
            // 
            // buttonI
            // 
            buttonI.BackColor = Color.White;
            buttonI.FlatStyle = FlatStyle.Flat;
            buttonI.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            buttonI.Location = new Point(163, 163);
            buttonI.Name = "buttonI";
            buttonI.Size = new Size(75, 75);
            buttonI.TabIndex = 7;
            buttonI.UseVisualStyleBackColor = false;
            buttonI.Click += buttonI_Click;
            // 
            // buttonF
            // 
            buttonF.BackColor = Color.White;
            buttonF.FlatStyle = FlatStyle.Flat;
            buttonF.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            buttonF.Location = new Point(163, 81);
            buttonF.Name = "buttonF";
            buttonF.Size = new Size(75, 75);
            buttonF.TabIndex = 8;
            buttonF.UseVisualStyleBackColor = false;
            buttonF.Click += buttonF_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(buttonA);
            panel1.Controls.Add(buttonF);
            panel1.Controls.Add(buttonH);
            panel1.Controls.Add(buttonI);
            panel1.Controls.Add(buttonE);
            panel1.Controls.Add(buttonB);
            panel1.Controls.Add(buttonG);
            panel1.Controls.Add(buttonC);
            panel1.Controls.Add(buttonD);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 236);
            panel1.TabIndex = 9;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 17;
            timer1.Tick += timer1_Tick;
            // 
            // ResetButton
            // 
            ResetButton.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ResetButton.Location = new Point(12, 302);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(238, 34);
            ResetButton.TabIndex = 10;
            ResetButton.Text = "Reset Board";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // GameOverLabel
            // 
            GameOverLabel.AutoSize = true;
            GameOverLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GameOverLabel.Location = new Point(87, 261);
            GameOverLabel.Name = "GameOverLabel";
            GameOverLabel.Size = new Size(0, 30);
            GameOverLabel.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(262, 348);
            Controls.Add(GameOverLabel);
            Controls.Add(ResetButton);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonA;
        private Button buttonH;
        private Button buttonE;
        private Button buttonG;
        private Button buttonD;
        private Button buttonC;
        private Button buttonB;
        private Button buttonI;
        private Button buttonF;
        private Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private Button ResetButton;
        private Label GameOverLabel;
    }
}
