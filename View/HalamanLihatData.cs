﻿using Kelompok8.Model;
using SQLite;
using System.Collections;
using System.IO;

using Xamarin.Forms;

namespace Kelompok8.View
{
    public class HalamanLihatData : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db4");

        public HalamanLihatData()
        {
            this.Title = "Data Mahasiswa";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<DataMahasiswa>().OrderBy(x => x.Nama).ToArray();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}
