using System;
using System.Security.Cryptography;

namespace App;
class Program
{
 public static int id = 0;
 public static string nome = "";
 public static string rg = "";
 public static string cpf = "";
 public static string telefone = "";
 public static string endereco = "";
 public static string email = "";
 public static string tipo = "";
 public static string opcao = "";
 static void Main(string[] args)
 {
  Cadastro cadastro = new Cadastro(id, nome, rg, cpf, telefone, endereco, email, tipo);
  while (opcao != "8")
  {
   Console.WriteLine("\n\tOPÇÕES\n1 - Novo Cadastro\n2 - Imprimir\n3 - Listar\n4 - Salvar\n5 - Atualizar\n6 - Excluir\n7 - Buscar\n8 - Sair ");
   Console.Write("\nOpção desejada? ");
   opcao = Console.ReadLine()!;
   switch (opcao)
   {
    case "1":
     Console.WriteLine("\n\tNOVO CADASTRO. ");
     cadastro.novoCadastro();
     break;
    case "2":
     Console.WriteLine("\n\tIMPRIMIR. ");
     Console.WriteLine(cadastro.ToString());
     break;
    case "3":
     Console.WriteLine("\n\tHISTÓRICO. ");
     cadastro.listarCadastro();
     break;
    case "4":
     Console.WriteLine("\n\tSALVAR LISTA CADASTRO. ");
     cadastro.salvarCadastro();
     break;
    case "5":
     Console.Write("Atualizar pelo ID: ");
     int atualiza_id = Convert.ToInt16(Console.ReadLine());
     cadastro.atualizarCadastro(atualiza_id);
     break;
    case "6":
     Console.Write("\n\tExcluir pelo ID: ");
     int delete_id = Convert.ToInt16(Console.ReadLine());
     cadastro.deletarCadastro(delete_id);
     break;
    case "7":
     Console.Write("\n\tBuscar pelo nome: ");
     string busca_nome = Console.ReadLine()!;
     cadastro.buscarCadastro(busca_nome);
     break;
    case "8":
     Console.WriteLine("\n\tOBRIGADO POR USAR NOSSO APP.\n ");
     break;
    default:
     Console.WriteLine("\n\tOPÇÃO INVÁLIDA! ");
     break;
   }
  }
 }
}
