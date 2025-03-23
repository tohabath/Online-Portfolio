extends Node
class_name story
var diary = {"startedGame": true, "examinedItems": false, "died": false}
var action_log = ["startedScene"]
var scene = 0
func _return_story(choice):
	if scene == 0:
		match choice:
			"begin":
				if (not action_log.has("begin")):
					_add_action(choice)
					$AudioStreamPlayer2.play()
					return ["\n\n\n[i]There is a well upon a hill,\nthat blood, and tears, and wishes fill.\nGreat men have marched upon the hill,\nto blood, and tears, and wishes spill.\nSo bring a gift up to the hill;\nthere’s blood, and tears, and wishes still.[/i]\n\n\n[center][hint=Awaken from your stupor.][u]Continue[/u][/hint][/center]", null]
				else:
					return _error()
			"continue":
				if (not action_log.has("continue")):
					_add_action(choice)
					$AudioStreamPlayer2.stop()
					return ["[font_size=25][b]Act One: Deepwood[/b][/font_size]\n\nDeepwood has always been home to strange fables.\n\nThe most well-known is of a company officer who discovered the forest’s trees regrew at twice the rate of any other wood, and even believed no seed was needed to be planted for the forest to restore itself.\n\nA sharp [shake rate=20.0 level=5 connected=1][color=orange]crackle[/color][/shake] from the campfire in front of you, and your mind returns to present circumstances, far from home and farther from the mysticism of fables.\n\nYou are seated on a log. Adjacent to you are two prized possessions: a [hint=The message that started this affair.\n\nYou can read it with the command “read letter”.][u]letter[/u][/hint], and a [hint=A dense, smiting blade.\n\nYou can examine it with the command “examine sabre”.][u]sabre[/u][/hint].", null]
				else:
					return _error()
			"read letter":
				if (not action_log.has("burn letter")):
					_add_action(choice)
					return ["The letter reads:\n\n[indent]Charkle,\n\nBy royal decree, His Majesty, Prince Dyr XI, has ordered for your decommission. Your final orders are to wait in your quarters to be brought to the boiler room, where you will be repurposed according to protocol.\n\nI look forward to overseeing your disassembly.\n\nCaptain Bryn.[/indent]\n\nWhen finished reading, you [hint=Use “return” to move on.][u]return[/u][/hint] the letter to your side, and gaze back into the fire.\n\nYou have half a mind to [hint=You can burn the letter using the command “burn letter”.][u]burn[/u][/hint] it.", null]
				else:
					_add_action(choice)
					return ["You have already burned the letter, but you remember the essentials.\n\nThe prince of Dyrfell has ordered for you to be destroyed. Captain Bryn is now on the hunt for you.\n\nWith this in mind, you [hint=Use “return” to move on.][u]return[/u][/hint] your attention to more immediate concerns.", null]
			"burn letter":
				if (not action_log.has("burn letter")):
					_add_action(choice)
					return ["You watch the cause of your current misery warp and darken in the flames, twisting and crumpling in on itself, what isn’t turned to ash fueling its destroyer.\n\nThis will be you, fairly soon. Once the Prince’s forces find you.\n\nBut you [hint=Use “return” to move on.][u]return[/u][/hint] your focus to a more immediate reality.", null]
				else:
					_add_action(choice)
					return ["You have already burned the letter. Time to [hint=Use “return” to move on.][u]move on.[/u][/hint]", null]
			"examine sabre":
				_add_action(choice)
				return ["The sword is of an uncommon make. After many years, you have been able to attune your mind to the magical force pulsing from its steel.\n\nYou have the ability to use the sword telekinetically.\n\nThe reflection in the blade stares back at you, eyes exhausted from a life completely uprooted.\n\nWhen finished looking, you [hint=Use “return” to move on.][u]return[/u][/hint] the sword to your side, and gaze back into the fire.", null]
			"return":
				if (action_log.has("read letter") && action_log.has("examine sabre")):
					_add_action(choice)
					diary["examinedItems"] = true
					return ["[indent]“Charkle!”[/indent]\n\nIn moments, you are on your feet, sword in hand.\n\nJust beyond the edge of the fire’s light, you see their silhouettes. You can make out three or four outlines, but none that resemble the royal guard.\n\n[indent]“Just how long did you think it would take to be found? Or did you assume the reward would be too cheap a price for your head?”[/indent]\n\nBounty hunters. Of course.\n\nYou grip the hilt of your sabre. It glows a faint crimson.\n\nIt’s unlikely you’ll survive if you [hint=Use “engage” to meet your fate.][u]engage directly[/u][/hint], but the [hint=Use “cover” to live another day.][u]cover of night[/u][/hint] could aid in your escape.", null]
				else:
					_add_action(choice)
					if (not action_log.has("burn letter")):
						return ["The fire is fading. You’ll have to rest soon.\n\nYour [hint=A dense, smiting blade.\n\nYou can examine it with the command “examine sabre”.][u]sword[/u][/hint] and accursed [hint=The message that started this affair.\n\nYou can read it with the command “read letter”.][u]letter[/u][/hint] are still within reach.", null]
					else:
						return ["The fire is fading. You’ll have to rest soon.\n\nThe letter is gone, but your [hint=A dense, smiting blade.\n\nYou can examine it with the command “examine sabre”.][u]sword[/u][/hint] is within reach.", null]
			"engage":
				if diary["examinedItems"]:
					diary["died"] = true
					return ["You fight desperately, a blaze of glory in the face of death.\n\nSteel clangs together, and thudding stabs mark the last breaths of most of your foes.\n\nAll except one, who ultimately defeats you.\n\n[indent]“Your bounty will keep me fed a long time, Charkle. If that is any solace.”[/indent]\n\nHe draws a final arrow, takes aim, and fires through your eye.\n\nTHE END.", null]
				else:
					return _error()
			"cover":
				if diary["examinedItems"]:
					$AudioStreamPlayer.play()
					return ["You know they will track you eventually, but you decide fighting them in daylight will offer a more even playing field.\n\nYou had planned to make this your final night in Deepwood, anyway.\n\nYou make as if to take a final stand, then just as the hunters converge, you douse the fire.\n\nTheir eyes fail to adjust in time, as you snag the essentials while easily avoiding their attacks. By the time they bring out their own light source, you are too far deep in the woods for them to find you.\n\nTaking no rest, you quietly [hint=Leave the current area and travel.][u]travel[/u][/hint] through the forest.", null]
				else:
					return _error()
			"travel":
				if diary["examinedItems"] && not diary["died"]:
					scene += 1
					return ["TravelingToOtherWorld", null]
				else:
					return _error()
			_:
				return _error()
	else:
		pass
	
func _error():
	action_log.pop_back()
	return ["ErrorMessageOutput", null]

func _add_action(choice):
	if (action_log.is_empty()):
		action_log.append(choice)
	elif (action_log.back() != choice):
		action_log.append(choice)
	else:
		pass
