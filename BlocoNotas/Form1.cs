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

namespace BlocoNotas
{
    public partial class Form1 : Form
    {
        private OpenFileDialog abrirDialogo;
        private SaveFileDialog salvarDialogo;
        private FontDialog fonteDialogo;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fonteDialogo = new FontDialog();
        }

        private void CriarNovo()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    this.Text = "Sem título";
                    this.richTextBox1.Text = string.Empty;
                } else
                {
                    MessageBox.Show("Nada para salvar!");
                }
            } catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void AbrirArquivo()
        {
            try
            {
                abrirDialogo = new OpenFileDialog();

                if(abrirDialogo.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(abrirDialogo.FileName);
                    this.Text = abrirDialogo.FileName;
                }    
            }
            catch (Exception ex)
            {

            }
            finally
            {
                abrirDialogo = null;
            }
        }

        private void SalvarArquivo()
        {
            try
            {
               salvarDialogo = new SaveFileDialog();

                salvarDialogo.Filter = "Arquivo de Texto (*.txt) | *.txt";
                
               if (salvarDialogo.ShowDialog() == DialogResult.OK)
               {
                    File.WriteAllText(salvarDialogo.FileName, this.richTextBox1.Text);
                    this.Text = salvarDialogo.FileName;
               }

            }
            catch (Exception ex)
            {

            }
            finally
            {
               
            }
        }
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriarNovo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArquivo();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvarArquivo();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (fonteDialogo.ShowDialog() == DialogResult.OK)
                { 
                    this.richTextBox1.Font = fonteDialogo.Font;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

    }
}
