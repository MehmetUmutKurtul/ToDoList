using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;


namespace TODO.ContentPages
{
    /// <summary>
    /// Interaction logic for ContentPage1.xaml
    /// </summary>
    public class Login {
        public int LoginId { get; set; }

        
        public string Name { get; set; }
		
     
        public string Passwrd { get; set; }
    }
    
    public partial class ContentPage1 : Page
    {
         public static int tutan;
       public ContentPage1()
        {
            
            HttpClient Http=new HttpClient();
            InitializeComponent();
        }
        
        private  async void OnClick(object sender, RoutedEventArgs e) //login sayfası
        {
             var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:5001");
           
            var response= await httpClient.GetFromJsonAsync<Login[]>("api/logins");
            
            for(int i=0;i<response.Count();i++){
            if(txt_login.Text==response[i].Name.ToString()&&txt_psswrd.Text==response[i].Passwrd.ToString()){
              tutan =response[i].LoginId;
              
                
              frmMain.Source = new Uri("/ContentPages/" + ((Button)sender).CommandParameter.ToString(), UriKind.Relative);
              this.txt_login.Visibility = Visibility.Hidden;
              this.txt_psswrd.Visibility = Visibility.Hidden;
              this.btn1.Visibility = Visibility.Hidden; //sayfa üzerine bastıgım için görünürlülüklerini hidden yaptım
              this.txt1.Visibility = Visibility.Hidden;
              this.txt2.Visibility = Visibility.Hidden;
              }
              
            }
            

              
            
                
        }
            

        
    }
}