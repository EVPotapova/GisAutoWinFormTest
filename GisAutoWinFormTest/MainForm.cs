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
                    MessageBox.Show("Ошибка при попытке подключения к каталогу. Пожалуйста, обратитесь к администратору.","Ошибка", MessageBoxButtons.OK);
                    Application.Exit();
                    
                }
                //TODO: Если сеанс закончился
            }
            else
            {
                //TODO: Загруженность обработка полосы загрузки?
                //TODO: Первый вход?
                //TODO: Изменить язык при ПЕРВОМ входе
                //CodeLanguePaysOI = ru_RU
                var lng = PeugeotWB.Document.GetElementById("ru_UA");
                if (lng != null)
                {
                    lng.InvokeMember("click");
                }
                PeugeotWB.Visible = true;
                LoadPB.Visible = false;
            }

            //Скрываем футер и кнопки навигации
            HideElementById("tools");
            HideElementById("footer");

        }

        private void MainForm_SizeChanged(object sender, System.EventArgs e)
        {
            ResetProgressBarPosition();
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
                //TODO: Make sure that credentials are correct
                var logPass = Properties.Settings.Default.CredentialsArray[0];
                Properties.Settings.Default.CredentialsArray.RemoveAt(0);
                Properties.Settings.Default.Save();


                var username = PeugeotWB.Document.GetElementById("username");
                var pass = PeugeotWB.Document.GetElementById("password");
                var btn = PeugeotWB.Document.GetElementById("btsubmit");
                if (username != null && pass != null && btn != null)
                {
                    var settings = logPass.Split(';');
                    username.InnerText = settings[0];
                    pass.InnerText = settings[1];
                    btn.InvokeMember("click");
                }
                else
                {
                    return false;
                }
                Properties.Settings.Default.CredentialsArray.Add(logPass);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
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
