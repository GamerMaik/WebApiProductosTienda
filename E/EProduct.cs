using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class EProduct
    {
        // Identificador único del producto
        public int ProductId { get; set; }

        // Nombre del producto
        public string Name { get; set; }

        // Descripción del producto
        public string Description { get; set; }

        // Precio del producto
        public decimal Price { get; set; }

        // Cantidad en stock del producto
        public int StockQuantity { get; set; }
    }
}
