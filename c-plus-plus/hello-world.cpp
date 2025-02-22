#include <iostream>
#include <fstream>
#include <string>
#include <list>
#include <map>
#include "fileReader.cpp"
#include "filePrinter.cpp"
#include "fileWriter.cpp"
using namespace std;

// My plan is to do the file reader/analyzer suggestion. The program will read from a text file, display it, then
// count the occurences of each word and display that. One class will read through the file and store it in a
// variable, one class will loop through the file and find occurences of each word, and store this information in a
// list. Conditionals will be used to list each word in order of its frequency.

fileReader filereader;
filePrinter fileprinter;
fileWriter filewriter;
int main()
{
    filewriter.writeToFile("index.txt");
    string s = filereader.readFile("index.txt");
    list<string> words = filereader.dissectFile(s);
    cout << "\nCounting words...\n" << endl;
    fileprinter.countWords(words);
    cout << "\nCounting complete.\n" << endl;
    return 0;
}