using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;

namespace WixExample
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private AggregateCatalog _catalog;
		private CompositionContainer _container;

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			_catalog = new AggregateCatalog();
			var extensionDir = Path.Combine(Environment.CurrentDirectory, "Extensions");
			if (Directory.Exists(extensionDir))
			{
				foreach (var asmFile in Directory.EnumerateFiles(extensionDir).Where(x => x.EndsWith(".dll")))
				{
					_catalog.Catalogs.Add(new AssemblyCatalog(asmFile));
				}
			}
			_container = new CompositionContainer(_catalog);
			var mainWindow = new MainWindow();
			_container.ComposeParts(mainWindow);
			mainWindow.Show();
		}
	}
}
