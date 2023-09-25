using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class EProduct
    {
        // Identificador único del productos
        [Key]
        public int ProductId { get; set; }

        // Nombre del productos
        public string Name { get; set; }

        // Descripción del productos
        public string Description { get; set; }

        // Precio del productos
        public decimal Price { get; set; }

        // Cantidad en stock del productos
        public int StockQuantity { get; set; }
    }
}
