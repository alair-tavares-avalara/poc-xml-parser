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
                //Console.WriteLine(item.Localizador);
                //Console.WriteLine("----");
            });

            string finalDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");

            Console.WriteLine($"Início: {initialDateTime}");
            Console.WriteLine($"Fim: {finalDateTime}");

            Console.ReadKey();
        }
        
        static public List<Fundamentacao> ParseXml(string inputFilePath)
        {
            var fundamentacao = new List<Fundamentacao>();
            using (var xmlReader = new StreamReader(inputFilePath))
            {
                var doc = XDocument.Load(xmlReader);

                fundamentacao = doc.Descendants("FUNDAMENTACAO")
                    .Select(item => new Fundamentacao {
                        Localizador = item.Element("LOCALIZADOR")?.Value,
                        Descricao = item.Element("DESCRICAO")?.Value,
                        Ato = item.Element("ATO")?.Value,
                        NumeroAto = item.Element("NUMEROATO")?.Value,
                        Ano = item.Element("ANO")?.Value,
                        Artigo = item.Element("ARTIGO")?.Value,
                        Alinea = item.Element("ALINEA")?.Value,
                        Item = item.Element("ITEM")?.Value,
                        Inciso = item.Element("INCISO")?.Value,
                        Letra = item.Element("LETRA")?.Value,
                        Paragrafo = item.Element("PARAGRAFO")?.Value,
                        ItemParagrafo = item.Element("ITEMPARAGRAFO")?.Value,
                        Anexo = item.Element("ANEXO")?.Value,
                        Observacao = item.Element("OBSERVACAO")?.Value,
                        VigenciaInicio = item.Element("VIGENCIAINICIO")?.Value,
                        VigenciaFim = item.Element("VIGENCIAFIM")?.Value,
                        UFSOrigem = item.Descendants("UFSORIGEM")
                            .Select(uf => uf.Element("UFORIGEM")?.Value)
                            .ToList(),
                        UFSDestino = item.Descendants("UFSDESTINO")
                            .Select(uf => uf.Element("UFDESTINO")?.Value)
                            .ToList(),
                        Esfera = item.Element("ESFERA")?.Value,
                        Tributo = item.Element("TRIBUTO")?.Value,
                        Especie = item.Element("ESPECIE")?.Value,
                        Aliquotas = item.Descendants("ALIQUOTAS")
                            .Select(aliquota => aliquota.Element("VALORALIQUOTA")?.Value)
                            .ToList(),
                        AtividadeFund = item.Element("ATIVIDADEFUND")?.Value,
                        DestinacaoFund = item.Element("DESTINACAOFUND")?.Value,
                        FinalidadeFund = item.Element("FINALIDADEFUND")?.Value,
                        TratativaFund = item.Element("TRATATIVAFUND")?.Value,
                        DetalheFundamentacao = item.Descendants("DETALHEFUNDAMENTACAO")
                            .Select(detalheFundamentacao => new DetalheFundamentacao
                            {
                                Detalhe = detalheFundamentacao.Descendants("DETALHE")
                                    .Select(det => new Detalhe
                                    {
                                        ValorDets = det.Descendants("VALORDETS")
                                            .Select(valor => new ValorDets
                                            {
                                                ItemDet = valor.Element("ITEMDET")?.Value,
                                                ValorDet = valor.Element("VALORDET")?.Value,
                                                CodigoCest = valor.Element("CODIGOCEST")?.Value,
                                                DescricaoDet = valor.Element("DESCRICAODET")?.Value,
                                                Categoria = valor.Element("CATEGORIA")?.Value,
                                                TipoIva = valor.Element("TIPOIVA")?.Value,
                                                ObedeceDestino = valor.Element("OBEDECEDESTINO")?.Value,
                                                Embalagem = valor.Element("EMBALAGEM")?.Value,
                                                UnidadeMedida = valor.Element("UNIDADEMEDIDA")?.Value,
                                                QuantidadeDe = valor.Element("QUANTIDADEDE")?.Value,
                                                QuantidadeAte = valor.Element("QUANTIDADEATE")?.Value,
                                                VigenciaInicial = valor.Element("VIGENCIAINICIAL")?.Value,
                                                VigenciaFinal = valor.Element("VIGENCIAFINAL")?.Value,
                                                Fabricante = valor.Element("FABRICANTE")?.Value,
                                                Cnpj = valor.Element("CNPJ")?.Value,
                                                Classe = valor.Element("CLASSE")?.Value,
                                                Observacao = valor.Element("OBSERVACAO")?.Value,
                                                Ncms = valor.Descendants("NCMS").Select(ncm => ncm.Element("NCM")?.Value).ToList(),
                                                AtivadadeDet = valor.Element("ATIVIDADEDET")?.Value,
                                                DestinacaoDet = valor.Element("DESTINACAODEET")?.Value,
                                                FinalidadeDet = valor.Element("FINALIDADEDET")?.Value,
                                                TratativaDet = valor.Element("TRATATIVADET")?.Value,
                                            }).ToList()
                                    }).ToList()
                            }).FirstOrDefault()
                    })
                    .ToList();
            }
            return fundamentacao;
        }
    }
}
