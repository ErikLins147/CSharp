using System;

namespace API.Models
{
    public class Cliente 
    {
        //Construtor
        public Cliente() => CriadoEm = DateTime.Now;
        
      

        //Atributos
        public int ClienteID     { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
    
        public string CPF {get; set;}

        //ToString

        public override string ToString() =>
            $"Nome: {Nome} | CPF: {CPF:C2} | Criado em: {CriadoEm}";
    }
}