#include <iostream>
#include <fstream>
#include <string>
using namespace std;

class fileWriter {
    public:
        int writeToFile (string filename) {
            // Takes a string from the user, then overwrites the file with it.
            string userInput;
            ofstream myfile (filename);
            if (myfile.is_open())
            {
                cout << "Input content for file:\n" << endl;
                getline (cin, userInput);
                myfile << userInput;
                myfile.close();
            }
            else cout << "Unable to open file";
            return 0;
        }
};