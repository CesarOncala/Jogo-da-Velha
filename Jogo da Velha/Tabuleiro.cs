using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Velha
{
    class Tabuleiro
    {
        public char[,] tabuleiro = new char[3, 3];

        public int esp_preenchido;
        public bool vencedor=false;
        public string modo_de_jogo;


        public void Atualizar_Tabuleiro(int x, int y, char jogada, int verificar_empate=0)
        {
            tabuleiro[x, y] = jogada;
        }// Atualiza a matriz do tabuleiro

        public void Calcular_Vitoria(TextBox HUD)
        {

            if (this.esp_preenchido > 9 && this.vencedor==false)
            {
                MessageBox.Show("Empate no jogo !");
                HUD.Text = "Fim do jogo !";
                this.vencedor = true;
                return;
            }
            else if (this.vencedor==false)
            {
                // Diagonal Principal e Secundária.
                if (this.verifica_DiagoP() == 'X' || this.verifica_DiagoS() == 'X')
                {
                    MessageBox.Show("Jogador 1 'X' venceu na diagonal");
                    HUD.Text = "Fim do jogo !";
                    this.vencedor = true;
                    return;
                }
                else if (this.verifica_DiagoP() == 'O' || this.verifica_DiagoS() == 'O')
                {
                    MessageBox.Show("Jogador 2 'O' venceu na diagonal");
                    HUD.Text = "Fim do jogo !";
                    this.vencedor = true;
                    return;
                }

                // Horizontalmente
                if (this.verifica_Horizontal() == 'X')
                {
                    MessageBox.Show("Jogador 1 'X' venceu na horizontal");
                    HUD.Text = "Fim do jogo !";
                    this.vencedor = true;
                    return;
                }
                else if (this.verifica_Horizontal() == 'O')
                {
                    MessageBox.Show("Jogador 2 'O' venceu na horizontal");
                    HUD.Text = "Fim do jogo !";
                    this.vencedor = true;
                    return;
                }
                // Verticalmente
                if (this.verifica_Vertical() == 'X')
                {
                    MessageBox.Show("Jogador 1 'X' venceu na vertical");
                    HUD.Text = "Fim do jogo !";
                    this.vencedor = true;
                    return;
                }
                else if (this.verifica_Vertical() == 'O')
                {
                    MessageBox.Show("Jogador 2 'O' venceu na vertical");
                    HUD.Text = "Fim do jogo !";
                    this.vencedor = true;
                    return;
                }
            }
           

        }

        private char verifica_Vertical()
        {
            int x = 0, o = 0;

            for (int l = 0; l < tabuleiro.GetLongLength(0); l++)
            {
                for (int c = 0; c < tabuleiro.GetLongLength(1); c++)
                {
                    for (int i = 0; i < tabuleiro.GetLongLength(0); i++)
                    {
                        if (tabuleiro[i,c]=='X')
                        {
                            x++;
                        }
                        else if (tabuleiro[i,c]=='O')
                        {
                            o++;
                        }
                    }
                    if (x<3)
                    {
                        x = 0;
                    }
                    else
                    {
                        return 'X';
                    }
                    if (o<3)
                    {
                        o = 0;
                    }
                    else
                    {
                        return 'O';
                    }
                }
            }
            return ' ';
        }

        private char verifica_Horizontal()
        {
            int x = 0, o = 0;

            for (int i = 0; i < tabuleiro.GetLongLength(0); i++)
            { 
                for (int j = 0; j < tabuleiro.GetLongLength(1); j++)
                {
                    if (tabuleiro[i,j]=='X')
                    {
                        x++;
                    }
                    else if (tabuleiro[i, j] == 'O')
                    {
                        o++;
                    }
                }
                if (x<3)
                {
                    x = 0;
                }
                else
                {
                    break;
                }
                if (o<3)
                {
                    o = 0;
                }
                else
                {
                    break;
                }
            }

            if (x == 3)
            {
                return 'X';
            }
            else if (o == 3)
            {
                return 'O';
            }
            else
            {
                return ' ';
            }


        }

        private char verifica_DiagoP()
        {
            int x = 0, o = 0;
            for (int i = 0; i < tabuleiro.GetLongLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLongLength(1); j++)
                {
                    if (i==j)
                    {
                        if (tabuleiro[i,j]=='X')
                        {
                            x++;
                        }
                        else if (tabuleiro[i,j]=='O')
                        {
                            o++;
                        }
                    }
                }
            }
            if (x==3)
            {
                return 'X';
            }
            else if (o==3)
            {
                return 'O';
            }
            else
            {
                return ' ';
            }

        }

        private char verifica_DiagoS()
        {
            int x = 0, o = 0;
            for (int i = 0; i < tabuleiro.GetLongLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLongLength(1); j++)
                {
                    if (i + j == 3 - 1)
                    {
                        if (tabuleiro[i, j] == 'X')
                        {
                            x++;
                        }
                        else if (tabuleiro[i, j] == 'O')
                        {
                            o++;
                        }
                    }
                }
            }

            if (x == 3)
            {
                return 'X';
            }
            else if (o == 3)
            {
                return 'O';
            }
            else
            {
                return ' ';
            }

        }

    }
}
