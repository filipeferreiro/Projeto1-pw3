using AppBancoADO;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Projeto1
{   
    class Program
    {
        static void Main(string[] args)
        {
            var Banco = new Banco();
            var usuarioDAO = new UsuarioDAO();
            var usuario = new Usuario();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("================AppBanco================");
            Console.WriteLine("=        0 - Cadastrar usuário         =");
            Console.WriteLine("=        1 - Editar usuário            =");
            Console.WriteLine("=        2 - Excluir usuário           =");
            Console.WriteLine("=        3 - Listar usuário            =");
            Console.WriteLine("=        4 - Sair                      =");
            Console.WriteLine("========================================");
            Console.WriteLine("Selecione uma das opções para prosseguir");
            var opcaoMenu = Console.ReadLine();

            var leitor = usuarioDAO.Listar();

            if (string.IsNullOrEmpty(opcaoMenu))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor, escolha uma das opções para prosseguir");
                opcaoMenu = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                if (string.IsNullOrEmpty(opcaoMenu))
                {
                    Environment.Exit(0);
                }
            } 
            if(opcaoMenu == "0")
            {
                Console.WriteLine("Digite seu nome: ");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.nomeUsu = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Informe seu cargo: ");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.cargo = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("informe sua data de nascimento: ");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.datanasc = DateTime.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Blue;

                usuarioDAO.Salvar(usuario);

                leitor = usuarioDAO.Listar();

            } else if(opcaoMenu == "1")
            {
                Console.WriteLine("Digite o id do usuário a ser alterado: ");
                usuario.idUsu = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite seu nome: ");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.nomeUsu = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Informe seu cargo: ");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.cargo = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("informe sua data de nascimento: ");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.datanasc = DateTime.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Blue;

                usuarioDAO.Salvar(usuario);

                leitor = usuarioDAO.Listar();

            } else if (opcaoMenu == "2")
            {
                Console.WriteLine("Digite o id do usuário a ser excluido: ");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.idUsu = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Blue;

                usuarioDAO.Excluir(usuario);

                leitor = usuarioDAO.Listar();

            } else if (opcaoMenu == "3")
            {
                
            } else if (opcaoMenu == "4")
            {
                Environment.Exit(0);
            }
            foreach (var usuarios in leitor)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Nascimento: {3}", usuarios.idUsu, usuarios.nomeUsu, usuarios.cargo, usuarios.datanasc);
            }

            Console.ReadLine();
        }
    }
}

