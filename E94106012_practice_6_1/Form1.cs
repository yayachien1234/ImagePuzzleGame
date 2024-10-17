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
            // ��pic9�ؼ����������
            //pic9 = pic9PictureBox; // ���� pic9PictureBox �����pic9�ؼ�������
            // ��ӵ���¼��������
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
            // ֹͣ��ʱ��
            timer1.Enabled = false;

            // ����ʱ����ʾ
            label1.Text = "Time: 00:00";

            // ���ò���
            steps = 0;
            min0 = 0;
            min1 = 0;
            num0 = 0;
            num1 = 0;
            label2.Text = "�ƄӲ���: 0";

            // ��ͣӋ�r��
            timer1.Interval = 1000;//(1��)



            // ���ͼƬ
            pictureBox1.Image = null;

            // ���ñ�����ɫ�Ϳɼ���
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Visible = true;

            // ���ñ�־����
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
            label2.Text = String.Format("�ƄӲ���:  {0}", steps);
            // ��ȡ�������Button��λ�ú�ͼ��
            Button clickedButton = (Button)sender;
            int clickedLeft = clickedButton.Left;
            int clickedTop = clickedButton.Top;
            Image clickedImage = clickedButton.Image;

            // �����Button��λ�ú�ͼ������Ϊpic9��λ�ú�ͼ��
            clickedButton.Left = pic9.Left;
            clickedButton.Top = pic9.Top;
            //clickedButton.Image = pic9.Image;

            // ��pic9��λ�ú�ͼ������Ϊ֮ǰ���Button��λ�ú�ͼ��
            pic9.Left = clickedLeft;
            pic9.Top = clickedTop;
            //pic9.Image = clickedImage;
            if (IsButtonsAtInitialPositions())
            {
                timer1.Enabled = false; // ֹͣ��ʱ��
                MessageBox.Show(String.Format("��@���ˣ�\n��ɕr�g: {0}{1}:{2}{3}\n�ƄӲ���{4}", min0, min1, num0, num1, steps), "", MessageBoxButtons.OK);
                Reset();
                for (int i = 0; i < pic.Length; i++)
                {
                    pic[i].Image = null; // ��հ�ť�ϵ�ͼ��
                }
            }
        }
        Button[] pic = new Button[9]; // ����һ��Button����
        private bool IsButtonsAtInitialPositions()
        {
            // ��鰴ť�Ƿ�ص���ʼλ��
            for (int i = 0; i < pic.Length; i++)
            {
                if (pic[i].Location != initialPositions[i])
                {
                    return false;
                }
            }
            return true;
        }
        //-------------�x��DƬ-------start---------------------------//
        private void button2_Click(object sender, EventArgs e)
        {

            String stFilter = "JPEG Files(*.jpg)|*.jpg";
            openFileDialog1.Filter = stFilter;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // ��ȡ��ѡ�ļ���·��
                imagePath = openFileDialog1.FileName;

                // ����ļ��Ƿ����
                if (File.Exists(imagePath))
                {
                    imageload = true;
                    // ʹ��Image�����ͼ���ļ�
                    Image image = Image.FromFile(imagePath);

                    // ����PictureBox��SizeMode����ΪAutoSize���Ա�ͼ���Զ�����Ϊ��PictureBox��Сһ��
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    // �����ص�ͼ����ʾ��PictureBox��
                    pictureBox1.Image = image;
                }
                else
                {
                    MessageBox.Show("ѡ����ļ������ڻ���Ч��");
                }
            }
        }
        //-------------�x��DƬ-------end---------------------------//

        //-------------�L�uƴ�D-------start---------------------------//
        private void button1_Click(object sender, EventArgs e)
        {
            if (imageload == false)
            {
                MessageBox.Show("Ո���x��DƬ", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                // ����ԭʼͼ��
                Image originalImage = Image.FromFile(imagePath);

                // ����һ���µ�600x600λͼ���洢�и��ľŹ���ͼ��
                Bitmap nineSliceImage = new Bitmap(600, 600);

                // ����һ��Graphics����������λͼ
                using (Graphics graphics = Graphics.FromImage(nineSliceImage))
                {
                    // ����ԭʼͼ������Ӧ600x600���صĴ�С
                    graphics.DrawImage(originalImage, new Rectangle(0, 0, 600, 600));
                }

                // �и��ľŹ����С
                int sliceWidth = 200;
                int sliceHeight = 200;

                // ����һ���������洢�Ÿ��и���ͼ��
                Image[] sliceImages = new Image[9];

                for (int i = 0; i < 9; i++)
                {
                    // ����һ���µ�Bitmap�������洢�и���ͼ��
                    Bitmap slice = new Bitmap(sliceWidth, sliceHeight);
                    using (Graphics g = Graphics.FromImage(slice))
                    {
                        g.DrawImage(nineSliceImage, new Rectangle(0, 0, sliceWidth, sliceHeight), new Rectangle((i % 3) * sliceWidth, (i / 3) * sliceHeight, sliceWidth, sliceHeight), GraphicsUnit.Pixel);
                    }

                    // �洢�и���ͼ��������
                    sliceImages[i] = slice;
                }

                // �ֱ��и���ͼ�������Ÿ�PictureBox
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
        //-------------�L�uƴ�D-------end---------------------------//

        //-------------�S�C��yƴ�D--------start--------------------//
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
                // ��ȡ�������Button��λ�ú�ͼ��
                int RandomNum1 = rnd.Next(0, 8);
                int RandomNum2 = rnd.Next(0, 8);
                int clickedLeft = pic[RandomNum1].Left;
                int clickedTop = pic[RandomNum1].Top;

                // �����Button��λ�ú�ͼ������Ϊpic9��λ�ú�ͼ��
                pic[RandomNum1].Left = pic[RandomNum2].Left;
                pic[RandomNum1].Top = pic[RandomNum2].Top;
                // ��pic9��λ�ú�ͼ������Ϊ֮ǰ���Button��λ�ú�ͼ��
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
                int currentValue = trackBar1.Value; // ��ȡTrackBar��ֵ

                // ����TrackBar��ֵȷ��ҪӦ�õĲ���
                if (currentValue <= trackBar1.Minimum + (trackBar1.Maximum - trackBar1.Minimum) / 2)
                {
                    // ���������ʱ����PictureBox�ı�����ɫ����ΪGray��ͼ������Ϊ���ɼ�
                    pictureBox1.BackColor = Color.Transparent;
                    pictureBox1.Visible = true;
                    button3.Visible = false;
                }
                else
                {
                    // �������ұ�ʱ����PictureBox�ı�����ɫ����Ϊ͸����ͼ������Ϊ�ɼ�
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