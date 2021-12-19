using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP06_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Estado> estadosIniciales = new List<Estado>();
            Estado padre1;
            Estado padre2;
            Estado hijo1;
            Estado hijo2;
            int ajusteMinimo;
            int cantidadDePasos = 0;

            estadosIniciales = new List<Estado>{
                new Estado(new int[]{6, 3, 7, 0, 5, 3, 1, 4}),
                new Estado(new int[]{3, 6, 0, 2, 7, 7, 1, 1}),
                new Estado(new int[]{1, 5, 7, 2, 6, 1, 3, 5}),
                new Estado(new int[]{6, 3, 6, 5, 2, 4, 6, 7}),
                new Estado(new int[]{2, 1, 3, 3, 7, 0, 3, 3}),
                new Estado(new int[]{1, 0, 1, 0, 7, 4, 2, 6}),
                new Estado(new int[]{1, 7, 1, 1, 6, 4, 4, 0}),
                new Estado(new int[]{0, 7, 3, 6, 0, 6, 2, 6}),
                new Estado(new int[]{0, 3, 5, 1, 4, 3, 2, 2}),
                new Estado(new int[]{0, 7, 2, 3, 0, 1, 2, 5}),
                new Estado(new int[]{5, 1, 1, 3, 3, 4, 5, 3}),
                new Estado(new int[]{6, 5, 0, 5, 3, 3, 0, 5}),
                new Estado(new int[]{0, 2, 2, 3, 5, 1, 0, 1}),
                new Estado(new int[]{4, 2, 7, 3, 4, 4, 7, 3}),
                new Estado(new int[]{2, 3, 6, 3, 0, 5, 2, 5}),
            };

            estadosIniciales = estadosIniciales.OrderBy(x => x.ObtenerAjuste()).ToList();
            padre1 = estadosIniciales[0];
            padre2 = estadosIniciales[1];
            ajusteMinimo = padre1.ObtenerAjuste();

            while (ajusteMinimo > 0)
            {
                cantidadDePasos++;
                hijo1 = new Estado(padre1, padre2);
                if (!(estadosIniciales.Where(x => Enumerable.SequenceEqual(x.EstadoDelTablero,hijo1.EstadoDelTablero)).Count() > 0))
                {
                    estadosIniciales.Add(hijo1);
                }

                hijo2 = new Estado(padre2, padre1);
                if (!(estadosIniciales.Where(x => Enumerable.SequenceEqual(x.EstadoDelTablero, hijo2.EstadoDelTablero)).Count() > 0))
                {
                    estadosIniciales.Add(hijo2);
                }
               
                estadosIniciales = estadosIniciales.OrderBy(x => x.ObtenerAjuste()).ToList();
                padre1 = estadosIniciales[0];
                padre2 = estadosIniciales[1];
                ajusteMinimo = padre1.ObtenerAjuste();
            }

            Console.WriteLine("Solución encontrada en " + cantidadDePasos + " pasos:");
            Escribir(padre1.EstadoDelTablero);
            Console.ReadLine();
        }

        public static void Escribir(int[] array)
        {
            foreach (int numero in array)
            {
                Console.Write(numero + " ");
            }
        }
    }
}
