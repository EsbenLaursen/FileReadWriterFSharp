// Learn more about F# at http://fsharp.org

open System
open System.IO

let pathRead = @"C:\Users\Esben\Documents\Visual Studio 2017\Projects\FileReaderWriterFSharp\FileReaderWriterFSharp\text.txt"
let pathWrite = @"C:\Users\Esben\Documents\Visual Studio 2017\Projects\FileReaderWriterFSharp\FileReaderWriterFSharp\WrittenFile.txt"


let checkWordInFile lines word =
    let returnthing= List.contains word lines
    returnthing

let checkIfWordExist words word = 
    List.contains word words

let checkOccurences words word = 
    let result = words |> Seq.countBy id |> Seq.toList |> List.filter (fun (x,y)-> x = word) |> Seq.head
    result

let readFile = 
    let text = File.ReadAllText(pathRead)
    let filterSymbols = text.Replace('.', ' ')
    let filterSymbols2 = filterSymbols.Replace(',', ' ')
    let toLower = filterSymbols2.ToLower()
    let words = toLower.Split(' ')
    Seq.toList words

let writeToFile occurences = 
    let toString = "The word " + (fst occurences).ToString() + " appeared " + (snd occurences).ToString() + " times"
    File.WriteAllText(pathWrite, toString)



// Create instance of Data and Read in the file.
let words = readFile
let word = Console.ReadLine()
let exist = checkIfWordExist words word
printfn "%b" exist
let result = checkOccurences words word
printfn "%s - %i" (fst result) (snd result)  

writeToFile result 


Console.ReadLine()



