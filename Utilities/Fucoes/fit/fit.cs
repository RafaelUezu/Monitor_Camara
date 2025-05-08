using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace Monitor_Camara.Utilities.Fucoes.fit
{
    public class fit
    {
        static double[] leitura = { 4000, 5600, 7200, 8800, 10400, 12000, 13600, 15200, 16800, 18400, 20000 };
        static double[] temperatura = {-64.76728426,
                                        -31.72102302,
                                        -11.06660893,
                                        12.71398415,
                                        36.09338986,
                                        55.56182199,
                                        83.18311953,
                                        113.3400121,
                                        127.4866623,
                                        137.075559,
                                        161.4686599};
        public class Coefficient_Generator()
        {
            public void A()
            {
                var coeficientes = Fit.Polynomial(leitura, temperatura, 10);

                for (int i = 0; i < coeficientes.Length; i++)
                {
                    System.Diagnostics.Debug.WriteLine($"Coeficiente a{i}: {coeficientes[i]}");
                }
                return;
            }
        }
    }
}
