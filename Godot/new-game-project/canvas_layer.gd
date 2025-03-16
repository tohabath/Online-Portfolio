extends CanvasLayer

# Access child nodes
@onready var fullSliver = $Panel
@onready var storyBox = $Panel/ScrollContainer/MarginContainer/RichTextLabel
@onready var genie = $Panel/PlayerInput/LineEdit
@onready var background = $TextureRect
@onready var music = $Music
@onready var sound = $Sound

# Story fading
var fade_duration = 0.25

func fade_in(node):
	node.modulate = Color.TRANSPARENT
	var tween = get_tree().create_tween()
	tween.tween_property(node, "modulate:a", 1, 0.5)
	tween.play()
	await tween.finished
	tween.kill()

func fade_out(node):
	var tween = get_tree().create_tween()
	tween.tween_property(node, "modulate:a", 0, fade_duration)
	tween.play()
	await tween.finished
	tween.kill()

#Access story script, genie data (see line edit functions below)
var genie_said = true
var genie_flavor = ["I await your command...", "What will you do?", "Type an action here."]
var genie_flavor_error = ["I can’t do that.", "I don’t understand.", "No can do.", "Not possible in the current context."]

# Main Story
func _ready():
	fade_in(storyBox)
	storyBox.text = "[font_size=25][b]Welcome![/b][/font_size]\n\nSay [hint=A command you can do.][u]yes[/u][/hint] in the box, and press enter."
	background.texture = load("res://images/backgrounds/until-further-notice.png")

# Player inputs text
func _on_line_edit_text_submitted(new_text):
	# use story script to decide current story
	var returnedStory = Global._return_story(new_text.to_lower())[0]
	# If input unacceptable, tell player
	if (returnedStory == "TravelingToOtherWorld"):
		fade_out(fullSliver)
		await get_tree().create_timer(fade_duration).timeout
		fade_out(background)
		await get_tree().create_timer(fade_duration).timeout
		get_tree().change_scene_to_file("res://travel.tscn")
	elif (returnedStory != "ErrorMessageOutput"):
		# Change background
		if (Global._return_story(new_text.to_lower())[1] != null):
			var returnedBackground = Global._return_story(new_text.to_lower())[1]
			background.texture = load(returnedBackground)
			fade_in(background)
		# Change text
		_genie_response(genie_flavor.pick_random())
		fade_out(storyBox)
		await get_tree().create_timer(fade_duration).timeout
		storyBox.text = returnedStory
		fade_in(storyBox)
	else:
		# Input disqualified
		_genie_response(genie_flavor_error.pick_random())

# Line Edit Functions (Genie)
func _genie_response(text):
	genie.placeholder_text = text
	genie.clear()
	fade_in(genie)
	genie_said = false
	genie.release_focus()

func _on_line_edit_focus_entered():
	genie.placeholder_text = ""

func _on_line_edit_focus_exited():
	if genie_said:
		genie.placeholder_text = genie_flavor.pick_random()
	else:
		genie_said = true
