using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SEMANA7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int Idseleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> rEliminar;
        IEnumerable<Estudiante> rActualizar;
        public Elemento(int Id, string Nombre, string Usuario, string Contrasena)
        {
            InitializeComponent();
            txtNombre.Text = Nombre;
            txtUsuario.Text = Usuario;
            txtContrasenia.Text = Contrasena;
            Idseleccionado = Id;

        }
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante WHERE Id=?",id);

        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int id,string nombre,string usuario, string contrasena)
        {
            return db.Query<Estudiante>("UPDATE  Estudiante set Nombre=?, Usuario=?, Contrasenia=? WHERE Id=?",nombre,usuario,contrasena, id);

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rActualizar = Update(db, Idseleccionado, txtNombre.Text, txtUsuario.Text, txtContrasenia.Text);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("alerta", ex.Message, "cerrar");
            }
        }

        private void Eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Delete(db, Idseleccionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("alerta", ex.Message, "cerrar");
            }
        }
    }
}