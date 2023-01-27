using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SEMANA7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> Testudiantes;

        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            listar();
        
        }

        public async void listar()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            Testudiantes = new ObservableCollection<Estudiante>(resultado);
            ListadeEstudiantes.ItemsSource = Testudiantes;
        }

        public void Onselection(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var Id = Convert.ToInt32(item);
            var Nombre= obj.Nombre.ToString();
            var Usuario=obj.Usuario.ToString();
            var Contrasena = obj.Contrasenia.ToString();
           Navigation.PushAsync(new Elemento(Id,Nombre,Usuario,Contrasena));


        }
        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

        }

        private void ListadeEstudiantes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var obj = (Estudiante)e.Item;
            var item = obj.Id.ToString();
            var Id = Convert.ToInt32(item);
            var Nombre = obj.Nombre.ToString();
            var Usuario = obj.Usuario.ToString();
            var Contrasena = obj.Contrasenia.ToString();
            Navigation.PushAsync(new Elemento(Id, Nombre, Usuario, Contrasena));
        }
    }
}