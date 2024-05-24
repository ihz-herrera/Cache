using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Cache.Modelos;


namespace Cache.Repository
{
    internal class LicenciasService
    {
        private MemoryCache memoryCache;
        private CacheItemPolicy policy;


        public LicenciasService()
        {
            InitializeCache();
        }

        public void InitializeCache()
        {
            memoryCache = MemoryCache.Default;
            policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10);
        }

        public bool LicenciaValida()
        {
            string cacheKey = "licencia";


            Licencia licencia;

            // Comprobar si los datos ya están en caché
            if (memoryCache.Contains(cacheKey))
            {
                licencia = memoryCache.Get(cacheKey) as Licencia;
            }
            else
            {
                // Simular una operación costosa para obtener datos
                licencia = ConsultarLicencia();
                memoryCache.Add(cacheKey, licencia, policy);
                
            }

            // Comprobar si la licencia está vencida
            return  DateTime.Parse(licencia.FechaVencimiento) < DateTime.Now ? false : true;

            
        }


        private Licencia ConsultarLicencia()
        {
            // Simulación de obtención de datos del servicio
            System.Threading.Thread.Sleep(3000); // Simula un retraso
            return new Licencia
            {
                Serial = "123456",
                Caracteristicas = "Licencia de prueba",
                FechaVencimiento = "2021-12-31"
            };
        }
    }
}
