namespace E94106012_practice_6_1
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
            button1 = new Button();
            button2 = new Button();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            pic1 = new Button();
            pic2 = new Button();
            pic3 = new Button();
            pic4 = new Button();
            pic5 = new Button();
            pic6 = new Button();
            pic7 = new Button();
            pic8 = new Button();
            pic9 = new Button();
            label1 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            trackBar1 = new TrackBar();
            label3 = new Label();
            label4 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(220, 769);
            button1.Name = "button1";
            button1.Size = new Size(531, 42);
            button1.TabIndex = 0;
            button1.Text = "繪製拼圖板";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1107, 769);
            button2.Name = "button2";
            button2.Size = new Size(531, 42);
            button2.TabIndex = 1;
            button2.Text = "選擇圖片";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(1065, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 600);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pic1
            // 
            pic1.Location = new Point(176, 87);
            pic1.Name = "pic1";
            pic1.Size = new Size(200, 200);
            pic1.TabIndex = 3;
            pic1.UseVisualStyleBackColor = true;
            pic1.Click += pic1_Click;
            // 
            // pic2
            // 
            pic2.Location = new Point(380, 87);
            pic2.Name = "pic2";
            pic2.Size = new Size(200, 200);
            pic2.TabIndex = 4;
            pic2.UseVisualStyleBackColor = true;
            pic2.Click += pic2_Click;
            // 
            // pic3
            // 
            pic3.Location = new Point(585, 87);
            pic3.Name = "pic3";
            pic3.Size = new Size(200, 200);
            pic3.TabIndex = 5;
            pic3.UseVisualStyleBackColor = true;
            pic3.Click += pic3_Click;
            // 
            // pic4
            // 
            pic4.Location = new Point(176, 290);
            pic4.Name = "pic4";
            pic4.Size = new Size(200, 200);
            pic4.TabIndex = 6;
            pic4.UseVisualStyleBackColor = true;
            pic4.Click += pic4_Click;
            // 
            // pic5
            // 
            pic5.Location = new Point(380, 290);
            pic5.Name = "pic5";
            pic5.Size = new Size(200, 200);
            pic5.TabIndex = 7;
            pic5.UseVisualStyleBackColor = true;
            pic5.Click += pic5_Click;
            // 
            // pic6
            // 
            pic6.Location = new Point(585, 290);
            pic6.Name = "pic6";
            pic6.Size = new Size(200, 200);
            pic6.TabIndex = 8;
            pic6.UseVisualStyleBackColor = true;
            pic6.Click += pic6_Click;
            // 
            // pic7
            // 
            pic7.Location = new Point(176, 495);
            pic7.Name = "pic7";
            pic7.Size = new Size(200, 200);
            pic7.TabIndex = 9;
            pic7.UseVisualStyleBackColor = true;
            pic7.Click += pic7_Click;
            // 
            // pic8
            // 
            pic8.Location = new Point(380, 495);
            pic8.Name = "pic8";
            pic8.Size = new Size(200, 200);
            pic8.TabIndex = 10;
            pic8.UseVisualStyleBackColor = true;
            pic8.Click += pic8_Click;
            // 
            // pic9
            // 
            pic9.Location = new Point(585, 496);
            pic9.Name = "pic9";
            pic9.Size = new Size(200, 200);
            pic9.TabIndex = 11;
            pic9.UseVisualStyleBackColor = true;
            pic9.Visible = false;
            pic9.Click += pic9_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(889, 208);
            label1.Name = "label1";
            label1.Size = new Size(116, 24);
            label1.TabIndex = 12;
            label1.Text = "Timer: 00:00";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(889, 299);
            label2.Name = "label2";
            label2.Size = new Size(103, 24);
            label2.TabIndex = 13;
            label2.Text = "移動步數  0";
            label2.Click += label2_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(1223, 694);
            trackBar1.Maximum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.RightToLeft = RightToLeft.Yes;
            trackBar1.Size = new Size(308, 69);
            trackBar1.TabIndex = 14;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1551, 694);
            label3.Name = "label3";
            label3.Size = new Size(46, 24);
            label3.TabIndex = 15;
            label3.Text = "顯示";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1160, 694);
            label4.Name = "label4";
            label4.Size = new Size(64, 24);
            label4.TabIndex = 16;
            label4.Text = "不顯示";
            label4.Click += label4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Gray;
            button3.Location = new Point(1065, 87);
            button3.Name = "button3";
            button3.Size = new Size(600, 600);
            button3.TabIndex = 17;
            button3.UseVisualStyleBackColor = false;
            button3.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1832, 888);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(trackBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pic9);
            Controls.Add(pic8);
            Controls.Add(pic7);
            Controls.Add(pic6);
            Controls.Add(pic5);
            Controls.Add(pic4);
            Controls.Add(pic3);
            Controls.Add(pic2);
            Controls.Add(pic1);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private Button pic1;
        private Button pic2;
        private Button pic3;
        private Button pic4;
        private Button pic5;
        private Button pic6;
        private Button pic7;
        private Button pic8;
        private Button pic9;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private TrackBar trackBar1;
        private Label label3;
        private Label label4;
        private Button button3;
    }
}