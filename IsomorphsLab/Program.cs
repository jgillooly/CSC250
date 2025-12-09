// See https://aka.ms/new-console-template for more information
using CSC250;

//CHANGE THESE TO MAKE THE PROGRAM WORK
string inputpath = "C:/Users/Joshua/source/repos/CSC250/CSC250/IsomorphInput2.txt";
string outputpath = "C:/Users/Joshua/source/repos/CSC250/CSC250/IsomorphOutput2.txt";

var words = Isomorphs.GetWordsFromFile(inputpath);

//console
Isomorphs.DoIsomorphThings(words);

//file output
Isomorphs.IsomorphAnalyzeToFile(outputpath, words);