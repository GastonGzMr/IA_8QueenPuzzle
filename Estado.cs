using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP06_5
{
    public class Estado
    {
        public int[] EstadoDelTablero;

        public Estado(int[] tablero)
        {
            EstadoDelTablero = tablero;
        }

        public Estado(Estado padre1, Estado padre2)
        {
            EstadoDelTablero = new int[]
            {
                padre1.EstadoDelTablero[0],
                padre1.EstadoDelTablero[1],
                padre1.EstadoDelTablero[2],
                padre1.EstadoDelTablero[3],
                padre2.EstadoDelTablero[4],
                padre2.EstadoDelTablero[5],
                padre2.EstadoDelTablero[6],
                padre2.EstadoDelTablero[7]
            };
            Mutar();
        }

        private void Mutar()
        {
            Random random = new Random();
            EstadoDelTablero[random.Next(0, 7)] = random.Next(0, 7);
        }

        public int ObtenerAjuste()
        {
            int ajuste = 0;
            for (int i = 0; i < EstadoDelTablero.Length; i++)
            {
                if(EstadoDelTablero.Where(x => (x == EstadoDelTablero[i]) && (Array.IndexOf(EstadoDelTablero,x) != i)).Count() > 0)
                {
                    ajuste++;
                }
                if(EstadoDelTablero.Where(x => (Math.Abs(Array.IndexOf(EstadoDelTablero, x) - i) == Math.Abs(EstadoDelTablero[i] - x))
                && (Array.IndexOf(EstadoDelTablero, x) != i)).Count() > 0)
                {
                    ajuste++;
                }
            }
            return ajuste;
        }
    }
}
