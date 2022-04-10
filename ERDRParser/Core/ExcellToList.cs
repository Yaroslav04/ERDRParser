using ExcelDataReader;
using ExcellDataReader.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERDRParser.Core
{
    public static class ExcellToList
    {
        public static List<F1Class> GetDataList(string _path)
        {
            List<F1Class> list = new List<F1Class>();
            using (Stream stream = File.Open(_path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;
                reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                var dataSet = reader.AsDataSet(conf);
                DataTable dataTable = dataSet.Tables[0];

                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    F1Class f1Class = new F1Class();
                    f1Class.НомерКримінальногоПровадження = dataTable.Rows[i][1].ToString();
                    f1Class.НомерПервинногоПровадження = dataTable.Rows[i][2].ToString();
                    if (dataTable.Rows[i][3].ToString() != "")
                    {
                        f1Class.ДатаВнесенняДоЄРДР = Convert.ToDateTime(dataTable.Rows[i][3]);
                    }
                    else
                    {
                        f1Class.ДатаВнесенняДоЄРДР = DateTime.MinValue;
                    }
                   
                    f1Class.ОДР = dataTable.Rows[i][4].ToString();
                    f1Class.Кваліфікація = dataTable.Rows[i][5].ToString();
                    f1Class.СтаршийПрокурор = dataTable.Rows[i][6].ToString();
                    f1Class.Прокурор = dataTable.Rows[i][7].ToString();
                    f1Class.Заявник = dataTable.Rows[i][8].ToString();

                    if (dataTable.Rows[i][9].ToString() != "")
                    {
                        f1Class.ДатаПовідомленняПроПідозру = Convert.ToDateTime(dataTable.Rows[i][9]);
                    }
                    else
                    {
                        f1Class.ДатаПовідомленняПроПідозру = DateTime.MinValue;
                    }
                    
                    f1Class.Рішення = dataTable.Rows[i][10].ToString();

                    if (dataTable.Rows[i][11].ToString() != "")
                    {
                        f1Class.ДатаПрийняттяРішення = Convert.ToDateTime(dataTable.Rows[i][11]);
                    }
                    else
                    {
                        f1Class.ДатаПрийняттяРішення = DateTime.MinValue;
                    }
                 
                    f1Class.СтатусПровадження = dataTable.Rows[i][12].ToString();
                    f1Class.СтатусПравопорушення = dataTable.Rows[i][13].ToString();

                    if (dataTable.Rows[i][14].ToString() != "")
                    {
                        f1Class.ДатаЗупинення = Convert.ToDateTime(dataTable.Rows[i][14]);
                    }
                    else
                    {
                        f1Class.ДатаЗупинення = DateTime.MinValue;
                    }

                    if (dataTable.Rows[i][15].ToString() != "")
                    {
                        f1Class.ДатаВідновлення = Convert.ToDateTime(dataTable.Rows[i][15]);
                    }
                    else
                    {
                        f1Class.ДатаВідновлення = DateTime.MinValue;
                    }
              
                    f1Class.ПідставаВідновлення = dataTable.Rows[i][16].ToString();
                    f1Class.ЗареєструвавОДР = dataTable.Rows[i][17].ToString();
                    f1Class.ДодатковіВідмітки = dataTable.Rows[i][18].ToString();
                    f1Class.Класифікація = dataTable.Rows[i][19].ToString();
                    f1Class.Зупинено = dataTable.Rows[i][20].ToString();
                    f1Class.ПідставаВнесення = dataTable.Rows[i][21].ToString();
                    f1Class.Вилучено = dataTable.Rows[i][22].ToString();
                    f1Class.ПродовженоСтрок = dataTable.Rows[i][23].ToString();
                    f1Class.ЗнаряддяТаЗасоби = dataTable.Rows[i][24].ToString();
                    f1Class.УстановленаСумаЗбитків = dataTable.Rows[i][25].ToString();
                    f1Class.ВідшкодованаСумаЗбитків = dataTable.Rows[i][26].ToString();
                    f1Class.НакладеноАрешт = dataTable.Rows[i][27].ToString();
                    f1Class.ЗаявленоПозови = dataTable.Rows[i][28].ToString();
                    list.Add(f1Class);
                }
            }
            return list;
        }
    }
}
