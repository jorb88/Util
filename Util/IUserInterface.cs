namespace Util
{
	public interface IUserInterface
	{
		void WriteLine(params object[] message);
		void ClearDisplay();
		bool YesNo(string caption, string text);
	}
}
