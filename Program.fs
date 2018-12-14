// Learn more about F# at http://fsharp.org

open System
open System.IO

let pathRead = @"C:\Users\Esben\Documents\Visual Studio 2017\Projects\FileReaderWriterFSharp\FileReaderWriterFSharp\text.txt"
let pathWrite = @"C:\Users\Esben\Documents\Visual Studio 2017\Projects\FileReaderWriterFSharp\FileReaderWriterFSharp\WrittenFile.txt"

let mutable searching = true
let exitWord = "exit"


let checkIfWordExist words word = 
    if List.contains word words then
        printfn "The word %s exists in the file" word  
        true
    else
        printfn "The word %s does not exist in the file" word  
        false

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

let checkForExit word = 
    if word = exitWord then
        false
    else
        true

let start =
    let words = readFile
    while searching do 
        printfn "Which word would you like to search for? Type 'exit' to exit"
        let word = Console.ReadLine()
        searching <- checkForExit word
        let exist = checkIfWordExist words word
        if exist = true then
            let result = checkOccurences words word
            printfn "%s - %i occurences" (fst result) (snd result)  
            writeToFile result 

start



