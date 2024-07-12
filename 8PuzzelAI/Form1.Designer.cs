namespace _8PuzzelAI
{
    partial class Form1
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
            this.Square11 = new System.Windows.Forms.Button();
            this.Square23 = new System.Windows.Forms.Button();
            this.Square22 = new System.Windows.Forms.Button();
            this.Square32 = new System.Windows.Forms.Button();
            this.Square31 = new System.Windows.Forms.Button();
            this.Square13 = new System.Windows.Forms.Button();
            this.Square21 = new System.Windows.Forms.Button();
            this.Square12 = new System.Windows.Forms.Button();
            this.Square33 = new System.Windows.Forms.Button();
            this.SolveButton = new System.Windows.Forms.Button();
            this.ScrambleButon = new System.Windows.Forms.Button();
            this.VisualizerTImer = new System.Windows.Forms.Timer(this.components);
            this.NumOfMoves = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Square11
            // 
            this.Square11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Square11.Location = new System.Drawing.Point(12, 12);
            this.Square11.Name = "Square11";
            this.Square11.Size = new System.Drawing.Size(100, 100);
            this.Square11.TabIndex = 0;
            this.Square11.Text = "1";
            this.Square11.UseVisualStyleBackColor = true;
            // 
            // Square23
            // 
            this.Square23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Square23.Location = new System.Drawing.Point(224, 118);
            this.Square23.Name = "Square23";
            this.Square23.Size = new System.Drawing.Size(100, 100);
            this.Square23.TabIndex = 1;
            this.Square23.Text = "6";
            this.Square23.UseVisualStyleBackColor = true;
            // 
            // Square22
            // 
            this.Square22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Square22.Location = new System.Drawing.Point(118, 118);
            this.Square22.Name = "Square22";
            this.Square22.Size = new System.Drawing.Size(100, 100);
            this.Square22.TabIndex = 2;
            this.Square22.Text = "5";
            this.Square22.UseVisualStyleBackColor = true;
            // 
            // Square32
            // 
            this.Square32.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Square32.Location = new System.Drawing.Point(118, 224);
            this.Square32.Name = "Square32";
            this.Square32.Size = new System.Drawing.Size(100, 100);
            this.Square32.TabIndex = 3;
            this.Square32.Text = "8";
            this.Square32.UseVisualStyleBackColor = true;
            // 
            // Square31
            // 
            this.Square31.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Square31.Location = new System.Drawing.Point(12, 224);
            this.Square31.Name = "Square31";
            this.Square31.Size = new System.Drawing.Size(100, 100);
            this.Square31.TabIndex = 4;
            this.Square31.Text = "7";
            this.Square31.UseVisualStyleBackColor = true;
            // 
            // Square13
            // 
            this.Square13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Square13.Location = new System.Drawing.Point(224, 12);
            this.Square13.Name = "Square13";
            this.Square13.Size = new System.Drawing.Size(100, 100);
            this.Square13.TabIndex = 5;
            this.Square13.Text = "3";
            this.Square13.UseVisualStyleBackColor = true;
            this.Square13.Click += new System.EventHandler(this.Square13_Click);
            // 
            // Square21
            // 
            this.Square21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Square21.Location = new System.Drawing.Point(12, 118);
            this.Square21.Name = "Square21";
            this.Square21.Size = new System.Drawing.Size(100, 100);
            this.Square21.TabIndex = 6;
            this.Square21.Text = "4";
            this.Square21.UseVisualStyleBackColor = true;
            // 
            // Square12
            // 
            this.Square12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Square12.Location = new System.Drawing.Point(118, 12);
            this.Square12.Name = "Square12";
            this.Square12.Size = new System.Drawing.Size(100, 100);
            this.Square12.TabIndex = 7;
            this.Square12.Text = "2";
            this.Square12.UseVisualStyleBackColor = true;
            // 
            // Square33
            // 
            this.Square33.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Square33.Location = new System.Drawing.Point(224, 224);
            this.Square33.Name = "Square33";
            this.Square33.Size = new System.Drawing.Size(100, 100);
            this.Square33.TabIndex = 8;
            this.Square33.UseVisualStyleBackColor = true;
            // 
            // SolveButton
            // 
            this.SolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolveButton.Location = new System.Drawing.Point(172, 330);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(152, 37);
            this.SolveButton.TabIndex = 9;
            this.SolveButton.Text = "Solve";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // ScrambleButon
            // 
            this.ScrambleButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScrambleButon.Location = new System.Drawing.Point(12, 330);
            this.ScrambleButon.Name = "ScrambleButon";
            this.ScrambleButon.Size = new System.Drawing.Size(154, 37);
            this.ScrambleButon.TabIndex = 10;
            this.ScrambleButon.Text = "Scramble";
            this.ScrambleButon.UseVisualStyleBackColor = true;
            this.ScrambleButon.Click += new System.EventHandler(this.button1_Click);
            // 
            // VisualizerTImer
            // 
            this.VisualizerTImer.Interval = 500;
            this.VisualizerTImer.Tick += new System.EventHandler(this.VisualizerTImer_Tick);
            // 
            // NumOfMoves
            // 
            this.NumOfMoves.AutoSize = true;
            this.NumOfMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfMoves.Location = new System.Drawing.Point(12, 370);
            this.NumOfMoves.Name = "NumOfMoves";
            this.NumOfMoves.Size = new System.Drawing.Size(71, 24);
            this.NumOfMoves.TabIndex = 11;
            this.NumOfMoves.Text = "Moves:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 397);
            this.Controls.Add(this.NumOfMoves);
            this.Controls.Add(this.ScrambleButon);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.Square33);
            this.Controls.Add(this.Square12);
            this.Controls.Add(this.Square21);
            this.Controls.Add(this.Square13);
            this.Controls.Add(this.Square31);
            this.Controls.Add(this.Square32);
            this.Controls.Add(this.Square22);
            this.Controls.Add(this.Square23);
            this.Controls.Add(this.Square11);
            this.Name = "Form1";
            this.Text = "8 Puzzel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Square11;
        private System.Windows.Forms.Button Square23;
        private System.Windows.Forms.Button Square22;
        private System.Windows.Forms.Button Square32;
        private System.Windows.Forms.Button Square31;
        private System.Windows.Forms.Button Square13;
        private System.Windows.Forms.Button Square21;
        private System.Windows.Forms.Button Square12;
        private System.Windows.Forms.Button Square33;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.Button ScrambleButon;
        private System.Windows.Forms.Timer VisualizerTImer;
        private System.Windows.Forms.Label NumOfMoves;
    }
}

