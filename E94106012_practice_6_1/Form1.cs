using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Drawing.Imaging;

namespace E94106012_practice_6_1
{
    public partial class Form1 : Form
    {

        int steps;
        private Point[] initialPositions;
        public Form1()
        {

            InitializeComponent();
            // 将pic9控件分配给变量
            //pic9 = pic9PictureBox; // 假设 pic9PictureBox 是你的pic9控件的名称
            // 添加点击事件处理程序
            pic1.Click += Button_Click;
            pic2.Click += Button_Click;
            pic3.Click += Button_Click;
            pic4.Click += Button_Click;
            pic5.Click += Button_Click;
            pic6.Click += Button_Click;
            pic7.Click += Button_Click;
            pic8.Click += Button_Click;
            pic9.Click += Button_Click;
            initialPositions = new Point[]
            {
                pic1.Location,
                pic2.Location,
                pic3.Location,
                pic4.Location,
                pic5.Location,
                pic6.Location,
                pic7.Location,
                pic8.Location,
                pic9.Location
            };
        }
        int min0, min1, num0, num1;
        bool imageload = false;

        private void Reset()
        {
            button3.Visible = false;
            // 停止计时器
            timer1.Enabled = false;

            // 重置时间显示
            label1.Text = "Time: 00:00";

            // 重置步数
            steps = 0;
            min0 = 0;
            min1 = 0;
            num0 = 0;
            num1 = 0;
            label2.Text = "移動步數: 0";

            // 暫停計時器
            timer1.Interval = 1000;//(1秒)



            // 清空图片
            pictureBox1.Image = null;

            // 重置背景颜色和可见性
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Visible = true;

            // 重置标志变量
            imageload = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            steps = 0;
        }
        string imagePath = "";
        private void Button_Click(object sender, EventArgs e)
        {
            steps++;
            label2.Text = String.Format("移動步數:  {0}", steps);
            // 获取被点击的Button的位置和图像
            Button clickedButton = (Button)sender;
            int clickedLeft = clickedButton.Left;
            int clickedTop = clickedButton.Top;
            Image clickedImage = clickedButton.Image;

            // 将点击Button的位置和图像设置为pic9的位置和图像
            clickedButton.Left = pic9.Left;
            clickedButton.Top = pic9.Top;
            //clickedButton.Image = pic9.Image;

            // 将pic9的位置和图像设置为之前点击Button的位置和图像
            pic9.Left = clickedLeft;
            pic9.Top = clickedTop;
            //pic9.Image = clickedImage;
            if (IsButtonsAtInitialPositions())
            {
                timer1.Enabled = false; // 停止计时器
                MessageBox.Show(String.Format("你獲勝了！\n完成時間: {0}{1}:{2}{3}\n移動步數{4}", min0, min1, num0, num1, steps), "", MessageBoxButtons.OK);
                Reset();
                for (int i = 0; i < pic.Length; i++)
                {
                    pic[i].Image = null; // 清空按钮上的图像
                }
            }
        }
        Button[] pic = new Button[9]; // 定义一个Button数组
        private bool IsButtonsAtInitialPositions()
        {
            // 检查按钮是否回到初始位置
            for (int i = 0; i < pic.Length; i++)
            {
                if (pic[i].Location != initialPositions[i])
                {
                    return false;
                }
            }
            return true;
        }
        //-------------選擇圖片-------start---------------------------//
        private void button2_Click(object sender, EventArgs e)
        {

            String stFilter = "JPEG Files(*.jpg)|*.jpg";
            openFileDialog1.Filter = stFilter;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 获取所选文件的路径
                imagePath = openFileDialog1.FileName;

                // 检查文件是否存在
                if (File.Exists(imagePath))
                {
                    imageload = true;
                    // 使用Image类加载图像文件
                    Image image = Image.FromFile(imagePath);

                    // 设置PictureBox的SizeMode属性为AutoSize，以便图像自动调整为与PictureBox大小一致
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    // 将加载的图像显示在PictureBox中
                    pictureBox1.Image = image;
                }
                else
                {
                    MessageBox.Show("选择的文件不存在或无效。");
                }
            }
        }
        //-------------選擇圖片-------end---------------------------//

        //-------------繪製拼圖-------start---------------------------//
        private void button1_Click(object sender, EventArgs e)
        {
            if (imageload == false)
            {
                MessageBox.Show("請先選擇圖片", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                // 加载原始图像
                Image originalImage = Image.FromFile(imagePath);

                // 创建一个新的600x600位图来存储切割后的九宫格图像
                Bitmap nineSliceImage = new Bitmap(600, 600);

                // 创建一个Graphics对象来操作位图
                using (Graphics graphics = Graphics.FromImage(nineSliceImage))
                {
                    // 缩放原始图像以适应600x600像素的大小
                    graphics.DrawImage(originalImage, new Rectangle(0, 0, 600, 600));
                }

                // 切割后的九宫格大小
                int sliceWidth = 200;
                int sliceHeight = 200;

                // 创建一个数组来存储九个切割后的图像
                Image[] sliceImages = new Image[9];

                for (int i = 0; i < 9; i++)
                {
                    // 创建一个新的Bitmap对象来存储切割后的图像
                    Bitmap slice = new Bitmap(sliceWidth, sliceHeight);
                    using (Graphics g = Graphics.FromImage(slice))
                    {
                        g.DrawImage(nineSliceImage, new Rectangle(0, 0, sliceWidth, sliceHeight), new Rectangle((i % 3) * sliceWidth, (i / 3) * sliceHeight, sliceWidth, sliceHeight), GraphicsUnit.Pixel);
                    }

                    // 存储切割后的图像到数组中
                    sliceImages[i] = slice;
                }

                // 分别将切割后的图像分配给九个PictureBox
                pic1.Image = sliceImages[0];
                pic2.Image = sliceImages[1];
                pic3.Image = sliceImages[2];
                pic4.Image = sliceImages[3];
                pic5.Image = sliceImages[4];
                pic6.Image = sliceImages[5];
                pic7.Image = sliceImages[6];
                pic8.Image = sliceImages[7];
                pic9.Image = sliceImages[8];
                get_messed(sender, e);
                timer1.Enabled = true;
            }


        }
        //-------------繪製拼圖-------end---------------------------//

        //-------------隨機打亂拼圖--------start--------------------//
        private void get_messed(object sender, EventArgs e)
        {

            pic[0] = pic1;
            pic[1] = pic2;
            pic[2] = pic3;
            pic[3] = pic4;
            pic[4] = pic5;
            pic[5] = pic6;
            pic[6] = pic7;
            pic[7] = pic8;
            pic[8] = pic9;
            Random rnd = new Random();
            int RandomNum0 = 200;


            for (int i = 0; i < RandomNum0; i++)
            {
                // 获取被点击的Button的位置和图像
                int RandomNum1 = rnd.Next(0, 8);
                int RandomNum2 = rnd.Next(0, 8);
                int clickedLeft = pic[RandomNum1].Left;
                int clickedTop = pic[RandomNum1].Top;

                // 将点击Button的位置和图像设置为pic9的位置和图像
                pic[RandomNum1].Left = pic[RandomNum2].Left;
                pic[RandomNum1].Top = pic[RandomNum2].Top;
                // 将pic9的位置和图像设置为之前点击Button的位置和图像
                pic[RandomNum2].Left = clickedLeft;
                pic[RandomNum2].Top = clickedTop;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = String.Format("Time: {0}{1}:{2}{3}", min0, min1, num0, num1);

            num1++;
            if (min1 == 10)
            {
                min1 -= 10;
                min0++;
            }
            else
            {
                if (num0 == 6)
                {
                    num0 -= 6;
                    min1++;
                }
                else
                {
                    if (num1 == 10)
                    {
                        num1 -= 10;
                        num0++;
                    }
                }
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pic1_Click(object sender, EventArgs e)
        {

        }
        private void pic2_Click(object sender, EventArgs e)
        {

        }
        private void pic3_Click(object sender, EventArgs e)
        {

        }

        private void pic4_Click(object sender, EventArgs e)
        {

        }

        private void pic5_Click(object sender, EventArgs e)
        {

        }

        private void pic6_Click(object sender, EventArgs e)
        {

        }

        private void pic7_Click(object sender, EventArgs e)
        {

        }

        private void pic8_Click(object sender, EventArgs e)
        {

        }

        private void pic9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                int currentValue = trackBar1.Value; // 获取TrackBar的值

                // 根据TrackBar的值确定要应用的操作
                if (currentValue <= trackBar1.Minimum + (trackBar1.Maximum - trackBar1.Minimum) / 2)
                {
                    // 当滚到左边时，将PictureBox的背景颜色设置为Gray，图像设置为不可见
                    pictureBox1.BackColor = Color.Transparent;
                    pictureBox1.Visible = true;
                    button3.Visible = false;
                }
                else
                {
                    // 当滚到右边时，将PictureBox的背景颜色设置为透明，图像设置为可见
                    pictureBox1.BackColor = Color.Gray;
                    pictureBox1.Visible = false;
                    button3.Visible = true;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}