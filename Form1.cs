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

				pictureBox2.Image = image;
				pictureBox2.Refresh();
				pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void идеальныйОтражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new PerfectReflector(image);
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void линейноеРастяжениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new LinearStretch(image);
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new GrayWorld(image);
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void гаммакоррекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new AdjustGamma();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void чернобелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new GrayScaleFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Sepia();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void увеличениеЯркостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Brightness();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void расширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Extension();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void сужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Narrowing();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void операторСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new SobelOperator();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Sharpness();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Transfer();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Embossing();
			backgroundWorker1.RunWorkerAsync(filter);

		}

        private void выделениеГраницToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Borders();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void медианныйФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new MedianFilter();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void размытиеВДвиженииToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new MotionBlur();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void операторРобетсаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new RobertOperator();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void операторПревиттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new PrevittaOperator();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void светящиесяКраяToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new GlowingEdges(image);
			MedianFilter median = new MedianFilter();
			backgroundWorker1.RunWorkerAsync(filter);
			
		}

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Waves();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void эффектСтеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Glass();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void закрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Closing();
			backgroundWorker1.RunWorkerAsync(filter);
		}

        private void открытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Filters filter = new Opening();
			backgroundWorker1.RunWorkerAsync(filter);
		}
    }
}
