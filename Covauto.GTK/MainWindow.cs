using System;
using System.IO;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using ClosedXML.Excel;

namespace Covauto.GTK
{
    class MainWindow : Window
    {
        [UI] private Button Export = null;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;

            Export.Clicked += OnExportButtonClicked;
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