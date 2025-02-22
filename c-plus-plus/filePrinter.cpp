#include <iostream>
#include <fstream>
#include <string>
#include <list>
#include <map>
using namespace std;

class filePrinter {
    public:
        map <string, int> wordcount;
        int countWords(list<string> words) {
            
            for (string i : words)
            {
                wordcount[i] += 1;
            }
            for (auto it : wordcount)
                {
                    cout << it.first << ": " << it.second << endl;
                }
            return 0;
        }
        int printWords (string s)
        {
            cout << s << endl;
            return 0;
        }
};