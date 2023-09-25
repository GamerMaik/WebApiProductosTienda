﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SWLNPersona
    {      
        public void Adicionar_EProducto(EProduct eProduct)
        {
            try
            {
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    context.Product.Add(eProduct);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar cambios en la base de datos");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
