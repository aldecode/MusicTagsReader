open System.IO
open System.Text

let readTags (musicDirectory: DirectoryInfo) (outputPath: string) =
    use fs = new FileStream(outputPath, FileMode.Create)
    use sw = new StreamWriter(fs, Encoding.UTF8)

    try
        try
            musicDirectory.GetFiles("*.mp3")
            |> Array.map (fun track -> TagLib.File.Create track.FullName)
            |> Array.iter (fun trackTags ->
                sw.WriteLine $"{System.String.Join(',', trackTags.Tag.Performers)} - {trackTags.Tag.Title}")
        with
        | ex -> printfn $"{ex.ToString}"
    finally
        fs.Close |> ignore
        sw.Close |> ignore
        printf "Finita"

readTags (DirectoryInfo(@"E:\Music")) "E:\output.txt"
