using System;
namespace Util
{
	public abstract class Publisher
	{
		public event EventHandler StateChanged;
		protected void Notify()
		{
			StateChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}