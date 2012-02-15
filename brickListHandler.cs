using System;
using System.IO;
using System.Text;
using System.Data;

public class brickList
{
	public static Boolean addBrick(String[] Info)
	{
		if (brickExists(Info[0], true))
			return false;

		BrickMaker.writeBrick(Info);

		return true;
	}

	public static Boolean brickExists(String FileName, Boolean noExt)
	{
		if (noExt)
			return File.Exists(FileName);
		return File.Exists(FileName + ".blb");
	}

	public static Boolean brickExists(String[] Info)
	{
		return File.Exists(Info[0] + ".blb");
	}

	public static String[] getBricks()
	{
		return Directory.GetFiles(Directory.GetCurrentDirectory(), "*.blb");
	}

	public static Boolean removeBrick(String Info)
	{
		if (!brickExists(Info, true) || Info.Substring(Info.IndexOf(".")) != ".blb")
			return false;

		File.Delete(Info);

		return true;
	}
}
