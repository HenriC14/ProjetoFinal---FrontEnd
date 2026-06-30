using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecicladorBlazor.Models.Enuns;

namespace RecicladorBlazor.Models
{
    public class MaterialViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ClasseEnum TipoMaterial { get; set; }
        public decimal Peso { get; set; }
        public decimal ValorPorPeso { get; set; }
    }
}