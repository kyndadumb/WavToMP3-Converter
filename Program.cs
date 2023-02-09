using NAudio.Wave;
using NAudio.Lame;

// select directories
String sourceDirectory = @"C:\Users\fbenn\Music\WAV";
String targetDirectory = @"C:\Users\fbenn\Music\MP3";

// search files
String[] wavFiles = Directory.GetFiles(sourceDirectory, "*.wav");

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
