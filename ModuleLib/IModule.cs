using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleLib
{
	public interface IModule
	{
		string Name { get; }

		void ClickAction();
	}
}
