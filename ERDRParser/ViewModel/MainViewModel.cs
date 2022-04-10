using ERDRParser.Core;
using ERDRParser.ViewModel;
using ExcellDataReader.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ERDRParser.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        List<F1Class> f1Class;
        List<string> inputList;

        public MainViewModel()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            f1Class = new List<F1Class>();
            inputList = new List<string>();         
        }

        #region Properties

        private string inputText;
        public string InputText
        {
            get => inputText;
            set
            {
                SetProperty(ref inputText, value);
            }
        }

        private string prosecutorText;
        public string ProsecutorText
        {
            get => prosecutorText;
            set
            {
                SetProperty(ref prosecutorText, value);
            }
        }

        private string qualificationText;
        public string QualificationText
        {
            get => qualificationText;
            set
            {
                SetProperty(ref qualificationText, value);
            }
        }

        private string additionalMarksText;
        public string AdditionalMarksText
        {
            get => additionalMarksText;
            set
            {
                SetProperty(ref additionalMarksText, value);
            }
        }

        #endregion

        #region Commands

        private ICommand command;
        public ICommand Command
        {
            get
            {
                return command ?? (command = new CommandHandler(param => CommandAction(param), true));
            }
        }

        public void CommandAction(object _parpam)
        {
            if (_parpam != null)
            {
                switch (_parpam.ToString())
                {
                    case "parse":
                        SetInputList(InputText);
                        ShowProsecutor();
                        ShowQualification();
                        ShowAdditionalMarks();
                        MessageBox.Show("Загружено");
                        break;

                    case "openFile":
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        if (openFileDialog.ShowDialog() == true)
                        {
                            f1Class = ExcellToList.GetDataList(openFileDialog.FileName);
                        }
                        MessageBox.Show("Загружено");
                        break;
                }
            }
        }

        #endregion

        #region Functions

        private void SetInputList(string _text)
        {
            inputList.Clear();
            foreach (var line in _text.Split("\n"))
            {
                if (TextServise.GetCriminalnumber(line) != "")
                {
                    inputList.Add(TextServise.GetCriminalnumber(line));
                    Debug.WriteLine(line);
                }
            }
        }

        private void ShowProsecutor()
        {
            List<string> list = new List<string>();
            if (inputList.Count > 0)
            {
                foreach (var line in inputList)
                {
                    string headProsecutor = "";
                    var result_1 = f1Class.Where(x => x.НомерКримінальногоПровадження == line).ToList();
                    if (result_1.Count > 0)
                    {
                        headProsecutor = result_1.FirstOrDefault().СтаршийПрокурор;
                    }

                    string lastProsecutor = "";
                    var result_2 = f1Class.Where(x => x.НомерКримінальногоПровадження == line).ToList();
                    if (result_2.Count > 0)
                    {
                        lastProsecutor = result_2.FirstOrDefault().Прокурор;
                    }

                    list.Add($"{headProsecutor},{lastProsecutor}");
                }
                string result = "";
                foreach (var line in list)
                {
                    result = result + line + "\n";
                }
                ProsecutorText = result;
            }
        }

        private void ShowQualification()
        {
            List<string> list = new List<string>();
            if (inputList.Count > 0)
            {
                foreach (var line in inputList)
                {
                    string qualification = "";
                    var result_1 = f1Class.Where(x => x.НомерКримінальногоПровадження == line).ToList();
                    if (result_1.Count > 0)
                    {
                        foreach (var s in result_1)
                        {
                            qualification = qualification + "," + s.Кваліфікація;
                        }
                    }

                    list.Add($"{qualification}");
                }
                string result = "";
                foreach (var line in list)
                {
                    result = result + line + "\n";
                }
                QualificationText = result;
            }
        }

        private void ShowAdditionalMarks()
        {
            List<string> list = new List<string>();
            if (inputList.Count > 0)
            {
                foreach (var line in inputList)
                {
                    string additionalMarks = "";
                    var result_1 = f1Class.Where(x => x.НомерКримінальногоПровадження == line).ToList();
                    result_1 = result_1.Distinct().ToList();
                    if (result_1.Count > 0)
                    {
                        foreach (var s in result_1)
                        {
                            additionalMarks = additionalMarks + "," + s.ДодатковіВідмітки;
                        }
                    }

                    list.Add($"{additionalMarks}");
                }
                string result = "";
                foreach (var line in list)
                {
                    result = result + line + "\n";
                }
                AdditionalMarksText = result;
            }
        }


        #endregion
    }
}
