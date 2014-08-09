using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModuleLib;

namespace WixExample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IEnumerable<IModule> _modules;
		private MenuItem _fileMenu;

		[ImportMany(typeof(IModule))]
		public IEnumerable<IModule> Modules
		{
			get { return _modules; }
			set
			{
				_modules = value;
				MenuItems.Clear();
				MenuItems.Add(_fileMenu);
				foreach (var module in value)
				{
					var menuItem = new MenuItem()
					               	{
					               		Header = module.Name,
					               	};
					IModule moduleLocal = module;
					menuItem.Click += (s, e) => moduleLocal.ClickAction();
					MenuItems.Add(menuItem);
				}
			}
		}

		public ObservableCollection<MenuItem> MenuItems { get; private set; }
		public MainWindow()
		{
			_fileMenu = new MenuItem()
			            	{
			            		Name = "File",
			            		Header = "File"
			            	};
			var quitButton = new MenuItem()
			               	{
			               		Name = "Quit",
								Header = "Quit"
			               	};
			quitButton.Click += (s, e) => Close();
			_fileMenu.Items.Add(quitButton);
			MenuItems = new ObservableCollection<MenuItem>()
			            	{
			            		_fileMenu
			            	};
			InitializeComponent();
		}
	}
}
