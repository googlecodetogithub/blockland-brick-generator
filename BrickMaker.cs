using System;
using System.IO;
using Ionic.Zip;

public class BrickMaker
{
	public const Double Version = 2.8; //Program Version

	public static String[] getBrickInfo(UInt32 Width, UInt32 Length, UInt32 Height) //Get info on the brick.
	{
		// ------------------------------------------------ \\
		// --- This is the UPDATED brickInfo Algorithm! --- \\
		// ------------------------------------------------ \\

		//Check if any of the arguments are 0, which is invalid.
		if (Length == 0)
			throw new System.ArgumentException("Parameter must be > 0", "Length");
		else if (Width == 0)
			throw new System.ArgumentException("Parameter must be > 0", "Width");
		else if (Height == 0)
			throw new System.ArgumentException("Parameter must be > 0", "Height");
		else if (Length < Width)
			throw new System.ArgumentException("Length was less than width!", "Length");

		String UiName, FileName, Category, subCategory; //Create info strings

		String[] Info = new String[7]; //Create info array

		FileName = "something has gone horribly wrong"; //If you see that, add it to the bug list

		// ----------------------------------------- \\
		// --- Info Generator Decision Tree v2.0 --- \\
		// ----------------------------------------- \\

		if (Height / 3f == Length && Length == Width && Height >= 12) //It's a Cube!
		{
			Category = "Baseplates"; //Cubes are in the baseplates category, kind of ironic.
			subCategory = "Cube"; //It's a Cube! Wait, I already said that...
			UiName = Width + "x Cube"; //Since all dimensions, you dont need to display all 3.
			FileName = Width + "x" + Length + "x" + Height; //Regular file name
		}
		else if (Width > 15 && Length > 15 && Height == 1) //Check if it's a Baseplate.
		{
			Category = "Baseplates"; //It goes in the baseplates section. (Obviously)
			subCategory = "Plain"; //It goes in "Plain".
			UiName = Width + "x" + Length + " Base"; //Base in the name, no "f" extension.
			FileName = Width + "x" + Length + "x" + Height; //Regular file name
		}
		else if (Height != 1) //Check if the brick is not a plate
		{
			Category = "Bricks"; //Set the category to bricks (Because it's not anything else!)

			if (Height == 3) //1x height doesnt need the 1x height prefix.
			{
				FileName = Width + "x" + Length; //Set the filename and subcategory.
				subCategory = Width + "x";
				UiName = subCategory + Length; //Uiname is Width x Length in this case.
			}
			else if (Height / 3 != Height / 3f) //Check if it's not divisible by 3. (In other words, is it a "halfbrick.")
			{
				if (Height < 3) //Check if the height is below 1 stud
					subCategory = Height + "/3x Height";
				else
					subCategory = Math.Floor(Height / 3f) + " & " + (Height - (Math.Floor(Height / 3f) * 3)) + "/3x Height"; //Splits the height into a full number and a fraction out of 3.
				UiName = Width + "x" + Length; //Standard UI Name
				FileName = Width + "x" + Length + "x" + Height;
			}
			else //The brick is a even-studded height.
			{
				subCategory = Height / 3 + "x Height"; //Make sure they know its a even height
				UiName = Width + "x" + Length + "x" + Height / 3; //Set the UiName the same way
				FileName = Width + "x" + Length + "x" + Height;
			}
		}
		else //The brick is a plate
		{
			UiName = Width + "x" + Length + "f"; //Set the ui name to "flat"
			FileName = UiName; // Since its a plate, instead of a height it just displays "f."
			Category = "Plates";
			subCategory = Width + "x";
		}
		// ---------------------------------------- \\
		// End of Info Generator Decision Tree v2.0 \\
		// ---------------------------------------- \\

		//Put the information of the brick into a array,
		Info[0] = FileName;
		Info[1] = UiName;
		Info[2] = Category;
		Info[3] = subCategory;
		Info[4] = Width.ToString();
		Info[5] = Length.ToString();
		Info[6] = Height.ToString();

		return Info; //Return the array.
	}

	public static Boolean writeBrick(String[] Info) //Function to write brick files
	{
		//Throw an error if any of the info parts are blank.
		for (UInt32 i = 0; i < 7; i++)
			if (Info[i] == "")
				throw new System.ArgumentException("Array item #" + (i + 1) + " was null.", "Info");

		//Create the brick file
		var brickFile = File.Create(Info[0] + ".blb");
		var brickWriter = new StreamWriter(brickFile); //Create a file writer for the brick file.

		//Write the BLB code
		brickWriter.WriteLine(Info[4] + " " + Info[5] + " " + Info[6]);
		brickWriter.Write("BRICK");

		//Get rid of the file and filewriter.
		brickWriter.Close();
		brickWriter.Dispose();

		return true; //return.
	}

	public static Boolean createCSFile(String[] Info) //Create the server.cs file for the info givin.
	{
		//Throw an error if any of the info parts are blank.
		for (UInt32 i = 0; i < 7; i++)
		{
			if (Info[i] == "")
				throw new System.ArgumentException("The " + (i + 1) + "th info array was null.", "Info");
		}

		//Create the filewriter to add to the existing (or create) server.cs file.
		StreamWriter csWriter = File.AppendText("server.cs");

		//Create the lines to write
		String[] Lines = new String[7];

		//Write the code from the info array to the line array
		Lines[0] = "datablock fxDTSBrickData(brick" + Info[4] + "x" + Info[5] + "x" + Info[6] + "Data)";
		Lines[1] = "{";
		Lines[2] = "	brickFile = \"./" + Info[0] + ".blb\";";
		Lines[3] = "	category = \"" + Info[2] + "\";";
		Lines[4] = "	subCategory = \"" + Info[3] + "\";";
		Lines[5] = "	uiName = \"" + Info[1] + "\";";
		Lines[6] = "};";

		for (UInt32 i = 0; i < 7; i++)
			csWriter.WriteLine(Lines[i]);

		//Get rid of the filewriter.
		csWriter.Close();
		csWriter.Dispose();

		return true; //return.
	}

	public static Boolean createDescription(String Title, String Author, String[] Description) //Create a Description text file
	{
		//Create the file and file writers.
		var desFile = File.Create("description.txt");
		var desWriter = new StreamWriter(desFile);

		//Write the title, author, and description
		desWriter.WriteLine("Title: " + Title);
		desWriter.WriteLine("Author: " + Author);

		for (Int32 a = 0; a < Description.Length; a++)
			desWriter.WriteLine(Description[a]);

		//Let em' know I helped make this puppy.
		desWriter.WriteLine("Created with Ipquarx's Brick Creator v" + Version);

		//Finish up and return
		desWriter.Close();
		desWriter.Dispose();
		return true;
	}

	public static Boolean zipFile(String[] Paths, String Name) //Zip the files listed in a path array.
	{
		//Create the zip file,
		ZipFile AddonZipper = new ZipFile();

		//Zip every single file in the path array,
		for (Int32 a = 0; a < Paths.Length; a++)
			AddonZipper.AddFile(Paths[a]);

		//Save the zip file,
		AddonZipper.Save("Brick_" + Name + ".zip");

		return true; //return.
	}
}
