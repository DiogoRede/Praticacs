// See https://aka.ms/new-console-template for more information
using System;

namespace Estudo
{
    class Program
    {
        static void Main(string[] args)
        {   
            string? opcUsuario=null;
            Aluno[] alunos = new Aluno[5];
            int z = 0;
            do{
                Console.WriteLine("\nMenu de Opções");
                Console.WriteLine("1 - Inserir aluno");
                Console.WriteLine("2 - Listar alunos");
                Console.WriteLine("3 - Listar media geral");
                Console.WriteLine("4 - Alterar Nota");
                Console.WriteLine("X - Sair");
                opcUsuario = Console.ReadLine();
                Console.WriteLine();

                switch (opcUsuario)
                {
                    case "1":
                        Console.WriteLine("Nome do Aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome  = Console.ReadLine();

                        Console.WriteLine("Nota do Aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota  = nota;
                        }else{
                            throw new ArgumentException("Valor da nota Invalida!");
                        }

                        alunos[z] = aluno;
                        z++;

                        break;

                    case "2":
                        foreach(var a in alunos)
                        {
                            if (a.Nome!=null)
                            {
                                Console.WriteLine($"Aluno : {a.Nome} | Nota : {a.Nota}");
                            }
                        }

                        break;

                    case "3":
                        decimal notaT=0;
                        int qtdAlunos=0;                      

                        for (int i=0;i<alunos.Length;i++)
                        {
                            if (alunos[i].Nome!=null)
                            {
                                notaT+= alunos[i].Nota;
                                qtdAlunos++;
                            }
                        }
                        notaT = notaT / qtdAlunos;
                        
                        Conceito conceitoGeral;

                        if (notaT>=8)
                        {
                            conceitoGeral = Conceito.A;
                        }
                        else if (notaT>=6)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else if (notaT>=4)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (notaT>=2)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else
                        {
                            conceitoGeral = Conceito.E;
                        }

                        Console.WriteLine($"Media Geral:  {notaT.ToString("0.0#")} | Conceito: {conceitoGeral}");

                        break;

                    case "4":
                        int id=0;
                        decimal cNota=0;
                        Console.WriteLine("Id Aluno (posição no array): ");

                        if (int.TryParse(Console.ReadLine(), out int idUsuario))
                        {
                            id = idUsuario;
                        }
                        else
                        {
                            throw new ArgumentException("ID aluno Invalida!");
                        }
                        
                        if (alunos[id].Nome!=null)
                        {
                            Console.WriteLine("Alterar Nota para: ");

                            if (decimal.TryParse(Console.ReadLine(), out decimal AlterarNota))
                            {
                                cNota = AlterarNota;
                            }
                            else
                            {
                                throw new ArgumentException("Nota do aluno Invalida!");
                            }
                            alunos[id].Nota = cNota;

                        }

                        break;

                    case "X" or "x":break;

                    default:
                        opcUsuario="p";

                        break;
                }

            } while (opcUsuario.ToUpper()!="X");
        }
    }
}
