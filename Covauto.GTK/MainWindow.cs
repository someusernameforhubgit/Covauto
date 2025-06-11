using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Rit;
using System.IO;
using System.Threading.Tasks;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using ClosedXML.Excel;

namespace Covauto.GTK
{
    class MainWindow : Window
    {
        [UI] private Button Export = null;

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

            Export.Clicked += OnExportButtonClicked;
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
            while (true)
            {
                try
                {
                    await client.GetAsync("https://localhost:7221/");
                    break;
                }
                catch (Exception)
                {
                    await Task.Delay(1000);
                }
            }
            
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

        private void OnExportButtonClicked(object sender, EventArgs e)
        {
            try
            {
                using (var fileDialog = new FileChooserDialog("Save Excel File",
                    this,
                    FileChooserAction.Save,
                    "Cancel", ResponseType.Cancel,
                    "Save", ResponseType.Accept))
                {
                    string currentDateTime = DateTime.Now.ToString("dd-MM-yyyy_HH.mm.ss");
                    fileDialog.CurrentName = $"Covauto {currentDateTime}.xlsx";
                    
                    var filter = new FileFilter();
                    filter.Name = "Excel files";
                    filter.AddPattern("*.xlsx");
                    fileDialog.AddFilter(filter);
                    
                    if (fileDialog.Run() == (int)ResponseType.Accept)
                    {
                        string filePath = fileDialog.Filename;
                        CreateExcelFile(filePath);
                        
                        using (var successDialog = new MessageDialog(this,
                            DialogFlags.Modal,
                            MessageType.Info,
                            ButtonsType.Ok,
                            $"Excel file successfully created at:\n{filePath}"))
                        {
                            successDialog.Title = "Export Successful";
                            successDialog.Run();
                            successDialog.Destroy();
                        }
                    }
                    
                    fileDialog.Destroy();
                }
            }
            catch (Exception ex)
            {
                using (var errorDialog = new MessageDialog(this,
                    DialogFlags.Modal,
                    MessageType.Error,
                    ButtonsType.Ok,
                    $"Error creating Excel file:\n{ex.Message}"))
                {
                    errorDialog.Title = "Export Error";
                    errorDialog.Run();
                    errorDialog.Destroy();
                }
            }
        }
        
        private void CreateExcelFile(string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Data");
                
                // Hier moet data van de tabel
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Gebruiker";
                worksheet.Cell(1, 3).Value = "Kilometers";
                worksheet.Cell(1, 4).Value = "Auto";
                worksheet.Cell(1, 5).Value = "Begin Tijd";
                worksheet.Cell(1, 6).Value = "Eind Tijd";
                
                // Styling
                var headerRange = worksheet.Range(1, 1, 1, 6);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                worksheet.Columns().Width = 18;
                worksheet.Columns().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                
                workbook.SaveAs(filePath);
            }
        }
    }
}