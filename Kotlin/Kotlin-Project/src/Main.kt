
fun main() {
    var running = true

    val gl = GameLogic()
    val word = gl.defineWord()
    val blanks = gl.defineWordBlanks(word)

    val hm = HangMan()

    println("Welcome to our game of Hangman!\nTry your luck at guessing the letters of a secret word!\nYou may only guess one letter at a time.\nToo many wrong guesses will result in a man being\nHANGED!")
    println()

    print(blanks)
    println()
    while (running)
    {
        gl.userInput()
        if (gl.calculateScore(word) < 5)
        {
            println()
            hm.printPartialMan(gl.getUserTries())
        }
        running = gl.printStatus(word)
        println()
    }
}

class GameLogic
{
    private var userString = ""
    private var userTries = 5
    fun defineWord(): String
    {
        val wordsAvailable = listOf("hamburger", "medusa", "bread", "jam")
        val secretWord = wordsAvailable.random()
        return secretWord
    }
    fun defineWordBlanks(secretWord: String): String
    {
        var secretWordBlanks = ""
        for (char in secretWord)
        {
            secretWordBlanks += "_"
        }
        return secretWordBlanks
    }
    fun userInput()
    {
        print("> ")
        val letter = readln().lowercase()
        if (letter.length == 1)
        {
            userString += letter
        }
        else
        {
            println("You can only guess one letter.")
        }
    }
//    printStatus tracks progress, and determines end conditions.
    fun printStatus(secretWord: String): Boolean
    {
        var runningGame = true
//        There is no universal score; each time the function is run, the game tracks how many letters the player
//        has guessed correctly. If score matches the number of letters in secret word, the player wins.
        var score = 0
        for (char in secretWord) {
            if (char in userString) {
                print(char)
                score += 1
            } else {
                print("_")
            }
        }
        if (score == secretWord.length)
        {
            runningGame = false
            println("\n\nGreat job!")
        }
        else if (userTries <= 0)
        {
            runningGame = false
            println("\n\nBetter luck next time!")
        }
        return runningGame
    }
//    CalculateScore and getUserTries are both used to control the printing of the hangman,
//    and determine the number of attempts the player has left.
    fun calculateScore(secretWord: String): Int
    {
        if (userString.last() !in secretWord || userString.last() in userString.dropLast(1))
        {
            userTries -= 1
//            println("($userTries)")
        }
        return userTries
    }
    fun getUserTries(): Int
    {
        return userTries
    }
}

class HangMan
{
    private val hangMap = mapOf("Head" to "o|O.O|o", "Neck" to " -----", "Shoulders" to " /|¯|\\", "Torso" to "  |||", "Legs" to "_/¯¯¯\\_")
    private fun printFullMan()
    {
        println("${hangMap["Head"]}")
        println("${hangMap["Neck"]}")
        println("${hangMap["Shoulders"]}")
        println("${hangMap["Torso"]}")
        println("${hangMap["Legs"]}")
    }
    fun printPartialMan(triesRemaining: Int)
    {
        when (triesRemaining)
        {
            4-> println("${hangMap["Head"]}")
            3-> println("${hangMap["Head"]}\n${hangMap["Neck"]}")
            2-> println("${hangMap["Head"]}\n${hangMap["Neck"]}\n${hangMap["Shoulders"]}")
            1-> println("${hangMap["Head"]}\n${hangMap["Neck"]}\n${hangMap["Shoulders"]}\n${hangMap["Torso"]}")
            0-> printFullMan()
        }
    }
}