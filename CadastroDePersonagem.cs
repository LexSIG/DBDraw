using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Random_Fun_Draw
{
	public class CadastroDePersonagem : Form
	{
		private Conexao conexao = new Conexao();

		private IContainer components;

		private Panel panel1;

		private Label label2;

		private TextBox txtNome;

		private Label label1;

		private Label label3;

		private ComboBox cbxSerie;

		private TextBox txtRaca;

		private Button btnSalvarPersona;

		public CadastroDePersonagem()
		{
			InitializeComponent();
		}

		private void CadastroDePersonagem_Load(object sender, EventArgs e)
		{
			cbxSerie.DataSource = conexao.buscarSeries();
			cbxSerie.DisplayMember = "Nome";
			cbxSerie.ValueMember = "Codigo";
		}

		private void btnSalvarPersona_Click(object sender, EventArgs e)
		{
			Personagem personagem = new Personagem();
			personagem.Nome = txtNome.Text;
			personagem.Raca = txtRaca.Text;
			personagem.Serie = Convert.ToInt32(cbxSerie.SelectedValue);
			conexao.SalvarPersonagem(personagem);
			txtNome.Text = "";
			txtRaca.Text = "";
			MessageBox.Show("Salvo", "Registro salvo.", MessageBoxButtons.OK);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CadastroDePersonagem));
			panel1 = new Panel();
			label1 = new Label();
			txtNome = new TextBox();
			label2 = new Label();
			txtRaca = new TextBox();
			cbxSerie = new ComboBox();
			label3 = new Label();
			btnSalvarPersona = new Button();
			panel1.SuspendLayout();
			base.SuspendLayout();
			panel1.BorderStyle = BorderStyle.Fixed3D;
			panel1.Controls.Add(label3);
			panel1.Controls.Add(cbxSerie);
			panel1.Controls.Add(txtRaca);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(txtNome);
			panel1.Controls.Add(label1);
			panel1.Location = new Point(13, 13);
			panel1.Name = "panel1";
			panel1.Size = new Size(259, 144);
			panel1.TabIndex = 0;
			label1.AutoSize = true;
			label1.Location = new Point(16, 18);
			label1.Name = "label1";
			label1.Size = new Size(35, 13);
			label1.TabIndex = 0;
			label1.Text = "Nome";
			txtNome.Location = new Point(57, 15);
			txtNome.Name = "txtNome";
			txtNome.Size = new Size(181, 20);
			txtNome.TabIndex = 1;
			label2.AutoSize = true;
			label2.Location = new Point(16, 60);
			label2.Name = "label2";
			label2.Size = new Size(33, 13);
			label2.TabIndex = 2;
			label2.Text = "Raça";
			txtRaca.Location = new Point(57, 57);
			txtRaca.Name = "txtRaca";
			txtRaca.Size = new Size(181, 20);
			txtRaca.TabIndex = 3;
			cbxSerie.FormattingEnabled = true;
			cbxSerie.Location = new Point(57, 97);
			cbxSerie.Name = "cbxSerie";
			cbxSerie.Size = new Size(181, 21);
			cbxSerie.TabIndex = 4;
			label3.AutoSize = true;
			label3.Location = new Point(16, 100);
			label3.Name = "label3";
			label3.Size = new Size(31, 13);
			label3.TabIndex = 5;
			label3.Text = "Série";
			btnSalvarPersona.Location = new Point(187, 163);
			btnSalvarPersona.Name = "btnSalvarPersona";
			btnSalvarPersona.Size = new Size(75, 23);
			btnSalvarPersona.TabIndex = 1;
			btnSalvarPersona.Text = "Salvar";
			btnSalvarPersona.UseVisualStyleBackColor = true;
			btnSalvarPersona.Click += btnSalvarPersona_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(284, 198);
			base.Controls.Add(btnSalvarPersona);
			base.Controls.Add(panel1);
			//base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "CadastroDePersonagem";
			Text = "CadastroDePersonagem";
			base.Load += CadastroDePersonagem_Load;
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
