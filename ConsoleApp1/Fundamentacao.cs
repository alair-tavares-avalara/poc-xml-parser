using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class ValorDets
    {
        public string ItemDet { get; set; }
        public string ValorDet { get; set; }
        public string CodigoCest { get; set; }
        public string DescricaoDet { get; set; }
        public string Categoria { get; set; }
        public string TipoIva { get; set; }
        public string ObedeceDestino { get; set; }
        public string Embalagem { get; set; }
        public string UnidadeMedida { get; set; }
        public string QuantidadeDe { get; set; }
        public string QuantidadeAte { get; set; }
        public string VigenciaInicial { get; set; }
        public string VigenciaFinal { get; set; }
        public string Fabricante { get; set; }
        public string Cnpj { get; set; }
        public string Classe { get; set; }
        public string Observacao { get; set; }
        public List<string> Ncms { get; set; }
        public string AtivadadeDet { get; set; }
        public string DestinacaoDet { get; set; }
        public string FinalidadeDet { get; set; }
        public string TratativaDet { get; set; }
    }
    class Detalhe
    {
        public List<ValorDets> ValorDets;
    }
    class DetalheFundamentacao
    {
        public List<Detalhe> Detalhe { get; set; }
    }

    class Fundamentacao
    {
        public string Localizador { get; set; }
        public string Descricao { get; set; }
        public string Ato { get; set; }
        public string NumeroAto { get; set; }
        public string Ano { get; set; }
        public string Artigo { get; set; }
        public string Alinea { get; set; }
        public string Item { get; set; }
        public string Inciso { get; set; }
        public string Letra { get; set; }
        public string Paragrafo { get; set; }
        public string ItemParagrafo { get; set; }
        public string Anexo { get; set; }
        public string Observacao { get; set; }
        public string VigenciaInicio { get; set; }
        public string VigenciaFim { get; set; }
        public List<string> UFSOrigem { get; set; }
        public List<string> UFSDestino { get; set; }
        public string Esfera { get; set; }
        public string Tributo { get; set; }
        public string Especie { get; set; }
        public List<string> Aliquotas { get; set; }
        public string AtividadeFund { get; set; }
        public string DestinacaoFund { get; set; }
        public string FinalidadeFund { get; set; }
        public string TratativaFund { get; set; }
        public List<DetalheFundamentacao> DetalheFundamentacao { get; set; }
    }
}