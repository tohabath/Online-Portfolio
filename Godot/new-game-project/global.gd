extends Node
class_name story
var diary = {"startedGame": true}
var action_log = []
var scene = 1
func _return_story(choice):
	_add_action(choice)
	if scene == 0:
		return ""
	if scene == 1:
		match choice:
			"yes":
				if diary["startedGame"]:
					return ["Good job!\n\nReady to start your adventure? Type [hint=Leave the current area and travel.][u]travel[/u][/hint] to head out!", null]
			"travel":
				return ["TravelingToOtherWorld", null]
			_:
				action_log.pop_back()
				return ["ErrorMessageOutput", null]
	elif scene == 2:
		match choice:
			"yes":
				return ["Cool!", null]
			_:
				action_log.pop_back()
				return ["ErrorMessageOutput", null]

func _add_action(choice):
	if (action_log.back() != choice || action_log.is_empty()):
		action_log.append(choice)
