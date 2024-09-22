using System.Collections.Generic;

namespace Distribuidora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FaturamentoDiario> faturamentos= new List<FaturamentoDiario>();

            getValores(faturamentos);
        }

        public class FaturamentoDiario
        {
            private DateOnly data { get; set; }
            private double faturamento { get; set; }
            public FaturamentoDiario proximoDia { get; set; }

            public FaturamentoDiario()
            {
                
            }
            public FaturamentoDiario(DateOnly _data, double _valor)
            {
                this.data = _data;
                this.faturamento = _valor;
            }

            public DateOnly getData()
            {
                return data;
            }

            public Double getFaturamento()
            {
                return faturamento;
            }

        }

        public static void getValores(List<FaturamentoDiario> _faturamentos)
        {
            double valorMaiorFat = -1, valorMenorFat = 9000000000000000000,soma = 0,valorMedia;
            int diasSemFat = 0, dias = 0;
            FaturamentoDiario melhorDia = new FaturamentoDiario();
            FaturamentoDiario piorDia = new FaturamentoDiario();

            foreach(var dia in _faturamentos)
            {
                soma += dia.getFaturamento();
                //Definição do maior valor
                if(dia.getFaturamento() > valorMaiorFat)
                {
                    melhorDia = dia;
                    valorMaiorFat = dia.getFaturamento();
                }
                //Definição do menor valor
                if (dia.getFaturamento() < valorMenorFat)
                {
                    piorDia = dia;
                    valorMenorFat = dia.getFaturamento();
                }
                //Dia sem faturamento
                if (dia.getFaturamento() == 0)
                {
                    diasSemFat++;
                }
                dias++;
            }
            valorMedia = soma / (dias - diasSemFat);
            Console.WriteLine($"O maior faturamento foi no dia:{melhorDia.getData()}\nFaturamento:R$ {melhorDia.getFaturamento()}");
            Console.WriteLine($"O menor faturamento foi no dia:{piorDia.getData()}\nFaturamento:R$ {piorDia.getFaturamento()}");
            Console.WriteLine($"O faturamento médio anual foi de: R$ {valorMedia}");
            Console.WriteLine($"O faturamento ultrapassou a média em: {getDiasAcimaDaMedia(_faturamentos,valorMedia)} dias");

        }

        public static int getDiasAcimaDaMedia(List<FaturamentoDiario> _faturamentos, double _media)
        {
            int dias = 0;
            foreach(var dia in _faturamentos)
            {
                if (dia.getFaturamento() > _media)
                {
                    dias++;
                }
            }
            return dias;
        }

        
    }
}
