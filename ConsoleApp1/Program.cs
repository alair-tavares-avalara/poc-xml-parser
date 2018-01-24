using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");

            //string filename = "./TAXADVISER_Oficial_MG_16 01 2018V3.xml";
            string filename = "./TAXADVISER_TESTECARGA_2.xml";
            //https://www.demacmedia.com/xml-parsing-using-linq/
            var obj = ParseXml(filename);

            obj.ForEach(item => {
                Console.WriteLine(item.Localizador);
                Console.WriteLine("----");
            });

            string finalDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");

            Console.WriteLine($"Início: {initialDateTime}");
            Console.WriteLine($"Fim: {finalDateTime}");

            Console.ReadKey();
        }

        static void parse(XmlReader reader)
        {
            
            List<string> nodes = new List<string>();
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element || reader.IsEmptyElement)
                {
                    continue;
                }

                //Console.WriteLine(reader.Name);

                switch (reader.Name)
                {
                    case "FUNDAMENTACAO":
                        Console.WriteLine(reader.Name);
                        nodes.Add(reader.Name);
                        break;
                    case "UFORIGEM":
                        Console.WriteLine(reader.ReadString());
                        break;
                }
                

                //Console.WriteLine(reader.ReadString());
                //Console.WriteLine(reader.Name);
                //nodes.Add(reader.Name);
                //reader.MoveToContent();
                //parse(reader);
            }

            Console.WriteLine(nodes.Count);
        }

        static public List<Fundamentacao> ParseXml(string inputFilePath)
        {
            var fundamentacao = new List<Fundamentacao>();
            using (var xmlReader = new StreamReader(inputFilePath))
            {
                var doc = XDocument.Load(xmlReader);

                fundamentacao = doc.Descendants("FUNDAMENTACAO")
                    .Select(item => new Fundamentacao {
                        Localizador = item.Element("LOCALIZADOR").Value,
                        Descricao = item.Element("DESCRICAO").Value,
                        Ato = item.Element("ATO").Value,
                        NumeroAto = item.Element("NUMEROATO").Value,
                        Ano = item.Element("ANO").Value,
                        Artigo = item.Element("ARTIGO").Value,
                        Alinea = item.Element("ALINEA").Value,
                        Item = item.Element("ITEM").Value,
                        Inciso = item.Element("INCISO").Value,
                        Letra = item.Element("LETRA").Value,
                        Paragrafo = item.Element("PARAGRAFO").Value,
                        ItemParagrafo = item.Element("ITEMPARAGRAFO").Value,
                        Anexo = item.Element("ANEXO").Value,
                        Observacao = item.Element("OBSERVACAO").Value,
                        VigenciaInicio = item.Element("VIGENCIAINICIO").Value,
                        VigenciaFim = item.Element("VIGENCIAFIM").Value,
                        UFSOrigem = item.Descendants("UFSORIGEM")
                            .Where(uf => uf != null && uf.Element("UFORIGEM") != null)
                            .Select(uf => uf.Element("UFORIGEM").Value)
                            .ToList(),
                        UFSDestino =  item.Descendants("UFSDESTINO")
                            .Where(uf => uf != null && uf.Element("UFDESTINO") != null)
                            .Select(uf => uf.Element("UFDESTINO").Value)
                            .ToList(),
                        Esfera = item.Element("ESFERA").Value,
                        Tributo = item.Element("TRIBUTO").Value,
                        Especie = item.Element("ESPECIE").Value,
                        Aliquotas = item.Descendants("ALIQUOTAS")
                            .Where(aliquota => aliquota != null && aliquota.Element("VALORALIQUOTA") != null)
                            .Select(aliquota => aliquota.Element("VALORALIQUOTA").Value)
                            .ToList(),
                        //AtividadeFund = item.Element("ATIVIDADEFUND").Value,
                        //DestinacaoFund = item.Element("DESTINACAOFUND").Value,
                        //FinalidadeFund = item.Element("FINALIDADEFUND").Value,
                        //TratativaFund = item.Element("TRATATIVAFUND").Value,
                        //DetalheFundamentacao
                    })
                    .ToList();
            }
            return fundamentacao;
        }
    }
}
