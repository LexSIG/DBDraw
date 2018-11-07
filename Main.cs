using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Random_Fun_Draw
{
	public class Main : Form
	{
		private Personagem personagem;

		private Roupa roupa;

		private Conexao conexao = new Conexao();

		private int codigo;

		private int forma;

		private IContainer components;

		private Button btnRandomPersonagem;

		private Panel pnlRandom;

		private Label lblRoupa;

		private Label lblForma;

		private Label lblNome;

		private Button btnRoupa;

		private Button btnForma;

		private Panel panel2;

		private Button btnReset;

		private Label lblSerie;

		private Button btnSortear;

		private Label label1;

		private ComboBox cbxSerie;

		private Button btnCadSerie;
		private ComboBox cbxPersonagens;
		private Label label2;
		private Label label3;
		private Button btnCadPersona;

		public Main()
		{
			InitializeComponent();
			cbxSerie.DataSource = conexao.buscarSeries();
			cbxSerie.DisplayMember = "Nome";
			cbxSerie.ValueMember = "Codigo";
			cbxPersonagens.DataSource = conexao.ListarAllPersonagem();
			cbxPersonagens.DisplayMember = "Nome";
			cbxPersonagens.ValueMember = "Codigo";
			label2.Text = cbxPersonagens.Items.Count.ToString();
		}

		private void btnRandomPersonagem_Click(object sender, EventArgs e)
		{
			Resetar();
			Random random = new Random();
			codigo = random.Next(conexao.QuantidadeTotalPersonagem()) + 1;
			personagem = new Personagem();
			personagem = conexao.BuscarPersonagem(codigo);
			lblNome.Text = personagem.Nome;
			lblNome.Visible = true;
			lblSerie.Text = conexao.BuscarSerie(personagem.Serie);
			lblSerie.Visible = true;
			switch (personagem.Raca)
			{
			case "Saiyajin":
				lblNome.BackColor = Color.Orange;
				lblNome.ForeColor = Color.Black;
				forma = random.Next(7);
				btnForma.Visible = true;
				break;
			case "Namek":
				lblNome.BackColor = Color.Green;
				lblNome.ForeColor = Color.Black;
				btnForma.Visible = false;
				break;
			case "Alien":
				lblNome.BackColor = Color.YellowGreen;
				lblNome.ForeColor = Color.Black;
				btnForma.Visible = false;
				break;
			case "Changeling":
				lblNome.BackColor = Color.MediumPurple;
				lblNome.ForeColor = Color.Black;
				forma = random.Next(4);
				btnForma.Visible = true;
				break;
			case "Androide":
				lblNome.BackColor = Color.Gray;
				lblNome.ForeColor = Color.Black;
				forma = random.Next(2);
				btnForma.Visible = true;
				break;
			case "Demonio":
				lblNome.BackColor = Color.Red;
				lblNome.ForeColor = Color.Black;
				btnForma.Visible = false;
				break;
			case "Majin":
				lblNome.BackColor = Color.LightPink;
				lblNome.ForeColor = Color.Black;
				btnForma.Visible = false;
				break;
			case "Humano":
				lblNome.BackColor = Color.LightSkyBlue;
				lblNome.ForeColor = Color.Black;
				btnForma.Visible = false;
				break;
			case "Hibrido":
				lblNome.BackColor = Color.Brown;
				lblNome.ForeColor = Color.Black;
				btnForma.Visible = false;
				break;
			case "Mágico":
				lblNome.BackColor = Color.Brown;
				lblNome.ForeColor = Color.Black;
				btnForma.Visible = false;
				break;
			case "Deus":
				lblNome.BackColor = Color.AntiqueWhite;
				lblNome.ForeColor = Color.Black;
				btnForma.Visible = false;
				break;
			case "Shinigami":
				lblNome.BackColor = Color.Black;
				lblNome.ForeColor = Color.White;
				break;
			case "Quincy":
				lblNome.BackColor = Color.DarkBlue;
				lblNome.ForeColor = Color.White;
				break;
			case "Arrancar":
				lblNome.BackColor = Color.White;
				lblNome.ForeColor = Color.Black;
				break;
			case "Pokémon":
				lblNome.BackColor = Color.Yellow;
				lblNome.ForeColor = Color.Blue;
				break;
			case "Digimon":
				lblNome.BackColor = Color.Orange;
				lblNome.ForeColor = Color.Blue;
				break;
			case "Arcobaleno":
				lblNome.BackColor = Color.BlueViolet;
				lblNome.ForeColor = Color.Black;
				break;
			}
			if (personagem.Serie == 1)
			{
				btnRoupa.Visible = true;
			}
		}

		private void btnForma_Click(object sender, EventArgs e)
		{
			if (personagem.Raca == "Saiyajin")
			{
				switch (forma)
				{
				case 0:
					lblForma.Text = "Normal";
					break;
				case 1:
					lblForma.Text = "Super Saiyajin";
					break;
				case 2:
					lblForma.Text = "Super Saiyajin 2";
					break;
				case 3:
					lblForma.Text = "Super Saiyajin 3";
					break;
				case 4:
					lblForma.Text = "Super Saiyajin 4";
					break;
				case 5:
					lblForma.Text = "Super Saiyajin God";
					break;
				case 6:
					lblForma.Text = "Super Saiyajin God Blue";
					break;
				case 7:
					lblForma.Text = "Super Saiyajin Ultra";
					break;
				}
			}
			else if (personagem.Raca == "Changeling")
			{
				switch (forma)
				{
				case 0:
					lblForma.Text = "Normal";
					break;
				case 1:
					lblForma.Text = "Segunda Fase";
					break;
				case 2:
					lblForma.Text = "Terceira Fase";
					break;
				case 3:
					lblForma.Text = "Quarta Fase";
					break;
				case 4:
					lblForma.Text = "Quinta Fase";
					break;
				}
			}
			else if (personagem.Raca == "Androide")
			{
				switch (forma)
				{
				case 0:
					lblForma.Text = "Primeira Forma";
					break;
				case 1:
					lblForma.Text = "Segunda Forma";
					break;
				case 2:
					lblForma.Text = "Forma Perfeita";
					break;
				}
			}
			lblForma.Visible = true;
			lblForma.BackColor = lblNome.BackColor;
		}

		private void btnRoupa_Click(object sender, EventArgs e)
		{
			int num = new Random().Next(48) + 1;
			Conexao conexao = new Conexao();
			roupa = conexao.BuscarRoupa(num);
			lblRoupa.Text = roupa.Skin;
			lblRoupa.Visible = true;
		}

		private void Resetar()
		{
			lblNome.Visible = false;
			lblForma.Visible = false;
			lblRoupa.Visible = false;
			btnForma.Visible = false;
			btnRoupa.Visible = false;
			lblSerie.Visible = false;
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			Resetar();
		}

		private void btnSortear_Click(object sender, EventArgs e)
		{
			personagem = new Personagem();
			Random random = new Random();
			personagem = conexao.ListarPersonagem(Convert.ToInt32(cbxSerie.SelectedValue));
			if (personagem.Nome == "erro")
			{
				MessageBox.Show("Série selecionada não possui personagens cadastrados.", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				lblNome.Text = personagem.Nome;
				lblNome.Visible = true;
				lblSerie.Text = conexao.BuscarSerie(personagem.Serie);
				lblSerie.Visible = true;
				switch (personagem.Raca)
				{
				case "Saiyajin":
					lblNome.BackColor = Color.Orange;
					lblNome.ForeColor = Color.Black;
					forma = random.Next(7);
					btnForma.Visible = true;
					break;
				case "Namek":
					lblNome.BackColor = Color.Green;
					lblNome.ForeColor = Color.Black;
					btnForma.Visible = false;
					break;
				case "Alien":
					lblNome.BackColor = Color.YellowGreen;
					lblNome.ForeColor = Color.Black;
					btnForma.Visible = false;
					break;
				case "Changeling":
					lblNome.BackColor = Color.MediumPurple;
					lblNome.ForeColor = Color.Black;
					forma = random.Next(4);
					btnForma.Visible = true;
					break;
				case "Androide":
					lblNome.BackColor = Color.Gray;
					lblNome.ForeColor = Color.Black;
					forma = random.Next(2);
					btnForma.Visible = true;
					break;
				case "Demonio":
					lblNome.BackColor = Color.Red;
					lblNome.ForeColor = Color.Black;
					btnForma.Visible = false;
					break;
				case "Majin":
					lblNome.BackColor = Color.LightPink;
					lblNome.ForeColor = Color.Black;
					btnForma.Visible = false;
					break;
				case "Humano":
					lblNome.BackColor = Color.LightSkyBlue;
					lblNome.ForeColor = Color.Black;
					btnForma.Visible = false;
					break;
				case "Hibrido":
					lblNome.BackColor = Color.Brown;
					lblNome.ForeColor = Color.Black;
					btnForma.Visible = false;
					break;
				case "Mágico":
					lblNome.BackColor = Color.Brown;
					lblNome.ForeColor = Color.Black;
					btnForma.Visible = false;
					break;
				case "Deus":
					lblNome.BackColor = Color.AntiqueWhite;
					lblNome.ForeColor = Color.Black;
					btnForma.Visible = false;
					break;
				case "Shinigami":
					lblNome.BackColor = Color.Black;
					lblNome.ForeColor = Color.White;
					break;
				case "Quincy":
					lblNome.BackColor = Color.DarkBlue;
					lblNome.ForeColor = Color.White;
					break;
				case "Arrancar":
					lblNome.BackColor = Color.White;
					lblNome.ForeColor = Color.Black;
					break;
				case "Pokémon":
					lblNome.BackColor = Color.Yellow;
					lblNome.ForeColor = Color.Blue;
					break;
				case "Digimon":
					lblNome.BackColor = Color.Orange;
					lblNome.ForeColor = Color.Blue;
					break;
				case "Arcobaleno":
					lblNome.BackColor = Color.BlueViolet;
					lblNome.ForeColor = Color.Black;
					break;
				}
				if (personagem.Serie == 1)
				{
					btnRoupa.Visible = true;
				}
			}
		}

		private void btnCadSerie_Click(object sender, EventArgs e)
		{
			new CadastroDeSerie().Show();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			cbxSerie.DataSource = conexao.buscarSeries();
			cbxSerie.DisplayMember = "Nome";
			cbxSerie.ValueMember = "Codigo";
		}

		private void btnCadPersona_Click(object sender, EventArgs e)
		{
			new CadastroDePersonagem().Show();
		}

		private void cbxSerie_Click(object sender, EventArgs e)
		{
			cbxSerie.DataSource = conexao.buscarSeries();
			cbxSerie.DisplayMember = "Nome";
			cbxSerie.ValueMember = "Codigo";
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
			this.btnRandomPersonagem = new System.Windows.Forms.Button();
			this.pnlRandom = new System.Windows.Forms.Panel();
			this.lblSerie = new System.Windows.Forms.Label();
			this.lblRoupa = new System.Windows.Forms.Label();
			this.lblForma = new System.Windows.Forms.Label();
			this.lblNome = new System.Windows.Forms.Label();
			this.btnRoupa = new System.Windows.Forms.Button();
			this.btnForma = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnSortear = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cbxSerie = new System.Windows.Forms.ComboBox();
			this.btnCadSerie = new System.Windows.Forms.Button();
			this.btnCadPersona = new System.Windows.Forms.Button();
			this.cbxPersonagens = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlRandom.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnRandomPersonagem
			// 
			this.btnRandomPersonagem.Location = new System.Drawing.Point(7, 3);
			this.btnRandomPersonagem.Name = "btnRandomPersonagem";
			this.btnRandomPersonagem.Size = new System.Drawing.Size(75, 41);
			this.btnRandomPersonagem.TabIndex = 0;
			this.btnRandomPersonagem.Text = "Personagem Random";
			this.btnRandomPersonagem.UseVisualStyleBackColor = true;
			this.btnRandomPersonagem.Click += new System.EventHandler(this.btnRandomPersonagem_Click);
			// 
			// pnlRandom
			// 
			this.pnlRandom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlRandom.Controls.Add(this.lblSerie);
			this.pnlRandom.Controls.Add(this.lblRoupa);
			this.pnlRandom.Controls.Add(this.lblForma);
			this.pnlRandom.Controls.Add(this.lblNome);
			this.pnlRandom.Controls.Add(this.btnRoupa);
			this.pnlRandom.Controls.Add(this.btnForma);
			this.pnlRandom.Controls.Add(this.btnRandomPersonagem);
			this.pnlRandom.Location = new System.Drawing.Point(5, 12);
			this.pnlRandom.Name = "pnlRandom";
			this.pnlRandom.Size = new System.Drawing.Size(273, 111);
			this.pnlRandom.TabIndex = 1;
			// 
			// lblSerie
			// 
			this.lblSerie.AutoSize = true;
			this.lblSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSerie.Location = new System.Drawing.Point(104, 25);
			this.lblSerie.Name = "lblSerie";
			this.lblSerie.Size = new System.Drawing.Size(41, 13);
			this.lblSerie.TabIndex = 7;
			this.lblSerie.Text = "label1";
			this.lblSerie.Visible = false;
			// 
			// lblRoupa
			// 
			this.lblRoupa.AutoSize = true;
			this.lblRoupa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRoupa.Location = new System.Drawing.Point(104, 84);
			this.lblRoupa.Name = "lblRoupa";
			this.lblRoupa.Size = new System.Drawing.Size(41, 13);
			this.lblRoupa.TabIndex = 5;
			this.lblRoupa.Text = "label3";
			this.lblRoupa.Visible = false;
			// 
			// lblForma
			// 
			this.lblForma.AutoSize = true;
			this.lblForma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblForma.Location = new System.Drawing.Point(104, 55);
			this.lblForma.Name = "lblForma";
			this.lblForma.Size = new System.Drawing.Size(41, 13);
			this.lblForma.TabIndex = 4;
			this.lblForma.Text = "label2";
			this.lblForma.Visible = false;
			// 
			// lblNome
			// 
			this.lblNome.AutoSize = true;
			this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNome.Location = new System.Drawing.Point(104, 11);
			this.lblNome.Name = "lblNome";
			this.lblNome.Size = new System.Drawing.Size(41, 13);
			this.lblNome.TabIndex = 3;
			this.lblNome.Text = "label1";
			this.lblNome.Visible = false;
			// 
			// btnRoupa
			// 
			this.btnRoupa.Location = new System.Drawing.Point(7, 79);
			this.btnRoupa.Name = "btnRoupa";
			this.btnRoupa.Size = new System.Drawing.Size(75, 23);
			this.btnRoupa.TabIndex = 2;
			this.btnRoupa.Text = "Roupa";
			this.btnRoupa.UseVisualStyleBackColor = true;
			this.btnRoupa.Visible = false;
			// 
			// btnForma
			// 
			this.btnForma.Location = new System.Drawing.Point(7, 50);
			this.btnForma.Name = "btnForma";
			this.btnForma.Size = new System.Drawing.Size(75, 23);
			this.btnForma.TabIndex = 1;
			this.btnForma.Text = "Forma";
			this.btnForma.UseVisualStyleBackColor = true;
			this.btnForma.Visible = false;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(233, 251);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(45, 23);
			this.btnReset.TabIndex = 6;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.btnSortear);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.cbxSerie);
			this.panel2.Location = new System.Drawing.Point(5, 130);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(273, 68);
			this.panel2.TabIndex = 2;
			// 
			// btnSortear
			// 
			this.btnSortear.Location = new System.Drawing.Point(196, 25);
			this.btnSortear.Name = "btnSortear";
			this.btnSortear.Size = new System.Drawing.Size(69, 23);
			this.btnSortear.TabIndex = 3;
			this.btnSortear.Text = "Sortear";
			this.btnSortear.UseVisualStyleBackColor = true;
			this.btnSortear.Click += new System.EventHandler(this.btnSortear_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(92, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Selecionar Série";
			// 
			// cbxSerie
			// 
			this.cbxSerie.FormattingEnabled = true;
			this.cbxSerie.Location = new System.Drawing.Point(7, 26);
			this.cbxSerie.Name = "cbxSerie";
			this.cbxSerie.Size = new System.Drawing.Size(183, 21);
			this.cbxSerie.TabIndex = 1;
			// 
			// btnCadSerie
			// 
			this.btnCadSerie.Location = new System.Drawing.Point(5, 251);
			this.btnCadSerie.Name = "btnCadSerie";
			this.btnCadSerie.Size = new System.Drawing.Size(92, 23);
			this.btnCadSerie.TabIndex = 7;
			this.btnCadSerie.Text = "Cadastrar Série";
			this.btnCadSerie.UseVisualStyleBackColor = true;
			this.btnCadSerie.Click += new System.EventHandler(this.btnCadSerie_Click);
			// 
			// btnCadPersona
			// 
			this.btnCadPersona.Location = new System.Drawing.Point(102, 251);
			this.btnCadPersona.Name = "btnCadPersona";
			this.btnCadPersona.Size = new System.Drawing.Size(125, 23);
			this.btnCadPersona.TabIndex = 8;
			this.btnCadPersona.Text = "Cadastrar Personagem";
			this.btnCadPersona.UseVisualStyleBackColor = true;
			this.btnCadPersona.Click += new System.EventHandler(this.btnCadPersona_Click);
			// 
			// cbxPersonagens
			// 
			this.cbxPersonagens.FormattingEnabled = true;
			this.cbxPersonagens.Location = new System.Drawing.Point(14, 204);
			this.cbxPersonagens.Name = "cbxPersonagens";
			this.cbxPersonagens.Size = new System.Drawing.Size(258, 21);
			this.cbxPersonagens.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(73, 228);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 13);
			this.label2.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(96, 228);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(131, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Personagens Cadastrados";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(284, 284);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbxPersonagens);
			this.Controls.Add(this.btnCadPersona);
			this.Controls.Add(this.btnCadSerie);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.pnlRandom);
			this.Name = "Main";
			this.Text = "Random Fun Draw";
			this.Load += new System.EventHandler(this.Main_Load_1);
			this.pnlRandom.ResumeLayout(false);
			this.pnlRandom.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void Main_Load_1(object sender, EventArgs e)
		{
		}
	}
}
