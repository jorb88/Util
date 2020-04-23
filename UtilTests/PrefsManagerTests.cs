using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace UtilTests
{
	[TestClass]
	public class PrefsManagerTests
	{
		private string defaultFilename = "Preferences.ser";
		private string defaultFolder;
		private string defaultFullPath;

		[TestInitialize]
		public void InitDefaultFolder()
		{
			PrefsManager<MockPrefs> serializer = new PrefsManager<MockPrefs>();
			defaultFolder = serializer.DefaultPrefsFolder;
			defaultFullPath = defaultFolder + "\\" + defaultFilename;
			if (File.Exists(defaultFullPath)) File.Delete(defaultFullPath);
		}
		[TestMethod]
		public void CreationTestUsingDefaultFilename()
		{
			PrefsManager<MockPrefs> serializer = new PrefsManager<MockPrefs>();
			Assert.AreEqual(defaultFullPath, serializer.FilePath);
		}
		[TestMethod]
		public void CreationTestUsingSpecifiedFilenameOnly()
		{
			PrefsManager<MockPrefs> serializer = new PrefsManager<MockPrefs>("Junk.ser");
			string path = defaultFolder + "\\Junk.ser";
			Assert.AreEqual(path, serializer.FilePath);
		}
		[TestMethod]
		public void CreationTestUsingSpecifiedFullPath()
		{
			PrefsManager<MockPrefs> serializer = new PrefsManager<MockPrefs>(Environment.CurrentDirectory + "\\Junk.ser");
			string expectedPath = Environment.CurrentDirectory + "\\Junk.ser";
			Assert.AreEqual(expectedPath, serializer.FilePath);
		}
		[TestMethod]
		public void NoPrefsFileNewDataCreated()
		{
			PrefsManager<MockPrefs> serializer = new PrefsManager<MockPrefs>();
			Assert.IsFalse(serializer.LoadedFromFile);
			MockPrefs prefs = serializer.Data;
			Assert.AreEqual(prefs.TestString, "Mock test string");
			Assert.AreEqual(prefs.TestInt, 0);
			Assert.AreEqual(prefs.TestDateTime, new DateTime(0));
			Assert.IsFalse(File.Exists(defaultFullPath));
		}
		[TestMethod]
		public void PrefsFileCreationTest()
		{
			PrefsManager<MockPrefs> serializer = new PrefsManager<MockPrefs>();
			serializer.Save();
			Assert.IsTrue(File.Exists(defaultFullPath));
			if (File.Exists(defaultFullPath)) File.Delete(defaultFullPath);
		}
		[TestMethod]
		public void SaveChangedDataTest()
		{
			PrefsManager<MockPrefs> serializer = new PrefsManager<MockPrefs>();
			MockPrefs prefs = serializer.Data;
			prefs.TestString = "New test string";
			prefs.TestInt = int.MaxValue;
			DateTime now = DateTime.Now;
			prefs.TestDateTime = now;
			serializer.Save();
			Assert.AreEqual(prefs.TestString, "New test string");
			Assert.AreEqual(prefs.TestInt, int.MaxValue);
			Assert.AreEqual(prefs.TestDateTime, now);
			if (File.Exists(defaultFullPath)) File.Delete(defaultFullPath);
		}
	}
}
