#include <iostream>
#include <fstream>
#include <string>
#include <list>
#include <map>
#include "fileReader.cpp"
#include "filePrinter.cpp"
#include "fileWriter.cpp"
using namespace std;

// Main file

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