extends Node

func _on_animated_sprite_2d_traveled():
	Global.scene += 1
	get_tree().change_scene_to_file("res://main.tscn")
