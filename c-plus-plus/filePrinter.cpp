#include <iostream>
#include <fstream>
#include <string>
#include <list>
#include <map>
using namespace std;

class filePrinter {
    public:
        map <string, int> wordcount;

        // cleanKey iterates through given string cleaned using remove_if(), 
        // iterating from beginning to end, to check whether character c isspace() or iscntrl(), 
        // which both create white or null space. char c is contained in a lambda, 
        // which returns true or false based on what is returned.
        // This block of code is a tailored version of a method provided by ChatGPT,
        // but I made sure to get an explanation for each component and how it works.
        // I've never used a lambda function like this before, however, which
        // does hurt my credibility for implementing this in my program.

        string cleanKey(string key) {
            string cleaned = key;
            cleaned.erase(remove_if(cleaned.begin(), cleaned.end(), 
                [](char c) { return isspace(c) || iscntrl(c); }), 
                cleaned.end());
            return cleaned;
        }
        int countWords(list<string> words) {
            for (string i : words)
            {
                wordcount[cleanKey(i)] += 1;
            }
            wordcount.erase("");
            for (auto it : wordcount)
                {
                    cout << it.first << ": " << it.second << endl;
                }
            return 0;
        }
        int printWords (string s) //Simply prints out everything from the string where the file's contents are stored.
        {
            cout << s << endl;
            return 0;
        }
};