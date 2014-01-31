using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectExplorer
{
    class Program
    {

        public class ObjectExplorer
        {
            public static D TransferData<O, D>(O source)
            {
                try
                {

                    D destination = Activator.CreateInstance<D>();

                    Type fontType = source.GetType();
                    Type destinyType = destination.GetType();

                    PropertyInfo[] pFont = fontType.GetProperties();
                    PropertyInfo[] pDestiny = destinyType.GetProperties();

                    for (int i = 0; i < pDestiny.Count(); i++)
                    {


                        for (int j = 0; j < pFont.Count(); j++)
                        {
                            var atributo = pFont[j].GetValue(source);
                            
                            var nomePropriedade = atributo.

                            var tipoAtributo = atributo.GetType();
                            
                            if (!tipoAtributo.Name.Contains("List"))
                                if (pFont[j].GetType().Equals(pDestiny[i].GetType()))
                                    pDestiny[i].SetValue(destination, pFont[j].GetValue(source));
                        }

                        //var pf = pFont[i].GetValue(source);

                        //if (pf != null)
                        //{
                        //    var d = pf.GetType();

                        //    if (!d.Name.Contains("List"))
                        //        if (pFont[i].GetType().Equals(pDestiny[i].GetType()))
                        //            pDestiny[i].SetValue(destination, pFont[i].GetValue(source));
                        //}

                    }

                    return destination;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            public static List<D> TransferData<O, D>(List<O> source)
            {
                try
                {
                    List<D> retorno = new List<D>();

                    foreach (var item in source)
                    {
                        retorno.Add(TransferData<O, D>(item));
                    }

                    return retorno;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        static void Main(string[] args)
        {

            Pessoa p = new Pessoa();
            OutraPessoa op = new OutraPessoa();

            op = ObjectExplorer.TransferData<Pessoa, OutraPessoa>(p);

            Console.ReadKey();
        }


        class OutraPessoa
        {
            public string Nome { get; set; }
            public string Endereco { get; set; }
            public string Telefone { get; set; }
            public string CPF { get; set; }
            public int Idade { get; set; }
            public string Email { get; set; }
            public char Sexo { get; set; }
        }

        class Pessoa
        {
            public string Nome { get; set; }
            public string Endereco { get; set; }
            public string Telefone { get; set; }
            public string CPF { get; set; }
            public int Idade { get; set; }


            public Pessoa()
            {
                this.Nome = "Gustavo";
                this.Endereco = "Rua Aristides Ladeira 23";
                this.Telefone = "24 - 98102-2507";
                this.CPF = "10140371745";
                this.Idade = 28;
            }
        }

    }
}
