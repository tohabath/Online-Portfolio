extends Node

func _on_animated_sprite_2d_traveled():
	get_tree().change_scene_to_file("res://main.tscn")
