using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using ModuleLib;

namespace ModuleB
{
	[Export(typeof(IModule))]
	public class ModuleB : IModule
	{
		public string Name
		{
			get { return "ModuleB"; }
		}

		public void ClickAction()
		{
			MessageBox.Show("Hi from Module B!");
		}
	}
}
