using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcellDataReader.Model
{
    public class F1Class
    {
        public string? НомерКримінальногоПровадження { get; set; }
        public string? НомерПервинногоПровадження { get; set; }
        public DateTime ДатаВнесенняДоЄРДР { get; set; }
        public string? ОДР { get; set; }
        public string? Кваліфікація { get; set; }
        public string? СтаршийПрокурор { get; set; }
        public string? Прокурор { get; set; }
        public string? Заявник { get; set; }
        public DateTime ДатаПовідомленняПроПідозру { get; set; }
        public string? Рішення { get; set; }
        public DateTime ДатаПрийняттяРішення { get; set; }
        public string? СтатусПровадження { get; set; }
        public string? СтатусПравопорушення { get; set; }
        public DateTime ДатаЗупинення { get; set; }
        public DateTime ДатаВідновлення { get; set; }
        public string? ПідставаВідновлення { get; set; }
        public string? ЗареєструвавОДР { get; set; }
        public string? ДодатковіВідмітки { get; set; }
        public string? Класифікація { get; set; }
        public string? Зупинено { get; set; }
        public string? ПідставаВнесення { get; set; }
        public string? Вилучено { get; set; }
        public string? ПродовженоСтрок { get; set; }
        public string? ЗнаряддяТаЗасоби { get; set; }
        public string? УстановленаСумаЗбитків { get; set; }
        public string? ВідшкодованаСумаЗбитків { get; set; }
        public string? НакладеноАрешт { get; set; }
        public string? ЗаявленоПозови { get; set; }
    }
}
