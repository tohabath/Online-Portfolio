let ToDo = [];
let ToDoScore = [];
let TotalScore = 0;
let UserInput = "";
let ListPrint = "";

//Keyboard Shortcuts

document.addEventListener('keydown', function(event) {
    if (document.activeElement != document.getElementById("userInputtedLine"))
    {
        if(event.keyCode == 49) {
            AddItem();
        }
        else if(event.keyCode == 50) {
            CompleteItem();
        }
        else if(event.keyCode == 51) {
            ClearItem();
        }
    }
    else if(event.keyCode == 13) {
        AddItem();
    }
});

//Updating list

function PrintList() 
{
    for (let i = 0; i < ToDo.length; i++)
    {
        if (ToDoScore[i] != 0 && ToDoScore[i] != undefined)
        {
            ListPrint += (i + 1) + ". " + ToDo[i] + " (" + ToDoScore[i] + ")" + "<br>";
        }
        else
        {
            ListPrint += (i + 1) + ". " + ToDo[i] + "<br>";
        }
    }
    document.getElementById("fullList").innerHTML = ListPrint;
    ListPrint = "";
}

//CompleteProtocol - called at the end of each button-related function

function CompleteProtocol(bool, string)
{
    if (! bool)
    {
        document.getElementById("status").innerHTML = "<br>" + string + ".<br><br>";
    }
    else
    {
        document.getElementById("status").innerHTML = "<br>ERROR: No such item.<br><br>";
    }
    ClearInput();
    PrintList();
    ClearStatus();
}

//Buttons

function AddItem()
{
    UserInput = document.getElementById("userInputtedLine").value;
    ToDo.push(UserInput);
    attachScore();
    CompleteProtocol(false, "Item added");
}

function CompleteItem()
{
    var noSuchItem = true;
    var searching = true;
    UserInput = document.getElementById("userInputtedLine");
    for (let i = 0; i <= ToDo.length; i++)
    {
        if (searching)
        {
            if (ToDo[i] === UserInput.value || i === parseInt(UserInput.value) - 1)
                {
                    ToDo[i] = "<del>" + ToDo[i] + "</del>";
                    TotalScore += ToDoScore[i];
                    ToDoScore[i] = 0;
                    noSuchItem = false;
                    searching = false;
                }
        }
    }
    CompleteProtocol(noSuchItem, "Item completed");
}

function ClearItem()
{
    var searching = true;
    var noSuchItem = true;
    UserInput = document.getElementById("userInputtedLine");
    for (let i = 0; i <= ToDo.length; i++)
    {
        if (searching)
        {
            if (ToDo[i] === UserInput.value || i === parseInt(UserInput.value) - 1 || ToDo[i] === "<del>" + UserInput.value + "</del>")
                {
                    ToDo.splice(ToDo.indexOf(i));
                    ToDoScore.splice(ToDoScore.indexOf(i));
                    noSuchItem = false;
                    searching = false;
                }
        }
    }
    CompleteProtocol(noSuchItem, "Item deleted");
}

//Clearing functions

function ClearInput()
{
    document.getElementById("userInputtedLine").value = "";
}
function ClearStatus()
{
    setTimeout(() => {
        document.getElementById("status").innerHTML = "<br>Total Score: " + TotalScore + "<br><br>";  
    }, 1500);
}

//Scoring

function attachScore()
{
    let targetScore = prompt("How many points should be awarded for completing this task?", "5");
    if (parseInt(targetScore) > 0)
    {
        ToDoScore.push(parseInt(targetScore));
    }
    else
    {
        ToDoScore.push(5);
        alert("ERROR: unnacceptable input. Default score applied.");
    }
}