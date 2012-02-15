using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace BrickCreator
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new brickCreatorForm());
		}
	}

	//To prevent visual studio from thinking this is a form file.
	[System.ComponentModel.DesignerCategory("")]
	public partial class brickCreatorForm : Form
	{
		public brickCreatorForm()
		{
			InitializeComponent();
		}

		//Go ahead, remove this variable, I dare you.
		//Go ahead and watch as this program eats itself up
		//and windows screams in horror as stack overflows
		//and infiniteloops occur.
		private Boolean isUpdating = false;
		private Boolean isMakingBrick = false;

		private Boolean hasSaved = true;
		private Int32 Index;

		private void brickCreatorForm_Load(object sender, System.EventArgs e)
		{
			isUpdating = true;
			nameBox.Text = Properties.Settings.Default.Name;
			isUpdating = false;

			updateBrickList();
			if (brickListBox.Items.Count == 0)
				addTempBrick();
			else
				brickListBox.SelectedIndex = 0;

			doEnables(1);
		}

		private void removeToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			if (brickListBox.SelectedIndex > -1 && hasSaved)
			{
				if (!brickListBox.SelectedItem.ToString().EndsWith("*"))
					brickList.removeBrick(brickListBox.SelectedItem.ToString());
				updateBrickList();
			}
		}

		private void brickListBox_mouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!hasSaved)
				return;

			//Make sure that right click selects items
			brickListBox.SelectedIndex = brickListBox.IndexFromPoint(e.X, e.Y);
		}

		private void widthCounter_valueChanged(object sender, System.EventArgs e)
		{
			if (!isUpdating)
			{
				lengthCounter.Minimum = widthCounter.Value;
				updateCurrentItem(widthCounter.Value, lengthCounter.Value, heightCounter.Value);
			}
			doEnables(1);
		}

		private void nameBox_textChanged(object sender, EventArgs e)
		{
			if (!isUpdating)
			{
				Properties.Settings.Default.Name = nameBox.Text;
				Properties.Settings.Default.Save();
			}
		}

		private void lengthCounter_valueChanged(object sender, System.EventArgs e)
		{
			if (!isUpdating)
				updateCurrentItem(widthCounter.Value, lengthCounter.Value, heightCounter.Value);
			doEnables(1);
		}

		private void heightCounter_valueChanged(object sender, System.EventArgs e)
		{
			if (!isUpdating)
				updateCurrentItem(widthCounter.Value, lengthCounter.Value, heightCounter.Value);
			doEnables(1);
		}

		private void brickListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (isUpdating)
				return;

			//Stop the user from selecting another brick before the current one is saved.
			//This may be removed in a newer version, but for now i'm leaving it in.
			if (!hasSaved && brickListBox.SelectedIndex != Index || isMakingBrick)
			{
				isUpdating = true;
				brickListBox.SelectedIndex = Index;
				isUpdating = false;
				return;
			}
			else
				saveBrickButton.Enabled = false;

			isUpdating = true;
			Index = brickListBox.SelectedIndex;

			//If there is no selected brick, reset all the controls
			//so that no more editing can be done unless a brick is selected.
			if (brickListBox.SelectedIndex >= 0)
			{
				lengthCounter.Minimum = 1;

				// I somehow managed to figure out how to get the exact dimensions of a brick made by my decision engine
				// by only knowing it's filename.

				// This is that code, and i'm using it because since custom filenames are NOT an option,
				// This is the only surefire way of getting the exact dimensions correct without opening
				// the actual file, which takes up valuable CPU and execution time.

				// Only works if the user hasnt screwed with the file.

				//Make a seperator that splits it at "x"
				String[] Seperator = new String[1];
				Seperator[0] = "x";
				Boolean docontinue = false;

				String FileName = brickListBox.SelectedItem.ToString();

				if (FileName.Contains("*"))
					FileName = FileName.Replace("*", "");

				//Split the filename through all x's
				String[] Filen = brickListBox.SelectedItem.ToString().Split(Seperator, StringSplitOptions.RemoveEmptyEntries);

				UInt32 Width = 0;

				if (FileName.Contains(" "))
				{
					doInvalid();
					isUpdating = false;
					return;
				}

				Width = UInt32.Parse(Filen[0]);

				UInt32 Length = 0, Height = 0;
				Boolean valid = false;

				try
				{
					//If there are 2 elements, then its either a flat or a 1x height.
					if (Filen.Length == 2 && !docontinue)
					{
						if (Filen[1].Contains("f")) //If the brick is a flat
						{
							//Get the height
							if (Filen[1].Contains(".blb")) //If it has the extension, we need to adjust a bit
								Length = UInt32.Parse(Filen[1].Substring(0, Filen[1].Length - 5));
							else
								Length = UInt32.Parse(Filen[1].Substring(0, Filen[1].Length - 2));

							//Since it's flat, the height is always one.
							Height = 1;
						}
						else //The brick is not a flat, so it's a 1x height.
						{
							if (Filen[1].Contains(".blb")) //Again, adjusting for the extension
								Length = UInt32.Parse(Filen[1].Substring(0, Filen[1].Length - 4));
							else
								Length = UInt32.Parse(Filen[1].Substring(0, Filen[1].Length - 1));

							//Since it's a 1x height, the height is always 3.
							Height = 3;
						}
						valid = true;
					}
					else if (Filen.Length == 3 && !docontinue) //It's not a flat or 1x height
					{
						//Length is the first element
						Length = UInt32.Parse(Filen[1]);

						if (Filen[2].Contains(".blb")) //Extensions, gotta hate 'em. (/sarcasm)
							Height = UInt32.Parse(Filen[2].Substring(0, Filen[2].Length - 4));
						else
							Height = UInt32.Parse(Filen[2].Substring(0, Filen[2].Length - 1));
						valid = true;
					}
				}
				catch (Exception)
				{
					doInvalid();
					isUpdating = false;
					return;
				}

				//Since the decision tree doesnt check for any of these, We have to check after.
				if ((Width == 0 || Length == 0 || Height == 0 || Length < Width || !valid) && !docontinue) //OHNOES FAILURE IMMINENT!
				{
					doInvalid();
					isUpdating = false;
					return;
				}

				//Success! Slap the info into the boxes.
				if (valid)
				{
					label1.ResetText();

					widthCounter.Enabled = true;
					lengthCounter.Enabled = true;
					heightCounter.Enabled = true;

					widthCounter.Value = Width;
					lengthCounter.Value = Length;
					heightCounter.Value = Height;

					isUpdating = false;
					//disableInfoBoxes = false;

					lengthCounter.Minimum = Width;

					String[] Info = BrickMaker.getBrickInfo(Width, Length, Height);

					categoryBox.Text = Info[2];
					subCatBox.Text = Info[3];
					UiBox.Text = Info[1];

					isUpdating = false;
				}
			}
			else
			{
				isUpdating = false;
				doEnables(1);
			}
		}

		private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//You can't delete a file that doesnt exist, so cancel the event if that's the case.
			if (brickListBox.SelectedIndex < 0 || brickListBox.SelectedItem.ToString().EndsWith("*"))
				e.Cancel = true;
		}

		private void titleBox_keyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//Prevent invalid input from going in the box.
			if (e.KeyCode == System.Windows.Forms.Keys.OemQuotes || e.KeyValue == 189 || e.KeyCode == System.Windows.Forms.Keys.Space)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void newBrickButton_Click(object sender, System.EventArgs e)
		{
			addTempBrick();
		}

		private void saveBrickButton_Click(object sender, System.EventArgs e)
		{
			saveCurrentBrick();
		}

		private void tabs_tabChanged(object sender, System.EventArgs e)
		{
			doEnables(1);
		}

		private void packBrickButton_Click(object sender, System.EventArgs e)
		{
			doPackageBricks();
		}

		private void saveCurrentBrick()
		{
			if (!brickListBox.SelectedItem.ToString().Contains("*"))
				return;

			isUpdating = true;

			UInt32 Width = UInt32.Parse(widthCounter.Value.ToString());
			UInt32 Length = UInt32.Parse(lengthCounter.Value.ToString());
			UInt32 Height = UInt32.Parse(heightCounter.Value.ToString());

			String[] Info = BrickMaker.getBrickInfo(Width, Length, Height);

			if (Info.Length != 7)
				throw new Exception("getBrickInfo did not return a 7 length array!");

			BrickMaker.writeBrick(Info);

			updateBrickList();

			hasSaved = true;

			isUpdating = false;
			isMakingBrick = false;

			brickListBox.SelectedIndex = -1;
			doEnables(1);
		}

		private void addTempBrick()
		{
			isUpdating = true;
			isMakingBrick = true;

			Int32 C = brickListBox.Items.Count;
			Index = C;
			brickListBox.Items.Add("1x1*");
			brickListBox.SelectedIndex = C;

			widthCounter.Value = 1;

			lengthCounter.Minimum = 1;
			lengthCounter.Value = 1;
			heightCounter.Value = 3;

			updateCurrentItem(1, 1, 3);

			isUpdating = false;

			doEnables(1);
		}

		private void doPackageBricks()
		{
			//Unlike torque, which is my main programming language,
			//arrays actually exist. Which means that I can't just
			//do whatever I want with arrays, they have to be a set
			//length, and it's length can't change.

			//That makes this code twice as long as it would be in the torque language.

			//Getting the list of files to create .cs's for (While avoiding broken files)
			Int32 FileCount = 0, currFile = 0;
			Boolean[] addFile = new Boolean[brickListBox.Items.Count];

			for (Int32 a = 0; a < brickListBox.Items.Count; a++)
			{
				brickListBox.SelectedIndex = a;
				if (label1.Text != "")
				{
					addFile[a] = false;
					continue;
				}
				addFile[a] = true;
				FileCount++;
			}

			String[] makeCSList = new String[FileCount];

			UInt32[] Width = new UInt32[FileCount];
			UInt32[] Length = new UInt32[FileCount];
			UInt32[] Height = new UInt32[FileCount];

			for (Int32 a = 0; a < addFile.Length; a++)
			{
				if (addFile[a])
				{
					brickListBox.SelectedIndex = a;
					makeCSList[currFile] = brickListBox.Items[a].ToString();
					Width[currFile] = UInt32.Parse(widthCounter.Value.ToString());
					Length[currFile] = UInt32.Parse(lengthCounter.Value.ToString());
					Height[currFile] = UInt32.Parse(heightCounter.Value.ToString());
				}
				currFile++;
			}

			brickListBox.SelectedIndex = -1;

			//Now that we have the finished list of files to create CS's for,
			//we can go ahead and do that.

			StreamWriter csWriter = File.AppendText("server.cs");

			//Let em know not to upload this.
			csWriter.WriteLine("//Created with Ipquarx's Brick Creator v2.8");
			csWriter.WriteLine("//For personal use ONLY. Not for uploading.");

			csWriter.Close();
			csWriter.Dispose();

			for (Int32 a = 0; a < makeCSList.Length; a++)
			{
				String[] Info = BrickMaker.getBrickInfo(Width[a], Length[a], Height[a]);
				BrickMaker.createCSFile(Info);
			}

			//Now that the cs is made, make the description
			//along with another secret file... (Hint: it keeps noobs from being nooby)
			BrickMaker.createDescription(titleBox.Text, nameBox.Text, descriptionBox.Lines);

			StreamWriter denoobWriter = File.AppendText("noUpload.txt");
			denoobWriter.WriteLine("If you see this file, and it has been uploaded to RTB, the blockland forums, or any public add-on downloading website,");
			denoobWriter.WriteLine("Please flag it for deletion.");
			denoobWriter.WriteLine("This was created with Ipquarx's Brick Creator v2.8, and is for person use only.");
			denoobWriter.WriteLine("And I, the creator of this program,");
			denoobWriter.WriteLine("phrohibit the public uploading of any file(s) created with this program,");
			denoobWriter.WriteLine("without my explicit permission.");

			denoobWriter.Close();
			denoobWriter.Dispose();

			String[] ZipList = new String[FileCount + 3];
			ZipList[FileCount] = "server.cs";
			ZipList[FileCount + 1] = "description.txt";
			ZipList[FileCount + 2] = "noUpload.txt";

			for (Int32 a = 0; a < FileCount; a++)
				ZipList[a] = makeCSList[a];

			BrickMaker.zipFile(ZipList, titleBox.Text);

			//Delete the files that are now in the zipped package.
			try
			{
				File.Delete("server.cs");
				File.Delete("description.txt");
				File.Delete("noUpload.txt");

				String[] BLBs = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.blb");

				FileInfo BLB;
				for (Int32 a = 0; a < BLBs.Length; a++)
				{
					BLB = new FileInfo(BLBs[a]);
					File.Delete(BLB.Name);
				}
			}
			catch (Exception)
			{
				//Do nothing.

				//If we want the file gone and it never existed,
				//That's just fine!
			}

			updateBrickList();
		}

		public void updateCurrentItem(UInt32 Width, UInt32 Length, UInt32 Height)
		{
			if (Width <= 0 || Length <= 0 || Height <= 0) //No arguments below one,
				return; //We don't want errors now do we!

			hasSaved = false;
			saveBrickButton.Enabled = true;
			newBrickButton.Enabled = false;
			packBrickButton.Enabled = false;

			//Get the brick's info
			String[] Info = BrickMaker.getBrickInfo(Width, Length, Height);

			if (!brickListBox.SelectedItem.ToString().EndsWith("*")) //If it was saved earlier,
				File.Delete(brickListBox.SelectedItem.ToString()); //Then delete the old file (It's nesscescary for preventing screw-ups)

			//Update the name and add a star to show it hasn't been saved yet.
			brickListBox.Items[brickListBox.SelectedIndex] = Info[0] + "*";

			categoryBox.Text = Info[2];
			subCatBox.Text = Info[3];
			UiBox.Text = Info[1];
		}

		//Overloads to avoid extra conversion crap
		public void updateCurrentItem(Int32 Width, Int32 Length, Int32 Height)
		{
			if (Width <= 0 || Length <= 0 || Height <= 0) //No arguments below one,
				return; //We don't want errors now do we!

			hasSaved = false;
			saveBrickButton.Enabled = true;
			newBrickButton.Enabled = false;
			packBrickButton.Enabled = false;

			UInt32 UWidth = UInt32.Parse(Width.ToString());
			UInt32 ULength = UInt32.Parse(Length.ToString());
			UInt32 UHeight = UInt32.Parse(Height.ToString());

			//Get the brick's info
			String[] Info = BrickMaker.getBrickInfo(UWidth, ULength, UHeight);

			if (!brickListBox.SelectedItem.ToString().EndsWith("*")) //If it was saved earlier,
				File.Delete(brickListBox.SelectedItem.ToString()); //Then delete the old file (It's nesscescary for preventing screw-ups)

			//Update the name and add a star to show it hasn't been saved yet.
			brickListBox.Items[brickListBox.SelectedIndex] = Info[0] + "*";

			categoryBox.Text = Info[2];
			subCatBox.Text = Info[3];
			UiBox.Text = Info[1];
		}

		public void updateCurrentItem(Decimal Width, Decimal Length, Decimal Height)
		{
			if (Width <= 0 || Length <= 0 || Height <= 0 || brickListBox.SelectedIndex < 0) //No arguments below one,
				return; //We don't want errors now do we!

			hasSaved = false;
			saveBrickButton.Enabled = true;
			newBrickButton.Enabled = false;
			packBrickButton.Enabled = false;

			UInt32 UWidth = UInt32.Parse(Width.ToString());
			UInt32 ULength = UInt32.Parse(Length.ToString());
			UInt32 UHeight = UInt32.Parse(Height.ToString());

			//Get the brick's info
			String[] Info = BrickMaker.getBrickInfo(UWidth, ULength, UHeight);

			if (!brickListBox.SelectedItem.ToString().EndsWith("*")) //If it was saved earlier,
				File.Delete(brickListBox.SelectedItem.ToString()); //Then delete the old file (It's nesscescary for preventing screw-ups)

			//Update the name and add a star to show it hasn't been saved yet.
			brickListBox.Items[brickListBox.SelectedIndex] = Info[0] + "*";

			categoryBox.Text = Info[2];
			subCatBox.Text = Info[3];
			UiBox.Text = Info[1];
		}

		public void updateBrickList()
		{
			isUpdating = true;
			String[] Bricks = brickList.getBricks();

			brickListBox.Items.Clear();
			FileInfo binfo;
			for (UInt32 a = 0; a < Bricks.Length; a++)
			{
				binfo = new FileInfo(Bricks[a]);
				brickListBox.Items.Add(binfo.Name);
			}
			isUpdating = false;
		}

		private void doInvalid() //OH NOES INVALIDNESS
		{
			widthCounter.Value = 1;
			lengthCounter.Value = 1;
			heightCounter.Value = 1;

			//ENABLE ALL SAFETY MEASURES ON THE DOUBLE!
			doEnables(2);

			//RESET ALL GUAGES, CAP-EE-TAIN!
			categoryBox.Text = "---";
			subCatBox.Text = "---";
			UiBox.Text = "---";

			//ANNOUNCE IT TO THE WORLD!
			label1.Text = "Invalid File!";

			//End of capsRage.
		}

		private void doEnables(Int16 Mode)
		{
			switch (Mode)
			{
				case 1:
					//Update bottom buttons based on tab index
					if (tabControl1.SelectedIndex != 0)
					{
						saveBrickButton.Enabled = false;
						newBrickButton.Enabled = false;
						packBrickButton.Enabled = false;
					}
					else
					{
						if (hasSaved)
						{
							newBrickButton.Enabled = true;
							packBrickButton.Enabled = true;
						}
						else
							saveBrickButton.Enabled = true;
					}

					//Disable stuff if there is no item selected on the brick list
					if (brickListBox.SelectedIndex < 0)
					{
						widthCounter.Enabled = false;
						lengthCounter.Enabled = false;
						heightCounter.Enabled = false;

						saveBrickButton.Enabled = false;

						if (hasSaved)
							packBrickButton.Enabled = true;
						lengthCounter.Minimum = 1;

						widthCounter.Value = 1;
						lengthCounter.Value = 1;
						heightCounter.Value = 1;

						categoryBox.Text = "---";
						subCatBox.Text = "---";
						UiBox.Text = "---";

						label1.ResetText();
					}
					else
					{
						widthCounter.Enabled = true;
						lengthCounter.Enabled = true;
						heightCounter.Enabled = true;
					}
					return;

				case 2: //Disable stuff for whatever reason.
					widthCounter.Enabled = false;
					lengthCounter.Enabled = false;
					heightCounter.Enabled = false;
					saveBrickButton.Enabled = false;
					return;
			}
		}
	}
}