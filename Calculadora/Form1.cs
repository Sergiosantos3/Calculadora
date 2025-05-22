using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Numero_Click(object sender, EventArgs e)
        {
            // Pegar  as infos do botão que está chamando o evento
            Button BotaoClicado = (Button)sender;
            // Mostrar na tela o num que foi clicado, juntando com oq já estava la
            //txbTela.Text += BotaoClicado.Text;

            string numero = BotaoClicado.Text;

            // Lógica para impedir zeros inválidos
            if (numero == "0")
            {
                if (string.IsNullOrEmpty(txbTela.Text))
                    return;

                char ultimoChar = txbTela.Text[txbTela.Text.Length - 1];
                if ("+-x÷".Contains(ultimoChar))
                    return;
            }
            // Adiciona o número ao TextBox
            txbTela.Text += numero;
        }
        private void Operador_Click(object sender, EventArgs e)
        {
            Button BotaoClicado = (Button)sender;
            //txbTela.Text += BotaoClicado.Text;

            string operador = BotaoClicado.Text;

            if(txbTela.Text != "")
            {
                char ultimoChar = txbTela.Text[txbTela.Text.Length - 1];
                // Adiciona o operador
                txbTela.Text += operador;
                // Substitui operador anterior pelo novo operador
                if ("+-*÷".Contains(ultimoChar))
                {
                    txbTela.Text = txbTela.Text.Remove(txbTela.Text.Length - 1);
                }
            }

            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Text = "";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                var v = dt.Compute(txbTela.Text.Replace("÷", "/").Replace("x", "*"), "");
                txbTela.Text = v.ToString();

                if (txbTela.Text[txbTela.Text.Length - 1].Equals("0"))
                {
                    MessageBox.Show("Erro: Divisão por zero!");
                }
            }
            catch
            {
                MessageBox.Show("Digite um número após o operador", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     

        }
    }
}
