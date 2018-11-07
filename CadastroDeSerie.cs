using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Random_Fun_Draw
{
	public class CadastroDeSerie : Form
	{
		private IContainer components;

		private Panel panel1;

		private TextBox txtSerie;

		private Label label1;

		private Button btnSalvarSerie;

		public CadastroDeSerie()
		{
			InitializeComponent();
		}

		private void btnSalvarSerie_Click(object sender, EventArgs e)
		{
			new Conexao().SalvarSerie(txtSerie.Text);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CadastroDeSerie));
			panel1 = new Panel();
			txtSerie = new TextBox();
			label1 = new Label();
			btnSalvarSerie = new Button();
			panel1.SuspendLayout();
			base.SuspendLayout();
			panel1.BorderStyle = BorderStyle.Fixed3D;
			panel1.Controls.Add(txtSerie);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(12, 12);
			panel1.Name = "panel1";
			panel1.Size = new Size(260, 73);
			panel1.TabIndex = 0;
			txtSerie.Location = new Point(55, 26);
			txtSerie.Name = "txtSerie";
			txtSerie.Size = new Size(186, 20);
			txtSerie.TabIndex = 1;
			label1.AutoSize = true;
			label1.Location = new Point(14, 29);
			label1.Name = "label1";
			label1.Size = new Size(35, 13);
			label1.TabIndex = 0;
			label1.Text = "Nome";
			btnSalvarSerie.Location = new Point(197, 91);
			btnSalvarSerie.Name = "btnSalvarSerie";
			btnSalvarSerie.Size = new Size(75, 23);
			btnSalvarSerie.TabIndex = 1;
			btnSalvarSerie.Text = "Salvar";
			btnSalvarSerie.UseVisualStyleBackColor = true;
			btnSalvarSerie.Click += btnSalvarSerie_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(284, 124);
			base.Controls.Add(btnSalvarSerie);
			base.Controls.Add(panel1);
			//base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "CadastroDeSerie";
			Text = "CadastroDeSerie";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
