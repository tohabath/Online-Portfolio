# Overview

This program allows the user to write into file index.txt. Then, the program will count the occurence of each word, and print out a list of the words in the file with the number of times each word is used.

[Software Demo Video](https://youtu.be/GFtMJaDyCSk)

# Development Environment

I used a combination of Visual Studio and VSCode to create the program.

# Useful Websites

- [GeeksForGeeks: How to erase from a dictionary](https://www.geeksforgeeks.org/how-to-delete-key-value-pair-from-map-in-cpp/)
- [CPlusPlus: How to write to and read from a text file](https://cplusplus.com/doc/tutorial/files/)
- [StackOverflow: How to use classes across multiple files](https://stackoverflow.com/questions/12733888/regarding-c-include-another-class)
- [W3Schools: How to create classes](https://www.w3schools.com/cpp/cpp_classes.asp)
- [GeeksForGeeks: How to create a dictionary](https://www.geeksforgeeks.org/how-to-create-a-dictionary-in-cpp/)
- [StackOverflow: How to use a character verbatim](https://stackoverflow.com/questions/2414478/escaping-an-apostrophe-in-a-character-literal#2414490)
- [GeeksForGeeks: Converting numbers to strings](https://www.geeksforgeeks.org/converting-number-to-string-in-cpp/)
- [GeeksForGeeks: Getting the size of a list](https://www.geeksforgeeks.org/list-size-function-in-c-stl/)
- [GeeksForGeeks: How to remove punctuation marks from a string](https://www.geeksforgeeks.org/removing-punctuations-given-string/)
- [W3Schools: How to change a list element](https://www.w3schools.com/CPP/cpp_list.asp)
- [FavTutor: How to split a string](https://favtutor.com/blogs/split-string-cpp)
- [CPlusPlus: How to use GetLine](https://cplusplus.com/reference/string/string/getline/)
- [W3Schools: More information on accessing a text file](https://www.w3schools.com/cpp/cpp_files.asp)

# Future Work

- The main file is called hello-world, because that is the name I gave it initially, and I haven't had time to change it.
- There's a small issue where the word counter method will remove whitespace characters, but the file dissecter method won't. It has not impact from a user standpoint, but is a flaw in the internal logic.
- The clean key method in the file printer class is based on a function written by ChatGPT, because I couldn't find a solution through my own research. I've tried to make up the difference by learning what each part of it does, but at some point I would want to replace it with something more original.