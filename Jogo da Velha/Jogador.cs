using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Velha
{
    class Jogador
    {
        int cont_turno = 1;
        TextBox turno;
        public Tabuleiro partida;
        Jogo_da_Velha controle_partida;

        public Jogador(Jogo_da_Velha controle)
        {
            controle_partida = controle;
            this.turno = controle.txtBoxHUD;
            this.turno.Text = "X faça sua jogada !";
        }

        public void Turno(Button jogada = null, int x = 0, int y = 0)
        {
            if (partida.vencedor == false)
            {
                if (this.cont_turno % 2 != 0) // Verifica de quem é o turno
                {

                    jogada.Text = "X";
                    partida.Atualizar_Tabuleiro(x, y, char.Parse(jogada.Text.ToString())); // Atualiza o tabuleiro
                    jogada.Enabled = false;
                    partida.Calcular_Vitoria(this.turno); // calcula a vitória
                    if (partida.vencedor == false) { this.turno.Text = "O faça sua jogada !"; };
                    cont_turno++; // passa a vez para o próximo jogador
                }
                else // mesma coisa para o segundo jogador
                {

                    jogada.Text = "O";
                    partida.Atualizar_Tabuleiro(x, y, char.Parse(jogada.Text.ToString()));
                    jogada.Enabled = false;
                    partida.Calcular_Vitoria(this.turno);

                    if (partida.vencedor == false) { this.turno.Text = "X faça sua jogada !"; };

                    if (partida.modo_de_jogo == "PCVSJOGADOR") // se estiver jogando com o pc,  esta condição o avisa de seu turno no jogo
                    {
                        cont_turno++;
                        this.Jogador_VS_PC();
                    }
                    else
                    {
                        this.cont_turno++;
                    }
                }

                this.partida.esp_preenchido = cont_turno;
                this.partida.Calcular_Vitoria(this.turno);
               
            }
            else
            {
                this.turno.Text = "Fim do jogo !";
            }

        }


        public void PC_VS_PC()
        {
            Random random = new Random();
            int X = 0, Y = 0;
            do
            {
                if (partida.vencedor != true)
                {
                    X = random.Next(0, 3);
                    Y = random.Next(0, 3);

	// Loop que repete até uma das máquinas ganhar, as condições são os botões que são escolhidos de forma aleatória, o loop repete caso não aperte em nenhum botão no turno.
                    if (this.partida.tabuleiro[X, Y] == 0 && X == 1 && Y == 0)
                    {
                        controle_partida.um_zero.PerformClick();

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 1 && Y == 1)
                    {
                        controle_partida.um_um.PerformClick();

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 1 && Y == 2)
                    {
                        controle_partida.um_dois.PerformClick();

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 0 && Y == 1)
                    {
                        controle_partida.zero_um.PerformClick();

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 0 && Y == 2)
                    {
                        controle_partida.zero_dois.PerformClick();

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 0 && Y == 0)
                    {
                        controle_partida.zero_zero.PerformClick();

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 2 && Y == 0)
                    {
                        controle_partida.dois_zero.PerformClick();
                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 2 && Y == 1)
                    {
                        controle_partida.dois_um.PerformClick();

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 2 && Y == 2)
                    {
                        controle_partida.dois_dois.PerformClick();

                    }
                   
                }
                else
                {
                    this.turno.Text = "Fim do jogo !";
                    return;
                }


            } while (true);


        }


        public void Jogador_VS_PC()
        {
            Random random = new Random();
            int X = 0, Y = 0;

            do
            {
// Mesma premissa da função PC VS PC a diferença é que pra cada jogada o pc paça a partida para o usuário
                if (partida.vencedor != true)
                {
                    X = random.Next(0, 3);
                    Y = random.Next(0, 3);

                    if (this.partida.tabuleiro[X, Y] == 0 && X == 1 && Y == 0)
                    {
                        controle_partida.um_zero.PerformClick();
                        return;

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 1 && Y == 1)
                    {
                        controle_partida.um_um.PerformClick();
                        return;

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 1 && Y == 2)
                    {
                        controle_partida.um_dois.PerformClick();
                        return;

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 0 && Y == 1)
                    {
                        controle_partida.zero_um.PerformClick();
                        return;

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 0 && Y == 2)
                    {
                        controle_partida.zero_dois.PerformClick();
                        return;

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 0 && Y == 0)
                    {
                        controle_partida.zero_zero.PerformClick();
                        return;

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 2 && Y == 0)
                    {
                        controle_partida.dois_zero.PerformClick();
                        return;

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 2 && Y == 1)
                    {
                        controle_partida.dois_um.PerformClick();
                        return;

                    }
                    else if (this.partida.tabuleiro[X, Y] == 0 && X == 2 && Y == 2)
                    {
                        controle_partida.dois_dois.PerformClick();
                        return;

                    }
                }
                else
                {
                    this.turno.Text = "Fim do jogo !";
                    break;
                }

            } while (true);


        }

    }


}
