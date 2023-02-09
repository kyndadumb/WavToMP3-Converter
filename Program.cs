using NAudio.Wave;
using NAudio.Lame;

// select music directory for current user
String musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
String sourceDirectory = musicFolder + @"\WAV";
String targetDirectory = musicFolder + @"\MP3";

Console.WriteLine(musicFolder);

// search files
String[] wavFiles = Directory.GetFiles(sourceDirectory, "*.wav");

// end if no files were found
if (wavFiles.Length == 0)
{
    Console.WriteLine("no .WAVs found, exiting...");
    Environment.Exit(0);
}

foreach (String wavFile in wavFiles)
{
    // change extension of wave-file to .mp3
    String mp3File = Path.ChangeExtension(wavFile, ".mp3");
    mp3File = Path.Combine(targetDirectory, Path.GetFileName(mp3File));

    // read wav-file
    using (var reader = new WaveFileReader(wavFile))
    {
        // write mp3-file with EXTREME-preset
        using (var writer = new LameMP3FileWriter(mp3File, reader.WaveFormat, LAMEPreset.EXTREME))
        {
            reader.CopyTo(writer);
        }
    
        // write message when conversion completed
        Console.WriteLine(Path.GetFileName(mp3File) + " created");
    }   
}

// end message
Console.WriteLine("Conversion completed"); 
Environment.Exit(0);
