# bp-sys-wpf
 **Note: Please make sure to put the contents of the unzipped software in a separate folder, if it causes data loss, the consequences are your own** (the principle of the updater is to download the update package "new_bpsys.7z" and then delete all files in the directory except for 7z, Resource, new_bpsys.7z and then unzip the update package). (then unzip the package).

 This software is not for commercial use.

 ## Introduction of the software:
 Net 8.0 framework, the interface is WPF framework, written in C#.

 The UI used in the current version is the full set of BP UI for IVL 2023 Fall Tournament.

 The match system is IVL 2023 Fall Tournament's semi-full BP BO5 system.

 If you need to modify the UI, you can modify the images in the folder /Resource/gui/ under the folder in equal proportion.

 This software has been open-sourced on Github: [plfjy/bp-sys-wpf](https://github.com/PLFJY/bp-sys-wpf)

 **[Download Address](https://plfjy.lanzouq.com/icsEH255s13a)**

 ### BP module:

 ### Role display:
 A drop-down combo box can be searched by inputting the pinyin initials of the character name, and press Tab key to fill in the details, meanwhile, Tab key is also the trigger key to update the character in that box to the foreground interface, ** only the corresponding picture will appear in the foreground interface if the Tab key is pressed ** *(Note: the pinyin initials of the 26th guard is bb i.e. "bang bang ", is a special value, mainly for your own convenience) **, ** the corresponding drop-down box will display the corresponding character's avatar below if operated correctly **

 **About the number buttons below the Pick Survivor preview: this is used after entering the game to match the player to the character being used, clicking on the corresponding number will swap the position of the character in that position with the position of the character in the position that corresponds to the number on the button **.

 At the end of each round, you can press the "Reset" button to reset the current character selection, it will not affect the BP of the map and the score of the score system, the global banned picks will be automatically recorded to the right side of the "global banned picks record" position, and it will be automatically on the screen when you change sides.

 *About the global banned picks record in the Pick interface: this is a convenient way to record the global banned picks, the top one is for the home game, the bottom one is for the away game, after filling in the name of the team, the outside border will show the name of the team. You can record the first two choices of the game on the right side when the player finishes choosing the first two roles, this will be linked with the left side of the "global banned", simply record will not affect the current game of the global banned choices of the current game, in the side of the change will be automatically filled with the survivor's team's global banned record to the global banned*.

 Map BP display: there's not much to say about this, it's not hard to understand in terms of general rationality.

 Talent display: also not difficult to understand, it is worth noting that the arrangement of the cross and the in-game talent position is corresponding, and according to the order of the left to right, top to bottom of the outer frame of the text is in accordance with the order of the Pick interface survivor to determine the order of the survivor, the display of the survivor's role in the name.
 *Currently (2024.8.2) you can only see the survivor's talents in the area selection stage, so only the survivor's talents are displayed, and more displays will be added according to the changes of the game.

 Team information (including team name, team logo and player ID): the only thing worth noting is that the player's name can be filled in directly with a nickname, not a team name, which will be automatically synthesized when uploaded to the frontend. The Survivor portion of the "current player" has a shortcut entry in the Pick screen, which also allows you to do the swap described below. You can also change the position as described below.

 *About the number buttons next to the player's name on the team info page: this is also used to match the player to the character being used, clicking on the corresponding number will swap the player's position with the one corresponding to the number on the button.

 #### About importing team information from a Json file:
 The example file for importing team information is TeamInfoExample.json in the root directory of the software, which can be opened directly with Notepad.
 Such a file can directly import team information, the team logo uri can either be a link or the exact location of the file in your computer, but if it is the latter then you need a double slash like for example E:\\Desktop\\YS.png, otherwise the directory won't be read correctly!
 *(Hint: you can use Gitee in the wiremap bed)*

 Ban number setting: there's not much to say about this, on means there's this Ban, off means there's no such Ban, which means the Ban will be locked, and the corresponding drop-down box will be disabled at this time

 Playing screen: the character you selected in the background will be synchronized to the playing screen, the order of the player's name and the order of the character will be the same as in the front window.


 ---Score Control: Score control will be synchronized with the player's name and character order in this screen.


 Score Control:

 BP screen and in-game score: here, the corresponding game result is the result of the game of the authorities, note: you need to press the result before switching sides, or else the score of the two sides is wrong, of course, if it is wrong, you can use the manual panel to correct it.

 The score can be displayed on the in-game screen using the "In-Game Score" window, one for the Survivor's team and one for the Regulator's team.

 I also developed an interface to display the score of each game, this is completely independent of the previous BP and in-game score, so it needs to be operated separately, and I don't need to explain too much about how to use it.

 I will maintain this software for a long time, if there is a new version, you will be alerted when you start the software, then you can go to the bottom right corner of the About screen to update it.

 ---The program will be maintained for a long time.

 Some special notes: the root directory of this program is structured in the following folders: 7z, pic, Resource.

 7z: 7zip is used to decompress the update packages, if you delete the program you will not be able to use the automatic update.

 pic: it stores all the character drawing resources and map display resources, if deleted, it will cause the software to crash when it can't find the corresponding picture.

 Resource: there is also a gui folder, used to store the software foreground UI, you can modify the pictures in the folder to achieve interface customization, and another Config.ini file can modify the foreground interface text color, detailed file inside the notes, color code error or gui picture files are missing, then it will lead to software crash!

 Overall change can be, do not delete or software crash do not blame me!





 Requirements

 Please use native OBS to display the front interface of this software.

 Please use the "Window Capture" in OBS and select the capture method as ""BitBlt", the priority of window matching as "Window title must match" and uncheck the box of "Window title must match". "and uncheck "Show Mouse Pointer".

 for the source using filters to add "color value", the key color is "green", similarity adjusted to just can not see the green can be (more will be to show that also deducted)

 Written in the end: It is recommended to install "Han Yi fifth personality body", "Huakang POP1 body W5", "Delight Black" font to achieve a better display effect, otherwise it will be very ugly, the first two The first two fonts can be found at the bottom of the [Fifth Person Wiki](dwrg.wiki) at the "Fonts", the latter can be searched on the B site directly by ooooooohmygosh production!


通过DeepL翻译 (https://www.deepl.com/app/?utm_source=ios&utm_medium=app&utm_campaign=share-translation)