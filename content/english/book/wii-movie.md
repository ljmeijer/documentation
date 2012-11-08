How to create a movie file (*.thp) ?
====================================


You can read detailed information about how to create a thp file here - <RVL_SDK>\docs\en_US\THP_Library_Guide\THP.pdf

* To create a thp file, you must have an array of jpeg images and a wav file. You can use virtualdub (http://www.virtualdub.org/) to extract jpeg images and an audio (wav file) from avi file, or any other software having similar feature.
> Note: Audio file should contain uncompressed 16-bit PCM data and playback frequency must be 32,000 Hz. If your audio has different frequency, the thp file might be played incorrectly, you can quickly change audio file's frequency with winamp:
    * Open your audio file with winamp, but don't play it.
    * Go to Options->Preferences->Plug-ins->Output
    * Choose Nullsoft DiskWriter, it means that instead of playing the audio file, it will be save to a disk instead.
    * Choose Configure
    * Choose Directory if need.
    * Select 'Convert to format', Format -> PCM, Attributes -> 32.000 kHz, 16 bit Stereo
    * Play the audio, it will be saved to your specified directory.

Also note, that thp file can have multiple audio tracks, so it's easy to make a video with localisation.

Example command line for creating thp file:
[=%=]REVOLUTION_SDK_ROOT[=%=]X86\bin\THPConv.exe -j Test\*.jpeg -s test.wav -r 25 -d test.thp
