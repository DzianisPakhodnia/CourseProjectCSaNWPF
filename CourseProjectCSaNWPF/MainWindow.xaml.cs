using System;
using System.Windows;
using System.IO;
using Spire.Xls;
using System.Net.Sockets;

namespace CourseProjectCSaNWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_12(object sender, RoutedEventArgs e)
        {

            string server = "127.0.0.1";
            int port = 13000;

            try
            {
                TcpClient client = new TcpClient(server, port);

                Byte[] dataLogin = System.Text.Encoding.ASCII.GetBytes(textBox1.Text);
                Byte[] dataPassword = System.Text.Encoding.ASCII.GetBytes(textBox2.Text);

                NetworkStream stream = client.GetStream();

                stream.Write(dataLogin, 0, dataLogin.Length);

                stream.Write(dataPassword, 0, dataPassword.Length);


                Console.WriteLine("Sent: {0}", textBox1.Text + ":" + textBox2.Text);

                dataLogin = new Byte[256];
                dataPassword = new Byte[256];

                String responseData = String.Empty;

                Int32 bytes = stream.Read(dataLogin, 0, dataLogin.Length);
                responseData = System.Text.Encoding.ASCII.GetString(dataLogin, 0, bytes);



                Console.WriteLine("Received: {0}", responseData);

                client.Close();



                //string pathExcel = Directory.GetCurrentDirectory() + "\\..\\..\\Resources\\UserDatabase.xlsx";

                //Workbook workbook = new Workbook();
                //workbook.LoadFromFile(pathExcel);
                //Worksheet sheet = workbook.Worksheets[0];

                //int nextRow = sheet.LastRow + 1;

                //sheet.Range[nextRow, 1].Value = textBox1.Text;
                //sheet.Range[nextRow, 2].Value = textBox2.Text;

                //workbook.SaveToFile(pathExcel, ExcelVersion.Version2013);
                //workbook.Dispose();

                //MessageBox.Show("Вы зарегистрировались");




            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException: {0}", ex);
                MessageBox.Show("ArgumentNullException: {0}", ex.Message);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }




            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string server = "127.0.0.1";
            int port = 13000;

            try
            {
                TcpClient client = new TcpClient(server, port);

                // Получаем поток для отправки данных на сервер
                NetworkStream stream = client.GetStream();

                // Кодируем логин и пароль в байты
                byte[] dataLogin = System.Text.Encoding.ASCII.GetBytes(textBox1.Text);
                byte[] dataPassword = System.Text.Encoding.ASCII.GetBytes(textBox2.Text);

                // Отправляем логин на сервер
                stream.Write(dataLogin, 0, dataLogin.Length);

                // Отправляем пароль на сервер
                stream.Write(dataPassword, 0, dataPassword.Length);

                // Выводим информацию об отправленных данных в консоль
                Console.WriteLine("Sent: {0}:{1}", textBox1.Text, textBox2.Text);

                // Создаем буфер для чтения ответа от сервера
                byte[] responseData = new byte[256];

                // Читаем ответ от сервера
                int bytes = stream.Read(responseData, 0, responseData.Length);

                // Преобразуем ответ в строку
                string response = System.Text.Encoding.ASCII.GetString(responseData, 0, bytes);

                // Выводим ответ от сервера в консоль
                Console.WriteLine("Received: {0}", response);

                // Закрываем клиентский сокет
                client.Close();

                // Обработка ответа от сервера или другая логика после получения ответа

                MessageBox.Show("Данные успешно отправлены на сервер");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("ArgumentNullException: {0}", ex);
                MessageBox.Show($"ArgumentNullException: {ex.Message}");
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
                MessageBox.Show($"SocketException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }


    }

}
