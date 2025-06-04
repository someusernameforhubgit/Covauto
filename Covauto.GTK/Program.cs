namespace CovAuto.GTK;

class Program
{
    static void Main(string[] args)
    {
        var application = Gtk.Application.New("org.gir.core", Gio.ApplicationFlags.FlagsNone);
        application.OnActivate += (sender, args) =>
        {
            var window = Gtk.ApplicationWindow.New((Gtk.Application) sender);
            window.Title = "Gtk4 Window";
            window.SetDefaultSize(300, 300);
            window.Show();
        };
        application.RunWithSynchronizationContext(null);
    }
}