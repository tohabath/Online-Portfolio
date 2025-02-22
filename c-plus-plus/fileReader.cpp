#include <iostream>
#include <fstream>
#include <string>
#include <list>
using namespace std;

class fileReader {
    public:
        string readFile(string filename) {
            ifstream f;
            string s;
            f.open (filename);
            if (!f.is_open())
            {
                cerr << "ERROR: Cannot access file!";
                return s;
            }
            getline(f, s);
            f.close();
            return s;
        }
        list<string> dissectFile(string s)
        {
            list<string> words;
            int i = 0;
            string x;
            char separator = ' ';
            char apostrophe = '\'';
            for (int i = 0; i <= s.length(); i++)
            {
                if (s[i] != separator && !ispunct(s[i]))
                {
                    x += s[i];
                }
                else if (s[i] == apostrophe)
                {
                    x += s[i];
                }
                else
                {
                    if (x != "")
                    {
                        words.push_back(x);
                    }
                    x = "";
                }
            }
            words.push_back(x);
            if (words.back() == "")
            {
                words.pop_back();
            }
            return words;
        }
};