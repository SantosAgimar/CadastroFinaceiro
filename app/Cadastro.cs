using System;
using System.Data;
using System.Data.Common;

namespace App;
class Cadastro
{
  public int Id {get; set; }
  public string Nome {get; set; }
  public string Rg {get; set; }
  public string Cpf {get; set; }
  public string Telefone {get; set; }
  public string Endereco {get; set; }
  public string Email {get; set; }
  public string Tipo {get; set; }
  public DateTime Data {get; }
  public string confirmar = "";
  public static int id = 0;
  public string file = "";
  private List<Cadastro> cadastros = new List<Cadastro>();
  public Cadastro(int id, string nome, string rg, string cpf, string telefone, string endereco, string email, string tipo)
  {
    Data = DateTime.Now;
    this.Id = id;
    this.Nome = nome;
    this.Rg = rg; 
    this.Cpf = cpf;
    this.Telefone = telefone;   
    this.Endereco = endereco;
    this.Email = email;
    this.Tipo = tipo;
  }
  public void salvarCadastro()
  {
    //Insert novo Cadastro
    listarCadastro();
    Console.Write("\tConfirmar? s/n ");
    confirmar = Console.ReadLine()!;
    if(confirmar == "s")
    {
      file = "arquivo.txt";
      using(StreamWriter escrever = new StreamWriter(file, true))
      {
        foreach (Cadastro cadastro in cadastros)
        {
          escrever.WriteLine($"{cadastro.Data} ");
          escrever.WriteLine($"ID: {cadastro.Id} ");
          escrever.WriteLine($"Nome: {cadastro.Nome} ");
          escrever.WriteLine($"Rg: {cadastro.Rg} ");
          escrever.WriteLine($"Cpf: {cadastro.Cpf} ");
          escrever.WriteLine($"Telefone: {cadastro.Telefone} ");
          escrever.WriteLine($"Endereco: {cadastro.Endereco} ");
          escrever.WriteLine($"Email: {cadastro.Email} ");
          escrever.WriteLine($"Tipo: {cadastro.Tipo} ");
        }
      }
      Console.WriteLine("\n\tCADASTRO SALVO COM SUCESSO. ");
    }
  }
  public void novoCadastro()
  { 
    //Inserir novo Cadastro
    Console.Write("Digite o Nome: ");
    Nome = Console.ReadLine()!;
    Console.Write("Digite a Rg: ");
    Rg = Console.ReadLine()!;
    Console.Write("Digite o Cpf: ");
    Cpf = Console.ReadLine()!;
    Console.Write("Digite o Telefone: ");
    Telefone = Console.ReadLine()!;
    Console.Write($"Digite o Endereço: ");
    Endereco = Console.ReadLine()!;
    Console.Write($"Digite o Email: ");
    Email = Console.ReadLine()!;
    Console.Write($"Digite o Tipo Conta: ");
    Tipo = Console.ReadLine()!;
    if(!string.IsNullOrEmpty(Nome))
    {
     id++;
     Id = id;
     cadastros.Add(new Cadastro(Id, Nome, Rg, Cpf, Telefone, Endereco, Email, Tipo ));
    }
  }
  public void listarCadastro()
  {
    foreach (Cadastro cadastro in cadastros)
    {
      Console.WriteLine(cadastro);
    }
    Console.WriteLine($"\nTotal Cadastros: {cadastros.Count}");
  }
  public void buscarCadastro(string busca_nome)
  {
    Cadastro buscar = cadastros.FirstOrDefault(c => c.Nome == busca_nome)!;
    if(buscar != null)
    {
      Console.WriteLine(buscar);
    }else{
      Console.WriteLine("\tCADASTRO NÃO ENCONTRADO! ");
    }
  }
  public void atualizarCadastro(int atualiza_id)
  {
    //Update Cadastro
    Cadastro atualizar = cadastros.FirstOrDefault(c => c.Id == atualiza_id)!;
    if(atualizar != null)
    {
      Console.WriteLine(atualizar);
      Console.Write("\tConfirmar? s/n ");
      confirmar = Console.ReadLine()!;
      if(confirmar == "s")
      {
        Console.Write("Atualizar o nome: ");
        string nome = Console.ReadLine()!;
        if(!string.IsNullOrEmpty(nome)) atualizar.Nome = nome;
        Console.Write("Atualizar o rg: ");
        string rg = Console.ReadLine()!;
        if(!string.IsNullOrEmpty(rg)) atualizar.Rg = rg;
        Console.Write("Atualizar o cpf: ");
        string cpf = Console.ReadLine()!;
        if(!string.IsNullOrEmpty(cpf)) atualizar.Cpf = cpf;
        Console.Write("Atualizar o telefone: ");
        string telefone = Console.ReadLine()!;
        if(!string.IsNullOrEmpty(telefone)) atualizar.Telefone = telefone;
        Console.Write("Atualizar o endereço: ");
        string endereco = Console.ReadLine()!;
        if(!string.IsNullOrEmpty(endereco)) atualizar.Endereco = endereco;
        Console.Write("Atualizar o email: ");
        string email = Console.ReadLine()!;
        if(!string.IsNullOrEmpty(email)) atualizar.Email = email;
        Console.Write("Atualizar o tipo conta: ");
        string tipo = Console.ReadLine()!;
        if(!string.IsNullOrEmpty(tipo)) atualizar.Tipo = tipo;
        Console.WriteLine("\tCADASTRO ATUALIZADO COM SUCESSO. ");
      }else{
        Console.WriteLine("\tCADASTRO NÃO ENCONTRADO! ");
      }
    }
  }
  public void deletarCadastro(int delete_id)
  {
    //Delete Cadastro
    Cadastro deletar = cadastros.FirstOrDefault(c => c.Id == delete_id)!;
    if(deletar != null)
    {
      Console.WriteLine(deletar);
      Console.Write("\tConfirmar? s/n ");
      confirmar = Console.ReadLine()!;
      if(confirmar == "s")
        cadastros.Remove(deletar);
      Console.WriteLine("\tCADASTRO EXCLUÍDO CO SUCESSO.");
    }else{
      Console.WriteLine("\tCADASTRO NÃO ENCONTRADO! ");
    }
  }
  public override string ToString()
  {
   //string mascaraTelefone = "(00) 0 0000-0000";
   //Telefone.ToString(mascaraTelefone);

      return $"\nData:\t{Data}\nID: {Id}\nNOME: {Nome}\nRG: {Rg}\nCPF: {Cpf}\nTELEFONE: {Telefone}\nENDEREÇO: {Endereco}\nEMAIL: {Email}\nTIPO CONTA: {Tipo} ";
  }
}
// string mascara = "00000-000";

//int cep = cep.ToString(mascara);