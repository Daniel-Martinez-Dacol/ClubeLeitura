using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    internal class TelaCadastroAmigo
    {
        public CadastroAmigo[] amigos;
        public int numeroDoCadastro;
        public Notificador notificador;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoCadastro()
        {
            MostrarTitulo("Inserindo novo Cadastro:");

           CadastroAmigo cadastroAmigo = ObterCadastro();

            cadastroAmigo.numeroDoCadastro = ++numeroDoCadastro;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = cadastroAmigo;

            notificador.ApresentarMensagem("Cadastro inserido com sucesso!", "Sucesso");
        }

        private CadastroAmigo ObterCadastro()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel: ");
            string nomeDoResponsavel = Console.ReadLine();

            Console.Write("Digite o endereço do amigo: ");
            string endereco = Console.ReadLine();

            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();

            CadastroAmigo cadastro = new CadastroAmigo();

            cadastro.nome = nome;
            cadastro.nomeDoResponsavel = nomeDoResponsavel;
            cadastro.endereco = endereco;
            cadastro.telefone = telefone;

            return cadastro;
        }

        public void EditarCadastro()
        {
            MostrarTitulo("Editando Cadastro");

            VisualizarCadastros("Pesquisando...");

            Console.Write("Digite o número do cadastro que deseja editar: ");
            int numeroCadastro = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].numeroDoCadastro == numeroCadastro)
                {
                    CadastroAmigo cadastro = ObterCadastro();
      
                    amigos[i] = cadastro;
                    amigos[i].numeroDoCadastro = numeroCadastro;
                    break;
                }
            }

            notificador.ApresentarMensagem("Cadastro editado com sucesso", "Sucesso");
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public void ExcluirCadastro()
        {
            MostrarTitulo("Excluindo Cadastro");

            VisualizarCadastros("Pesquisando...");

            Console.Write("Digite o número do cadastro que deseja excluir: ");
            int numeroCadastro = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].numeroDoCadastro == numeroCadastro)
                {
                    amigos[i] = null;
                    break;
                }
            }

            notificador.ApresentarMensagem("Cadastro excluído com sucesso", "Sucesso");
        }

        public void VisualizarCadastros(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Revistas");

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                CadastroAmigo c = amigos[i];

                Console.WriteLine("Número do cadastro: " + c.numeroDoCadastro);
                Console.WriteLine("Nome do Amigo: " + c.nome);
                Console.WriteLine("Nome do responsavel: " + c.nomeDoResponsavel);
                Console.WriteLine("Endereço do amigo: " + c.endereco);
                Console.WriteLine("Telefone do amigo: " + c.telefone);

                Console.WriteLine();
            }
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

    }
}
