using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NSMB_Randomiser
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }

        //Variables, lists and whatever
        private decimal currentSetSeed;
        private string overlayFilePath;
        private long overlayFileSize = 0;
        private int[] dataNodesWorldOffsets = new int[8] { 111092, 111320, 110204, 110636, 112068, 111560, 110420, 110864 };
        private int[] nodesPerWorld = new int[8] { 19, 20, 18, 19, 24, 20, 18, 17 };
        private int[][] worldNodesAreas = new int[8][];

        private int[] secretExitNodesAreas = { 3, 14, 26, 28, 34, 46, 58, 66, 80, 89, 99, 96, 144, 134, 135, 138 };
        private int[] secretExitAreasHexPos = { 111120, 111144, 111360, 111372, 111468, 110256, 110304, 110652, 110736, 112108, 112168, 112264, 110448, 110496, 110508, 110616 };

        private int[] normalExitNodesAreas = { 0, 6, 7, 10, 17, 12, 21, 24, 37, 30, 32, 40, 44, 61, 48, 63, 51, 54, 56, 67, 69, 83, 71, 73, 76, 85, 78, 88, 102, 91, 93, 104, 94, 97, 107, 109, 122, 111, 113, 124, 114, 116, 126, 119, 121, 129, 130, 132, 147, 141, 142, 149, 151, 153, 167, 156, 158, 171, 160, 162, 164, 165, 169, 173 };
        private int[] normalExitAreasHexPos = { 111108, 111132, 111156, 111168, 111180, 111240, 111336, 111348, 111384, 111408, 111432, 111444, 110232, 110268, 110292, 110328, 110340, 110364, 110388, 110664, 110676, 110688, 110712, 110748, 110760, 110772, 110808, 112084, 112132, 112156, 112192, 112204, 112228, 112288, 111588, 111612, 111624, 111636, 111648, 111660, 111684, 111696, 111708, 111720, 111792, 110436, 110460, 110472, 110484, 110628, 110520, 110544, 110880, 110892, 110904, 110916, 110928, 110940, 110952, 110964, 110976, 110988, 111000, 111012 };
        //-----------------------------
        private void OpenButtonClicked(object sender, EventArgs e)
        {;
            #region OpenFileDialog settings
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "overlay9_8.bin";
            ofd.Filter = "Binary Files|*.bin|All Files|*.*";
            ofd.Title = "Open overlay9_8";
            #endregion

            //Console.WriteLine("Opening Windows File Dialog...");
            DialogResult ofdResult = ofd.ShowDialog(); //Runs Windows File Dialog to select your overlay9_8 file
            overlayFilePath = ofd.FileName;
            try
            {
                overlayFileSize = new FileInfo(overlayFilePath).Length;
            }
            catch { }
            if (ofdResult == DialogResult.OK && overlayFileSize == 139360)
            {
                //Console.WriteLine("Overlay filepath saved successfully!");
                ofdButton.Enabled = false;
                try
                {
                    Directory.CreateDirectory("Temp");
                    try
                    {
                        File.Copy(overlayFilePath, "Temp/overlay9_8.tmp", true);
                        // readOverlay();
                        goButton.Enabled = true;
                        seedCheckBox.Enabled = true;
                    }
                    catch
                    {
                        ofdButton.Enabled = true;
                    }
                }
                catch
                {
                    ofdButton.Enabled = true;
                }
                
            }
            else if (ofdResult == DialogResult.Cancel)
            { 
                //Console.WriteLine("Please select a file!"); 
            }
            else
            {
                //Console.WriteLine("This Overlay file has been modified, is corrupted or is not an Overlay file at all. Please make sure you grab a freshly extracted one from your ROM!");
                MessageBox.Show("This Overlay file has been modified, is corrupted or is not an Overlay file at all. Please make sure you grab a freshly extracted one from your NTSC-U ROM.","Error");
            }
        }

        /// <summary>
        /// Most of this code was used to find all the hex positions and area ID locations. Left it for reference, obsolete now
        /// </summary>
        [Obsolete]
        private void readOverlay()
        {

            #region long ass manual (working) way to do it
            worldNodesAreas[0] = new int[19];
            worldNodesAreas[1] = new int[20];
            worldNodesAreas[2] = new int[18];
            worldNodesAreas[3] = new int[19];
            worldNodesAreas[4] = new int[24];
            worldNodesAreas[5] = new int[20];
            worldNodesAreas[6] = new int[18];
            worldNodesAreas[7] = new int[17];
            #endregion

            #region cool (broken) way to do it
            //for (int i = 0; i < 8; i++)
            //{ 
            //    worldNodesAreas[i] = new nodesPerWorld[i];
            //}
            #endregion

            BinaryReader br = new BinaryReader(File.Open("Temp/overlay9_8.tmp", FileMode.Open));

            try
            {
                for (int i = 0; i < 8; i++)
                {
                    br.BaseStream.Position = dataNodesWorldOffsets[i];
                    ;
                    //Console.WriteLine("Starting BinaryReader stream for World {0}...", i + 1);

                    for (int j = 0; j < nodesPerWorld[i]; j++)
                    {
                        //Console.WriteLine("--------------------");
                        int area;
                        br.BaseStream.Position += 4;
                        //Console.WriteLine("--------------------");
                        //Console.WriteLine("[Area] Current byte position: {0}", br.BaseStream.Position);

                        area = br.ReadByte();
                        //Console.WriteLine("Area ID is: {0}", area);
                        br.BaseStream.Position += 7;
                        worldNodesAreas[i][j] = area;
                        //Console.WriteLine("worldNodesAreas[i][j]: {0}", worldNodesAreas[i][j]);
                    }
                }
                goButton.Enabled = true;
                seedCheckBox.Enabled = true;
            }
            catch
            {
                ofdButton.Enabled = true;                
                MessageBox.Show("Failed to read the overlay file's data.","Error");
            }
            br.Close();
        }
            
        private void GoButtonClicked(object sender, EventArgs e)
        {
            //Check whether the seed check box is ticked or not, and if it is use the seed entered in that checkbox
            if (seedCheckBox.Checked)
            {
                currentSetSeed = seedNumericBox.Value;
                //Console.WriteLine("Proceeding with seed: {0}", currentSetSeed);
            }
            else if (!seedCheckBox.Checked) 
            {
                Random tempRand = new Random();
                currentSetSeed = tempRand.Next();
                //Console.WriteLine("Proceeding with random seed: {0}", currentSetSeed);
            }
            else { }
            goButton.Enabled = false;
            seedCheckBox.Enabled = false;
            seedNumericBox.Enabled = false;
            //Randomise the order of the Area IDs in the lists
            Random rand = new Random(Decimal.ToInt32(currentSetSeed));
            int[] randomisedSecretExAreas = secretExitNodesAreas.OrderBy(x => rand.Next()).ToArray();
            int[] randomisedNormalExAreas = normalExitNodesAreas.OrderBy(x => rand.Next()).ToArray();
            //Write everything  to the file
            BinaryWriter bw = new BinaryWriter(File.Open("Temp/overlay9_8.tmp", FileMode.Open, FileAccess.Write));
            //Console.WriteLine("Writing randomized normal exits to the file...");
            for (int i = 0; i < 64; i++)
            {
                bw.Seek(normalExitAreasHexPos[i], 0);

                bw.Write((byte)randomisedNormalExAreas[i]);
            }
            //Console.WriteLine("Writing randomized secret exits to the file...");
            for (int i = 0; i < 16; i++)
            {
                bw.Seek(secretExitAreasHexPos[i], 0);

                bw.Write((byte)randomisedSecretExAreas[i]);

            }
            bw.Close();
            //Create directory for exporting the modified file and then copy it. The randomisation process is finished.
            try
            {
                Directory.CreateDirectory("Out");
                try
                {
                    File.Copy("Temp/overlay9_8.tmp", "Out/overlay9_8.bin", true);
                    File.Delete("Temp/overlay9_8.tmp");
                    Directory.Delete("Temp");
                    //Console.WriteLine("All done! Find your randomized file in the Out folder!");
                    string[] seed = new string[] { currentSetSeed.ToString() };
                    File.WriteAllLines("Out/seed.txt",seed);
                    MessageBox.Show("All done! Find your randomized file in the \"Out\" folder, and the seed that was used in the seed.txt!","Success!");
                    Application.Exit();

                }
                catch 
                { 
                    MessageBox.Show("Failed to copy randomized file, aborted","Critical Error!"); 
                    Application.Exit(); 
                }
            }
            catch
            {
                MessageBox.Show("Failed to create out directory, aborted", "Critical Error!"); 
                Application.Exit(); 
            };
        }

        private void SeedBoxCheckChanged(object sender, EventArgs e)
        {
            
            if (seedCheckBox.Checked)
            {
                goButton.Enabled = false;
                seedNumericBox.Enabled = true;
                goButton.Enabled = true;
            }
            else if (!seedCheckBox.Checked)
            {
                goButton.Enabled = false;
                seedNumericBox.Enabled = false;
                goButton.Enabled = true;
            }

        }

        private void EditorFormLoaded(object sender, EventArgs e)
        {
            //Console.WriteLine("Randomizer window has loaded successfully!");
        }
    }
}
