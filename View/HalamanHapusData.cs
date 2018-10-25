using Kelompok8.Model;
using SQLite;
using System;
using System.IO;

using Xamarin.Forms;

namespace Kelompok8.View
{
    public class HalamanHapusData : ContentPage
    {
        private ListView _listView;
        private Button _hapus;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db4");

        DataMahasiswa dataMahasiswa = new DataMahasiswa();

        public HalamanHapusData()
        {
            this.Title = "Edit Data Mahasiswa";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<DataMahasiswa>().OrderBy(x => x.Nama).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _hapus = new Button();
            _hapus.Text = "Hapus Data";
            _hapus.Clicked += _hapus_Clicked;
            stackLayout.Children.Add(_hapus);

            Content = stackLayout;
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            dataMahasiswa = (DataMahasiswa)e.SelectedItem;
        }

        private async void _hapus_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<DataMahasiswa>().Delete(x => x.Id == dataMahasiswa.Id);

            await DisplayAlert(null, "Data " + dataMahasiswa.Nama + " Berhasil Dihapus", "Ok");
            await Navigation.PopAsync();
            db.Delete(dataMahasiswa);
        }
    }
}