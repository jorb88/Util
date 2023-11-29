namespace Util
{
	public interface IThreadable
	{
		int Maximum { get; }
		int Completed { get; }
		string Message { get; }
	}

	public static class ThreadManager
	{
		public static bool AbortAllThreads = false;
	}
}
