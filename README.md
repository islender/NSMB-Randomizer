# NSMB-Randomizer
Randomizes the level order from NSMB (DS). Works on USA/NTSC-U ROMs ONLY.

Credits:
-thegreatwaluigi: Started the project. Level documentation and testing.
-RicBent/Bent: Created the NSMBDS worldmap editor that was used for code reference, testing,
and made moving the levels around possible in the first place.
-islender: Coded the randomizer.

Full guide:

You will need:
-The .NET Framework v4.0 or higher installed on your computer.
-The latest release of the NSMB editor which can be found here:
https://nsmbhd.net/download/
-A seperate version of the above editor to decompress the required file:
http://www.mediafire.com/file/c0023rbntizjdz7/NSMBe_OverlayDecompress.rar/file
-A clean USA/NTSC .nds rom of NSMBDS [You can extract your own copy with a 3Ds.]
(EU/PAL roms are not supported.)

1. Open the OverlayDecompress version of NSMBe, (not the most recent) and select your rom.
2. Select the "ROM File Browser" tab at the top. Open the "FILESYSTEM" folder, then the
"ARM9 Overlay Table" folder.
3. Locate the file named:
020CC2E0 - 020EE33F, OV 8, FILE 18
4. Select it, and then press the "Decompress overlay" button. (Again if unsure of change.)
5. Close the program, and open the NEWEST version of NSMBe.
6. Select your rom and go to the "ROM File Browser" tab again. You will notice that it looks
a bit different now, but this is normal.
7. Open the "overlay9" folder and locate the file named:
overlay9_8.bin
This is the file you decompressed.
8. Select it, and press extract. Save the file somewhere. (DO NOT RENAME IT)
You may be wondering, "Why couldn't I just do the decompressing with this editor instead?"
The decompress button is broken on the majority of NSMBe versions, and the ones that it
DOES work on, the extract button is broken. I have no idea why nobody will fix this already.
9. Open the NSMBRandomizer.exe
10. Press the "Open overlay9-8.bin" button and select the file you saved earlier.
10a. (Optional) Check the "Use Seed" box and enter any number between 0 and 2147483647.
11. Press "Go!"
12. Now open the newest version of NSMBe again, and repeat steps 6 and 7.
13. This time, select "overlay9_8.bin" in NSMBe and press the "Replace" button.
14. Locate and select your newly randomized overlay9_8.bin file to replace the old one.
15. DO NOT compress the file after replacing! Close NSMBe to save your rom.
16. (IMPORTANT) Be sure to keep the original overlay9_8.bin file and the .nds rom you used
for this process! They can be reused so you only have to repeat steps 9-15 in the future!

World 4 and 7:
To get to these worlds, beat whichever stage appears OVER "2-Castle" and "5-Castle" with
a mini mushroom! (EVERY castle, if appearing in ANY level of world 2 or 5, will have the
"change world" sign at the end that mini mario can interact with. That sign is NOT linked to
the world destination change in any way, only the mentioned stage slots themselves are.)

Send a message on Discord if you have any questions or encounter any crashes!
thegreatwaluigi#3716
islender#3477
