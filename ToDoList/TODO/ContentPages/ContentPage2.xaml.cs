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
    /// Interaction logic for ContentPage2.xaml
    /// </summary>
     public class ToDo {
        public int ToDoId { get; set; }
        public string Date { get; set; }
        public string Desc { get; set; }
        public int IsComplete { get; set; }
        public int LoginId { get; set; }
    }
    public partial class ContentPage2 : Page
    {
        List<CheckBox> chcList=new List<CheckBox>();
        List<Label> lblList=new List<Label>();
       public ContentPage2()
        {
            HttpClient Http=new HttpClient();
            InitializeComponent();
        }
         public async void GetDataAll(object sender,EventArgs e){ //Giriş yapanın Id sine göre todoları getirdim
         
         var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:5001");
           Label[] labels = new Label[100];         //checkbox ve labelı stringte tutup i ninci degeri cagırdık.
           CheckBox[] checkBoxes = new CheckBox[100];
           
           try
             {
              ToDo[] response= await httpClient.GetFromJsonAsync<ToDo[]>("api/todos"); 
             for(int i=0;i<response.Count();i++){ //tablodaki tüm indexleri label ve checkbox olarak bastık.
             if(ContentPage1.tutan==response[i].LoginId){ // Loginle gelen ID deki todoları getirdik.
            CheckBox chBox=new CheckBox();
            chBox.IsChecked=false;
            chBox.Checked+=new RoutedEventHandler(checkedevent);
            Label lbl=new Label();
            
            lbl.Content=AddTodo.Text.ToString();
            
            lbl.Content =response[i].Desc.ToString();
            lbl.Content+=" ("+response[i].Date.ToString()+")";
            chcList.Add(checkBoxes[i]);
            lblList.Add(labels[i]);
            lbl.Margin=new Thickness(20,-20,0,0);
            Checksp.Children.Add(chBox);
            Checksp.Children.Add(lbl);
            }
            }
              }
              catch (HttpRequestException) //içerik olmadıgında hata
              {
               lmsg.Content="An error occurred." ;
              }
              
         }
        public async void AddClick(object sender, RoutedEventArgs e) //Her add de yeni bir checkbox ve label olusturduk.Yeni Todo yazmak  için    
        {
            Label[] labels = new Label[100];         //checkbox ve labelı stringte tutup i ninci degeri cagırdık.
           CheckBox[] checkBoxes = new CheckBox[100];
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:5001");
            var newData = new ToDo{ Date = DateTime.Now.ToString("dd/MM/yyyy"), Desc = AddTodo.Text.ToString(), IsComplete = 0,LoginId=ContentPage1.tutan};
           
             try
             {
             var response = await httpClient.PostAsJsonAsync("api/todos/addrec", newData);
              
              response.EnsureSuccessStatusCode();
     
            
            CheckBox chBox=new CheckBox();
            chBox.IsChecked=false;
            chBox.Checked+=new RoutedEventHandler(checkedevent);
            
            Label lbl=new Label();
            lbl.Content=AddTodo.Text.ToString();
            chcList.Add(chBox);
            lblList.Add(lbl);
            lbl.Margin=new Thickness(20,-20,0,0);
            Checksp.Children.Add(chBox);
            Checksp.Children.Add(lbl);
             
               
             
             }
             catch (HttpRequestException) // Başarısız içerik olmadıgında hata
              {
               lmsg.Content="İçerik yok." ;
              }
              
        }
        
        public void checkedevent(object sender, RoutedEventArgs e)
        {         
        }
        
    }
}
