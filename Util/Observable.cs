using System;
namespace Util
{
	public abstract class Observable
	{
		public event EventHandler StateChanged;
		protected void Notify()
		{
			StateChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}