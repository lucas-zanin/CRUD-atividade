using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atividade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Pessoa pessoa = new Pessoa();
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Inserir(txtNome.Text, txtDatanasc.Text, txtEmail.Text, txtCelular.Text, txtCidade.Text);
            MessageBox.Show("Cadastro realizado com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
            txtNome.Text = "";
            txtDatanasc.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Localiza(id);
            txtNome.Text = pessoa.nome;
            txtDatanasc.Text = pessoa.datanasc;
            txtEmail.Text = pessoa.email;
            txtCelular.Text = pessoa.celular;
            txtCidade.Text = pessoa.cidade;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Atualizar(id, txtNome.Text, txtDatanasc.Text, txtEmail.Text, txtCelular.Text, txtCidade.Text);
            MessageBox.Show("Cadastro atualizado com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
            txtNome.Text = "";
            txtDatanasc.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Exclui(id);
            MessageBox.Show("Cadastro excluído com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoa();
            dgvPessoa.DataSource = pessoas;
            txtNome.Text = "";
            txtDatanasc.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtDatanasc.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtCidade.Text = "";
        }

        private void dgvPessoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtID.Text = Convert.ToString(this.dgvPessoa.CurrentRow.Cells["id"].Value);
            this.txtNome.Text = Convert.ToString(this.dgvPessoa.CurrentRow.Cells["nome"].Value);
            this.txtDatanasc.Text = Convert.ToString(this.dgvPessoa.CurrentRow.Cells["datanasc"].Value);
            this.txtEmail.Text = Convert.ToString(this.dgvPessoa.CurrentRow.Cells["email"].Value);
            this.txtCelular.Text = Convert.ToString(this.dgvPessoa.CurrentRow.Cells["celular"].Value);
            this.txtCidade.Text = Convert.ToString(this.dgvPessoa.CurrentRow.Cells["cidade"].Value);
        }
    }
}
