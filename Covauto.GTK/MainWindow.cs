using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Rit;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace Covauto.GTK
{
    class MainWindow : Window
    {
        private static HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        private static readonly HttpClient client = new HttpClient(handler);
        private TreeView treeView;
        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            
            treeView = builder.GetObject("Treeview") as TreeView;
            
            var treeStore = new TreeStore(
                typeof(int),
                typeof(string),
                typeof(string),
                typeof(int),
                typeof(string),
                typeof(string)
            );
            treeView.Model = treeStore;
            
            PrepareTreeView();
            
            Shown += ShownHandler;
            DeleteEvent += Window_DeleteEvent;
        }
        
        private void PrepareTreeView()
        {
            var idCell = new CellRendererText();
            var idColumn = new TreeViewColumn("ID", idCell, "text", 0);
            treeView.AppendColumn(idColumn);
            
            var gebruikerCell = new CellRendererText();
            var gebruikerColumn = new TreeViewColumn("Gebruiker", gebruikerCell, "text", 1);
            treeView.AppendColumn(gebruikerColumn);
            
            var autoCell = new CellRendererText();
            var autoColumn = new TreeViewColumn("Auto", autoCell, "text", 2);
            treeView.AppendColumn(autoColumn);
            
            var kmCell = new CellRendererText();
            var kmColumn = new TreeViewColumn("Kilometers", kmCell, "text", 3);
            treeView.AppendColumn(kmColumn);
            
            var beginCell = new CellRendererText();
            var beginColumn = new TreeViewColumn("Begin", beginCell, "text", 4);
            treeView.AppendColumn(beginColumn);
            
            var endCell = new CellRendererText();
            var endColumn = new TreeViewColumn("End", endCell, "text", 5);
            treeView.AppendColumn(endColumn);
            
            foreach (TreeViewColumn col in treeView.Columns)
            {
                col.Resizable = true;
            }
        }
        
        private async void ShownHandler(object sender, EventArgs e)
        {
            var response = await client.GetFromJsonAsync<List<RitListItem>>("https://localhost:7221/api/Rit");
            var treeStore = treeView.Model as TreeStore;
            
            var autoResponse = await client.GetFromJsonAsync<List<AutoListItem>>("https://localhost:7221/api/Auto");
            var autos = autoResponse.ToDictionary(auto => auto.ID, auto => auto);
            
            foreach (var partialRit in response)
            {
                var rit = await client.GetFromJsonAsync<RitItem>("https://localhost:7221/api/Rit/" + partialRit.ID);
                treeStore.AppendValues(
                    rit.ID,
                    rit.Gebruiker.Voornaam + " " + rit.Gebruiker.Achternaam,
                    autos[rit.AutoId].Merk + " " + autos[rit.AutoId].Model,
                    rit.Kilometers,
                    rit.Begin.ToString("yyyy-MM-dd  HH:mm:ss"),
                    rit.End.ToString("yyyy-MM-dd  HH:mm:ss")
                );
            }
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}
