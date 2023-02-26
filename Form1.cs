using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace КГ_Лаб1_Фильтры
{
	public partial class Form1 : Form
	{
		
		Bitmap image;
		public Form1()
		{
			InitializeComponent();
		}

		private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//создаем диалог для открытия файла
			OpenFileDialog dailog = new OpenFileDialog();
			dailog.Filter = "Image files | *.png; *.jpg; *bmp | All Files (*.*) | *.*";
			if (dailog.ShowDialog() == DialogResult.OK)
			{
				image = new Bitmap(dailog.FileName);
				pictureBox1.Image = image;
				pictureBox1.Refresh();
				pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			}
		}

		private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new Invert();
			backgroundWorker1.RunWorkerAsync(filter);
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
			if (backgroundWorker1.CancellationPending != true)
				image = newImage;
		}

		// изменяет цвет полосы
		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		//визуализирует обработанное изображение на форме
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!e.Cancelled)
			{
				pictureBox1.Image = image;
				pictureBox1.Refresh();
			}
			progressBar1.Value = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			backgroundWorker1.CancelAsync();
		}

		private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Filters filter = new Blur();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new GaussianBlur();
			backgroundWorker1.RunWorkerAsync(filter);
		}
    }
}
