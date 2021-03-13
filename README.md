# beatsaber-gc-fixer
A quick and dirty application that auto detects your Beat Saber folder & fixes Beat Sabers garbage collection to prevent stutters on version 1.13.4 and 1.13.5

Based off of denpadokei's findings [GitHub](https://github.com/denpadokei) [Twitter](https://twitter.com/j_denpadokei)

[![GC Fixer](https://i.imgur.com/nDAAmwL.png)](https://github.com/Umbranoxio/beatsaber-gc-fixer/releases/latest)

# What It's Doing
Over time, GC (garbage collection) will "collect" any "garbage" made by an application. The new update changed the way Beat Saber's garbage collector functions. This program reverts it to the old version by modifying `boot.config`, a file that loads engine specific settings into Beat Saber. All it does is add an extra line to it: `gc-max-time-slice=3`. It does not modify any game files.
