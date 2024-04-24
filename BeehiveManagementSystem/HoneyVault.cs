using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        public static string StatusReport
        {
            get
            {
                string status = $"{honey:0.0} единиц мёда\n" +
                                $"{nectar:0.0} единиц нектара";
                string warnings = "";
                if (honey < LOW_LEVEL_WARNING) warnings +=
                                    "\nМАЛО МЁДА - ДОБАВЬТЕ HONEY MANUFACTURER";
                if (nectar < LOW_LEVEL_WARNING) warnings +=
                                    "\nМАЛО НЕКТАРА - ДОБАВЬТЕ NECTAR COLLECTOR";
                return status + warnings;
            }
        }
        public const float NECTAR_CONVERSION_RATIO = .19f;
        public const float LOW_LEVEL_WARNING = 10f;
        private static float honey = 25f;
        private static float nectar = 100f;

        public static void CollectNectar(float amount)
        {
            if(amount > 0f) nectar += amount;
        }

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if(nectarToConvert > nectar) nectarToConvert = nectar;
            nectar -= nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount)
        {
            if (honey >= amount)
            {
                honey -= amount;
                return true;
            }
            return false;
        }
    }
}
