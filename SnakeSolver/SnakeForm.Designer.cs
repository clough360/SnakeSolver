namespace SnakeSolver
{
    partial class SnakeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.RunSimpleSolverButton = new System.Windows.Forms.Button();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.MovesLabel = new System.Windows.Forms.Label();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            this.GridContainer = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RunSimpleSolverButton);
            this.panel1.Controls.Add(this.ScoreLabel);
            this.panel1.Controls.Add(this.MovesLabel);
            this.panel1.Controls.Add(this.LeftButton);
            this.panel1.Controls.Add(this.RightButton);
            this.panel1.Controls.Add(this.DownButton);
            this.panel1.Controls.Add(this.UpButton);
            this.panel1.Controls.Add(this.RestartButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1359, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 1117);
            this.panel1.TabIndex = 0;
            // 
            // RunSimpleSolverButton
            // 
            this.RunSimpleSolverButton.Location = new System.Drawing.Point(17, 435);
            this.RunSimpleSolverButton.Name = "RunSimpleSolverButton";
            this.RunSimpleSolverButton.Size = new System.Drawing.Size(188, 58);
            this.RunSimpleSolverButton.TabIndex = 9;
            this.RunSimpleSolverButton.Text = "Simple";
            this.RunSimpleSolverButton.UseVisualStyleBackColor = true;
            this.RunSimpleSolverButton.Click += new System.EventHandler(this.RunSimpleSolverButton_Click);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(17, 69);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(92, 41);
            this.ScoreLabel.TabIndex = 8;
            this.ScoreLabel.Text = "Score";
            // 
            // MovesLabel
            // 
            this.MovesLabel.AutoSize = true;
            this.MovesLabel.Location = new System.Drawing.Point(17, 9);
            this.MovesLabel.Name = "MovesLabel";
            this.MovesLabel.Size = new System.Drawing.Size(106, 41);
            this.MovesLabel.TabIndex = 7;
            this.MovesLabel.Text = "Moves";
            // 
            // LeftButton
            // 
            this.LeftButton.Location = new System.Drawing.Point(141, 212);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(89, 58);
            this.LeftButton.TabIndex = 6;
            this.LeftButton.Text = "Left";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Location = new System.Drawing.Point(242, 212);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(89, 58);
            this.RightButton.TabIndex = 5;
            this.RightButton.Text = "Right";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Location = new System.Drawing.Point(190, 276);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(89, 58);
            this.DownButton.TabIndex = 4;
            this.DownButton.Text = "Down";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Location = new System.Drawing.Point(190, 148);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(89, 58);
            this.UpButton.TabIndex = 3;
            this.UpButton.Text = "Up";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(17, 371);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(188, 58);
            this.RestartButton.TabIndex = 2;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // GridContainer
            // 
            this.GridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridContainer.Location = new System.Drawing.Point(0, 0);
            this.GridContainer.Name = "GridContainer";
            this.GridContainer.Size = new System.Drawing.Size(1359, 1117);
            this.GridContainer.TabIndex = 1;
            this.GridContainer.TabStop = false;
            this.GridContainer.Click += new System.EventHandler(this.RestartButton_Click);
            this.GridContainer.Resize += new System.EventHandler(this.GridContainer_Resize);
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1859, 1117);
            this.Controls.Add(this.GridContainer);
            this.Controls.Add(this.panel1);
            this.Name = "SnakeForm";
            this.Text = "SnakeForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private PictureBox GridContainer;
        private Button RestartButton;
        private Button LeftButton;
        private Button RightButton;
        private Button DownButton;
        private Button UpButton;
        private Label ScoreLabel;
        private Label MovesLabel;
        private Button RunSimpleSolverButton;
    }
}