Please note this is a work in progress and may or may not ever be fully refined. I made
this while playing through the game myself. As such, if I wind up beating the game before
it is finished, it will likely remain at the state it was in when I beat the game.

Currently, this mod definitely has some glitches and isn't fully working-correctly. 
It seems to max out the player's currency just fine. However, one call that I was using
to remove any and all enemies (to sort of trample their instances since even nullifying
object instances didn't seem to work) was:

		EnemyManager.Clear();

		EnemeyManager class is declared as: public static class EnemyManager

		and Clear is defined as: public static void Clear()

Them both being static means nothing should need to be instantiated. However, when
calling Clear(), it causes all sorts of problems! It seems to prevent you from being able to
exit the building, it also prevents money from accumulating and the game from auto-saving!!!


Additional notes:

	To get this to build:
		Add these references (from the game's WTTG2_Data\Managed directory):
			UnityEngine
			UnityEngine.CoreModule
			UnityEngine.IMGUIModule
			UnityEngine.TestRenderingModule
			UnityEngine.UI
			UnityEngine.UIElementModule
			UnityEngine.UIModule
			Assembly-CSharp

		and add these references for UniversalUnityHooks:
			HookAttribute
			UniversalUnityHooks

	Some of these dependencies could likely be streamlined / optimized by being removed as they
	may not all be needed, but some of them I'm leaving in (like the UI and Text ones) because
	at some point I'd like to latch into the UI to display information about what the mod is
	detecting (any enemy events that it's shutting down, etc.) or doing.


	I will only give a brief explanation of how to install Universal Unity Hooks since
	that project's page is really where one should go for more information on that -- though
	it isn't hard.

	First, (either before you build your DLL or after, either way is fine), put the files of
	Universal Unity Hooks (UUH) in the game's root directory alongside where the WTTG2.exe is.
	That means, do NOT create a directory just for UUH in the root directory and put UUH there, I mean
	quite literally, place UUH's files directly in the directory with WTTG2.exe :)

	Next, run UUH once from the command line (no arguments needed). This should create a directory
	a Plugins directory under the game's root directory.

	TADA, UUH is installed. Easy right? :)


	NOTE: Before you have UUH patch / inject any game DLLs, you may want to make a backup of,
		and there may be others -- these are just what I make a back up,

		Assembly-CSharp.dll
		Assembly-CSharp-firstpass.dll
		Assembly-UnityScript.dll

		That way if you have a feeling that something is really whacked out you can just copy over
		those files back overtop without needing to re-validate the entire set of game files.

	If you already built the mod, copy the DLL into that Plugins directory, and drop to the
	command line and re-run UUH again. This time, UUH will pick up that there is a file in thar
	directory and automatically do all the patching / injection necessary.

	If you have not already built the mod, then do so, and then do the above :)

	If you are looking to extend or modify the code, I'd recommend downloading ILSpy; it will let
	you examine the game's code since C# "compiles" down to MSIL (MicroSoft Intermediate Language).

UPDATE:
6/20/2021 12:30PM -- The call EnemyManager.Clear() may not be what is preventing the player
						 from exiting the building, and the game auto-saving. It seems like, if
						 Clear() is rem'ed out, the player is still unable to exit the building,
						 and interaction (fully leaving things like the computer if the player
						 were "in the screen") is locked if, for example, Lucas is
						 triggered. In fact, there have been times that I have exited my
						 appartment, and have discovered Lucas just standing in the middle
						 of the hallway just before the apartment door with his back to it.
						 I have even gotten up from the computer and have seen him just
						 standing in the corner of the main apartment room in the corner
						 by the window and bathroom door. To test his "state" I walked
						 into him and nothing. So it is like he spawns and certain
						 interactions break, but he doesn't do anything. This is still
						 somewhat advantageous since it provides the player the opportunity
						 to force-close the game and prevent the game from auto-saving
						 and wiping out your save as the player would have been killed.
						 For this reason, I'm leaving it as is until I can figure out
						 a way to prevent him from spawning in the first place.

Leveraging HitManManager.SpawnHitman (since only public members and methods can be
pre-pended / post-pended to -- a limitation of Universal Unity Hooks), the line
HitmanManager.DeSpawn() was added and UUH told to append any custom code to the end of the
method. This, theoretically would have the effect of Lucas spawning in, and then immediately
being spawned back out. However, even doing this he still spawns in. It seems the
police-triggers are squashed, but I'm not sure. So far, I haven't lost to that yet.

I've heard the police scanner and footsteps and immediately ran into the bathroom behind the
shower curtain but I'm wondering if that is Lucas and the police scanner was more of a random
ambient and unrelated to the player character.
