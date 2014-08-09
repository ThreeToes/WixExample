using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using ModuleLib;

namespace ModuleA
{
	[Export(typeof(IModule))]
	public class ModuleA : IModule
	{
		public string Name
		{
			get { return "ModuleA"; }
		}

		public void ClickAction()
		{
			MessageBox.Show("Hi from Module A!");
		}
	}
}
