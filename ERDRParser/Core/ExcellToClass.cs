using ExcellDataReader.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERDRParser.Core
{
    public static class ExcellToClass
    {
        public static List<F1Class> GetF1(List<List<string>> _list)
        {
            List<F1Class> result = new List<F1Class>();

            foreach (var item in _list)
            {
                F1Class f1Class = new F1Class();
                f1Class.НомерКримінальногоПровадження = item[1].ToString();
                f1Class.НомерПервинногоПровадження = item[2].ToString();
                if (item[3].ToString() != "")
                {
                    f1Class.ДатаВнесенняДоЄРДР = Convert.ToDateTime(item[3]);
                }
                else
                {
                    f1Class.ДатаВнесенняДоЄРДР = DateTime.MinValue;
                }

                f1Class.ОДР = item[4].ToString();
                f1Class.Кваліфікація = item[5].ToString();
                f1Class.СтаршийПрокурор = item[6].ToString();
                f1Class.Прокурор = item[7].ToString();
                f1Class.Заявник = item[8].ToString();

                if (item[9].ToString() != "")
                {
                    f1Class.ДатаПовідомленняПроПідозру = Convert.ToDateTime(item[9]);
                }
                else
                {
                    f1Class.ДатаПовідомленняПроПідозру = DateTime.MinValue;
                }

                f1Class.Рішення = item[10].ToString();

                if (item[11].ToString() != "")
                {
                    f1Class.ДатаПрийняттяРішення = Convert.ToDateTime(item[11]);
                }
                else
                {
                    f1Class.ДатаПрийняттяРішення = DateTime.MinValue;
                }

                f1Class.СтатусПровадження = item[12].ToString();
                f1Class.СтатусПравопорушення = item[13].ToString();

                if (item[14].ToString() != "")
                {
                    f1Class.ДатаЗупинення = Convert.ToDateTime(item[14]);
                }
                else
                {
                    f1Class.ДатаЗупинення = DateTime.MinValue;
                }

                if (item[15].ToString() != "")
                {
                    f1Class.ДатаВідновлення = Convert.ToDateTime(item[15]);
                }
                else
                {
                    f1Class.ДатаВідновлення = DateTime.MinValue;
                }

                f1Class.ПідставаВідновлення = item[16].ToString();
                f1Class.ЗареєструвавОДР = item[17].ToString();
                f1Class.ДодатковіВідмітки = item[18].ToString();
                f1Class.Класифікація = item[19].ToString();
                f1Class.Зупинено = item[20].ToString();
                f1Class.ПідставаВнесення = item[21].ToString();
                f1Class.Вилучено = item[22].ToString();
                f1Class.ПродовженоСтрок = item[23].ToString();
                f1Class.ЗнаряддяТаЗасоби = item[24].ToString();
                f1Class.УстановленаСумаЗбитків = item[25].ToString();
                f1Class.ВідшкодованаСумаЗбитків = item[26].ToString();
                f1Class.НакладеноАрешт = item[27].ToString();
                f1Class.ЗаявленоПозови = item[28].ToString();
                result.Add(f1Class);
            }

            return result;
        }
    }
}
