using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Velha
{

    public partial class Jogo_da_Velha : Form
    {

        Jogador x;

        public Jogo_da_Velha()
        {
            InitializeComponent();
            x = new Jogador(this);
            this.txtBoxHUD.Text = "Escolha as opções e aperte Start";
        }
        // Eventos de Click nos turnos.
        private void button1_Click(object sender, EventArgs e)
        {
            if (x.partida != null)
            {
                if (x.partida.vencedor != true)
                {
                    x.Turno(this.zero_zero, 0, 0);
                }
            }
            else
            {
                MessageBox.Show("Aperte o botão start para começar o jogo!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (x.partida != null)
            {
                if (x.partida.vencedor != true)
                {
                    x.Turno(this.zero_um, 0, 1);
                }
            }
            else
            {
                MessageBox.Show("Aperte o botão start para começar o jogo!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (x.partida != null)
            {
                if (x.partida.vencedor != true)
                {
                    x.Turno(this.zero_dois, 0, 2);
                }

            }
            else
            {
                MessageBox.Show("Aperte o botão start para começar o jogo!");
            }


        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (x.partida != null)
            {
                if (x.partida.vencedor != true)
                {
                    x.Turno(this.um_zero, 1, 0);
                }

            }
            else
            {
                MessageBox.Show("Aperte o botão start para começar o jogo!");
            }
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (x.partida != null)
            {
                if (x.partida.vencedor != true)
                {
                    x.Turno(this.um_um, 1, 1);
                }
            }
            else
            {
                MessageBox.Show("Aperte o botão start para começar o jogo!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (x.partida != null)
            {
                if (x.partida.vencedor != true)
                {
                    x.Turno(this.um_dois, 1, 2);
                }
            }
            else
            {
                MessageBox.Show("Aperte o botão start para começar o jogo!");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (x.partida != null)
            {
                if (x.partida.vencedor != true)
                {
                    x.Turno(this.dois_zero, 2, 0);
                }
            }
            else
            {
                MessageBox.Show("Aperte o botão start para começar o jogo!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (x.partida != null)
            {
                if (x.partida.vencedor != true)
                {
                    x.Turno(this.dois_um, 2, 1);
                }
            }
            else
            {
                MessageBox.Show("Aperte o botão start para começar o jogo!");
            }

        }


        private void button9_Click(object sender, EventArgs e)
        {
            if (x.partida != null)
            {
                if (x.partida.vencedor != true)
                {
                    x.Turno(this.dois_dois, 2, 2);
                }
            }
            else
            {
                MessageBox.Show("Aperte o botão start para começar o jogo!");
            }

        }


        // Evento do botão start, que inicia o jogo
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Condições de verificação do modo de jogo
            if (x.partida==null)
            {
                try
                {
                    if (this.Normal.Checked == true)
                    {
                        x.partida = new Tabuleiro();
                        x.partida.modo_de_jogo = "Normal";
                    }
                    else if (PCxPC.Checked == true) // Caso o modo de jogo for automatico, é necessário especificar qual deles
                    {
                        x.partida = new Tabuleiro(); // Modo máquina contra máquina
                        x.partida.modo_de_jogo = "PCVSPC";
                        x.PC_VS_PC();
                    }
                    else if (JogadorxPC.Checked == true)
                    {
                        x.partida = new Tabuleiro(); // Modo máquina contra jogador
                        x.partida.modo_de_jogo = "PCVSJOGADOR";
                        x.Jogador_VS_PC();

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Selecione uma das opções do modo automático.");
                }
            }
            else
                this.Reiniciar.PerformClick();
           

        }

        private void radioButton2_Click(object sender, EventArgs e) // Evento que torna visivel as opções de automatico
        {
            this.PCxPC.Visible = true;
            this.JogadorxPC.Visible = true;
        }


        private void Reiniciar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
