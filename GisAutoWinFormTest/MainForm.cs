using System;
using System.Windows.Forms;

namespace GisAutoWinFormTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ResetProgressBarPosition();

            PeugeotWB.Visible = false;
            LoadPB.Visible = true;

            PeugeotWB.Navigate("http://public.servicebox.peugeot.com/do/login");
        }

        #region Events

        private void PeugeotWB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (PeugeotWB.Url.AbsoluteUri.Contains("login"))
            {
                if (!LogIn())
                {
                    MessageBox.Show("Ошибка при попытке подключения к каталогу. Пожалуйста, обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
            else
            {
                var lg = PeugeotWB.Document.GetElementById("libelleflag");
                if (lg != null && !lg.InnerText.Contains("Россия"))
                {
                    //ru_RU
                    var lng = PeugeotWB.Document.GetElementById("ru_RU");
                    if (lng != null)
                    {
                        lng.InvokeMember("click");
                    }
                }
                PeugeotWB.Visible = true;
                LoadPB.Visible = false;
            }

            //Скрываем футер и кнопки навигации
            HideElementById("tools");
            HideElementById("footer");

        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResetProgressBarPosition();
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Reorder credentials
            //Если мы не попадаем в это событие, значит приложение завершилось некорректно и делать перестановку не нужно
            var logPass = Properties.Settings.Default.CredentialsArray[0];
            Properties.Settings.Default.CredentialsArray.RemoveAt(0);
            Properties.Settings.Default.CredentialsArray.Add(logPass);
            Properties.Settings.Default.Save();
        }

        #endregion

        #region Methods

        private void ResetProgressBarPosition()
        {
            LoadPB.Left = (ClientSize.Width - LoadPB.Width) / 2;
            LoadPB.Top = (ClientSize.Height - LoadPB.Height) / 2;
        }

        private bool LogIn()
        {
            try
            {
                //Make sure that credentials are correct
                if (Properties.Settings.Default.CredentialsArray.Count < 1)
                {
                    return false;
                }
                var settings = Properties.Settings.Default.CredentialsArray[0].Split(';');
                if (settings.Length < 2)
                {
                    return false;
                }

                var username = PeugeotWB.Document.GetElementById("username");
                var pass = PeugeotWB.Document.GetElementById("password");
                var btn = PeugeotWB.Document.GetElementById("btsubmit");
                if (username != null && pass != null && btn != null)
                {
                    username.InnerText = settings[0];
                    pass.InnerText = settings[1];
                    btn.InvokeMember("click");
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                //TODO: Log
                return false;
            }

            return true;
        }

        private void HideElementById(string id)
        {
            var tools = PeugeotWB.Document.GetElementById(id);
            if (tools != null)
                tools.Style = "display:none";
        }

        #endregion

    }
}
